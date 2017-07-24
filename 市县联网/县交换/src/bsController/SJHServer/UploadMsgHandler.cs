using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using ZIT.LOG;
using ZIT.Utility;
using ZIT.XJHServer.Model;
using ZIT.XJHServer.Model.SystemFunction;
using ZIT.XJHServer.bsController.DataUpload;

namespace ZIT.XJHServer.bsController.SJHServer
{
    class UploadMsgHandler
    {
        public void HandleMsg(string strMsg)
        {
            try
            {
                string commandID = XmlUtil.XmlAnalysis("CommandID", strMsg);
                if (commandID != "SubCenterHandshake" && commandID != "SubCenterBssHandShark")
                {
                    LogHelper.WriteNetMsgLog("Recieve UploadServer message:" + strMsg);
                }
                switch (commandID)
                {
                    case "LoginServerResp":
                        DealLoginServerResp(strMsg);
                        break;
                    case "LogoutServerResp":
                        break;
                    //单位信息上传应答
                    case "UnitInfoDataResp":
                        Controller.GetInstance().us.Upload.DealUnitInfoDataResp(strMsg);
                        break;
                    //车辆信息上传应答
                    case "VehicleDataResp":
                        Controller.GetInstance().us.Upload.DealVehicleDataResp(strMsg);
                        break;
                    //系统人员信息上传应答
                    case "SysUserDataResp":
                        Controller.GetInstance().us.Upload.DealSysUserDataResp(strMsg);
                        break;
                    //同步呼叫记录信息数据应答
                    case "CallRcordDataResp":
                        Controller.GetInstance().us.Upload.DealCallRcordDataResp(strMsg);
                        break;
                    //同步受理记录信息数据应答
                    case "DealDataResp":
                        Controller.GetInstance().us.Upload.DealDealDataResp(strMsg);
                        break;
                    //同步调度分站记录信息数据应答
                    case "DispatchStationInfoDataResp":
                        Controller.GetInstance().us.Upload.DealDispatchStationInfoData(strMsg);
                        break;
                    //同步出车记录信息数据应答
                    case "DispatchVehicleDataResp":
                        Controller.GetInstance().us.Upload.DealDispatchVehicleDataResp(strMsg);
                        break;
                    //同步病历填写项目值数据应答
                    case "Web_MedicalProjectValueResp":
                        Controller.GetInstance().us.Upload.DealWeb_MedicalProjectValueResp(strMsg);
                        break;
                    //同步病历填写项目数据应答
                    case "Web_MedicalProjectResp":
                        Controller.GetInstance().us.Upload.DealWeb_MedicalProjectResp(strMsg);
                        break;
                    //同步病历记录数据应答
                    case "Web_MedicalRecordsResp":
                        Controller.GetInstance().us.Upload.DealWeb_MedicalRecordsResp(strMsg);
                        break;
                    //同步病历填写项目与值对应数据应答
                    case "Web_MedicalStatisticsResp":
                        Controller.GetInstance().us.Upload.DealWeb_MedicalStatisticsResp(strMsg);
                        break;
                    //同步病历基础信息表数据应答
                    case "BLJCXXBResp":
                        Controller.GetInstance().us.Upload.DealBLJCXXBResp(strMsg);
                        break;
                    //同步呼救区域表数据应答
                    case "HJQYBResp":
                        Controller.GetInstance().us.Upload.DealHJQYBResp(strMsg);
                        break;
                    //同步来电类型表数据应答
                    case "LDLXBResp":
                        Controller.GetInstance().us.Upload.DealLDLXBResp(strMsg);
                        break;
                    //同步值班员信息表数据应答
                    case "ZBYXXBResp":
                        Controller.GetInstance().us.Upload.DealZBYXXBResp(strMsg);
                        break;
                    //同步症状表数据应答
                    case "ZZBResp":
                        Controller.GetInstance().us.Upload.DealZZBResp(strMsg);
                        break;
                    //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
                    case "LWBLGXTBDELBResp":
                        Controller.GetInstance().us.Upload.DealLWBLGXTBDELBResp(strMsg);
                        break;
                    //20151216修改人:朱星汉 修改内容:添加病历记录删除表的上传
                    case "LWBLTBDELBResp":
                        Controller.GetInstance().us.Upload.DealLWBLTBDELBResp(strMsg);
                        break;
                    //大型事故表
                    case "DXSGBResp":
                        Controller.GetInstance().us.Upload.DealDXSGBResp(strMsg);
                        break;
                    default: break;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 登陆应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        private void DealLoginServerResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("LoginResult", recStr);
                if (flag == "1")
                {
                    //更新状态为已登录
                    Controller.GetInstance().us.OnUploadServerLogin();
                    //开启定时上传数据线程
                    Controller.GetInstance().us.StartScanOnTimeThread();
                }
            }
            catch { }
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
                Controller.GetInstance().us.SendMessage(lsStr);
            }
            catch { }
        }

        public void SendSharkHandMsg()
        {
            SubCenterHandshake hs = new SubCenterHandshake();
            hs.CommandID = "SubCenterHandshake";
            string hsStr = XmlUtil.Serializer(hs.GetType(), hs);
            Controller.GetInstance().us.SendMessage(hsStr);
        }


    }
}
