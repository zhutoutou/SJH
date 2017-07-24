using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.Utility;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.Model.PositioningFunction;
using ZIT.SJHServer.Model.DispatchFunction;
using ZIT.SJHServer.Model.HuaiAnFunction;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.bsController.SJHServer;
using ZIT.LOG;

namespace ZIT.SJHServer.bsController.BusinessServer
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
                        GetHandMsg(ShakeHand);
                    }
                    break;
                case "CommonInterface":
                    HandleCommonInterfaceMsg(strMsg);
                    break;
                case "DispatchTaskRequestReinforcement":
                    HandleDispatchTaskRequestReinforcement(strMsg);
                    break;
                default:
                    break;
            }
        }

        private void HandleCommonInterfaceMsg(string strMsg)
        {
            CommonInterface ci = (CommonInterface)XmlUtil.Deserialize(typeof(CommonInterface), strMsg);

            //发给所有分中心
            if (ci.DWBH == "0")
            {
                foreach (var item in Controller.GetInstance().es.OnlineClents)
                {
                    item.SendMessage(XmlUtil.GetXMlStart() + strMsg);
                }
            }
            //发给指定分中心
            else
            {
                foreach (var item in Controller.GetInstance().es.OnlineClents)
                {
                    if(item.UnitCode == ci.DWBH)
                    {
                        item.SendMessage(XmlUtil.GetXMlStart() + strMsg);
                        break;
                    }
                }
            }
        }

        private void HandleDispatchTaskRequestReinforcement(string strMsg)
        {
            DispatchTaskRequestReinforcement Dispacth = (DispatchTaskRequestReinforcement)XmlUtil.Deserialize(typeof(DispatchTaskRequestReinforcement), strMsg);

            foreach (var item in Controller.GetInstance().es.OnlineClents)
            {
                if (item.UnitCode == Dispacth.TargetUnitID)
                {
                    item.SendMessage(XmlUtil.GetXMlStart() + strMsg);
                    break;
                }
            }
        }

        

       
        /// <summary>
        /// 得到BSS发来的握手消息
        /// </summary>
        public void GetHandMsg(ShakeHand Cache)
        {
            try
            {

            }
             catch (Exception ex) { LogHelper.WriteLog("" , ex); }
        }
    }
}
