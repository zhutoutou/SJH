using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.Utility;
using ZIT.XJHServer.Model;
using ZIT.XJHServer.Model.PositioningFunction;
using ZIT.XJHServer.Model.DispatchFunction;
using ZIT.XJHServer.Model.HuaiAnFunction;
using ZIT.XJHServer.Model.DataExchangeFunction;
using ZIT.XJHServer.bsController.SJHServer;
using ZIT.LOG;

namespace ZIT.XJHServer.bsController.BusinessServer
{
    class BServerMsgHandler
    {
        public void HandleMsg(string strMsg)
        {
            string CommandID = XmlUtil.XmlAnalysis("CommandID", strMsg);
            if (CommandID != "ShakeHand")
            {
                LogHelper.WriteNetMsgLog("Recieve BServer message:" + strMsg);
            }
            switch (CommandID)
            {
                case "ShakeHand":
                    ShakeHand ShakeHand = (ShakeHand)XmlUtil.Deserialize(typeof(ShakeHand), strMsg);
                    if (ShakeHand.TLX == "BSS")
                    {
                        HandleSharkHandleMsg(ShakeHand);
                    }
                    break;
                case "CommonInterface":
                    CommonInterface Common = (CommonInterface)XmlUtil.Deserialize(typeof(CommonInterface), strMsg);
                    OnMessageChange(Common);
                    break;
                case "DispatchTaskSelectData":
                    DispatchTaskSelectData SelectData = (DispatchTaskSelectData)XmlUtil.Deserialize(typeof(DispatchTaskSelectData), strMsg);
                    //SelectData.DWBH = ConfigurationManager.AppSettings["UnitCode"].Trim();
                    OnMessageChange(SelectData);
                    break;
                case "GetVehiclePositionResp":
                    GetVehiclePositionResp VehiclePositionResp = (GetVehiclePositionResp)XmlUtil.Deserialize(typeof(GetVehiclePositionResp), strMsg);
                    OnMessageChange(VehiclePositionResp);
                    break;
                case "MonitorData":
                    MonitorData MonitorData = (MonitorData)XmlUtil.Deserialize(typeof(MonitorData), strMsg);
                    OnMessageChange(MonitorData);
                    break;
                case "VehicleStatus":
                    VehicleStatus VehicleStatus = (VehicleStatus)XmlUtil.Deserialize(typeof(VehicleStatus), strMsg);
                    //VehicleStatus.DWBH = ConfigurationManager.AppSettings["UnitCode"].Trim();
                    OnMessageChange(VehicleStatus);
                    break;
                case "DispatchTaskRequestReinforcementResp":
                    DispatchTaskRequestReinforcementResp DispatchTaskResp = (DispatchTaskRequestReinforcementResp)XmlUtil.Deserialize(typeof(DispatchTaskRequestReinforcementResp), strMsg);
                    OnMessageChange(DispatchTaskResp);
                    break;
                default:
                    break;
            }
        }

        private void OnMessageChange(object obj)
        {
            try
            {
                ExchangeServer es = Controller.GetInstance().es;
                string Name = obj.GetType().Name;
                string xml = "";
                switch (Name)
                {
                    case "MonitorData":
                        MonitorData md = obj as MonitorData;
                        xml = XmlUtil.Serializer(md.GetType(), md);
                        es.SendMessage(xml);
                        break;
                    case "DispatchTaskSelectData":
                        DispatchTaskSelectData SelectData = obj as DispatchTaskSelectData;
                        xml = XmlUtil.Serializer(SelectData.GetType(), SelectData);
                        es.SendMessage(xml);
                        break;
                    case "DispatchTaskNoAnswer":
                        DispatchTaskNoAnswer NoAnswer = obj as DispatchTaskNoAnswer;
                        xml = XmlUtil.Serializer(NoAnswer.GetType(), NoAnswer);
                        es.SendMessage(xml);
                        break;
                    case "SubCenterState":
                        SubCenterState State = obj as SubCenterState;
                        xml = XmlUtil.Serializer(State.GetType(), State);
                        //es.SendNotLogMessage(xml);
                        break;
                    case "CommonInterface":
                        CommonInterface Common = obj as CommonInterface;
                        xml = XmlUtil.Serializer(Common.GetType(), Common);
                        es.SendMessage(xml);
                        break;
                    case "GetVehiclePositionResp":
                        GetVehiclePositionResp PositionResp = obj as GetVehiclePositionResp;
                        xml = XmlUtil.Serializer(PositionResp.GetType(), PositionResp);
                        es.SendMessage(xml);
                        break;
                    case "ShakeHand":
                        ShakeHand ShakeHand = obj as ShakeHand;
                        xml = XmlUtil.Serializer(ShakeHand.GetType(), ShakeHand);
                       // es.SendNotLogMessage(xml);
                        break;
                    case "DispatchTaskRequestReinforcementResp":
                        DispatchTaskRequestReinforcementResp Resp = obj as DispatchTaskRequestReinforcementResp;
                        xml = XmlUtil.Serializer(Resp.GetType(), Resp);
                        es.SendMessage(xml);
                        break;
                    case "VehicleStatus":
                        VehicleStatus Status = obj as VehicleStatus;
                        xml = XmlUtil.Serializer(Status.GetType(), Status);
                        es.SendMessage(xml);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 处理BSS发来的握手消息
        /// </summary>
        public void HandleSharkHandleMsg(ShakeHand sh)
        {
            try
            {
                SubCenterBssHandShark scbhk = new SubCenterBssHandShark();
                scbhk.CommandID = "SubCenterBssHandShark";
                scbhk.DWBH = Controller.GetInstance().Args.args.UnitCode;

                string xml = XmlUtil.Serializer(scbhk.GetType(), scbhk);
                Controller.GetInstance().es.SendMessage(xml);
            }
            catch { }
        }
    }
}
