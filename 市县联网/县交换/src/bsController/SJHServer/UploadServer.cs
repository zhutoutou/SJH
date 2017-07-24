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
using ZIT.XJHServer.bsController.DataUpload;
using System.Collections.Concurrent;
using ZIT.XJHServer.fnDataAccess.DataSync.Oracle;

namespace ZIT.XJHServer.bsController.SJHServer
{
    public class UploadServer
    {
        /// <summary>
        /// 与数据上传通道连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> ConnectionStatusChanged;

        /// <summary>
        /// 接收到数据上传通道消息事件
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;
        /// <summary>
        /// 发送给数据上传通道消息事件
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageSent;

        /// <summary>
        /// 连接数据上传通道客户端类
        /// </summary>
        private IScsClient tcpClient;

        public string UploadServerIP;

        public short UploadServerPort;

        /// <summary>
        /// 定时扫描数据库线程
        /// </summary>
        public Thread ThreadScanOnTime;

        /// <summary>
        /// 接收消息缓冲区
        /// </summary>
        private string strRecvMsg;

        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
        /// <summary>
        /// 重发的消息队列
        /// </summary>
        public static ConcurrentQueue<ReSendMsg> reSendQueue=new ConcurrentQueue<ReSendMsg>();

        /// <summary>
        /// 消息队列互斥量
        /// </summary>
        private Mutex MsgMutex = new Mutex();
        
        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
        /// <summary>
        /// 重发队列互斥量
        /// </summary>
        private Mutex QueueMutex = new Mutex();

        /// <summary>
        /// 消息处理类
        /// </summary>
        private UploadMsgHandler MsgHandler;

        /// <summary>
        /// 上传数据类
        /// </summary>
        internal UploadData Upload;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UploadServer()
        {
            strRecvMsg = "";
            MsgHandler = new UploadMsgHandler();
            Upload = new UploadData();
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

            //20160712 修改人：朱星汉 修改内容：添加定时重发机制
            ThreadPool.QueueUserWorkItem(new WaitCallback(ReSendMsg_Thread));
            tcpClient = ScsClientFactory.CreateClient(new ScsTcpEndPoint(UploadServerIP, UploadServerPort));
            ClientReConnecter crc = new ClientReConnecter(tcpClient);
            tcpClient.Disconnected += new EventHandler(UploadServer_Disconnected);
            tcpClient.Connected += new EventHandler(UploadServer_Connected);
            tcpClient.ConnectTimeout = 30;
            tcpClient.MessageReceived += new EventHandler<MessageEventArgs>(UploadServer_MessageReceived);
            tcpClient.MessageSent += new EventHandler<MessageEventArgs>(UploadServer_MessageSent);
            tcpClient.Connect();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {

        }

        /// <summary>
        /// 启动定时扫描数据库线程
        /// </summary>
        public void StartScanOnTimeThread()
        {
            if (ThreadScanOnTime == null)
            {
                ThreadScanOnTime = new Thread(Upload.ScanOnTime);
                ThreadScanOnTime.IsBackground = true;
                ThreadScanOnTime.Start();
            }
        }

        /// <summary>
        /// 与数据上传服务器握手线程
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

        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
        public void ReSendMsg_Thread(object e)
        {
            while (true)
            {
                try
                {
                    
                    while(reSendQueue.Count()>0)
                    {
                        ReSendMsg re = new ReSendMsg();
                        bool blnSuccess= reSendQueue.TryPeek(out re);
                        TimeSpan Ts =(re.lastSendTime - DateTime.Now);
                        if (Math.Abs(Ts.TotalMinutes) > 5)
                        {
                            LogHelper.WriteLog("重发语句：" + re.reUpdateSQL);
                            int i = OraclHelp.OperationRecord(re.reUpdateSQL);
                            if (i > 0)
                            {
                                OraclHelp.OperationRecord(re.reUpdateSQL);
                                LogHelper.WriteLog("重发sql更新成功");
                            }
                            blnSuccess = reSendQueue.TryDequeue(out re);
                            Thread.Sleep(200);
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                catch (OutOfMemoryException ex)
                {
                    LogHelper.WriteLog("重发队列内存溢出", ex);
                    reSendQueue = new ConcurrentQueue<ReSendMsg>();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }
                finally
                {
                    Thread.Sleep(5000);
                }
            }

        }

        private void UploadServer_Disconnected(object sender, EventArgs e)
        {
            var handler = ConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(NetStatus.DisConnected));
            }
        }


        private void UploadServer_Connected(object sender, EventArgs e)
        {
            var handler = ConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(NetStatus.Connected));
            }
            MsgHandler.SendLoginServerMsg();
        }

        public void OnUploadServerLogin()
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
        private void UploadServer_MessageSent(object sender, MessageEventArgs e)
        {
            try
            {
                string commandID = XmlUtil.XmlAnalysis("CommandID", e.Message);
                if (commandID != "SubCenterHandshake" && commandID != "SubCenterBssHandShark")
                {
                    LogHelper.WriteNetMsgLog("Sent message to UploadServer:" + e.Message);
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadServer_MessageReceived(object sender, MessageEventArgs e)
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
        /// 发给消息给数据上传通道
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
