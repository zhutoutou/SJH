using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using ZIT.Comm.Communication;
using ZIT.LOG;
using ZIT.Utility;

namespace ZIT.SJHServer.bsController.SJHServer
{
    class UploadServerClient
    {
        /// <summary>
        /// This event is raised when recieved a whole message
        /// </summary>
        event EventHandler<MessageEventArgs> MessageRecieved;


        public string strClientIP;
        public string strClientPort;
        public long intClientID;

        public string UnitCode;
        public string UnitName;
        public string UnitXZBM;

        public DateTime dtClientConnTime;

        public NetStatus Status;

        /// <summary>
        /// 处理消息线程
        /// </summary>
        private Thread HandleRecvMsgThread;

        /// <summary>
        /// 接收消息缓冲区
        /// </summary>
        private string strRecvMsg;

        /// <summary>
        /// 消息队列互斥量
        /// </summary>
        private Mutex MsgMutex = new Mutex();

        public UploadServerClient()
        {
            UploadMsgHandler MsgHandler = new UploadMsgHandler(this);
            this.MessageRecieved += MsgHandler.Message_Recieved;
            strRecvMsg = "";
            Status = NetStatus.DisConnected;
            dtClientConnTime = DateTime.MinValue;

            HandleRecvMsgThread = new Thread(HandleRecvMsg_Thread);
            HandleRecvMsgThread.Start();
        }

        public void MessageReceived(object sender, MessageEventArgs e)
        {
            MsgMutex.WaitOne();
            try
            {
                LogHelper.WriteNetMsgLog("Recieve UploadServer Client message, Client DWBH is " + UnitCode + ":" + e.Message.Trim());
                strRecvMsg += e.Message.Trim();
                LogHelper.WriteLog("接收后的长度：" + strRecvMsg.Length);
                //HandleRecvMsg();
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
        private void HandleRecvMsg_Thread()
        {
            while (true)
            {
                if (strRecvMsg == null || strRecvMsg == "") Thread.Sleep(100);
                try
                {
                    HandleRecvMsg();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("B strRecvMsg length:" + strRecvMsg.Length, ex);
                }
            }
        }


        private void HandleRecvMsg()
        {
            LogHelper.WriteLog("开始进入：" + strRecvMsg.Length);
            if (strRecvMsg == null || strRecvMsg == "") return;
            string strOneMsg = "";
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
                LogHelper.WriteLog("A strRecvMsg length:" + strRecvMsg.Length, ex);
            }
            finally
            {
                MsgMutex.ReleaseMutex();
            }

            if (strOneMsg != "")
            {
                LogHelper.WriteLog("开始处理：" + strOneMsg);
                OnMessageRecieved(strOneMsg);
                LogHelper.WriteLog("开始结束");
            }
        }



        /// <summary>
        /// 关闭此对象线程服务
        /// </summary>
        public void Close()
        {
            try
            {
                if (null != HandleRecvMsgThread)
                {
                    HandleRecvMsgThread.Abort();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }


        /// <summary>
        /// Raises MessageRecieved event
        /// </summary>
        /// <param name="message"></param>
        protected virtual void OnMessageRecieved(string message)
        {
            var handler = MessageRecieved;
            if (handler != null)
            {
                handler(this, new MessageEventArgs(message));
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                UploadServer.server.Clients[this.intClientID].SendMessage(message);
                string CommandID = XmlUtil.XmlAnalysis("CommandID", message);
                if (CommandID != "SubCenterHandshake" && CommandID != "SubCenterBssHandShark")
                {
                    LogHelper.WriteNetMsgLog("Send message to UploadServer Client, Client DWBH is " + UnitCode + ":" + message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
