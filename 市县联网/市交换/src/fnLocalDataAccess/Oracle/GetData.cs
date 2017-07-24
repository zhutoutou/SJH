using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using System.Data;
using System.Configuration;
using ZIT.LOG;
using ZIT.Utility;
using ZIT.SJHServer.fnArgs;
using ZIT.SJHServer.Model;

namespace ZIT.SJHServer.fnLocalDataAccess.Oracle
{
    public class GetData : IGetData
    {

        public static string DWBH = SystemArgs.GetInstance().args.UnitCode;
        /// <summary>
        /// 车辆基础信息
        /// </summary>
        /// <returns></returns>
        public List<VehicleData> GetVehicleData()
        {
            try
            {
                List<VehicleData> list = new List<VehicleData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetVehicleDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        VehicleData vd = new VehicleData();
                        vd.CommandID = "VehicleData";
                        vd.VehicleID = r["ID"].ToString();
                        vd.Mobile = r["CZDH"].ToString();
                        vd.EngineNumber = r["FDJHM"].ToString();
                        vd.VehicleCode = r["CLBH"].ToString();
                        vd.CarNumber = r["CPH"].ToString();
                        vd.VehicleType = r["CLLX"].ToString();
                        vd.UnitName = r["SSDW"].ToString();
                        vd.PurchaseDate = r["GZSJ"].ToString();
                        vd.UseDate = r["SYSJ"].ToString();
                        vd.Cancel = r["ZXBZ"].ToString();
                        vd.VehicleName = r["MC"].ToString();
                        vd.Remark = r["BZ"].ToString();
                        list.Add(vd);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 系统人员
        /// </summary>
        /// <returns></returns>
        public List<SysUserData> GetSysUserData()
        {
            try
            {
                List<SysUserData> list = new List<SysUserData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetSysUserDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        SysUserData vd = new SysUserData();
                        vd.CommandID = "SysUserData";
                        vd.UserName = r["RYBH"].ToString();
                        vd.Name = r["XM"].ToString();
                        vd.Sex = r["XB"].ToString();
                        vd.CertificateNumber = r["sfzhm"].ToString();
                        vd.OwnUnit = r["ssdw"].ToString();
                        vd.Headship = r["zw"].ToString();
                        vd.Function = r["zn"].ToString();
                        vd.TechnicalPost = r["jszc"].ToString();
                        vd.Education = r["xl"].ToString();
                        vd.GraduationSchool = r["byxx"].ToString();
                        vd.Profession = r["zy"].ToString();
                        vd.WorkForm = r["ygxs"].ToString();
                        vd.OfficeTelephone = r["bgdh"].ToString();
                        vd.Mobile = r["lxfs"].ToString();
                        vd.FamilyTelephone = r["jtdh"].ToString();
                        vd.BirthDay = r["cssj"].ToString();
                        vd.GraduationDate = r["bysj"].ToString();
                        vd.JobDate = r["cjgzsj"].ToString();
                        vd.EntryPositionDate = r["rzrq"].ToString();
                        vd.RegisterDate = r["djrq"].ToString();
                        vd.WriteoffDate = r["zxrq"].ToString();
                        vd.Cancel = r["zxbz"].ToString();
                        vd.Remark = r["bz"].ToString();
                        //20151210 修改人:朱星汉 修改内容:添加系统人员密码
                        vd.Password = r["MM"].ToString();
                        list.Add(vd);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }
        // <summary>
        // 当前状态信息表
        // </summary>
        // <returns></returns>
        //public List<Dqclztxxb> GetDqclztxxb()
        //{
        //    try
        //    {
        //        List<Dqclztxxb> list = new List<Dqclztxxb>();
        //        DataTable dt = DBHelperOracle.Query(GetDataSql.GetDqclztxxbStr()).Tables[0];
        //        foreach (DataRow r in dt.Rows)
        //        {
        //            try
        //            {
        //                Dqclztxxb vd = new Dqclztxxb();
        //                vd.CommandID = vd.GetType().Name; ;
        //                20151120修改人:朱星汉 修改内容:工作状态的70消息全局库模式应为数字而不是汉字
        //                vd.GZZT = r["GZZT"].ToString();
        //                int isNumber;
        //                if (int.TryParse(r["GZZT"].ToString(), out isNumber) == false)
        //                {
        //                    vd.GZZT = GetNumberGZZT(r["GZZT"].ToString());
        //                }
        //                else
        //                {
        //                    vd.GZZT = r["GZZT"].ToString();
        //                }
        //                vd.ID = r["ID"].ToString();
        //                vd.LSH = r["LSH"].ToString();
        //                vd.xslc = r["xslc"].ToString();
        //                vd.zhfxsj = r["zhfxsj"].ToString();
        //                list.Add(vd);
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }
        //        return list;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //20151120 修改人:朱星汉 修改内容:添加从文字到数字的工作状态的转化
        private string GetNumberGZZT(string strGZZT)
        {
            string strGZZTNUM = "";

            try
            {
                switch (strGZZT)
                {
                    case "待命":
                        strGZZTNUM = "00";
                        break;
                    case "未值班":
                        strGZZTNUM = "07"; //未上班/下班;
                        break;
                    case "维修":
                        strGZZTNUM = "08";
                        break;
                    case "暂停调用":
                        strGZZTNUM = "09"; //暂停调度
                        break;
                    case "出车":
                        strGZZTNUM = "01";
                        break;
                    case "收到信息":
                        strGZZTNUM = "19";
                        break;
                    case "到达现场":
                        strGZZTNUM = "02";
                        break;
                    case "病人上车":
                        strGZZTNUM = "31";
                        break;
                    case "死亡不送":
                        strGZZTNUM = "32";
                        break;
                    case "病人不去":
                        strGZZTNUM = "33";
                        break;
                    case "车到人走":
                        strGZZTNUM = "34";
                        break;
                    case "它车接走":
                        strGZZTNUM = "35";
                        break;
                    case "就地处置":
                        strGZZTNUM = "36";
                        break;
                    case "送达医院":
                        strGZZTNUM = "04"; //到达医院
                        break;
                    case "任务完成":
                        strGZZTNUM = "05";
                        break;
                    case "回站":
                        strGZZTNUM = "06";
                        break;
                    case "车辆故障":
                        strGZZTNUM = "10";
                        break;
                    case "道路阻塞":
                        strGZZTNUM = "11";
                        break;
                    case "申请联络":
                        strGZZTNUM = "12";
                        break;
                    case "应急申请":
                        strGZZTNUM = "13";
                        break;
                }
            }
            catch { return strGZZT = ""; }
            return strGZZTNUM;
        }

        /// <summary>
        ///急救人员及急救车辆关系
        /// </summary>
        /// <returns></returns>
        public List<PVRelation> GetPVRelationData()
        {
            try
            {

                List<PVRelation> list = new List<PVRelation>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetPVRelationDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        PVRelation vd = new PVRelation();
                        vd.CommandID = "PVRelation";
                        vd.Index = r["XH"].ToString();
                        vd.Mobile = r["CZDH"].ToString();
                        if (r["ZN"].ToString() == "医生")
                            vd.Doctor = r["RYBH"].ToString();
                        else if (r["ZN"].ToString() == "护士")
                            vd.Nurse = r["RYBH"].ToString();
                        else if (r["ZN"].ToString() == "司机")
                            vd.Driver = r["RYBH"].ToString();
                        else
                            vd.StretcherPerson = r["XM"].ToString();
                        if (r["SBSJ"].ToString() != string.Empty && r["xbsj"].ToString() == string.Empty)
                        {
                            vd.Flag = "1";
                            vd.OnOffDutyTime = r["sbsj"].ToString();
                            list.Add(vd);
                        }
                        else if (r["SBSJ"].ToString() != string.Empty && r["XBSJ"].ToString() != string.Empty)
                        {
                            vd.Flag = "1";
                            vd.OnOffDutyTime = r["SBSJ"].ToString();
                            list.Add(vd);
                            PVRelation vd1 = new PVRelation();
                            vd1.Index = vd.Index;
                            vd1.CommandID = vd.CommandID;
                            vd1.Doctor = vd.Doctor;
                            vd1.Driver = vd.Driver;
                            vd1.Nurse = vd.Nurse;
                            vd1.StretcherPerson = vd.StretcherPerson;
                            vd1.Mobile = vd.Mobile;
                            vd1.Flag = "0";
                            vd1.OnOffDutyTime = r["XBSJ"].ToString();
                            list.Add(vd1);
                        }
                        else if (r["SBSJ"].ToString() == string.Empty && r["xbsj"].ToString() != string.Empty)
                        {
                            vd.OnOffDutyTime = r["XBSJ"].ToString();
                            vd.Flag = "0";
                            list.Add(vd);
                        }
                        else
                        {
                            vd.Flag = "";
                            vd.OnOffDutyTime = "";

                        }

                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }

                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 受理信息上报
        /// </summary>
        /// <returns></returns>
        public List<DealData> GetDealData()
        {
            try
            {
                List<DealData> list = new List<DealData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetDealDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        DealData vd = new DealData();
                        vd.CommandID = "DealData";
                        vd.DealRecordID = r["lsh"].ToString();
                        vd.InfoSource = r["xxly"].ToString();
                        vd.AgentNo = r["slth"].ToString();
                        vd.WatcherName = r["zby"].ToString();
                        vd.WatchShiftGroup = r["zbbc"].ToString();
                        vd.DealTime = r["slsj"].ToString();
                        vd.CallNumber = r["zjhm"].ToString();
                        vd.CallAddress = r["hjdz"].ToString();
                        vd.CallArea = r["hjqy"].ToString();
                        vd.CallType = r["ldlx"].ToString();
                        vd.CallerName = r["hjr"].ToString();
                        vd.CallerType = r["hczlx"].ToString();
                        vd.ContactTelphone = r["lxdh"].ToString();
                        vd.SuffererName = r["hzxm"].ToString();
                        vd.SuffererSex = r["hzxb"].ToString();
                        vd.SuffererAge = r["hznl"].ToString();
                        vd.Nationality = r["hzgj"].ToString();
                        vd.Standing = r["hzsf"].ToString();
                        vd.AnaphylacticMedication = r["gmyw"].ToString();
                        vd.Symptom = r["hzzz"].ToString();
                        vd.SuffererMedicalRecord = r["hzbs"].ToString();
                        vd.MeetAddress = r["jcdz"].ToString();
                        vd.SendArriveAddress = r["swdd"].ToString();
                        vd.TreatmentMode = r["czfs"].ToString();
                        vd.RejectFlag = r["hcbz"].ToString();
                        vd.RejectReason = r["hcyy"].ToString();
                        vd.HangupTime = r["gjsj"].ToString();
                        vd.DealTimeSpan = r["slsc"].ToString();
                        vd.AttemperBeginTime = r["DDKSSJ"].ToString();
                        vd.AttemperEndTime = r["DDJSSJ"].ToString();
                        vd.AttemperTimeSpan = r["DDSC"].ToString();
                        vd.CallAddressX = r["HJDZ_X"].ToString();
                        vd.CallAddressY = r["HJDZ_y"].ToString();
                        vd.MeetAddressX = r["JCDZ_X"].ToString();
                        vd.MeetAddressY = r["JCDZ_Y"].ToString();
                        string hjlx = r["HJLX"].ToString();
                        if (hjlx == "普通呼叫")
                        {
                            vd.CallHelpType = "1";
                        }
                        else if (hjlx == "大型事故")
                        {
                            vd.CallHelpType = "2";
                        }
                        else
                        {
                            vd.CallHelpType = r["HJLX"].ToString();
                        }
                        vd.SlipType = r["SGLX"].ToString();
                        vd.SlipReason = r["SGYY"].ToString();
                        vd.SlipName = r["SGMC"].ToString();
                        vd.DealStatus = r["SLZT"].ToString();
                        vd.DispatchVehiclePrinciple = r["PCYZ"].ToString();
                        vd.AnearRoadName = r["KJLM"].ToString();
                        vd.RelateDealRecordID = r["SJGLLSH"].ToString();
                        vd.DominationStreet = r["GXJD"].ToString();
                        vd.DominationHospital = r["GXYY"].ToString();
                        vd.HappenAddress = r["FBDD"].ToString();
                        vd.SpecialCaseFalg = r["TSAJBZ"].ToString();
                        vd.ReportFalg = r["SBBZ"].ToString();
                        vd.AffectNumber = r["HZRS"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 出车信息数据
        /// </summary>
        /// <returns></returns>
        public List<DispatchVehicleData> GetDispatchVehicleData()
        {
            try
            {

                List<DispatchVehicleData> list = new List<DispatchVehicleData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetDispatchVehicleDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        DispatchVehicleData vd = new DispatchVehicleData();
                        vd.CommandID = "DispatchVehicleData";
                        //201511201 修改人:朱星汉 修改内容:添加车辆编号
                        vd.VehicleCode = r["CLBH"].ToString();
                        vd.DealRecordID = r["LSH"].ToString();
                        vd.Times = r["CS"].ToString();
                        vd.DispatchVehicleType = r["CCLX"].ToString();
                        vd.Driver = r["SJ"].ToString();
                        vd.Doctor = r["scys"].ToString();
                        vd.Nurse = r["SCHS"].ToString();
                        //vd.StretcherPerson = r["Scdjg"].ToString();
                        vd.VehicleID = r["CLID"].ToString();
                        vd.ReceiveTaskTime = r["SDXXSJ"].ToString();
                        vd.AcceptHospital = r["SWYY"].ToString();
                        vd.DispatchVehicleTime = r["PCSJ"].ToString();
                        vd.StartoffAddress = r["CCDD"].ToString();
                        vd.StartoffTime = r["CCSJ"].ToString();
                        vd.ArriveSceneTime = r["DDXCSJ"].ToString();
                        vd.GetInVehicleTime = r["SCSJ"].ToString();
                        vd.ArriveDestinationTime = r["DDSJ"].ToString();
                        vd.FinishTaskTime = r["WCSJ"].ToString();
                        vd.ReturnParkTime = r["FZSJ"].ToString();
                        vd.StartoffUseTime = r["CCYS"].ToString();
                        vd.ArriveSceneUseTime = r["LTYS"].ToString();
                        vd.SceneUseTime = r["XCYS"].ToString();
                        vd.AarriveDestinationUseTime = r["ZTYS"].ToString();
                        vd.TotalUseTime = r["ZHS"].ToString();
                        vd.SteerMileage = r["XSLC"].ToString();
                        vd.SpecialEvent = r["TSSJ"].ToString();
                        vd.SpecialReason = r["TSYY"].ToString();
                        vd.SpecialEventTime = r["TSSJSJ"].ToString();
                        //20151210 修改人:朱星汉 修改内容:添加车辆信息状态字段
                        vd.VehicleZT = r["ZT"].ToString();
                        //20160106 修改人:朱星汉 修改内容:添加出车车次(CCCC)字段
                        vd.VehicleCCCC = r["CCCC"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        ///  患者数据
        /// </summary>
        /// <returns></returns>
        public List<SuffererData> GetSuffererData()
        {


            try
            {
                List<SuffererData> list = new List<SuffererData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetSuffererDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        SuffererData vd = new SuffererData();
                        vd.CommandID = "SuffererData";
                        //201511201 修改人:朱星汉 修改内容:添加车辆编号
                        vd.VehicleNo = r["CLBH"].ToString();
                        vd.Mobile = r["CZDH"].ToString();
                        vd.DealRecordID = r["LSH"].ToString();
                        vd.SuffererNo = r["XH"].ToString();
                        vd.SuffererName = r["XM"].ToString();
                        vd.SuffererSex = r["XB"].ToString();
                        vd.SuffererAge = r["NL"].ToString();
                        vd.Nationality = r["GJ"].ToString();
                        vd.Profession = r["ZY"].ToString();
                        vd.Telephone = r["DHHM"].ToString();
                        vd.Hospital = r["SWDD"].ToString();

                        //vd.Symptom = r["HZZZ"].ToString();
                        vd.FirstDiag = r["CBZD"].ToString();
                        vd.InjuredDegree = r["SSCD"].ToString();
                        vd.LocaleSalvage = r["XCQJ"].ToString();
                        vd.ValidSalvage = r["YXQJ"].ToString();
                        vd.CureResult = r["JZJG"].ToString();
                        vd.LocalePlace = r["XCDD"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 患者病历信息数据
        /// </summary>
        /// <returns></returns>
        public List<SuffererCaseHistoryData> GetSuffererCaseHistoryData()
        {
            try
            {
                List<SuffererCaseHistoryData> list = new List<SuffererCaseHistoryData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetSuffererCaseHistoryDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {

                        SuffererCaseHistoryData vd = new SuffererCaseHistoryData();
                        vd.CommandID = "SuffererCaseHistoryData";
                        //201511201 修改人:朱星汉 修改内容:添加车辆编号
                        vd.VehicleNo = r["CLBH"].ToString();
                        vd.Mobile = r["CZDH"].ToString();
                        vd.DealRecordID = r["LSH"].ToString();
                        vd.SuffererNo = r["XH"].ToString();
                        vd.IllnessState = r["BQ"].ToString();
                        vd.IllnessHistory = r["BS"].ToString();
                        vd.BloodPressure = r["XY"].ToString();
                        vd.Pulse = r["MB"].ToString();
                        vd.Breath = r["HX"].ToString();
                        vd.HeartRate = r["XL"].ToString();
                        vd.AnimalHeat = r["TW"].ToString();
                        vd.Pupil = r["TK"].ToString();
                        vd.LightEcho = r["DGFS"].ToString();
                        vd.CommonlyCircs = r["YBQK"].ToString();
                        vd.Mind = r["SHZ"].ToString();
                        vd.Skin = r["PF"].ToString();
                        vd.Heart = r["XZ"].ToString();
                        vd.Lung = r["FB"].ToString();
                        vd.Abdomen = r["FUB"].ToString();
                        vd.Extremity = r["SZ"].ToString();
                        vd.HeadNeck = r["TJB"].ToString();
                        vd.Neural = r["SJXT"].ToString();
                        vd.FirstAidPurpose = r["JJXG"].ToString();
                        vd.Other = r["QT"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 呼叫记录表
        /// </summary>
        /// <returns></returns>
        public List<CallRcordData> GetCallRcordData()
        {
            try
            {
                List<CallRcordData> list = new List<CallRcordData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetCallRcordDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        CallRcordData vd = new CallRcordData();
                        vd.CommandID = "CallRcordData";
                        vd.CallID = r["LSH"].ToString();
                        vd.CallNumber = r["ZJHM"].ToString();
                        vd.CallType = r["ZJLX"].ToString();
                        vd.DealType = r["HJZT"].ToString();
                        vd.CallTime = r["LDSJ"].ToString();
                        vd.RespTime = r["SLSJ"].ToString();
                        vd.WaitTime = r["DDSC"].ToString();
                        vd.HangupTime = r["GJSJ"].ToString();
                        vd.TalkTime = r["SLSC"].ToString();
                        vd.AttempeStartTime = r["DDKSSJ"].ToString();
                        vd.AttempeEndTime = r["DDJSSJ"].ToString();
                        vd.AttempeTime = r["DDUSC"].ToString();
                        vd.AgentID = r["SLTH"].ToString();
                        vd.InfoSurce = r["XXLY"].ToString();
                        //vd.NetworkDealRecordID = r["GLLSH"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 单位信息数据
        /// </summary>
        /// <returns></returns>
        public List<UnitInfoData> GetUnitInfoData()
        {
            try
            {
                List<UnitInfoData> list = new List<UnitInfoData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetUnitInfoDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        UnitInfoData vd = new UnitInfoData();
                        vd.CommandID = "UnitInfoData";
                        vd.UnitCode = r["DWBH"].ToString();
                        vd.SequenceNO = r["XH"].ToString();
                        vd.Telephone = r["FZHM"].ToString();
                        vd.UnitName = r["DWMC"].ToString();
                        vd.Spelling = r["PY"].ToString();
                        vd.UnitTypeID = r["DWLX"].ToString();
                        vd.SuperiorUnitName = r["SJDW"].ToString();
                        vd.Area = r["SSQY"].ToString();
                        vd.StationType = r["LX"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }

                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 大型事故信息数据
        /// </summary>
        /// <returns></returns>
        public List<LargeSlipData> GetLargeSlipData()
        {
            try
            {

                List<LargeSlipData> list = new List<LargeSlipData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLargeSlipDataStr());
                foreach (DataRow r in dt.Rows)
                {

                    try
                    {
                        LargeSlipData vd = new LargeSlipData();
                        vd.CommandID = "LargeSlipData";
                        vd.ID = r["LSH"].ToString();

                        vd.SlipName = r["SGMC"].ToString();
                        vd.SlipType = r["SGLX"].ToString();
                        vd.ReportDepartment1 = r["SBBM1"].ToString();
                        vd.Telephone1 = r["DHHM1"].ToString();
                        vd.CalledPerson1 = r["JHR1"].ToString();
                        vd.ReportTime1 = r["SBSJ1"].ToString();
                        vd.ArriveTime1 = r["ZHCDDSJ1"].ToString();
                        vd.ReportDepartment2 = r["SBBM2"].ToString();
                        vd.Telephone2 = r["DHHM2"].ToString();
                        vd.CalledPerson2 = r["JHR2"].ToString();
                        vd.ReportTime2 = r["SBSJ2"].ToString();
                        vd.ArriveTime2 = r["ZHCDDSJ2"].ToString();
                        vd.ReportDepartment3 = r["SBBM3"].ToString();
                        vd.Telephone3 = r["DHHM3"].ToString();
                        vd.CalledPerson3 = r["JHR3"].ToString();
                        vd.ReportTime3 = r["SBSJ3"].ToString();
                        vd.ArriveTime3 = r["ZHCDDSJ3"].ToString();
                        vd.Remark = r["XJ"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 调度分站记录信息数据
        /// </summary>
        /// <returns></returns>
        public List<DispatchStationInfoData> GetDispatchStationInfoData()
        {
            try
            {
                List<DispatchStationInfoData> list = new List<DispatchStationInfoData>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetDispatchStationInfoDataStr());
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        DispatchStationInfoData vd = new DispatchStationInfoData();
                        vd.CommandID = "DispatchStationInfoData";
                        vd.ID = r["lsh"].ToString();
                        vd.DispatchVehicleUnit = r["CCDW"].ToString();
                        vd.BranchWatcher = r["FZZBY"].ToString();
                        vd.DispatchTime = r["FZDDSJ"].ToString();
                        vd.FeedbackTime = r["FZFKSJ"].ToString();
                        vd.CenterWatcher = r["ZXZBY"].ToString();
                        list.Add(vd);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }

                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 病历填写项目数据
        /// </summary>
        /// <returns></returns>
        public List<Web_MedicalProject> GetWeb_MedicalProjectData()
        {
            try
            {
                List<Web_MedicalProject> list = new List<Web_MedicalProject>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetWeb_MedicalProjectStr());
                foreach (DataRow r in dt.Rows)
                {
                    Web_MedicalProject wmp = new Web_MedicalProject();
                    wmp.CommandID = "Web_MedicalProject";
                    wmp.ID = r["ID"].ToString();
                    wmp.NAME = r["NAME"].ToString();
                    wmp.TYPE = r["TYPE"].ToString();
                    wmp.STATISTICS = r["STATISTICS"].ToString();
                    wmp.CANCELLATION = r["CANCELLATION"].ToString();
                    wmp.CODENAME = r["CODENAME"].ToString();
                    list.Add(wmp);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 病历填写项目值数据
        /// </summary>
        /// <returns></returns>
        public List<Web_MedicalProjectValue> GetWeb_MedicalProjectValueData()
        {
            try
            {
                List<Web_MedicalProjectValue> list = new List<Web_MedicalProjectValue>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetWeb_MedicalProjectValueStr());
                foreach (DataRow r in dt.Rows)
                {
                    Web_MedicalProjectValue item = new Web_MedicalProjectValue();
                    item.CommandID = "Web_MedicalProjectValue";
                    item.ID = r["ID"].ToString();
                    item.MEDICALPROJECTID = r["MEDICALPROJECTID"].ToString();
                    item.NAME = r["NAME"].ToString();
                    item.CANCELLATION = r["CANCELLATION"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 病历记录数据
        /// </summary>
        /// <returns></returns>
        public List<Web_MedicalRecords> GetWeb_MedicalRecordsData()
        {
            try
            {
                List<Web_MedicalRecords> list = new List<Web_MedicalRecords>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetWeb_MedicalRecordsStr());
                foreach (DataRow r in dt.Rows)
                {
                    Web_MedicalRecords item = new Web_MedicalRecords();
                    item.CommandID = "Web_MedicalRecords";
                    item.JJYXM = r["JJYXM"].ToString();
                    item.SXB = r["SXB"].ToString();
                    item.APGAR = r["APGAR"].ToString();
                    item.TAPGAR = r["TAPGAR"].ToString();
                    item.MEDICALTYPE = r["MEDICALTYPE"].ToString();
                    item.BRGJ = r["BRGJ"].ToString();
                    item.BQSCTP = r["BQSCTP"].ToString();
                    item.ZZLB = r["ZZLB"].ToString();
                    item.ZZ = r["ZZ"].ToString();
                    item.YY1 = r["YY1"].ToString();
                    item.BS = r["BS"].ToString();
                    item.JJCS = r["JJCS"].ToString();
                    item.HZZJ = r["HZZJ"].ToString();
                    item.HZBZ = r["HZBZ"].ToString();
                    item.ID = r["ID"].ToString();
                    item.LSH = r["LSH"].ToString();
                    item.CS = r["CS"].ToString();
                    item.CLBH = r["CLBH"].ToString();
                    item.SSDWMC = r["SSDWMC"].ToString();
                    item.ZBCH = r["ZBCH"].ToString();
                    item.BRXM = r["BRXM"].ToString();
                    item.BRNL = r["BRNL"].ToString();
                    item.BRXB = r["BRXB"].ToString();
                    item.WJDD = r["WJDD"].ToString();
                    item.SWDD = r["SWDD"].ToString();
                    item.BZ = r["BZ"].ToString();
                    item.DJR = r["DJR"].ToString();
                    item.DJRQ = r["DJRQ"].ToString();
                    item.BRID = r["BRID"].ToString();
                    item.XBS = r["XBS"].ToString();
                    item.GQXGS = r["GQXGS"].ToString();
                    item.ZCYZD = r["ZCYZD"].ToString();
                    item.YWGMS = r["YWGMS"].ToString();
                    item.T = r["T"].ToString();
                    item.P = r["P"].ToString();
                    item.BP = r["BP"].ToString();
                    item.ZTK = r["ZTK"].ToString();
                    item.CBYX = r["CBYX"].ToString();
                    item.XT = r["XT"].ToString();
                    item.XYBHD = r["XYBHD"].ToString();
                    item.XDTYX = r["XDTYX"].ToString();
                    item.XDJHYX = r["XDJHYX"].ToString();
                    item.BRMZ = r["BRMZ"].ToString();
                    item.BRZY = r["BRZY"].ToString();
                    item.BRJG = r["BRJG"].ToString();
                    item.BRGZDW = r["BRGZDW"].ToString();
                    item.XG_FLAG = r["XG_FLAG"].ToString();
                    item.XG_YY = r["XG_YY"].ToString();
                    item.XG_SHR = r["XG_SHR"].ToString();
                    item.XG_SJ = r["XG_SJ"].ToString();
                    item.FLAG = r["FLAG"].ToString();
                    item.R = r["R"].ToString();
                    item.ZBY = r["ZBY"].ToString();
                    item.HJDH = r["HJDH"].ToString();
                    item.WJDD_TJ = r["WJDD_TJ"].ToString();
                    item.SWDD_TJ = r["SWDD_TJ"].ToString();
                    item.HYZK = r["HYZK"].ToString();
                    item.HR = r["HR"].ToString();
                    item.YTK = r["YTK"].ToString();
                    item.QT = r["QT"].ToString();
                    item.GCS = r["GCS"].ToString();
                    item.TI = r["TI"].ToString();
                    item.ZDS = r["ZDS"].ToString();
                    item.RZY = r["RZY"].ToString();
                    item.RFBYL = r["RFBYL"].ToString();
                    item.QTJC = r["QTJC"].ToString();
                    item.SWZMBH = r["SWZMBH"].ToString();
                    item.XDTYXFJ = r["XDTYXFJ"].ToString();
                    item.XDJHYXFJ = r["XDJHYXFJ"].ToString();
                    item.TIMPLATENAME = r["TIMPLATENAME"].ToString();
                    item.TIMPLATEFLAG = r["TIMPLATEFLAG"].ToString();
                    item.JZYS = r["JZYS"].ToString();
                    item.TGCS = r["TGCS"].ToString();
                    item.TTI = r["TTI"].ToString();
                    item.TIMPLATEPY = r["TIMPLATEPY"].ToString();
                    item.TIMPLATEPARENTID = r["TIMPLATEPARENTID"].ToString();
                    item.READER = r["READER"].ToString();

                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 病历填写项目与值对应数据
        /// </summary>
        /// <returns></returns>
        public List<Web_MedicalStatistics> GetWeb_MedicalStatisticsData()
        {
            try
            {
                List<Web_MedicalStatistics> list = new List<Web_MedicalStatistics>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetWeb_MedicalStatisticsStr());
                foreach (DataRow r in dt.Rows)
                {
                    Web_MedicalStatistics item = new Web_MedicalStatistics();
                    item.CommandID = "Web_MedicalStatistics";
                    item.ID = r["ID"].ToString();
                    item.CONTROLID = r["CONTROLID"].ToString();
                    item.MEDICALRECORDSID = r["MEDICALRECORDSID"].ToString();
                    item.CONTROLVALUE = r["CONTROLVALUE"].ToString();
                    item.CONTROLPARENTID = r["CONTROLPARENTID"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        /// <returns></returns>
        public List<BLJCXXB> GetBLJCXXBData()
        {
            try
            {
                List<BLJCXXB> list = new List<BLJCXXB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetBLJCXXBStr());
                foreach (DataRow r in dt.Rows)
                {
                    BLJCXXB item = new BLJCXXB();
                    item.CommandID = "BLJCXXB";
                    item.XH = r["XH"].ToString();
                    item.LX = r["LX"].ToString();
                    item.MC = r["MC"].ToString();
                    item.GPS = r["GPS"].ToString();
                    item.BH = r["BH"].ToString();
                    item.YWLX = r["YWLX"].ToString();
                    item.BZ = r["BZ"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        /// <returns></returns>
        public List<HJQYB> GetHJQYBData()
        {
            try
            {
                List<HJQYB> list = new List<HJQYB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetHJQYBStr());
                foreach (DataRow r in dt.Rows)
                {
                    HJQYB item = new HJQYB();
                    item.CommandID = "HJQYB";
                    item.XH = r["XH"].ToString();
                    item.HJQY = r["HJQY"].ToString();
                    item.JD = r["JD"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 来电类型表数据
        /// </summary>
        /// <returns></returns>
        public List<LDLXB> GetLDLXBData()
        {
            try
            {
                List<LDLXB> list = new List<LDLXB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLDLXBStr());
                foreach (DataRow r in dt.Rows)
                {
                    LDLXB item = new LDLXB();
                    item.CommandID = "LDLXB";
                    item.XH = r["XH"].ToString();
                    item.LX = r["LX"].ToString();
                    item.RJ = r["RJ"].ToString();
                    item.PCBZ = r["PCBZ"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        /// <returns></returns>
        public List<ZBYXXB> GetZBYXXBData()
        {

            try
            {
                List<ZBYXXB> list = new List<ZBYXXB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetZBYXXBStr());
                foreach (DataRow r in dt.Rows)
                {
                    ZBYXXB item = new ZBYXXB();
                    item.CommandID = "ZBYXXB";
                    item.ID = r["ID"].ToString();
                    item.XM = r["XM"].ToString();
                    item.MM = r["MM"].ToString();
                    item.BC = r["BC"].ToString();
                    item.XTSF = r["XTSF"].ToString();
                    item.DJRQ = r["DJRQ"].ToString();
                    item.ZXBZ = r["ZXBZ"].ToString();
                    item.ZXRQ = r["ZXRQ"].ToString();
                    item.MS = r["MS"].ToString();
                    item.LXFF = r["LXFF"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 症状表数据
        /// </summary>
        /// <returns></returns>
        public List<ZZB> GetZZBData()
        {
            try
            {

                List<ZZB> list = new List<ZZB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetZZBStr());
                foreach (DataRow r in dt.Rows)
                {
                    ZZB item = new ZZB();
                    item.CommandID = "ZZB";
                    item.XH = r["XH"].ToString();
                    item.ZZ = r["ZZ"].ToString();
                    item.ZZLB = r["ZZLB"].ToString();
                    item.ID = r["ID"].ToString();
                    item.LX = r["LX"].ToString();
                    item.KB = r["KB"].ToString();
                    item.YY = r["YY"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系记录删除表数据
        /// </summary>
        /// <returns></returns>
        public List<LWBLGXTBDELB> GetLWBLGXTBDELBData()
        {
            try
            {

                List<LWBLGXTBDELB> list = new List<LWBLGXTBDELB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLWBLGXTBDELBStr());
                foreach (DataRow r in dt.Rows)
                {
                    LWBLGXTBDELB item = new LWBLGXTBDELB();
                    item.CommandID = "LWBLGXTBDELB";
                    item.ID = r["ID"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历记录删除表数据
        /// </summary>
        /// <returns></returns>
        public List<LWBLTBDELB> GetLWBLTBDELBData()
        {
            try
            {

                List<LWBLTBDELB> list = new List<LWBLTBDELB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLWBLTBDELBStr());
                foreach (DataRow r in dt.Rows)
                {
                    LWBLTBDELB item = new LWBLTBDELB();
                    item.CommandID = "LWBLTBDELB";
                    item.ID = r["ID"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 大型事故表数据
        /// </summary>
        /// <returns></returns>
        public List<DXSGB> GetDXSGBData()
        {
            try
            {
                List<DXSGB> list = new List<DXSGB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetDXSGBStr());
                foreach (DataRow r in dt.Rows)
                {
                    DXSGB item = new DXSGB();
                    item.CommandID = "DXSGB";
                    item.DDXCBZ1 = r["DDXCBZ1"].ToString();
                    item.DDXCBZ2 = r["DDXCBZ2"].ToString();
                    item.DDXCBZ3 = r["DDXCBZ3"].ToString();
                    item.DHHM1 = r["DHHM1"].ToString();
                    item.DHHM2 = r["DHHM2"].ToString();
                    item.DHHM3 = r["DHHM3"].ToString();
                    item.DHHM4 = r["DHHM4"].ToString();
                    item.GYXS = r["GYXS"].ToString();
                    item.JHR1 = r["JHR1"].ToString();
                    item.JHR2 = r["JHR2"].ToString();
                    item.JHR3 = r["JHR3"].ToString();
                    item.JHR4 = r["JHR4"].ToString();
                    item.LSH = r["LSH"].ToString();
                    item.SBBM1 = r["SBBM1"].ToString();
                    item.SBBM2 = r["SBBM2"].ToString();
                    item.SBBM3 = r["SBBM3"].ToString();
                    item.SBBM4 = r["SBBM4"].ToString();
                    item.SBSJ1 = r["SBSJ1"].ToString();
                    item.SBSJ2 = r["SBSJ2"].ToString();
                    item.SBSJ3 = r["SBSJ3"].ToString();
                    item.SBSJ4 = r["SBSJ4"].ToString();
                    //20160727 修改人:朱星汉 修改内容：添加突发事件等级
                    item.SGLV = r["SGLV"].ToString();

                    item.SGLX = r["SGLX"].ToString();
                    item.SGMC = r["SGMC"].ToString();
                    item.SGYY = r["SGYY"].ToString();
                    item.SQCBFL = r["SQCBFL"].ToString();
                    item.SQRS0 = r["SQRS0"].ToString();
                    item.SQRS1 = r["SQRS1"].ToString();
                    item.SQRS10 = r["SQRS10"].ToString();
                    item.SQRS2 = r["SQRS2"].ToString();
                    item.SQRS3 = r["SQRS3"].ToString();
                    item.SQRS4 = r["SQRS4"].ToString();
                    item.SQRS5 = r["SQRS5"].ToString();
                    item.SQRS6 = r["SQRS6"].ToString();
                    item.SQRS7 = r["SQRS7"].ToString();
                    item.SQRS8 = r["SQRS8"].ToString();
                    item.SQRS9 = r["SQRS9"].ToString();
                    item.XCJZ = r["XCJZ"].ToString();
                    item.XCJZ0 = r["XCJZ0"].ToString();
                    item.XCJZ1 = r["XCJZ1"].ToString();
                    item.XJ = r["XJ"].ToString();
                    item.XXSBBZ = r["XXSBBZ"].ToString();
                    item.XXSBZBYID = r["XXSBZBYID"].ToString();
                    item.ZHCDDSJ1 = r["ZHCDDSJ1"].ToString();
                    item.ZHCDDSJ2 = r["ZHCDDSJ2"].ToString();
                    item.ZHCDDSJ3 = r["ZHCDDSJ3"].ToString();
                    item.ZHCDDSJ4 = r["ZHCDDSJ4"].ToString();

                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 联网调度关联表数据
        /// </summary>
        /// <returns></returns>
        public List<LWDDGLB> GetLWDDGLBData()
        {
            try
            {
                List<LWDDGLB> list = new List<LWDDGLB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLWDDGLBStr());
                foreach (DataRow r in dt.Rows)
                {
                    LWDDGLB item = new LWDDGLB();
                    item.CommandID = "LWDDGLB";
                    item.RemoteLSH = r["RemoteLSH"].ToString();
                    item.RemoteDWBH = r["RemoteDWBH"].ToString();
                    item.LocalLSH = r["LocalLSH"].ToString();
                    item.DDLX = r["DDLX"].ToString();
                    item.SGSB = r["SGSB"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 联网车辆同步对应表数据
        /// </summary>
        /// <returns></returns>
        public List<LWCLTBDYB> GetLWCLTBDYBData()
        {
            try
            {
                List<LWCLTBDYB> list = new List<LWCLTBDYB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLWCLTBDYBStr());

                foreach (DataRow r in dt.Rows)
                {
                    LWCLTBDYB item = new LWCLTBDYB();
                    item.CommandID = "LWCLTBDYB";
                    item.LocalLSH = r["LocalLSH"].ToString();
                    item.LocalCS = r["LocalCS"].ToString();
                    item.LocalCLBH = r["LocalCLBH"].ToString();
                    item.TargetLSH = r["TargetLSH"].ToString();
                    item.TargetCS = r["TargetCS"].ToString();
                    item.TargetCLBH = r["TargetCLBH"].ToString();
                    item.TargetDWBH = r["TargetDWBH"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        /// <returns></returns>
        public List<LWBLTBDYB> GetLWBLTBDYBData()
        {
            try
            {
                List<LWBLTBDYB> list = new List<LWBLTBDYB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLWBLTBDYBStr());
                foreach (DataRow r in dt.Rows)
                {
                    LWBLTBDYB item = new LWBLTBDYB();
                    item.CommandID = "LWBLTBDYB";
                    item.LocalLSH = r["LocalLSH"].ToString();
                    item.LocalRecordID = r["LocalRecordID"].ToString();
                    item.TargetLSH = r["TargetLSH"].ToString();
                    item.TargetRecordID = r["TargetRecordID"].ToString();
                    item.TargetDWBH = r["TargetDWBH"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        /// <returns></returns>
        public List<LWBLGXTBDYB> GetLWBLGXTBDYBData()
        {
            try
            {
                List<LWBLGXTBDYB> list = new List<LWBLGXTBDYB>();
                DataTable dt = DB120Help.GetRecord(GetDataSql.GetLWBLGXTBDYBStr());
                foreach (DataRow r in dt.Rows)
                {
                    LWBLGXTBDYB item = new LWBLGXTBDYB();
                    item.CommandID = "LWBLGXTBDYB";
                    item.LocalLSH = r["LocalLSH"].ToString();
                    item.LocalStatisticsID = r["LocalStatisticsID"].ToString();
                    item.TargetLSH = r["TargetLSH"].ToString();
                    item.TargetStatisticsID = r["TargetStatisticsID"].ToString();
                    item.TargetDWBH = r["TargetDWBH"].ToString();
                    list.Add(item);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
