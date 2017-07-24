using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.Comm.Communication;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.Model.SystemFunction;
using ZIT.Utility;
using ZIT.LOG;

namespace ZIT.SJHServer.bsController.SJHServer
{
    class ExchangeMsgHandler
    {
        private ExchangeServerClient ServerClient;

        public ExchangeMsgHandler(ExchangeServerClient client)
        {
            ServerClient = client;
        }

        public void Message_Recieved(object sender, MessageEventArgs Args)
        {
           
            string CommandID = XmlUtil.XmlAnalysis("CommandID", Args.Message);
            if (CommandID !="SubCenterHandshake" && CommandID != "SubCenterBssHandShark")
            {
                LogHelper.WriteNetMsgLog("Recieve ExchangeServer Client message, Client DWBH is " + ServerClient.UnitCode + ":" + Args.Message);
            }
            switch (CommandID)
            {
                case "SubCenterHandshake":
                    HandleClientSharkHand(Args.Message);
                    break;
                case "LoginServer":
                    HandleLoginServer(Args.Message);
                    break;
                case "ConnectServer":
                    HandleConnectServer(Args.Message);
                    break;
                case "LogoutServer":
                    HandleLoginOutServer(Args.Message);
                    break;
                case "CommonInterface":
                    HandleCommonInterface(Args.Message);
                    break;
                case "SubCenterBssHandShark":
                    HandleSubCenterBssHandShark(Args.Message);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 处理握手消息
        /// </summary>
        /// <param name="message"></param>
        private void HandleClientSharkHand(string message)
        {
            try
            {
                ServerClient.SendMessage(message);
            }
             catch (Exception ex) { LogHelper.WriteLog("" , ex); }
        }
        /// <summary>
        /// 处理连接服务器消息 --注意：此版本已不用这个消息，保留是为了兼容前面的版本
        /// </summary>
        /// <param name="message"></param>
        private void HandleConnectServer(string message)
        {
            //try
            //{
                ConnectServer Data = (ConnectServer)XmlUtil.Deserialize(typeof(ConnectServer), message);
                string ZXIT_JSKF_TEST = Data.CommandID;
                if (ZXIT_JSKF_TEST == "ConnectServer")
                {
                    string xml = XmlUtil.GetXMlStart() + "<ZXEMC><CommandID>ConnectServerResp</CommandID><ConnectResult>1</ConnectResult><FailtureReason></FailtureReason></ZXEMC>";
                    ServerClient.SendMessage(xml);
                }
                else
                {
                    string xml = XmlUtil.GetXMlStart() + "<ZXEMC><CommandID>ConnectServerResp</CommandID><ConnectResult>0</ConnectResult><FailtureReason>网络单元连接服务器名称不正确</FailtureReason></ZXEMC>";
                    ServerClient.SendMessage(xml);
                }
            //}
            // catch (Exception ex) { LogHelper.WriteLog("" , ex); }
        }
        /// <summary>
        /// 处理客户端登录消息
        /// </summary>
        /// <param name="message"></param>
        private void HandleLoginServer(string message)
        {
            //try
            //{
                string strUnitCode = XmlUtil.XmlAnalysis("UnitCode", message);
                string strUnitName = XmlUtil.XmlAnalysis("UnitName", message);
                string strStationType = XmlUtil.XmlAnalysis("StationType", message);
                string ServerResp = "";
                if (strStationType != "JHL")
                {
                    ServerResp = XmlUtil.GetXMlStart() + "<ZXEMC><CommandID>LoginServerResp</CommandID><LoginResult>0</LoginResult> <FailtureReason>不能识别的台类型</FailtureReason></ZXEMC>";
                }
                else if (!Controller.GetInstance().dicUnit.ContainsKey(strUnitCode))
                {
                    ServerResp = XmlUtil.GetXMlStart() + "<ZXEMC><CommandID>LoginServerResp</CommandID><LoginResult>0</LoginResult> <FailtureReason>不能识别的单位编号</FailtureReason></ZXEMC>";
                }
                else
                {
                    TUnit unit = Controller.GetInstance().dicUnit[strUnitCode];
                    ServerClient.UnitCode = strUnitCode;
                    ServerClient.UnitName = unit.UnitXZQMC;
                    ServerClient.UnitXZBM = unit.UnitXZBM;
                    ServerClient.Status = NetStatus.Login;

                    Controller.GetInstance().es.OnServerConnectedClientChanged();

                    ServerResp = XmlUtil.GetXMlStart() + "<ZXEMC><CommandID>LoginServerResp</CommandID><LoginResult>1</LoginResult> <FailtureReason></FailtureReason></ZXEMC>";
                }
                ServerClient.SendMessage(ServerResp);
                
            //}
            // catch (Exception ex) { LogHelper.WriteLog("" , ex); }
        }

        private void HandleLoginOutServer(string message)
        {
            //try
            //{
                string LogoutServer = XmlUtil.GetXMlStart() + "<ZXEMC><CommandID>LogoutServerResp</CommandID></ZXEMC>";
                ServerClient.SendMessage(LogoutServer);
            //}
            // catch (Exception ex) { LogHelper.WriteLog("" , ex); }
        }

        private void HandleCommonInterface(string message)
        {
            //20151213 修改人:朱星汉 修改内容:只转发内容
            string messageNR = XmlUtil.XmlAnalysis("NR", message); 
            Controller.GetInstance().bs.SendMessage(messageNR);
        }

        private void HandleSubCenterBssHandShark(string message)
        {
            SubCenterBssHandShark Data = (SubCenterBssHandShark)XmlUtil.Deserialize(typeof(SubCenterBssHandShark), message);
            string strMsg = "";
            strMsg = "[3001DWBH:" + Data.DWBH + "*#]";
            Controller.GetInstance().bs.SendMessage(strMsg);
        }

    }
}
