using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using ZIT.Comm.Communication.EndPoints.Tcp;
using ZIT.Comm.Communication;
using ZIT.Comm.Server;
using ZIT.SJHServer.Model;
using ZIT.LOG;


namespace ZIT.SJHServer.bsController.SJHServer
{
    class UploadServer
    {
        /// <summary>
        /// 与数据上传通道连接客户端改变事件
        /// </summary>
        public event EventHandler<UnitsEventArgs> ServerConnectedClientChanged;

        public static IScsServer server;

        public short UploadServerPort;

        /// <summary>
        /// 在线的客户端
        /// </summary>
        public IList<UploadServerClient> OnlineClents;

        public ReaderWriterLockSlim OnlineClentsLock;

        private Thread CheckConnectedStatusThread;


        public UploadServer()
        {
            OnlineClentsLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion); ;
            OnlineClents = new List<UploadServerClient>();
        }

        public void Start()
        {
            //check upload client
            CheckConnectedStatusThread = new Thread(CheckConnectedStatus_Thread);
            CheckConnectedStatusThread.Start(Controller.GetInstance().Args.args.SharkHandsInterval);

            //Create a server that listens gParam.sLocalPort TCP port for incoming connections
            server = ScsServerFactory.CreateServer(new ScsTcpEndPoint(UploadServerPort));

            //Register events of the server to be informed about clients
            server.ClientConnected += Server_ClientConnected;
            server.ClientDisconnected += Server_ClientDisconnected;
            //Start the server
            server.Start();
        }

        public void Stop()
        { }

        /// <summary>
        /// //客户端已连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Server_ClientConnected(object sender, ServerClientEventArgs e)
        {
            //try
            //{
            UploadServerClient Client = new UploadServerClient();
            Client.dtClientConnTime = DateTime.Now;
            Client.strClientIP = ((ScsTcpEndPoint)e.Client.RemoteEndPoint).IpAddress;
            Client.strClientPort = ((ScsTcpEndPoint)e.Client.RemoteEndPoint).TcpPort.ToString();
            Client.intClientID = e.Client.ClientId;
            Client.Status = NetStatus.Connected;
            e.Client.MessageReceived += new EventHandler<MessageEventArgs>(Client.MessageReceived);
            OnlineClentsLock.EnterWriteLock();
            try
            {
                OnlineClents.Add(Client);
            }
            finally
            {
                OnlineClentsLock.ExitWriteLock();
            }
            OnServerConnectedClientChanged();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //    //LogHelper.WriteLog("Error Occurred", ex);
            //}
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Server_ClientDisconnected(object sender, ServerClientEventArgs e)
        {
            try
            {
                OnlineClentsLock.EnterWriteLock();
                try
                {
                    foreach (UploadServerClient Client in OnlineClents)
                    {
                        if (Client.intClientID == e.Client.ClientId)
                        {
                            LogHelper.WriteLog("客户端断开连接，县交换名称：" + Client.UnitName +",地址：" + Client.strClientIP+":" +Client.strClientPort);
                            Client.Status = NetStatus.DisConnected;
                            OnlineClents.Remove(Client);
                            e.Client.MessageReceived -= new EventHandler<MessageEventArgs>(Client.MessageReceived);
                            Client.Close();

                            break;
                        }
                    }
                }
                finally
                {
                    OnlineClentsLock.ExitWriteLock();
                }
                OnServerConnectedClientChanged();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error Occurred", ex);
            }
        }

        /// <summary>
        /// Raises ServerConnectedClientChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        public virtual void OnServerConnectedClientChanged()
        {
            var handler = ServerConnectedClientChanged;
            if (handler != null)
            {
                List<OnlineUnit> units = new List<OnlineUnit>();
                foreach (var item in OnlineClents)
                {
                    string status = "";
                    switch (item.Status)
                    {
                        case NetStatus.Connected:
                            status = "已连接";
                            break;
                        case NetStatus.Login:
                            status = "已登录";
                            break;
                        case NetStatus.DisConnected:
                            status = "断开";
                            break;
                        default:
                            break;
                    }
                    OnlineUnit unit = new OnlineUnit();
                    unit.IPAddress = item.strClientIP;
                    unit.Status = status;
                    unit.UnitName = item.UnitName;
                    unit.UnitCode = item.UnitCode;
                    unit.ConnectedTime = item.dtClientConnTime.ToString("yyyy-MM-dd HH:mm:ss");

                    units.Add(unit);
                }

                handler(this, new UnitsEventArgs(units));
            }
        }

        /// <summary>
        /// 检测数据上传客户端是否正常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckConnectedStatus_Thread(object e)
        {
            int SharkHandsTime = int.Parse(e.ToString());
            int CheckConnectedInterval = 5;
            while (true)
            {
                Thread.Sleep(CheckConnectedInterval * 1000);
                try
                {
                    foreach (var item in OnlineClents)
                    {
                        if (DateTime.Now.Subtract(server.Clients[item.intClientID].LastReceivedMessageTime) > new TimeSpan(0, 0, SharkHandsTime * 5 + 5)
                            || (DateTime.Now.Subtract(item.dtClientConnTime) > new TimeSpan(0, 0, 10) && item.Status != NetStatus.Login))
                        {
                            LogHelper.WriteLog("断开通讯不正常的客户端连接,IP:" + item.strClientIP + "Port:" + item.strClientPort + ",超时：" + DateTime.Now.Subtract(server.Clients[item.intClientID].LastReceivedMessageTime).ToString());
                            server.Clients[item.intClientID].Disconnect();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog("", ex);
                }
            }
        }

    }
}
