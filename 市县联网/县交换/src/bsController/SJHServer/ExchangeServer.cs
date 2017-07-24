using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using ZIT.Comm.Client;
using ZIT.Comm.Client.Tcp;
using ZIT.Comm.Communication;
using ZIT.Comm.Communication.EndPoints.Tcp;
using ZIT.LOG;
using ZIT.Utility;
using ZIT.XJHServer.Model;
using ZIT.XJHServer.Model.SystemFunction;

namespace ZIT.XJHServer.bsController.SJHServer
{
    class ExchangeServer
    {
        /// <summary>
        /// 与数据交换通道连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> ConnectionStatusChanged;

        /// <summary>
        /// 接收到数据交换通道消息事件
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;
        /// <summary>
        /// 发送给数据交换通道消息事件
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageSent;

        /// <summary>
        /// 连接数据交换通道客户端类
        /// </summary>
        private IScsClient tcpClient;

        public string ExchangeServerIP;

        public short ExchangeServerPort;

        /// <summary>
        /// 接收消息缓冲区
        /// </summary>
        private string strRecvMsg;

        /// <summary>
        /// 消息队列互斥量
        /// </summary>
        private Mutex MsgMutex = new Mutex();

        /// <summary>
        /// 消息处理类
        /// </summary>
        private ExchangeMsgHandler MsgHandler;


        /// <summary>
        /// 构造函数
        /// </summary>
        public ExchangeServer()
        {
            strRecvMsg = "";
            MsgHandler = new ExchangeMsgHandler();
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            // handle recieved message
            ThreadPool.QueueUserWorkItem(new WaitCallback(HandleRecvMsg_Thread));

            //shake handle with server
            ThreadPool.QueueUserWorkItem(new WaitCallback(SharkHands_Thread), Controller.GetInstance().SharkHandsInterval);

            tcpClient = ScsClientFactory.CreateClient(new ScsTcpEndPoint(ExchangeServerIP, ExchangeServerPort));
            ClientReConnecter crc = new ClientReConnecter(tcpClient);
            tcpClient.Disconnected += new EventHandler(ExchangeServer_Disconnected);
            tcpClient.Connected += new EventHandler(ExchangeServer_Connected);
            tcpClient.ConnectTimeout = 30;
            tcpClient.MessageReceived += new EventHandler<MessageEventArgs>(ExchangeServer_MessageReceived);
            tcpClient.MessageSent += new EventHandler<MessageEventArgs>(ExchangeServer_MessageSent);
            tcpClient.Connect();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {

        }

        /// <summary>
        /// 与数据交换服务器握手线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SharkHands_Thread(object e)
        {
            int intSharkHandsInterval = int.Parse(e.ToString());
            while (true)
            {
                try
                {
                     MsgHandler.SendSharkHandMsg(); 
                    Controller.GetInstance().us.StartScanOnTimeThread();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Error occurred:", ex);
                }
                finally
                {
                    Thread.Sleep(intSharkHandsInterval * 1000);
                }
            }

        }


        private void ExchangeServer_Disconnected(object sender, EventArgs e)
        {
            var handler = ConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(NetStatus.DisConnected));
            }
        }

     
        private void ExchangeServer_Connected(object sender, EventArgs e)
        {
            var handler = ConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(NetStatus.Connected));
            }
            MsgHandler.SendLoginServerMsg();
        }

        public void OnExchangeServerLogin()
        {
            var handler = ConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(NetStatus.Login));
            }
        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeServer_MessageSent(object sender, MessageEventArgs e)
        {
            try
            {
                string commandID = XmlUtil.XmlAnalysis("CommandID", e.Message);
                if (commandID != "SubCenterHandshake" && commandID != "SubCenterBssHandShark")
                {
                    LogHelper.WriteNetMsgLog("Sent message to ExchangeServer:" + e.Message);
                }
            }
            catch
            {}
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeServer_MessageReceived(object sender, MessageEventArgs e)
        {
            MsgMutex.WaitOne();
            try
            {
                strRecvMsg += e.Message.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsgMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// 处理数据线程
        /// </summary>
        private void HandleRecvMsg_Thread(object e)
        {
            while (true)
            {

                Thread.Sleep(100);
                if (strRecvMsg == null || strRecvMsg == "") continue;

                string strOneMsg = "";
                try
                {
                    MsgMutex.WaitOne();
                    try
                    {
                        int StartIndex = strRecvMsg.IndexOf("<?xml");
                        int EndIndex = strRecvMsg.IndexOf("</ZXEMC>");

                        if (StartIndex >= 0 && EndIndex >= 1)
                        {
                            if (EndIndex > StartIndex)
                            {
                                strOneMsg = strRecvMsg.Substring(StartIndex, EndIndex + 8 - StartIndex);
                                strRecvMsg = strRecvMsg.Substring(EndIndex + 8);
                            }
                            else
                            {
                                //去掉错误的消息内容
                                strRecvMsg = strRecvMsg.Substring(EndIndex + 8);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog("", ex);
                    }
                    finally
                    {
                        MsgMutex.ReleaseMutex();
                    }

                    if (strOneMsg != "")
                    {
                        MsgHandler.HandleMsg(strOneMsg);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }
            }
        }


        /// <summary>
        /// 发给消息给数据交换通道
        /// </summary>
        /// <param name="strMsg"></param>
        public void SendMessage(string strMsg)
        {
            try
            {
                if (null != tcpClient)
                {
                    tcpClient.SendMessage(strMsg);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
    }
}
