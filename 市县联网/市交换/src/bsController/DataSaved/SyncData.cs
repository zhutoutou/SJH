using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model.SystemFunction;
using ZIT.Utility;
using ZIT.LOG;
using ZIT.SJHServer.fnDataAccess;
using ZIT.SJHServer.fnDataAccess.Oracle;
using ZIT.SJHServer.fnLocalDataAccess;
using ZIT.SJHServer.bsController.DataSaved;
using ZIT.SJHServer.bsController.SJHServer;
using System.Data;
using ZIT.SJHServer.fnDataAccess.Oracle.SQl;
using System.Data.OracleClient;
using ZIT.SJHServer.fnLocalDataAccess.Oracle;

namespace ZIT.SJHServer.bsController.DataSaved
{
    /// <summary>
    /// 负责将县120上传上来的数据同步到市全局库中
    /// </summary>
    class SyncData
    {
        private UploadServerClient ServerClient;

        public SyncData(UploadServerClient client)
        {
            ServerClient = client;
        }

        #region 基础数据上报处理
        /// <summary>
        /// 单位信息数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleUnitInfoData(string message)
        {
            try
            {
                UnitInfoData UnitInfo = (UnitInfoData)XmlUtil.Deserialize(typeof(UnitInfoData), message);
                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.UnitInfoDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_UnitInfoDataRespExchange);
                // 单位类型(1: 政府机关； 2: 事业单位；3: 企业单位；4: 急救中心；5: 急救分站；6: 医院；7: 血站；8: CDC疾控中心；9: 卫生监督所；10: 学校；11: 指挥中心；12: 应急办；13: 联动单位)
                string UnitTypeID = UnitInfo.UnitTypeID;
                switch (UnitTypeID)
                {
                    case "1":
                        UnitInfo.UnitTypeID = "政府机关";
                        break;
                    case "2":
                        UnitInfo.UnitTypeID = "事业单位";
                        break;
                    case "3":
                        UnitInfo.UnitTypeID = "企业单位";
                        break;
                    case "4":
                        UnitInfo.UnitTypeID = "急救中心";
                        break;
                    case "5":
                        UnitInfo.UnitTypeID = "急救分站";
                        break;
                    case "6":
                        UnitInfo.UnitTypeID = "医院";
                        break;
                    case "7":
                        UnitInfo.UnitTypeID = "血站";
                        break;
                    case "8":
                        UnitInfo.UnitTypeID = "CDC疾控中心";
                        break;
                    case "9":
                        UnitInfo.UnitTypeID = "卫生监督所";
                        break;
                    case "10":
                        UnitInfo.UnitTypeID = "学校";
                        break;
                    case "11":
                        UnitInfo.UnitTypeID = "指挥中心";
                        break;
                    case "12":
                        UnitInfo.UnitTypeID = "应急办";
                        break;
                    case "13":
                        UnitInfo.UnitTypeID = "联动单位";
                        break;
                    default:
                        break;
                }
                string StationType = UnitInfo.StationType;
                switch (StationType)
                {

                    case "中心":
                        UnitInfo.StationType = "0";
                        break;
                    case "分站":
                        UnitInfo.StationType = "1";
                        break;
                    default:
                        break;
                }
                List<UnitInfoData> DataList = new List<UnitInfoData>();
                DataList.Add(UnitInfo);
                Data.InsertUnitInfoData(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("dtArgs_UnitInfoDataExchange", ex);
            }
        }

        /// <summary>
        /// 单位信息数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_UnitInfoDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(UnitInfoDataResp), e.UnitInfoDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 车辆基础信息数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleVehicleData(string message)
        {
            try
            {
                VehicleData Vehicle = (VehicleData)XmlUtil.Deserialize(typeof(VehicleData), message);
                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.VehicleDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_VehicleDataRespExchange);
                //车辆类型(1、指挥车辆；2、普通车；3、监护车等)
                string VehicleType = Vehicle.VehicleType;
                switch (VehicleType)
                {
                    case "1":
                        Vehicle.VehicleType = "指挥车辆";
                        break;
                    case "2":
                        Vehicle.VehicleType = "普通车";
                        break;
                    case "3":
                        Vehicle.VehicleType = "监护车";
                        break;
                    default:
                        break;
                }
                // 注销标志(0：未注销，1：注销)
                string Cancel = Vehicle.Cancel;
                switch (Cancel)
                {
                    //1:普通呼救； 2:工作电话； 3:骚扰电话； 4: 咨询电话； 5: 重点用户
                    case "0":
                        Vehicle.Cancel = "否";
                        break;
                    case "1":
                        Vehicle.Cancel = "是";
                        break;
                    default:
                        break;
                }
                List<VehicleData> DataList = new List<VehicleData>();
                DataList.Add(Vehicle);
                Data.InsertVehicleData(DataList, ServerClient.UnitXZBM);
                    
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("dtArgs_VehicleDataExchange", ex);
            }
        }

        /// <summary>
        /// 车辆基础信息数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_VehicleDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(VehicleDataResp), e.VehicleDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 系统人员信息数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleSysUserData(string message)
        {
            try
            {
                SysUserData SysUser = (SysUserData)XmlUtil.Deserialize(typeof(SysUserData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.SysUserDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_SysUserDataRespExchange);
                /// 性别（1：男；2：女）
                string Sex = SysUser.Sex;
                switch (Sex)
                {
                    //1:普通呼救； 2:工作电话； 3:骚扰电话； 4: 咨询电话； 5: 重点用户
                    case "1":
                        SysUser.Sex = "男";
                        break;
                    case "2":
                        SysUser.Sex = "女";
                        break;
                    default:
                        break;
                }
                /// 职能（1：医生；2：护士；3：司机；4：担架工；5：管理；6：后勤；7：其它)
                string Function = SysUser.Function;
                switch (Function)
                {

                    case "1":
                        SysUser.Function = "医生";
                        break;
                    case "2":
                        SysUser.Function = "护士";
                        break;
                    case "3":
                        SysUser.Function = "司机";
                        break;
                    case "4":
                        SysUser.Function = "担架工";
                        break;
                    case "5":
                        SysUser.Function = "管理";
                        break;
                    case "6":
                        SysUser.Function = "后勤";
                        break;
                    case "7":
                        SysUser.Function = "其它";
                        break;
                    default:
                        break;
                }
                /// 技术职称(1：主任医师；2：副主任医师；3：主管医师；4：主治医师；5：医师；6：主管护师；7：医士；8：护师9：护士；10：其它)
                string TechnicalPost = SysUser.TechnicalPost;
                switch (TechnicalPost)
                {
                    //1:普通呼救； 2:工作电话； 3:骚扰电话； 4: 咨询电话； 5: 重点用户
                    case "1":
                        SysUser.TechnicalPost = "主任医师";
                        break;
                    case "2":
                        SysUser.TechnicalPost = "副主任医师";
                        break;
                    case "3":
                        SysUser.TechnicalPost = "主管医师";
                        break;
                    case "4":
                        SysUser.TechnicalPost = "主治医师";
                        break;
                    case "5":
                        SysUser.TechnicalPost = "医师";
                        break;
                    case "6":
                        SysUser.TechnicalPost = "主管护师";
                        break;
                    case "7":
                        SysUser.TechnicalPost = "医士";
                        break;
                    case "8":
                        SysUser.TechnicalPost = "护师";
                        break;
                    case "9":
                        SysUser.TechnicalPost = "护士";
                        break;
                    case "10":
                        SysUser.TechnicalPost = "其它";
                        break;
                    default:
                        break;
                }

                /// 学历(1：小学；2：中学；3：中专；4：大专；5：本科；6：硕士；7：博士；8：其它)
                string Education = SysUser.Education;
                switch (Education)
                {
                    //1:普通呼救； 2:工作电话； 3:骚扰电话； 4: 咨询电话； 5: 重点用户
                    case "1":
                        SysUser.Education = "小学";
                        break;
                    case "2":
                        SysUser.Education = "中学";
                        break;
                    case "3":
                        SysUser.Education = "中专";
                        break;
                    case "4":
                        SysUser.Education = "大专";
                        break;
                    case "5":
                        SysUser.Education = "本科";
                        break;
                    case "6":
                        SysUser.Education = "硕士";
                        break;
                    case "7":
                        SysUser.Education = "博士";
                        break;
                    case "8":
                        SysUser.Education = "其它";
                        break;
                    default:
                        break;
                }
                /// 用工形式(0:在编；1:非编)
                string WorkForm = SysUser.WorkForm;
                switch (WorkForm)
                {

                    case "0":
                        SysUser.WorkForm = "在编";
                        break;
                    case "1":
                        SysUser.WorkForm = "非编";
                        break;
                    default:
                        break;
                }
                List<SysUserData> DataList = new List<SysUserData>();
                DataList.Add(SysUser);
                Data.InsertSysUserData(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 系统人员信息应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_SysUserDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(SysUserDataResp), e.SysUserDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }



        /// <summary>
        /// 病历填写项目
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleWeb_MedicalProjectData(string message)
        {
            try
            {
                Web_MedicalProject item = (Web_MedicalProject)XmlUtil.Deserialize(typeof(Web_MedicalProject), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.Web_MedicalProjectRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalProjectRespExchange);

                List<Web_MedicalProject> DataList = new List<Web_MedicalProject>();
                DataList.Add(item);
                Data.InsertWeb_MedicalProject(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 病历填写项目应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalProjectRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(Web_MedicalProjectResp), e.Web_MedicalProjectRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 病历填写项目值
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleWeb_MedicalProjectValueData(string message)
        {
            try
            {
                Web_MedicalProjectValue item = (Web_MedicalProjectValue)XmlUtil.Deserialize(typeof(Web_MedicalProjectValue), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.Web_MedicalProjectValueRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalProjectValueRespExchange);

                List<Web_MedicalProjectValue> DataList = new List<Web_MedicalProjectValue>();
                DataList.Add(item);
                Data.InsertWeb_MedicalProjectValue(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 病历填写项目值应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalProjectValueRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(Web_MedicalProjectValueResp), e.Web_MedicalProjectValueRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }


        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleBLJCXXBData(string message)
        {
            try
            {
                BLJCXXB item = (BLJCXXB)XmlUtil.Deserialize(typeof(BLJCXXB), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.BLJCXXBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_BLJCXXBRespExchange);

                List<BLJCXXB> DataList = new List<BLJCXXB>();
                DataList.Add(item);
                Data.InsertBLJCXXB(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 病历基础信息表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_BLJCXXBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(BLJCXXBResp), e.BLJCXXBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleHJQYBData(string message)
        {
            try
            {
                HJQYB item = (HJQYB)XmlUtil.Deserialize(typeof(HJQYB), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.HJQYBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_HJQYBRespExchange);

                List<HJQYB> DataList = new List<HJQYB>();
                DataList.Add(item);
                Data.InsertHJQYB(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 呼救区域表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_HJQYBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(HJQYBResp), e.HJQYBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 来电类型表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleLDLXBData(string message)
        {
            try
            {
                LDLXB item = (LDLXB)XmlUtil.Deserialize(typeof(LDLXB), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.LDLXBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LDLXBRespExchange);

                List<LDLXB> DataList = new List<LDLXB>();
                DataList.Add(item);
                Data.InsertLDLXB(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 来电类型表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LDLXBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(LDLXBResp), e.LDLXBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleZBYXXBData(string message)
        {
            try
            {
                ZBYXXB item = (ZBYXXB)XmlUtil.Deserialize(typeof(ZBYXXB), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.ZBYXXBRespExchange+= new EventHandler<DataExchangeRespEventArgs>(Data_ZBYXXBRespExchange);

                List<ZBYXXB> DataList = new List<ZBYXXB>();
                DataList.Add(item);
                Data.InsertZBYXXB(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 值班员信息表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_ZBYXXBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(ZBYXXBResp), e.ZBYXXBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 症状表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleZZBData(string message)
        {
            try
            {
                ZZB item = (ZZB)XmlUtil.Deserialize(typeof(ZZB), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.ZZBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_ZZBRespExchange);

                List<ZZB> DataList = new List<ZZB>();
                DataList.Add(item);
                Data.InsertZZB(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 症状表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_ZZBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(ZZBResp), e.ZZBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
 
        #endregion

        #region 业务数据上报处理


        /// <summary>
        /// 呼叫记录信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCallRcordData(string message)
        {
            try
            {
                LogHelper.WriteLog("Call处理。");
                CallRcordData CallRcord = (CallRcordData)XmlUtil.Deserialize(typeof(CallRcordData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.CallRcordDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_CallRcordDataRespExchange);
                string CallType = CallRcord.CallType;
                switch (CallType)
                {
                    //1:普通呼救； 2:工作电话； 3:骚扰电话； 4: 咨询电话； 5: 重点用户
                    case "1":
                        CallRcord.CallType = "普通呼救";
                        break;
                    case "2":
                        CallRcord.CallType = "工作电话";
                        break;
                    case "3":
                        CallRcord.CallType = "骚扰电话";
                        break;
                    case "4":
                        CallRcord.CallType = "咨询电话";
                        break;
                    case "5":
                        CallRcord.CallType = "重点用户";
                        break;
                    default:
                        break;
                }
                List<CallRcordData> DataList = new List<CallRcordData>();
                DataList.Add(CallRcord);
                
                Data.InsertCallRcordData(DataList, ServerClient.UnitXZBM);
                LogHelper.WriteLog("Call结束。");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 呼叫记录信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_CallRcordDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(CallRcordDataResp), e.CallRcordDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 受理信息上报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleDealData(string message)
        {
            try
            {
                DealData Deal = (DealData)XmlUtil.Deserialize(typeof(DealData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.DealDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DealDataRespExchange);
                string Standing = Deal.Standing;
                switch (Standing)
                {
                    //患者身份(1:普通人员;2:重要人员)
                    case "1":
                        Deal.Standing = "普通人员";
                        break;
                    case "2":
                        Deal.Standing = "重要人员";
                        break;
                    default:
                        break;
                }
                // 回车标志(0：否；1：是) 
                string RejectFlag = Deal.RejectFlag;
                switch (RejectFlag)
                {

                    case "0":
                        Deal.RejectFlag = "否";
                        break;
                    case "1":
                        Deal.RejectFlag = "是";
                        break;
                    default:
                        break;
                }
                /// 呼救类型(1：普通呼叫；2：大型事故)
                string CallHelpType = Deal.CallHelpType;
                switch (CallHelpType)
                {
                    case "1":
                        Deal.CallHelpType = "普通呼叫";
                        break;
                    case "2":
                        Deal.CallHelpType = "大型事故";
                        break;
                    default:
                        break;
                }
                ////// 受理状态(1：接听；2：未处理；3：已处理；4：待派车；5：已派车；6：已完成；7：已归档)
                string DealStatus = Deal.DealStatus;
                switch (DealStatus)
                {
                    case "1":
                        Deal.DealStatus = "接听";
                        break;
                    case "2":
                        Deal.DealStatus = "未处理";
                        break;
                    case "3":
                        Deal.DealStatus = "已处理";
                        break;
                    case "4":
                        Deal.DealStatus = "待派车";
                        break;
                    case "5":
                        Deal.DealStatus = "已派车";
                        break;
                    case "6":
                        Deal.DealStatus = "已完成";
                        break;
                    case "7":
                        Deal.DealStatus = "已归档";
                        break;
                    default:
                        break;
                }
                /// 特殊案件标志(0：否；1：是)
                string SpecialCaseFalg = Deal.SpecialCaseFalg;
                switch (SpecialCaseFalg)
                {
                    case "0":
                        Deal.SpecialCaseFalg = "否";
                        break;
                    case "1":
                        Deal.SpecialCaseFalg = "是";
                        break;
                    default:
                        break;
                }
                /// 上报标志(0：否；1：是)
                string ReportFalg = Deal.ReportFalg;
                switch (ReportFalg)
                {
                    case "0":
                        Deal.RejectFlag = "否";
                        break;
                    case "1":
                        Deal.RejectFlag = "是";
                        break;
                    default:
                        break;
                }
                List<DealData> DataList = new List<DealData>();
                DataList.Add(Deal);

                Data.InsertDealData(DataList, ServerClient.UnitXZBM);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 受理信息应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_DealDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(DealDataResp), e.DealDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Controller.Data_DealDataRespExchange", ex);
            }
        }


        /// <summary>
        /// 调度分站记录信息上报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleDispatchStationInfoData(string message)
        {
            try
            {
                DispatchStationInfoData DispatchVehicle = (DispatchStationInfoData)XmlUtil.Deserialize(typeof(DispatchStationInfoData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.DispatchStationInfoDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DispatchStationInfoDataRespExchange);

                List<DispatchStationInfoData> DataList = new List<DispatchStationInfoData>();
                DataList.Add(DispatchVehicle);
                Data.InsertDispatchStationInfoData(DataList, ServerClient.UnitXZBM);
                
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 调度分站记录信息应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_DispatchStationInfoDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {

            try
            {
                string xml = XmlUtil.Serializer(typeof(DispatchStationInfoDataResp), e.DispatchStationInfoDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 出车信息上报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleDispatchVehicleData(string message)
        {
            try
            {
                DispatchVehicleData DispatchVehicle = (DispatchVehicleData)XmlUtil.Deserialize(typeof(DispatchVehicleData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.DispatchVehicleDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DispatchVehicleDataRespExchange);
                
                List<DispatchVehicleData> DataList = new List<DispatchVehicleData>();
                DataList.Add(DispatchVehicle);

                Data.InsertDispatchVehicleData(DataList, ServerClient.UnitXZBM);
                
                //同步联网调度单的出车信息到市120本地库中
                ISyncData syncData =   LocalDataAccess.SyncDataAccess();
                syncData.DispatchVehicleDataRespExchange += new EventHandler<SyncDataRespEventArgs>(Data_DispatchVehicleDataRespSync);
                syncData.SyncDispatchVehicleData(DispatchVehicle, ServerClient.UnitCode);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        private void Data_DispatchVehicleDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                //string xml = XmlUtil.Serializer(typeof(DispatchVehicleDataResp), e.DispatchVehicleDataRespMessage);
                //ServerClient.SendMessage(xml);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 出车信息应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_DispatchVehicleDataRespSync(object sender, SyncDataRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(DispatchVehicleDataResp), e.DispatchVehicleDataRespMessage);
                ServerClient.SendMessage(xml);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 大型事故数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleLargeSlipData(string message)
        {
            try
            {
                LargeSlipData LargeSlip = (LargeSlipData)XmlUtil.Deserialize(typeof(LargeSlipData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.LargeSlipDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LargeSlipDataRespExchange);
                List<LargeSlipData> DataList = new List<LargeSlipData>();
                DataList.Add(LargeSlip);
                Data.InsertLargeSlipData(DataList, ServerClient.UnitXZBM);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 大型事故数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LargeSlipDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(LargeSlipDataResp), e.LargeSlipDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
            //SendMessage(e.LargeSlipDataRespMessage.CommandID);
        }

        /// <summary>
        /// 患者信息数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleSuffererData(string message)
        {
            try
            {
                SuffererData Sufferer = (SuffererData)XmlUtil.Deserialize(typeof(SuffererData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.SuffererDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_SuffererDataRespExchange);
                List<SuffererData> DataList = new List<SuffererData>();
                DataList.Add(Sufferer);
                Data.InsertSuffererData(DataList, ServerClient.UnitXZBM);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 患者信息数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_SuffererDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(SuffererDataResp), e.SuffererDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 患者病历信息数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleSuffererCaseHistoryData(string message)
        {
            try
            {
                SuffererCaseHistoryData Sufferer = (SuffererCaseHistoryData)XmlUtil.Deserialize(typeof(SuffererCaseHistoryData), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.SuffererCaseHistoryDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_SuffererCaseHistoryDataRespExchange);
                List<SuffererCaseHistoryData> DataList = new List<SuffererCaseHistoryData>();
                DataList.Add(Sufferer);
                Data.InsertSuffererCaseHistoryData(DataList, ServerClient.UnitXZBM);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 患者病历信息数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_SuffererCaseHistoryDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(SuffererCaseHistoryDataResp), e.SuffererCaseHistoryDataRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }

        }

        /// <summary>
        /// 急救人员及急救车辆关系信息数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandlePVRelation(string message)
        {
            try
            {
                PVRelation Sufferer = (PVRelation)XmlUtil.Deserialize(typeof(PVRelation), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.PVRelationRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_PVRelationRespExchange);
                List<PVRelation> DataList = new List<PVRelation>();
                DataList.Add(Sufferer);
                Data.InsertPVRelation(DataList, ServerClient.UnitXZBM);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 急救人员及急救车辆关系信息数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_PVRelationRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(PVRelationResp), e.PVRelationRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }

        }

        /// <summary>
        /// 同步病历记录
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleWeb_MedicalRecordsData(string message)
        {
            try
            {
                Web_MedicalRecords item = (Web_MedicalRecords)XmlUtil.Deserialize(typeof(Web_MedicalRecords), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.Web_MedicalRecordsRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalRecordsRespExchange);

                List<Web_MedicalRecords> DataList = new List<Web_MedicalRecords>();
                DataList.Add(item);
                Data.InsertWeb_MedicalRecords(DataList, ServerClient.UnitXZBM);

                //同步联网调度单的患者信息到市120本地库中
                ISyncData syncData = LocalDataAccess.SyncDataAccess();
                syncData.Web_MedicalRecordsRespExchange += new EventHandler<SyncDataRespEventArgs>(Data_Web_MedicalRecordsRespSync);
                syncData.SyncWeb_MedicalRecords(item, ServerClient.UnitCode);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }


        /// <summary>
        /// 同步病历记录应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalRecordsRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                //string xml = XmlUtil.Serializer(typeof(Web_MedicalRecordsResp), e.Web_MedicalRecordsRespMessage);
                //ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 同步病历记录应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalRecordsRespSync(object sender, SyncDataRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(Web_MedicalRecordsResp), e.Web_MedicalRecordsRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 病历填写项目与值对应关系数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleWeb_MedicalStatisticsData(string message)
        {
            try
            {
                Web_MedicalStatistics item = (Web_MedicalStatistics)XmlUtil.Deserialize(typeof(Web_MedicalStatistics), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.Web_MedicalStatisticsRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalStatisticsRespExchange);

                List<Web_MedicalStatistics> DataList = new List<Web_MedicalStatistics>();
                DataList.Add(item);
                Data.InsertWeb_MedicalStatistics(DataList, ServerClient.UnitXZBM);

                //同步联网调度单的患者病历内容对应关系信息到市120本地库中
                ISyncData syncData = LocalDataAccess.SyncDataAccess();
                syncData.Web_MedicalStatisticsRespExchange += new EventHandler<SyncDataRespEventArgs>(Data_Web_MedicalStatisticsRespSync);
                syncData.SyncWeb_MedicalStatistics(item, ServerClient.UnitCode);
                
           
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        private void Data_Web_MedicalStatisticsRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(Web_MedicalStatisticsResp), e.Web_MedicalStatisticsRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 病历填写项目与值对应关系数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalStatisticsRespSync(object sender, SyncDataRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(Web_MedicalStatisticsResp), e.Web_MedicalStatisticsRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系记录删除表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleLWBLGXTBDELBData(string message)
        {
            try
            {
                LWBLGXTBDELB item = (LWBLGXTBDELB)XmlUtil.Deserialize(typeof(LWBLGXTBDELB), message);
                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.LWBLGXTBDELBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWBLGXTBDELBRespExchange);

                List<LWBLGXTBDELB> DataList = new List<LWBLGXTBDELB>();
                DataList.Add(item);
                Data.DeleteWeb_MedicalStatistics(DataList, ServerClient.UnitXZBM);

                ISyncData syncData = LocalDataAccess.SyncDataAccess();
                syncData.SyncLWBLGXTBDELB(item, ServerClient.UnitCode);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系记录删除表数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWBLGXTBDELBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(LWBLGXTBDELBResp), e.LWBLGXTBDELBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历记录删除表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleLWBLTBDELBData(string message)
        {
            try
            {
                LWBLTBDELB item = (LWBLTBDELB)XmlUtil.Deserialize(typeof(LWBLTBDELB), message);
                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.LWBLTBDELBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWBLTBDELBRespExchange);

                List<LWBLTBDELB> DataList = new List<LWBLTBDELB>();
                DataList.Add(item);
                Data.DeleteWeb_MedicalRecords(DataList, ServerClient.UnitXZBM);

                ISyncData syncData = LocalDataAccess.SyncDataAccess();
                syncData.SyncLWBLTBDELB(item, ServerClient.UnitCode);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        //20151216修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历记录删除表数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWBLTBDELBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(LWBLTBDELBResp), e.LWBLTBDELBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 大型事故表数据
        /// </summary>
        /// <param name="strMsg"></param>
        public void HandleDXSGBData(string message)
        {
            try
            {
                DXSGB item = (DXSGB)XmlUtil.Deserialize(typeof(DXSGB), message);

                IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                Data.DXSGBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DXSGBRespExchange);

                List<DXSGB> DataList = new List<DXSGB>();
                DataList.Add(item);
                Data.InsertDXSGB(DataList, ServerClient.UnitXZBM);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 大型事故表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_DXSGBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                string xml = XmlUtil.Serializer(typeof(DXSGBResp), e.DXSGBRespMessage);
                ServerClient.SendMessage(xml);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        
        #endregion
    }
}
