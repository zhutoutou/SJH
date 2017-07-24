﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using ZIT.SJHServer.Model;
using ZIT.LOG;

namespace ZIT.SJHServer.bsController.GpsServer
{
    class GServer
    {
        public delegate void dgBusinessServer_Status(int Status);

        private bool blConnected;

        /// <summary>
        /// 接收消息缓冲区
        /// </summary>
        private string strRecvMsg;

        public dgBusinessServer_Status BusinessServer_Status;
        /// <summary>
        /// 与120业务服务器通信
        /// </summary>
        public UdpClient udpClient;
        /// <summary>
        /// 消息队列互斥量
        /// </summary>
        private Mutex MsgMutex = new Mutex();
        /// <summary>
        /// 处理消息线程
        /// </summary>
        public Thread UdpThread = null;

        /// <summary>
        /// 120业务服务器IP地址
        /// </summary>
        public string strRemoteIP;
        /// <summary>
        /// 120业务服务器IP端口
        /// </summary>
        public short nRemotePort;
        /// <summary>
        /// 本地端口
        /// </summary>
        public short nLocalPort;

        /// <summary>
        /// 与业务服务器握手时间间隔
        /// </summary>
        public int SharkHandsInterval;

        private DateTime dtLastRecieveMsgTime;

        /// <summary>
        /// 消息处理类
        /// </summary>
        private GServerMsgHandler MsgHandler;

        /// <summary>
        /// 单位编号
        /// </summary>
        public string strDWBH;

        /// <summary>
        /// 构造函数
        /// </summary>
        public GServer()
        {
            strRecvMsg = "";
            blConnected = false;
            MsgHandler = new GServerMsgHandler();
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            try
            {
                //StartLocalListener();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// 检测与业务服务器连接状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckConnectedStatus_Thread(object e)
        {
            int SharkHandsTime = int.Parse(e.ToString());
            int CheckConnectedInterval = SharkHandsTime + 1;
            while (true)
            {
                Thread.Sleep(CheckConnectedInterval * 1000);
                try
                {
                    if (DateTime.Now.Subtract(dtLastRecieveMsgTime) > new TimeSpan(0, 0, (SharkHandsTime * 2) + 1))
                    {
                        if (blConnected)
                        {
                            blConnected = false;
                            //raise disconnect event
                        }
                    }
                    else
                    {
                        if(!blConnected)
                        {
                            blConnected = true;
                             //raise connect event
                        }
                    }
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 与业务服务器握手线程
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
                    ///发送握手消息
                    if (udpClient != null)
                    {
                        string str = "[3000DWBH:" + strDWBH + "*#DWMC:*#ZJM:*#TLX:JHL*#TH:*#ZBY:*#ZT:1*#LSH:*#ZBBC:*#]";
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(str);
                        udpClient.Send(sendBytes, sendBytes.Length, strRemoteIP, nRemotePort);
                        //OnMessageCommucate(DateTime.Now.ToShortTimeString() + " " + "发送" + str);
                    }
                    else
                    {
                        udpClient = null;
                        udpClient.Close();
                        udpClient = new UdpClient(nLocalPort);
                        UdpThread = new Thread(new ThreadStart(UdpReciveThread));
                        UdpThread.Start();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Error occurred:",ex);
                }
                finally
                {
                    Thread.Sleep(intSharkHandsInterval * 1000);
                }
            }

        }
        /// <summary>
        /// 开启本地UDP监听
        /// </summary>
        public void StartLocalListener()
        {
            try
            {
                if (udpClient != null)
                {
                    UdpThread.Abort();
                    udpClient.Close();
                }
                udpClient = new UdpClient(nLocalPort);
                UdpThread = new Thread(new ThreadStart(UdpReciveThread));
                UdpThread.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 接收数据线程
        /// </summary>
        private void UdpReciveThread()
        {
            IPEndPoint remoteHost = null;
            while (udpClient != null && Thread.CurrentThread.ThreadState.Equals(System.Threading.ThreadState.Running))
            {
                try
                {
                    byte[] buf = udpClient.Receive(ref remoteHost);
                    string bufs = Encoding.GetEncoding(936).GetString(buf);
                    dtLastRecieveMsgTime = DateTime.Now;
                    MsgMutex.WaitOne();
                    try
                    {
                        strRecvMsg += bufs.Trim();
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
                catch (Exception ex)
                {
                    LogHelper.WriteLog("",ex);
                }

            }
        }

        /// <summary>
        /// 处理数据线程
        /// </summary>
        public void HandleRecvMsg_Thread(object e)
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
                        int StartIndex = strRecvMsg.IndexOf("<ZXEMC>");
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
        /// 发给消息给GPS业务服务器
        /// </summary>
        /// <param name="strMsg"></param>
        public void SendMessage(string strMsg)
        {
            try
            {
                if (udpClient != null)
                {
                    if (strMsg != "")
                    {
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(strMsg);
                        udpClient.Send(sendBytes, sendBytes.Length, strRemoteIP, nRemotePort);
                        //OnMessageCommucate(DateTime.Now.ToShortTimeString() + " " + "发送" + strMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
    }
}
