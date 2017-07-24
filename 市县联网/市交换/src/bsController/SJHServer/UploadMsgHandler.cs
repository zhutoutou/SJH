using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.Comm.Communication;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model.SystemFunction;
using ZIT.Utility;
using ZIT.LOG;
using ZIT.SJHServer.fnDataAccess;
using ZIT.SJHServer.fnDataAccess.Oracle;
using ZIT.SJHServer.bsController.DataSaved;

namespace ZIT.SJHServer.bsController.SJHServer
{
    class UploadMsgHandler
    {
        private UploadServerClient ServerClient;

        private SyncData Sync;

        public UploadMsgHandler(UploadServerClient client)
        {
            Sync = new SyncData(client);
            ServerClient = client;
        }

        public void Message_Recieved(object sender, MessageEventArgs Args)
        {
            string CommandID = XmlUtil.XmlAnalysis("CommandID", Args.Message);
            if (CommandID != "SubCenterHandshake" && CommandID != "SubCenterBssHandShark")
            {
                LogHelper.WriteNetMsgLog("Deal UploadServer Client message, Client DWBH is " + ServerClient.UnitCode + ":" + Args.Message);
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
                    //同步单位信息数据
                case "UnitInfoData":
                        Sync.HandleUnitInfoData(Args.Message);
                    break;
                    //同步车辆信息数据
                case "VehicleData":
                        Sync.HandleVehicleData(Args.Message);
                    break;
                    //同步系统人员信息数据
                case "SysUserData":
                        Sync.HandleSysUserData(Args.Message);
                    break;
                    //同步呼叫记录信息数据
                case "CallRcordData":
                        Sync.HandleCallRcordData(Args.Message);
                    break;
                    //同步受理记录信息数据
                case "DealData":
                    if (ServerClient.Status == NetStatus.Login)
                        Sync.HandleDealData(Args.Message);
                    break;
                    //同步调度分站记录信息数据
                case "DispatchStationInfoData":
                    if (ServerClient.Status == NetStatus.Login)
                        Sync.HandleDispatchStationInfoData(Args.Message);
                    break;
                    //同步出车记录信息数据
                case "DispatchVehicleData":
                        Sync.HandleDispatchVehicleData(Args.Message);
                    break;
                    //同步病历填写项目
                case "Web_MedicalProject":
                        Sync.HandleWeb_MedicalProjectData(Args.Message);
                    break;
                    //同步病历填写项目值
                case "Web_MedicalProjectValue":
                        Sync.HandleWeb_MedicalProjectValueData(Args.Message);
                    break;
                    //同步病历记录
                case "Web_MedicalRecords":
                        Sync.HandleWeb_MedicalRecordsData(Args.Message);
                    break;
                    //同步病历填写项目与值对应关系数据
                case "Web_MedicalStatistics":
                        Sync.HandleWeb_MedicalStatisticsData(Args.Message);
                    break;
                //病历基础信息表数据
                case "BLJCXXB":
                        Sync.HandleBLJCXXBData(Args.Message);
                    break;
                //呼救区域表数据
                case "HJQYB":
                        Sync.HandleHJQYBData(Args.Message);
                    break;
                //来电类型表数据
                case "LDLXB":
                        Sync.HandleLDLXBData(Args.Message);
                    break;
                //值班员信息表数据
                case "ZBYXXB":
                        Sync.HandleZBYXXBData(Args.Message);
                    break;
                //症状表数据
                case "ZZB":
                        Sync.HandleZZBData(Args.Message);
                    break;
                //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
                //病历关系记录删除表数据
                case "LWBLGXTBDELB":
                        Sync.HandleLWBLGXTBDELBData(Args.Message);
                    break;
                //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
                //病历记录删除表数据
                case "LWBLTBDELB":
                        Sync.HandleLWBLTBDELBData(Args.Message);
                    break;
                //大型事故表数据
                case "DXSGB":
                        Sync.HandleDXSGBData(Args.Message);
                    break;
                default:
                    LogHelper.WriteNetMsgLog("UNhandle message Client DWBH is " + ServerClient.UnitCode + ":" + Args.Message);
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
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error Occurred", ex);
            }
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
                Controller.GetInstance().us.OnServerConnectedClientChanged();
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


       
   
    }
}
