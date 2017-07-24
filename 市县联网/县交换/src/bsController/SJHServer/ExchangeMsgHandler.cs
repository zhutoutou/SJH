using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using ZIT.LOG;
using ZIT.Utility;
using ZIT.XJHServer.Model;
using ZIT.XJHServer.Model.DataExchangeFunction;
using ZIT.XJHServer.Model.SystemFunction;

namespace ZIT.XJHServer.bsController.SJHServer
{
    class ExchangeMsgHandler
    {
        public void HandleMsg(string strMsg)
        {
            try
            {
               
                string commandID = XmlUtil.XmlAnalysis("CommandID", strMsg);
                if (commandID != "SubCenterHandshake" && commandID != "SubCenterBssHandShark")
                {
                    LogHelper.WriteNetMsgLog("Recieve ExchangeServer message:" + strMsg);
                }
                switch (commandID)
                {
                    case "CommonInterface":
                        DealCommonInterface(strMsg);
                        break;
                    case "DispatchTaskRequestReinforcement":
                        DealDispatchTaskRequestReinforcement(strMsg);
                        break;
                    //case "GetTrackData":
                    //    DealGetTrackData(strMsg);
                    //    break;
                    //case "StopTrack":
                    //    DealStopTrack(strMsg);
                    //    break;
                    //case "DispatchTaskSelectDataResp":
                    //    DealDispatchTaskSelectDataResp(strMsg);
                    //    break;
                    //case "Monitor":
                    //    DealMonitor(strMsg);
                    //    break;
                    //case "GetVehiclePosition":
                    //    DealGetVehiclePosition(strMsg);
                    //    break;
                    //case "WithdrawMonitor":
                    //    DealWithdrawMonitor(strMsg);
                    //    break;
                    case "LoginServerResp":
                        DealLoginServerResp(strMsg);
                        break;
                    case "LogoutServerResp":
                       // handTimer.Stop();
                        break;
                    default: break;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 处理CommonInterface公共接口数据
        /// </summary>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        private void DealCommonInterface(string strMsg)
        {
            CommonInterface CommonData = (CommonInterface)XmlUtil.Deserialize(typeof(CommonInterface), strMsg);
            //20151213 修改人:朱星汉 修改内容:转发内容
            string strMsgNR = XmlUtil.XmlAnalysis("NR", strMsg);
            if (CommonData.ServerType == "BSS")
            {
                Controller.GetInstance().bs.SendMessage(strMsgNR);
            }
            else if (CommonData.ServerType == "GPS")
            {

            }
            else
            {
               //收到CommonInterface,类型不对不处理
            }
        }

        private void DealDispatchTaskRequestReinforcement(string strMsg)
        {
            DispatchTaskRequestReinforcement Data = (DispatchTaskRequestReinforcement)XmlUtil.Deserialize(typeof(DispatchTaskRequestReinforcement), strMsg);
            string message = "[1081LSH:" + Data.DealRecordID + "*#DWBH:" + Data.TargetUnitID + "*#LocalDWBH:" + Data.SourceUnitID + "*#HJQY:" + Data.CallArea + "*#ZJHM:" + Data.CallNumber + "*#HZ:" + Data.HostName + "*#ZJDZ:" + Data.Address + "*#HJR:" + Data.CallerName + "*#LDSJ:" + Data.CallTime + "*#SLSJ:" + Data.DealTime + "*#GJSJ:" + Data.HangupTime + "*#XXLY:" + Data.InfoSource + "*#ZBY:" + Data.WatcherName + "*#LDLX:" + Data.CallType + "*#LXDH:" + Data.ContactTelphone + "*#JCDZ:" + Data.MeetAddress + "*#HCZLX:" + Data.CallerType + "*#FBDZ:" + Data.HappenAddress + "*#HZGJ:" + Data.Nationality + "*#HJYY:" + Data.Symptom + "*#HZBS:" + Data.SuffererMedicalRecord + "*#GXJD:" + Data.DominationStreet + "*#GXYY:" + Data.DominationHospital + "*#HZXM:" + Data.SuffererName + "*#HZXB:" + Data.SuffererSex + "*#HZNL:" + Data.SuffererAge + "*#HZRS:" + Data.SuffererCount + "*#HZZZ:" + Data.Firstdiag + "*#CZFS:" + Data.TreatmentMode + "*#SWDD:" + Data.SendArriveAddress + "*#KJLM:" + Data.AnearRoadName + "*#]";

            Controller.GetInstance().bs.SendMessage(message);           
        }

        /// <summary>
        /// 登陆应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        private void DealLoginServerResp(string strMsg)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("LoginResult", strMsg);
                if (flag == "1")
                {
                    Controller.GetInstance().es.OnExchangeServerLogin();
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 发送登录消息
        /// </summary>
        public void SendLoginServerMsg()
        {
            try
            {
                LoginServer ls = new LoginServer();
                ls.CommandID = "LoginServer";
                ls.UnitCode = Controller.GetInstance().strUnitCode;
                ls.UnitName = Controller.GetInstance().strUnitName;
                ls.StationType = "JHL";
                string lsStr = XmlUtil.Serializer(ls.GetType(), ls);
                Controller.GetInstance().es.SendMessage(lsStr);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        public void SendSharkHandMsg()
        {
            SubCenterHandshake hs = new SubCenterHandshake();
            hs.CommandID = "SubCenterHandshake";
            string hsStr = XmlUtil.Serializer(hs.GetType(), hs);
            Controller.GetInstance().es.SendMessage(hsStr);
        }
    }
}
