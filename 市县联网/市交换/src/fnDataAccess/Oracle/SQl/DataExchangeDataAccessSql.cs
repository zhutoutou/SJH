using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model;
using System.Collections;
using ZIT.SJHServer.fnDataAccess.Oracle.SQl;
using System.Configuration;
using ZIT.SJHServer.Model.DispatchFunction;
using System.Data.OracleClient;
//using Oracle.DataAccess.Client;

namespace ZIT.SJHServer.fnDataAccess.Oracle
{
    public class DataExchangeDataAccessSql
    {
        private static string ConvertDataTime(string Time)
        {
            string DataTime = "to_date('" + Time + "','yyyy-MM-dd hh24:mi:ss')";
            return DataTime;
        }
        public static string GetDataExchangeDataAccessSql(VehicleStatus Data, string ID, string AreaCode)
        {
            string sql = "insert into dqclztxxb(ZHFXSJ,DXDDSJ,JD,WD,SD,FX,KJXS,GZXS,TXZT,GZZT,XSLC,ID,XZBM)values('" + GetDateTime(Data.StatusChangeTime) + "','" + GetDateTime(Data.StatusChangeTime) + "'," +
                "'" + Data.Longitude + "','" + Data.Latitude + "','" + Data.Speed + "','" + Data.Direction + "','" + Data.VisibleStar + "','" + Data.TrackStar + "','" + Data.AntennaStatus + "','" + Data.WorkStatus + "','" + Data.SteerMileage + "','" + AreaCode + "','" + ID + "')";
            return sql;
        }
        /// <summary>
        /// 车辆基础数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string GetDataExchangeDataAccessSql(VehicleData Data, string AreaCode)
        {

            string sql = "insert into clxxb(CLBH,ID,CPH,CZDH,FDJHM,MC,CLLX,SSDW,GZSJ,SYSJ,ZXBZ,BZ,XZBM)values" +
                         "('" + Data.VehicleCode + "','" + Data.VehicleID + "','" + Data.CarNumber + "','" + Data.Mobile + "','" + Data.EngineNumber + "','" + Data.VehicleName + "'" +
                         ",'" + Data.VehicleType + "' ,'" + Data.UnitName + "'," + ConvertDataTime(Data.PurchaseDate) + "," + ConvertDataTime(Data.UseDate) + ",'" + Data.Cancel + "','" + Data.Remark + "','" + AreaCode + "')";
            return sql;
        }
        /// <summary>
        /// 车辆基础数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static ArrayList GetGpsVehicleDataAccessSql(VehicleData Data, string ID)
        {
            ArrayList List = new ArrayList();
            string sql = "insert into clzlb(ID,CPZ,CZDH,CLLX,SSDW,CLBH,CLMC,YWLX)values('" + ID + "','" + Data.CarNumber + "','" + Data.Mobile + "','" + Data.VehicleType + "','" + Data.UnitName + "','" + Data.VehicleCode + "','" + Data.VehicleName + "','120')";
            List.Add(sql);
            sql = "insert into dqclztxxb(ID)values('" + ID + "')";
            List.Add(sql);
            return List;
        }
        /// <summary>
        /// 更新120库车辆信息表（2合一模式120库与GPS为一个数据库）
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static ArrayList GetBSSVehicleDataAccessSql(VehicleData Data, string ID)
        {
            ArrayList List = new ArrayList();
            string sql = "insert into clxxb(ID,CPH,CZDH,CLLX,SSDW,CLBH,MC,YWLX,GPS)values('" + ID + "','" + Data.CarNumber + "','" + Data.Mobile + "','" + Data.VehicleType + "','" + Data.UnitName + "','" + Data.VehicleCode + "','" + Data.VehicleName + "','120','是')";
            List.Add(sql);
            sql = "insert into dqclztxxb(ID)values('" + ID + "')";
            List.Add(sql);
            return List;
        }
        /// <summary>
        /// 系统人员数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static ParameterSql GetDataExchangeDataAccessSql(SysUserData Data, string XZBM)
        {
            ParameterSql sqlpar = new ParameterSql();
            //20151210 修改人:朱星汉 修改内容:添加系统人员密码
            sqlpar.StrSql = "insert into XTRYB(RYBH,XM,XB,SFZHM,SSDW,ZW,ZN,JSZC,XL,BYXX,ZY,YGXS,BGDH,LXFS,JTDH,CSSJ,BYSJ,CJGZSJ,RZRQ,DJRQ,ZXRQ,ZXBZ,BZ,XZBM,MM)values(:RYBH,:XM,:XB,:SFZHM,:SSDW,:ZW,:ZN,:JSZC,:XL,:BYXX,:ZY,:YGXS,:BGDH,:LXFS,:JTDH,:CSSJ,:BYSJ,:CJGZSJ,:RZRQ,:DJRQ,:ZXRQ,:ZXBZ,:BZ,:XZBM,:MM)";
            OracleParameter[] par ={new OracleParameter(":RYBH",GetString(Data.UserName)),
                                    new OracleParameter(":XM",GetString(Data.Name)),
                                    new OracleParameter(":XB",GetString(Data.Sex)),
                                    new OracleParameter(":SFZHM",GetString(Data.CertificateNumber)),
                                    new OracleParameter(":SSDW",GetString(Data.OwnUnit)),
                                    new OracleParameter(":ZW",GetString(Data.Headship)),
                                    new OracleParameter(":ZN",GetString(Data.Function)),
                                    new OracleParameter(":JSZC",GetString(Data.TechnicalPost)),
                                    new OracleParameter(":XL",GetString(Data.Education)),
                                    new OracleParameter(":BYXX",GetString(Data.GraduationSchool)),
                                    new OracleParameter(":ZY",GetString(Data.Profession)),
                                    new OracleParameter(":YGXS",GetString(Data.WorkForm)),
                                    new OracleParameter(":BGDH",GetString(Data.OfficeTelephone)),
                                    new OracleParameter(":LXFS",GetString(Data.Mobile)),
                                    new OracleParameter(":JTDH",GetString(Data.FamilyTelephone)),
                                    new OracleParameter(":CSSJ", GetDateTime(Data.BirthDay)),
                                    new OracleParameter(":BYSJ",GetDateTime(Data.GraduationDate)),
                                    new OracleParameter(":CJGZSJ",""),
                                    new OracleParameter(":RZRQ",""),
                                    new OracleParameter(":DJRQ",GetDateTime(Data.RegisterDate)),
                                    new OracleParameter(":ZXRQ",""),
                                    new OracleParameter(":ZXBZ",GetString(Data.Cancel)),
                                    new OracleParameter(":BZ",GetString(Data.Remark)),
                                    new OracleParameter(":XZBM",GetString(XZBM)), 
                                    new OracleParameter(":MM",GetString(Data.Password)), 
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;

        }
        /// <summary>
        /// 急救人员及急救车辆关系
        /// </summary>
        public static ArrayList GetDataExchangeDataAccessSql(PVRelation Data, string VehicleNo, string XZBM)
        {
            ArrayList List = new ArrayList();
            try
            {
                DataExchangeDataAccessSelectSql selSql = new DataExchangeDataAccessSelectSql();
                string DriverID = Data.Driver;
                if (!string.IsNullOrEmpty(DriverID))
                {
                    string sql;
                    string Number = selSql.GetNumber();
                    if (Data.Flag == "1")
                    {
                        //20151130 修改人:朱星汉 修改内容:成都版本没有rybh
                        //sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,RYBH,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + DriverID + "'),(select ZN from XTRYB where RYBH='" + DriverID + "')," + ConvertDataTime(Data.OnOffDutyTime) + ",'" + DriverID + "','" + XZBM + "')";
                        sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + DriverID + "'),(select ZN from XTRYB where RYBH='" + DriverID + "')," + ConvertDataTime(Data.OnOffDutyTime) + ",'" + XZBM + "')";
                    }
                    else
                    {
                        string data = DateTime.Now.ToString("yyyyMMdd");
                        //跟新下班时间
                        sql = "update rykqb set xbsj=" + ConvertDataTime(Data.OnOffDutyTime) + " , XZBM='" + XZBM + "' where xh=(select xh from rykqb where sbsj=(select max(sbsj) from  rykqb where clbh='" + VehicleNo + "' and xm=(select XM from XTRYB where RYBH='" + DriverID + "') and substr(xh,0,8)=" + data + "  and xbsj is null) and  xm=(select XM from XTRYB where RYBH='" + DriverID + "'))";

                    }
                    List.Add(sql);
                }
                string DoctorID = Data.Doctor;
                if (!string.IsNullOrEmpty(DoctorID))
                {
                    string[] Doctors = DoctorID.Split('|');
                    for (int i = 0; i < Doctors.Length; i++)
                    {
                        string sql;
                        string Number = selSql.GetNumber();
                        if (Data.Flag == "1")
                        {
                            //20151130 修改人:朱星汉 修改内容:成都版本没有rybh
                            //sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,RYBH,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + Doctors[i] + "'),(select ZN from XTRYB where RYBH='" + Doctors[i] + "')," + ConvertDataTime(Data.OnOffDutyTime) + ",'" + Doctors[i] + "','" + XZBM + "')";
                            sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + Doctors[i] + "'),(select ZN from XTRYB where RYBH='" + Doctors[i] + "')," + ConvertDataTime(Data.OnOffDutyTime) +  ",'" + XZBM + "')";
                        }
                        else
                        {
                            //跟新下班时间
                            string data = DateTime.Now.ToString("yyyyMMdd");

                            sql = "update rykqb set xbsj=" + ConvertDataTime(Data.OnOffDutyTime) + ",'" + XZBM + "' where xh=(select xh from rykqb where sbsj=(select max(sbsj) from  rykqb where clbh='" + VehicleNo + "' and xm=(select XM from XTRYB where RYBH='" + Doctors[i] + "') and substr(xh,0,8)=" + data + "  and xbsj is null and " + ConvertDataTime(Data.OnOffDutyTime) + " >sbsj) and xm=(select XM from XTRYB where RYBH='" + Doctors[i] + "'))";
                        }
                        List.Add(sql);
                    }

                }
                string NurseID = Data.Nurse;
                if (!string.IsNullOrEmpty(NurseID))
                {
                    string[] Nurses = NurseID.Split('|');
                    for (int i = 0; i < Nurses.Length; i++)
                    {
                        string sql;

                        string Number = selSql.GetNumber();
                        if (Data.Flag == "1")
                        {
                            //20151130 修改人:朱星汉 修改内容:成都版本没有rybh
                            //sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,RYBH,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + Nurses[i] + "'),(select ZN from XTRYB where RYBH='" + Nurses[i] + "')," + ConvertDataTime(Data.OnOffDutyTime) + ",'" + Nurses[i] + "','" + XZBM + "')";
                            sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + Nurses[i] + "'),(select ZN from XTRYB where RYBH='" + Nurses[i] + "')," + ConvertDataTime(Data.OnOffDutyTime) + ",'"  + XZBM + "')";

                        }
                        else
                        {
                            //跟新下班时间
                            string data = DateTime.Now.ToString("yyyyMMdd");
                            sql = "update rykqb set xbsj=" + ConvertDataTime(Data.OnOffDutyTime) + ",XZBM='" + XZBM + "' where xh=(select xh from rykqb where sbsj=(select max(sbsj) from  rykqb where clbh='" + VehicleNo + "' and xm=(select XM from XTRYB where RYBH='" + Nurses[i] + "') and substr(xh,0,8)=" + data + "  and xbsj is null)  and xm=(select XM from XTRYB where RYBH='" + Nurses[i] + "'))";
                        }
                        List.Add(sql);
                    }

                }
                string StretcherPersonID = Data.StretcherPerson;
                if (!string.IsNullOrEmpty(StretcherPersonID))
                {
                    string[] StretcherPersons = StretcherPersonID.Split('|');
                    for (int i = 0; i < StretcherPersons.Length; i++)
                    {
                        string sql;

                        string Number = selSql.GetNumber();
                        if (Data.Flag == "1")
                        {
                            //20151130 修改人:朱星汉 修改内容:成都版本没有rybh
                            //sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,RYBH,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + StretcherPersons[i] + "'),(select ZN from XTRYB where RYBH='" + StretcherPersons[i] + "')," + ConvertDataTime(Data.OnOffDutyTime) + ",'" + StretcherPersons[i] + "','" + XZBM + "')";
                            sql = "insert into RYKQB(XH,CLBH,XM,ZN,SBSJ,RYBH,XZBM)values('" + Number + "','" + VehicleNo + "',(select XM from XTRYB where RYBH='" + StretcherPersons[i] + "'),(select ZN from XTRYB where RYBH='" + StretcherPersons[i] + "')," + ConvertDataTime(Data.OnOffDutyTime) + ",'" + XZBM + "')";
                        }
                        else
                        {
                            //跟新下班时间
                            string data = DateTime.Now.ToString("yyyyMMdd");
                            sql = "update rykqb set xbsj=" + ConvertDataTime(Data.OnOffDutyTime) + " ,XZBM='" + XZBM + "'  where xh=(select xh from rykqb where sbsj=(select max(sbsj) from  rykqb where clbh='" + VehicleNo + "' and xm=(select XM from XTRYB where RYBH='" + StretcherPersons[i] + "') and substr(xh,0,8)=" + data + "  and xbsj is null) xm=(select XM from XTRYB where RYBH='" + StretcherPersons[i] + "'))";
                        }
                        List.Add(sql);
                    }

                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("PVRelation", ex);
            }
            return List;
        }
        /// <summary>
        /// 受理信息数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(DealData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into SLJLB(LSH,XXLY,SLTH,ZBY,ZBBC,SLSJ,ZJHM,HZ,HJDZ,HJQY,LDLX,HJR,HCZLX,LXDH,HZXM,HZXB,HZNL,HZGJ,HZSF,GMYW,HZZZ,HZBS,JCDZ,SWDD,CZFS,HCBZ,HCYY,GJSJ,SLSC,DDKSSJ,DDJSSJ,DDSC,HJDZ_X,HJDZ_Y,JCDZ_X,JCDZ_Y,HJLX,SGLX,SGYY,SGMC,SLZT,PCYZ,KJLM,SJGLLSH,GXJD,GXYY,FBDD,TSAJBZ,SBBZ,XZBM,HZRS)values"
                + "(:LSH,:XXLY,:SLTH,:ZBY,:ZBBC,:SLSJ,:ZJHM,:HZ,:HJDZ,:HJQY,:LDLX,:HJR,:HCZLX,:LXDH,:HZXM,:HZXB,:HZNL,:HZGJ,:HZSF,:GMYW,:HZZZ,:HZBS,:JCDZ,:SWDD,:CZFS,:HCBZ,:HCYY,:GJSJ,:SLSC,:DDKSSJ,:DDJSSJ,:DDSC,:HJDZ_X,:HJDZ_Y,:JCDZ_X,:JCDZ_Y,:HJLX,:SGLX,:SGYY,:SGMC,:SLZT,:PCYZ,:KJLM,:SJGLLSH,:GXJD,:GXYY,:FBDD,:TSAJBZ,:SBBZ,:XZBM,:HZRS)";
            //
            OracleParameter[] par ={new OracleParameter(":LSH",GetString(Data.DealRecordID)),
                                    new OracleParameter(":XXLY",GetString(Data.InfoSource)),
                                    new OracleParameter(":SLTH",GetString(Data.AgentNo)),
                                    new OracleParameter(":ZBY",GetString(Data.WatcherName)),
                                    new OracleParameter(":ZBBC",GetString(Data.WatchShiftGroup)),
                                    new OracleParameter(":SLSJ",GetDateTime(Data.DealTime)),
                                    new OracleParameter(":ZJHM",GetString(Data.CallNumber)),
                                    new OracleParameter(":HZ",GetString(Data.HostName)),
                                    new OracleParameter(":HJDZ",GetString(Data.CallAddress)),
                                    new OracleParameter(":HJQY",GetString(Data.CallArea)),
                                    new OracleParameter(":LDLX",GetString(Data.CallType)),
                                    new OracleParameter(":HJR",GetString(Data.CallerName)),
                                    new OracleParameter(":HCZLX",GetString(Data.CallerType)),
                                    new OracleParameter(":LXDH",GetString(Data.ContactTelphone)),
                                    new OracleParameter(":HZXM",GetString(Data.SuffererName)),
                                    new OracleParameter(":HZXB",GetString(Data.SuffererSex)),
                                    new OracleParameter(":HZNL",GetString(Data.SuffererAge)),
                                    new OracleParameter(":HZGJ",GetString(Data.Nationality)),
                                    new OracleParameter(":HZSF",GetString(Data.Standing)),
                                    new OracleParameter(":GMYW",GetString(Data.AnaphylacticMedication)),
                                    new OracleParameter(":HZZZ",GetString(Data.Symptom)),
                                    new OracleParameter(":HZBS",GetString(Data.SuffererMedicalRecord)),
                                    new OracleParameter(":JCDZ",GetString(Data.MeetAddress)),
                                    new OracleParameter(":SWDD",GetString(Data.SendArriveAddress)),
                                    new OracleParameter(":CZFS",GetString(Data.TreatmentMode)),
                                    new OracleParameter(":HCBZ",GetString(Data.RejectFlag)),
                                    new OracleParameter(":HCYY",GetString(Data.RejectReason)),
                                    new OracleParameter(":GJSJ", GetDateTime(Data.HangupTime)),
                                    new OracleParameter(":SLSC",GetNumber(Data.DealTimeSpan)),
                                    new OracleParameter(":DDKSSJ", GetDateTime(Data.AttemperBeginTime)),                
                                    new OracleParameter(":DDJSSJ",GetDateTime(Data.AttemperEndTime)),
                                    new OracleParameter(":DDSC",GetNumber(Data.AttemperTimeSpan)),
                                    new OracleParameter(":HJDZ_X",GetString(Data.CallAddressX)),
                                    new OracleParameter(":HJDZ_Y",GetString(Data.CallAddressY)),
                                    new OracleParameter(":JCDZ_X",GetString(Data.MeetAddressX)),
                                    new OracleParameter(":JCDZ_Y",GetString(Data.MeetAddressY)),
                                    new OracleParameter(":HJLX",GetString(Data.CallHelpType)),
                                    new OracleParameter(":SGLX",GetString(Data.SlipType)),
                                    new OracleParameter(":SGYY",GetString(Data.SlipReason)),
                                    new OracleParameter(":SGMC",GetString(Data.SlipName)),
                                    new OracleParameter(":SLZT",GetString(Data.DealStatus)),
                                    new OracleParameter(":PCYZ",GetString(Data.DispatchVehiclePrinciple)),
                                    new OracleParameter(":KJLM",GetString(Data.AnearRoadName)),
                                    new OracleParameter(":SJGLLSH",GetString(Data.RelateDealRecordID)),
                                    new OracleParameter(":GXJD",GetString(Data.DominationStreet)),

                                    new OracleParameter(":GXYY",GetString(Data.DominationHospital)),
                                    new OracleParameter(":FBDD",GetString(Data.HappenAddress)),
                                    new OracleParameter(":TSAJBZ",GetString(Data.SpecialCaseFalg)),
                                    new OracleParameter(":SBBZ",GetString(Data.ReportFalg)),
                                    new OracleParameter(":XZBM",GetString(AreaCode)),
                                    new OracleParameter(":HZRS",GetString(Data.AffectNumber)),
                             };
            sqlpar.OrclPar = par;
            return sqlpar;

        }
        /// <summary>
        /// 出车信息数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(DispatchVehicleData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            //20151210 修改人:朱星汉 修改内容:添加车辆信息状态字段
            sqlpar.StrSql = "insert into CCXXB(LSH,CLBH,CS,CCLX,SJ,SCYS,SCHS,SCDJG,PCSJ,CCDD,CCSJ,DDXCSJ,SCSJ,DDSJ,WCSJ,FZSJ,CCYS,LTYS,XCYS,ZTYS,ZHS,XSLC,TSSJ,TSYY,TSSJSJ,CLID,SDXXSJ,SWYY,XZBM,ZT,CCCC)values(:LSH,:CLBH,:CS,:CCLX,:SJ,:SCYS,:SCHS,:SCDJG,:PCSJ,:CCDD,:CCSJ,:DDXCSJ,:SCSJ,:DDSJ,:WCSJ,:FZSJ,:CCYS,:LTYS,:XCYS,:ZTYS,:ZHS,:XSLC,:TSSJ,:TSYY,:TSSJSJ,:CLID,:SDXXSJ,:SWYY,:XZBM,:ZT,:CCCC)";
            OracleParameter[] par ={new OracleParameter(":LSH",GetString(Data.DealRecordID)),
                                    new OracleParameter(":CLBH",GetString(Data.VehicleCode)),
                                    new OracleParameter(":CS",GetString(Data.Times)),
                                    new OracleParameter(":CCLX",GetString(Data.DispatchVehicleType)),
                                    new OracleParameter(":SJ",GetString(Data.Driver)),
                                    new OracleParameter(":SCYS",GetString(Data.Doctor)),
                                    new OracleParameter(":SCHS",GetString(Data.Nurse)),
                                    new OracleParameter(":SCDJG",GetString(Data.StretcherPerson)),
                                    new OracleParameter(":PCSJ",GetDateTime(Data.DispatchVehicleTime)),
                                    new OracleParameter(":CCDD",GetString(Data.StartoffAddress)),
                                    new OracleParameter(":CCSJ",GetDateTime(Data.StartoffTime)),
                                    new OracleParameter(":DDXCSJ",GetDateTime(Data.ArriveSceneTime)),
                                    new OracleParameter(":SCSJ",GetDateTime(Data.GetInVehicleTime)),
                                    new OracleParameter(":DDSJ",GetDateTime(Data.ArriveDestinationTime)),
                                    new OracleParameter(":WCSJ", GetDateTime(Data.FinishTaskTime)),       
                                    new OracleParameter(":FZSJ",GetDateTime(Data.ReturnParkTime)),
                                    new OracleParameter(":CCYS", GetNumber(Data.StartoffUseTime)),
                                    new OracleParameter(":LTYS",GetNumber(Data.ArriveSceneUseTime)),
                                    new OracleParameter(":XCYS", GetNumber(Data.SceneUseTime)),
                                    new OracleParameter(":ZTYS",GetNumber(Data.AarriveDestinationUseTime)),
                                    new OracleParameter(":ZHS",GetNumber(Data.TotalUseTime)),
                                    new OracleParameter(":XSLC",GetNumber(Data.SteerMileage)),
                                    new OracleParameter(":TSSJ",GetString(Data.SpecialEvent)),
                                    new OracleParameter(":TSYY",GetString(Data.SpecialReason)),
                                    new OracleParameter(":TSSJSJ",GetDateTime(Data.SpecialEventTime)),
                                    new OracleParameter(":CLID",GetString(Data.VehicleID)),
                                    new OracleParameter(":SDXXSJ",GetDateTime(Data.ReceiveTaskTime)),
                                    new OracleParameter(":SWYY",GetString(Data.AcceptHospital)),
                                    new OracleParameter(":XZBM",AreaCode),
                                    new OracleParameter(":ZT",GetString(Data.VehicleZT)),
                                    //20160106 修改人:朱星汉 修改内容:添加出车车次(CCCC)字段
                                    new OracleParameter(":CCCC",GetString(Data.VehicleCCCC)),
                             };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 患者信息数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(SuffererData Data, string VehicleNo, string XZBM)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into HZXXB(LSH,CLBH,XH,XM,XB,NL,GJ,ZY,DHHM,SWDD,CBZD,SSCD,XCQJ,YXQJ,JZJG,XCDD,XZBM)values(:LSH,:CLBH,:XH,:XM,:XB,:NL,:GJ,:ZY,:DHHM,:SWDD,:CBZD,:SSCD,:XCQJ,:YXQJ,:JZJG,:XCDD,:XZBM)";
            OracleParameter[] par ={new OracleParameter(":LSH",GetString(Data.DealRecordID)),
                                    new OracleParameter(":CLBH",GetString(VehicleNo)),
                                    new OracleParameter(":XH",GetString(Data.SuffererNo)),
                                    new OracleParameter(":XM",GetString(Data.SuffererName)),
                                    new OracleParameter(":XB",GetString(Data.SuffererSex)),
                                    new OracleParameter(":NL",GetString(Data.SuffererAge)),
                                    new OracleParameter(":GJ",GetString(Data.Nationality)),
                                    new OracleParameter(":ZY",GetString(Data.Profession)),
                                    new OracleParameter(":DHHM",GetString(Data.Telephone)),
                                    new OracleParameter(":SWDD",GetString(Data.Hospital)),
                                    //new OracleParameter(":HZZZ",Data.Symptom),
                                    new OracleParameter(":CBZD", GetString(Data.FirstDiag)),
                                    new OracleParameter(":SSCD",GetString(Data.InjuredDegree)),
                                    new OracleParameter(":XCQJ",GetString(Data.LocaleSalvage)),
                                    new OracleParameter(":YXQJ",GetString(Data.ValidSalvage)),
                                    new OracleParameter(":JZJG",GetString(Data.CureResult)),
                                    new OracleParameter(":XCDD",GetString(Data.LocalePlace)),
                                    new OracleParameter(":XZBM",GetString(XZBM)),
                             };
            sqlpar.OrclPar = par;
            return sqlpar;

        }
        /// <summary>
        /// 患者病例信息
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(SuffererCaseHistoryData Data, string VehicleNo, string XZBM)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into HZBLB(LSH,CLBH,XH,BQ,BS,XY,MB,HX,XL,TW,TK,DGFS,YBQK,SHZ,PF,XZ,FB,FUB,SZ,TJB,SJXT,JJXG,QT,XZBM)values(:LSH,:CLBH,:XH,:BQ,:BS,:XY,:MB,:HX,:XL,:TW,:TK,:DGFS,:YBQK,:SHZ,:PF,:XZ,:FB,:FUB,:SZ,:TJB,:SJXT,:JJXG,:QT,:XZBM)";
            OracleParameter[] par ={new OracleParameter(":LSH",GetString(Data.DealRecordID)),
                                    new OracleParameter(":CLBH",GetString(VehicleNo)),
                                    new OracleParameter(":XH",GetString(Data.SuffererNo)),
                                    new OracleParameter(":BQ",GetString(Data.IllnessState)),
                                    new OracleParameter(":BS",GetString(Data.IllnessHistory)),
                                    new OracleParameter(":XY",GetString(Data.BloodPressure)),
                                    new OracleParameter(":MB",GetString(Data.Pulse)),
                                    new OracleParameter(":HX",GetString(Data.Breath)),
                                    new OracleParameter(":XL",GetString(Data.HeartRate)),
                                    new OracleParameter(":TW",GetString(Data.AnimalHeat)),
                                    new OracleParameter(":TK",GetString(Data.Pupil)),
                                    new OracleParameter(":DGFS", GetString(Data.LightEcho)),
                                    new OracleParameter(":YBQK",GetString(Data.CommonlyCircs)),
                                    new OracleParameter(":SHZ",GetString(Data.Mind)),
                                    new OracleParameter(":PF",GetString(Data.Skin)),
                                    new OracleParameter(":XZ",GetString(Data.Heart)),
                                    new OracleParameter(":FB",GetString(Data.Lung)),
                                    new OracleParameter(":FUB", GetString(Data.Abdomen)),
                                    new OracleParameter(":SZ",GetString(Data.Extremity)),
                                    new OracleParameter(":TJB",GetString(Data.HeadNeck)),
                                    new OracleParameter(":SJXT",GetString(Data.Neural)),
                                    new OracleParameter(":JJXG",GetString(Data.FirstAidPurpose)),
                                    new OracleParameter(":QT",GetString(Data.Other)),
                                     new OracleParameter(":XZBM",GetString(XZBM)) 
                             };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 呼叫记录数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(CallRcordData Data, string AreaCode)
        {

            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into hjjlb(LSH,ZJHM,ZJLX,HJZT,LDSJ,SLSJ,DDSC,GJSJ,SLSC,DDKSSJ,DDJSSJ,DDUSC,SLTH,XXLY,XZBM)values(:LSH,:ZJHM,:ZJLX,:HJZT,:LDSJ,:SLSJ,:DDSC,:GJSJ,:SLSC,:DDKSSJ,:DDJSSJ,:DDUSC,:SLTH,:XXLY,:XZBM)";
            OracleParameter[] par ={new OracleParameter(":LSH",GetString(Data.CallID)),
                                    new OracleParameter(":ZJHM",GetString(Data.CallNumber)),
                                    new OracleParameter(":ZJLX",GetString(Data.CallType)),
                                    new OracleParameter(":HJZT",GetString(Data.DealType)),
                                    new OracleParameter(":LDSJ",GetDateTime(Data.CallTime)),
                                    new OracleParameter(":SLSJ", GetDateTime(Data.RespTime)),
                                    new OracleParameter(":DDSC",GetNumber(Data.WaitTime)),
                                    new OracleParameter(":GJSJ",GetDateTime(Data.HangupTime)),
                                    new OracleParameter(":SLSC", GetNumber(Data.TalkTime)),
                                    new OracleParameter(":DDKSSJ",GetDateTime(Data.AttempeTime)),
                                    new OracleParameter(":DDJSSJ",GetDateTime(Data.AttempeEndTime)),
                                    new OracleParameter(":DDUSC",GetNumber(Data.AttempeTime)),
                                    new OracleParameter(":SLTH",GetString(Data.AgentID)),
                                    new OracleParameter(":XXLY",GetString(Data.InfoSurce)),
                                    new OracleParameter(":XZBM",GetString(AreaCode)),
                             };
            sqlpar.OrclPar = par;
            
            return sqlpar;
        }
        /// <summary>
        /// 单位信息上报
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(UnitInfoData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into DWXXB(DWBH,XH,DWMC,PY,DWLX,SJDW,LX,XZBM,FZHM)values(:DWBH,:XH,:DWMC,:PY,:DWLX,:SJDW,:LX,:XZBM,:FZHM)";
            OracleParameter[] par ={    new OracleParameter(":DWBH",Data.UnitCode),
                                        new OracleParameter(":XH",Data.SequenceNO),
                                        new OracleParameter(":DWMC",Data.UnitName),
                                        new OracleParameter(":PY",Data.Spelling),
                                        new OracleParameter(":DWLX",Data.UnitTypeID),
                                        new OracleParameter(":SJDW",Data.SuperiorUnitName),
                                        //new OracleParameter(":SSQY",Data.CenterWatcher),
                                        new OracleParameter(":LX",Data.StationType),
                                        new OracleParameter(":XZBM",AreaCode),
                                        new OracleParameter(":FZHM",""),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// GPS单位信息
        /// </summary>
        public static string GetGpsUnitInfoDataAccessSql(UnitInfoData Data)
        {

            string sql = "insert into dwxxb(dwbh,dwmc,lwtype)values('" + Data.UnitCode + "','" + Data.UnitName + "',0)";
            return sql;
        }
        /// <summary>
        /// 跟新BSS库单位信息表（二合一 BSS库与GPS库为一个库）
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string GetBSSUnitInfoDataAccessSql(UnitInfoData Data)
        {

            string sql = "insert into dwxxb(DWBH,XH,DWMC,PY,DWLX,SJDW,LX,FZHM)values('" + Data.UnitCode + "','" + Data.SequenceNO + "','" + Data.UnitName + "','" + Data.Spelling + "','" + Data.UnitTypeID + "','" + Data.SuperiorUnitName + "','" + Data.StationType + "','" + Data.Telephone + "')";
            return sql;
        }
        /// <summary>
        /// 大型事故数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(LargeSlipData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into DXSGB(LSH,SGMC,SGLX,SBBM1,DHHM1,JHR1,SBSJ1,ZHCDDSJ1,SBBM2,DHHM2,JHR2,SBSJ2,ZHCDDSJ2,SBBM3,DHHM3,JHR3,SBSJ3,ZHCDDSJ3,XJ,XZBM)values(:LSH,:SGMC,:SGLX,:SBBM1,:DHHM1,:JHR1,:SBSJ1,:ZHCDDSJ1,:SBBM2,:DHHM2,:JHR2,:SBSJ2,:ZHCDDSJ2,:SBBM3,:DHHM3,:JHR3,:SBSJ3,:ZHCDDSJ3,:XJ,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":LSH",GetString(Data.ID)),

      
                                        new OracleParameter(":SGMC",GetString(Data.SlipName)),
                                        new OracleParameter(":SGLX",GetString(Data.SlipType)),
                                        new OracleParameter(":SBBM1",GetString(Data.ReportDepartment1)),
                                        new OracleParameter(":DHHM1",GetString(Data.Telephone1)),
                                        new OracleParameter(":JHR1",GetString(Data.CalledPerson1)),
                                        new OracleParameter(":SBSJ1",GetDateTime(Data.ReportTime1)),
                                        new OracleParameter(":ZHCDDSJ1",GetDateTime(Data.ArriveTime1)),
                                        new OracleParameter(":SBBM2",GetString(Data.ReportDepartment2 )),
                                        new OracleParameter(":DHHM2",GetString(Data.Telephone2)),
                                        new OracleParameter(":JHR2",GetString(Data.CalledPerson2)),
                                        new OracleParameter(":SBSJ2",GetDateTime(Data.ReportTime2)),
                                        new OracleParameter(":ZHCDDSJ2",GetDateTime(Data.ArriveTime2)),
                                        new OracleParameter(":SBBM3",GetString(Data.ReportDepartment3)),
                                        new OracleParameter(":DHHM3",GetString(Data.Telephone3)),
                                        new OracleParameter(":JHR3",GetString(Data.CalledPerson3)),
                                        new OracleParameter(":SBSJ3",GetDateTime(Data.ReportTime3)),
                                        new OracleParameter(":ZHCDDSJ3",GetDateTime(Data.ArriveTime3)),
                                        new OracleParameter(":XJ",GetString(Data.Remark)),
                                        new OracleParameter(":XZBM",AreaCode),
                                         
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 分站记录信息数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(DispatchStationInfoData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into DDFZJLB(LSH,CCDW,FZZBY,FZDDSJ,FZFKSJ,ZXZBY,XZBM)values(:LSH,:CCDW,:FZZBY,:FZDDSJ,:FZFKSJ,:ZXZBY,:XZBM)";
            OracleParameter[] par ={    new OracleParameter(":LSH",Data.ID),
                                        new OracleParameter(":CCDW",Data.DispatchVehicleUnit),
                                        new OracleParameter(":FZZBY",Data.BranchWatcher ),
                                        new OracleParameter(":FZDDSJ",GetDateTime(Data.DispatchTime)),
                                        new OracleParameter(":FZFKSJ",GetDateTime(Data.FeedbackTime)),
                                        new OracleParameter(":ZXZBY",Data.CenterWatcher),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        ///病历填写项目
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalProject Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();

            sqlpar.StrSql = "insert into web_medicalproject(ID,NAME,TYPE,STATISTICS,CANCELLATION,CODENAME,XZBM)values(:ID,:NAME,:TYPE,:STATISTICS,:CANCELLATION,:CODENAME,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":ID",GetString(Data.ID)),
                                        new OracleParameter(":NAME",GetString(Data.NAME)),
                                        new OracleParameter(":TYPE",GetNumber(Data.TYPE)),
                                        new OracleParameter(":STATISTICS",GetNumber(Data.STATISTICS)),
                                        new OracleParameter(":CANCELLATION",GetNumber(Data.CANCELLATION)),
                                        new OracleParameter(":CODENAME",GetString(Data.CODENAME)),
                                        new OracleParameter(":XZBM",AreaCode),                                   
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        


        /// <summary>
        ///病历填写项目值
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalProjectValue Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into web_medicalprojectvalue(ID,MEDICALPROJECTID,NAME,CANCELLATION,XZBM)values(:ID,:MEDICALPROJECTID,:NAME,:CANCELLATION,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":ID",GetString(Data.ID)),
                                        new OracleParameter(":MEDICALPROJECTID",GetNumber(Data.MEDICALPROJECTID)),
                                        new OracleParameter(":NAME",GetString(Data.NAME)),
                                        new OracleParameter(":CANCELLATION",GetNumber(Data.CANCELLATION)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        ///病历记录
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalRecords Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
//            sqlpar.StrSql = @"insert into web_medicalrecords(
//            JJYXM,SXB,APGAR,TAPGAR,MEDICALTYPE,BRGJ,BQSCTP,ZZLB,ZZ,YY1,BS,
//            JJCS,HZZJ,HZBZ,ID,LSH,CS,CLBH,SSDWMC,ZBCH,BRXM,BRNL,BRXB,WJDD,
//            SWDD,BZ,DJR,DJRQ,BRID,XBS,GQXGS,ZCYZD,YWGMS,T,P,BP,ZTK,CBYX,XT,
//            XYBHD,XDTYX,XDJHYX,BRMZ,BRZY,BRJG,BRGZDW,XG_FLAG,XG_YY,XG_SHR,XG_SJ,
//            FLAG,R,ZBY,HJDH,WJDD_TJ,SWDD_TJ,HYZK,HR,YTK,QT,GCS,TI,ZDS,RZY,
//            RFBYL,QTJC,SWZMBH,XDTYXFJ,XDJHYXFJ,TIMPLATENAME,TIMPLATEFLAG,JZYS,
//            TGCS,TTI,TIMPLATEPY,TIMPLATEPARENTID,READER,XZBM)
//            values(:JJYXM,:SXB,:APGAR,:TAPGAR,:MEDICALTYPE,:BRGJ,:BQSCTP,:ZZLB,:ZZ,:YY1,:BS,
//            :JJCS,:HZZJ,:HZBZ,:ID,:LSH,:CS,:CLBH,:SSDWMC,:ZBCH,:BRXM,:BRNL,:BRXB,:WJDD,
//            :SWDD,:BZ,:DJR,:DJRQ,:BRID,:XBS,:GQXGS,:ZCYZD,:YWGMS,:T,:P,:BP,:ZTK,:CBYX,:XT,
//            :XYBHD,:XDTYX,:XDJHYX,:BRMZ,:BRZY,:BRJG,:BRGZDW,:XG_FLAG,:XG_YY,:XG_SHR,:XG_SJ,
//            :FLAG,:R,:ZBY,:HJDH,:WJDD_TJ,:SWDD_TJ,:HYZK,:HR,:YTK,:QT,:GCS,:TI,:ZDS,:RZY,
//            :RFBYL,:QTJC,:SWZMBH,:XDTYXFJ,:XDJHYXFJ,:TIMPLATENAME,:TIMPLATEFLAG,:JZYS,
//            :TGCS,:TTI,:TIMPLATEPY,:TIMPLATEPARENTID,:READER,:XZBM)";
            sqlpar.StrSql="insert into web_medicalrecords(JJYXM,SXB,APGAR,TAPGAR,MEDICALTYPE,BRGJ,BQSCTP,ZZLB,ZZ,YY1,BS,JJCS,HZZJ,HZBZ,ID,LSH,CS,CLBH,SSDWMC,ZBCH,BRXM,BRNL,BRXB,WJDD,SWDD,BZ,DJR,DJRQ,BRID,XBS,GQXGS,ZCYZD,YWGMS,T,P,BP,ZTK,CBYX,XT,XYBHD,XDTYX,XDJHYX,BRMZ,BRZY,BRJG,BRGZDW,XG_FLAG,XG_YY,XG_SHR,XG_SJ,FLAG,R,ZBY,HJDH,WJDD_TJ,SWDD_TJ,HYZK,HR,YTK,QT,GCS,TI,ZDS,RZY,RFBYL,QTJC,SWZMBH,XDTYXFJ,XDJHYXFJ,TIMPLATENAME,TIMPLATEFLAG,JZYS,TGCS,TTI,TIMPLATEPY,TIMPLATEPARENTID,READER,XZBM) values(:JJYXM,:SXB,:APGAR,:TAPGAR,:MEDICALTYPE,:BRGJ,:BQSCTP,:ZZLB,:ZZ,:YY1,:BS,:JJCS,:HZZJ,:HZBZ,:ID,:LSH,:CS,:CLBH,:SSDWMC,:ZBCH,:BRXM,:BRNL,:BRXB,:WJDD,:SWDD,:BZ,:DJR,:DJRQ,:BRID,:XBS,:GQXGS,:ZCYZD,:YWGMS,:T,:P,:BP,:ZTK,:CBYX,:XT,:XYBHD,:XDTYX,:XDJHYX,:BRMZ,:BRZY,:BRJG,:BRGZDW,:XG_FLAG,:XG_YY,:XG_SHR,:XG_SJ,:FLAG,:R,:ZBY,:HJDH,:WJDD_TJ,:SWDD_TJ,:HYZK,:HR,:YTK,:QT,:GCS,:TI,:ZDS,:RZY,:RFBYL,:QTJC,:SWZMBH,:XDTYXFJ,:XDJHYXFJ,:TIMPLATENAME,:TIMPLATEFLAG,:JZYS,:TGCS,:TTI,:TIMPLATEPY,:TIMPLATEPARENTID,:READER,:XZBM)";

            OracleParameter[] par ={  
                                       //JJYXM,SXB,APGAR,TAPGAR,MEDICALTYPE,BRGJ,BQSCTP,ZZLB,ZZ,YY1,BS,
                                       new OracleParameter(":JJYXM",GetString(Data.JJYXM)),
                                        new OracleParameter(":SXB",GetString(Data.SXB)),
                                        new OracleParameter(":APGAR",GetNumber(Data.APGAR)),
                                        new OracleParameter(":TAPGAR",GetString(Data.TAPGAR)),
                                        new OracleParameter(":MEDICALTYPE",GetNumber(Data.MEDICALTYPE)),
                                        new OracleParameter(":BRGJ",GetString(Data.BRGJ)),
                                        new OracleParameter(":BQSCTP",GetString(Data.BQSCTP)),
                                        new OracleParameter(":ZZLB",GetString(Data.ZZLB)),
                                        new OracleParameter(":ZZ",GetString(Data.ZZ )),
                                        new OracleParameter(":YY1",GetString(Data.YY1)),
                                        new OracleParameter(":BS",GetString(Data.BS)),
                                        //JJCS,HZZJ,HZBZ,ID,LSH,CS,CLBH,SSDWMC,ZBCH,BRXM,BRNL,BRXB,WJDD,
                                        new OracleParameter(":JJCS",GetString(Data.JJCS)),
                                        new OracleParameter(":HZZJ",GetString(Data.HZZJ)),
                                        new OracleParameter(":HZBZ",GetString(Data.HZBZ)),
                                        new OracleParameter(":ID",GetNumber(Data.ID)),
                                        new OracleParameter(":LSH",GetString(Data.LSH)),
                                        new OracleParameter(":CS",GetString(Data.CS)),
                                        new OracleParameter(":CLBH",GetString(Data.CLBH)),
                                        new OracleParameter(":SSDWMC",GetString(Data.SSDWMC)),
                                        new OracleParameter(":ZBCH",GetString(Data.ZBCH )),
                                        new OracleParameter(":BRXM",GetString(Data.BRXM)),
                                        new OracleParameter(":BRNL",GetString(Data.BRNL)),
                                        new OracleParameter(":BRXB",GetString(Data.BRXB)),
                                        new OracleParameter(":WJDD",GetString(Data.WJDD)),
                                        //SWDD,BZ,DJR,DJRQ,BRID,XBS,GQXGS,ZCYZD,YWGMS,T,P,BP,ZTK,CBYX,XT,
                                        new OracleParameter(":SWDD",GetString(Data.SWDD)),
                                        new OracleParameter(":BZ",GetString(Data.BZ)),
                                        new OracleParameter(":DJR",GetString(Data.DJR)),
                                        new OracleParameter(":DJRQ",GetDateTime(Data.DJRQ)),
                                        new OracleParameter(":BRID",GetString(Data.BRID)),
                                        new OracleParameter(":XBS",GetString(Data.XBS)),
                                        new OracleParameter(":GQXGS",GetString(Data.GQXGS)),
                                        new OracleParameter(":ZCYZD",GetString(Data.ZCYZD)),
                                        new OracleParameter(":YWGMS",GetString(Data.YWGMS )),
                                        new OracleParameter(":T",GetString(Data.T)),
                                        new OracleParameter(":P",GetString(Data.P)),
                                        new OracleParameter(":BP",GetString(Data.BP)),
                                        new OracleParameter(":ZTK",GetString(Data.ZTK)),
                                        new OracleParameter(":CBYX",GetString(Data.CBYX)),
                                        new OracleParameter(":XT",GetString(Data.XT)),
                                        //XYBHD,XDTYX,XDJHYX,BRMZ,BRZY,BRJG,BRGZDW,XG_FLAG,XG_YY,XG_SHR,XG_SJ,
                                        new OracleParameter(":XYBHD",GetString(Data.XYBHD)),
                                        new OracleParameter(":XDTYX",GetString(Data.XDTYX)),
                                        new OracleParameter(":XDJHYX",GetString(Data.XDJHYX)),
                                        new OracleParameter(":BRMZ",GetString(Data.BRMZ)),
                                        new OracleParameter(":BRZY",GetString(Data.BRZY)),
                                        new OracleParameter(":BRJG",GetString(Data.BRJG)),
                                        new OracleParameter(":BRGZDW",GetString(Data.BRGZDW)),
                                        new OracleParameter(":XG_FLAG",GetString(Data.XG_FLAG)),
                                        new OracleParameter(":XG_YY",GetString(Data.XG_YY )),
                                        new OracleParameter(":XG_SHR",GetString(Data.XG_SHR)),
                                        new OracleParameter(":XG_SJ",GetDateTime(Data.XG_SJ)),
                                        //FLAG,R,ZBY,HJDH,WJDD_TJ,SWDD_TJ,HYZK,HR,YTK,QT,GCS,TI,ZDS,RZY,
                                        new OracleParameter(":FLAG",GetString(Data.FLAG)),
                                        new OracleParameter(":R",GetString(Data.R)),
                                        new OracleParameter(":ZBY",GetString(Data.ZBY)),
                                        new OracleParameter(":HJDH",GetString(Data.HJDH)),
                                        new OracleParameter(":WJDD_TJ",GetString(Data.WJDD_TJ)),
                                        new OracleParameter(":SWDD_TJ",GetString(Data.SWDD_TJ)),
                                        new OracleParameter(":HYZK",GetString(Data.HYZK)),
                                        new OracleParameter(":HR",GetString(Data.HR)),
                                        new OracleParameter(":YTK",GetString(Data.YTK )),
                                        new OracleParameter(":QT",GetString(Data.QT)),
                                        new OracleParameter(":GCS",GetNumber(Data.GCS)),
                                        new OracleParameter(":TI",GetNumber(Data.TI)),
                                        new OracleParameter(":ZDS",GetString(Data.ZDS)),
                                        new OracleParameter(":RZY",GetString(Data.RZY)),
                                        //RFBYL,QTJC,SWZMBH,XDTYXFJ,XDJHYXFJ,TIMPLATENAME,TIMPLATEFLAG,JZYS,
                                        new OracleParameter(":RFBYL",GetString(Data.RFBYL)),
                                        new OracleParameter(":QTJC",GetString(Data.QTJC)),
                                        new OracleParameter(":SWZMBH",GetString(Data.SWZMBH)),
                                        new OracleParameter(":XDTYXFJ",GetString(Data.XDTYXFJ)),
                                        new OracleParameter(":XDJHYXFJ",GetString(Data.XDJHYXFJ)),
                                        new OracleParameter(":TIMPLATENAME",GetString(Data.TIMPLATENAME)),
                                        new OracleParameter(":TIMPLATEFLAG",GetNumber(Data.TIMPLATEFLAG)),
                                        new OracleParameter(":JZYS",GetString(Data.JZYS)),
                                        //TGCS,TTI,TIMPLATEPY,TIMPLATEPARENTID,READER,XZBM
                                        new OracleParameter(":TGCS",GetString(Data.TGCS)),
                                        new OracleParameter(":TTI",GetString(Data.TTI)),
                                        new OracleParameter(":TIMPLATEPY",GetString(Data.TIMPLATEPY)),
                                        new OracleParameter(":TIMPLATEPARENTID",GetString(Data.TIMPLATEPARENTID)),
                                        new OracleParameter(":READER",GetNumber(Data.READER)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        ///病历填写项目与值对应关系数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalStatistics Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into web_medicalstatistics(ID,CONTROLID,MEDICALRECORDSID,CONTROLVALUE,CONTROLPARENTID,XZBM)values(:ID,:CONTROLID,:MEDICALRECORDSID,:CONTROLVALUE,:CONTROLPARENTID,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":ID",GetNumber(Data.ID)),
                                        new OracleParameter(":CONTROLID",GetString(Data.CONTROLID)),
                                        new OracleParameter(":MEDICALRECORDSID",GetNumber(Data.MEDICALRECORDSID)),
                                        new OracleParameter(":CONTROLVALUE",GetNumber(Data.CONTROLVALUE)),
                                        new OracleParameter(":CONTROLPARENTID",GetString(Data.CONTROLPARENTID)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(BLJCXXB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into BLJCXXB(XH,LX,MC,GPS,BH,YWLX,BZ,XZBM)values(:XH,:LX,:MC,:GPS,:BH,:YWLX,:BZ,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":XH",GetNumber(Data.XH)),
                                        new OracleParameter(":LX",GetString(Data.LX)),
                                        new OracleParameter(":MC",GetString(Data.MC)),
                                        new OracleParameter(":GPS",GetString(Data.GPS)),
                                        new OracleParameter(":BH",GetNumber(Data.BH)),
                                        new OracleParameter(":YWLX",GetString(Data.YWLX)),
                                        new OracleParameter(":BZ",GetString(Data.BZ)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(HJQYB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into HJQYB(XH,HJQY,JD,XZBM)values(:XH,:HJQY,:JD,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":XH",GetNumber(Data.XH)),
                                        new OracleParameter(":HJQY",GetString(Data.HJQY)),
                                        new OracleParameter(":JD",GetString(Data.JD)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 来电类型表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(LDLXB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into LDLXB(XH,LX,RJ,PCBZ,XZBM)values(:XH,:LX,:RJ,:PCBZ,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":XH",GetNumber(Data.XH)),
                                        new OracleParameter(":LX",GetString(Data.LX)),
                                        new OracleParameter(":RJ",GetString(Data.RJ)),
                                        new OracleParameter(":PCBZ",GetString(Data.PCBZ)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(ZBYXXB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into ZBYXXB(ID,XM,MM,BC,XTSF,DJRQ,ZXBZ,ZXRQ,MS,LXFF,XZBM)values(:ID,:XM,:MM,:BC,:XTSF,:DJRQ,:ZXBZ,:ZXRQ,:MS,:LXFF,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":ID",GetNumber(Data.ID)),
                                        new OracleParameter(":XM",GetString(Data.XM)),
                                        new OracleParameter(":MM",GetString(Data.MM)),
                                        new OracleParameter(":BC",GetString(Data.BC)),
                                        new OracleParameter(":XTSF",GetString(Data.XTSF)),
                                        new OracleParameter(":DJRQ",GetDateTime(Data.DJRQ)),
                                        new OracleParameter(":ZXBZ",GetString(Data.ZXBZ)),
                                        new OracleParameter(":ZXRQ",GetDateTime(Data.ZXRQ)),
                                        new OracleParameter(":MS",GetString(Data.MS)),
                                        new OracleParameter(":LXFF",GetString(Data.LXFF)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 症状表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(ZZB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into ZZB(XH,ZZ,ZZLB,ID,LX,KB,YY,XZBM)values(:XH,:ZZ,:ZZLB,:ID,:LX,:KB,:YY,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":XH",GetNumber(Data.XH)),
                                        new OracleParameter(":ZZ",GetString(Data.ZZ)),
                                        new OracleParameter(":ZZLB",GetString(Data.ZZLB)),
                                        new OracleParameter(":ID",GetString(Data.ID)),
                                        new OracleParameter(":LX",GetString(Data.LX)),
                                         new OracleParameter(":KB",GetString(Data.KB)),
                                          new OracleParameter(":YY",GetString(Data.YY)),
                                        new OracleParameter(":XZBM",AreaCode),
                                   };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 大型事故表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(DXSGB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = @"insert into DXSGB(
                                LSH,SGLV,SGMC,SGLX,SBBM1,DHHM1,JHR1,SBSJ1,ZHCDDSJ1,SBBM2,DHHM2,
                                JHR2,SBSJ2,ZHCDDSJ2,SBBM3,DHHM3,JHR3,SBSJ3,ZHCDDSJ3,XJ,
                                DDXCBZ1,DDXCBZ2,DDXCBZ3,SGYY,XXSBBZ,XXSBZBYID,SBBM4,DHHM4,JHR4,
                                SBSJ4,ZHCDDSJ4,XCJZ,XCJZ1,XCJZ0,GYXS,SQCBFL,SQRS0,
                                SQRS1,SQRS2,SQRS3,SQRS4,SQRS5,SQRS6,SQRS7,SQRS8,SQRS9,SQRS10,XZBM
                                )values(
                                :LSH,:SGLV,:SGMC,:SGLX,:SBBM1,:DHHM1,:JHR1,:SBSJ1,:ZHCDDSJ1,:SBBM2,:DHHM2,:JHR2,:SBSJ2,:ZHCDDSJ2,:SBBM3,:DHHM3,:JHR3,:SBSJ3,:ZHCDDSJ3,:XJ,:
                                DDXCBZ1,:DDXCBZ2,:DDXCBZ3,:SGYY,:XXSBBZ,:XXSBZBYID,:SBBM4,:DHHM4,:JHR4,:SBSJ4,:ZHCDDSJ4,:XCJZ,:XCJZ1,:XCJZ0,:GYXS,:SQCBFL,:SQRS0,:
                                SQRS1,:SQRS2,:SQRS3,:SQRS4,:SQRS5,:SQRS6,:SQRS7,:SQRS8,:SQRS9,:SQRS10,:XZBM)";
            OracleParameter[] par ={   
                                       //LSH,SGMC,SGLX,SBBM1,DHHM1,JHR1,SBSJ1,ZHCDDSJ1,SBBM2,DHHM2,
                                        new OracleParameter(":LSH",GetString(Data.LSH)),
                                        //20160727 修改人：朱星汉 修改内容：添加突发公共事件等级
                                        new OracleParameter(":SGLV",GetString(Data.SGLV)),

                                        new OracleParameter(":SGMC",GetString(Data.SGMC)),
                                        new OracleParameter(":SGLX",GetString(Data.SGLX)),
                                        new OracleParameter(":SBBM1",GetString(Data.SBBM1)),
                                        new OracleParameter(":DHHM1",GetString(Data.DHHM1)),
                                        new OracleParameter(":JHR1",GetString(Data.JHR1)),
                                        new OracleParameter(":SBSJ1",GetDateTime(Data.SBSJ1)),
                                        new OracleParameter(":ZHCDDSJ1",GetDateTime(Data.ZHCDDSJ1)),
                                        new OracleParameter(":SBBM2",GetString(Data.SBBM2)),
                                        new OracleParameter(":DHHM2",GetString(Data.DHHM2)),

                                        //JHR2,SBSJ2,ZHCDDSJ2,SBBM3,DHHM3,JHR3,SBSJ3,ZHCDDSJ3,XJ,
                                        new OracleParameter(":JHR2",GetString(Data.JHR2)),
                                        new OracleParameter(":SBSJ2",GetDateTime(Data.SBSJ2)),
                                        new OracleParameter(":ZHCDDSJ2",GetDateTime(Data.ZHCDDSJ2)),
                                        new OracleParameter(":SBBM3",GetString(Data.SBBM3)),
                                        new OracleParameter(":DHHM3",GetString(Data.DHHM3)),
                                        new OracleParameter(":JHR3",GetString(Data.JHR3)),
                                        new OracleParameter(":SBSJ3",GetDateTime(Data.SBSJ3)),
                                        new OracleParameter(":ZHCDDSJ3",GetDateTime(Data.ZHCDDSJ3)),
                                        new OracleParameter(":XJ",GetString(Data.XJ)),

                                        // DDXCBZ1,DDXCBZ2,DDXCBZ3,SGYY,XXSBBZ,XXSBZBYID,SBBM4,DHHM4,JHR4,
                                        new OracleParameter(":DDXCBZ1",GetString(Data.DDXCBZ1)),
                                        new OracleParameter(":DDXCBZ2",GetString(Data.DDXCBZ2)),
                                        new OracleParameter(":DDXCBZ3",GetString(Data.DDXCBZ3)),
                                        new OracleParameter(":SGYY",GetString(Data.SGYY)),
                                        new OracleParameter(":XXSBBZ",GetString(Data.XXSBBZ)),
                                        new OracleParameter(":XXSBZBYID",GetString(Data.XXSBZBYID)),
                                        new OracleParameter(":SBBM4",GetString(Data.SBBM4)),
                                        new OracleParameter(":DHHM4",GetString(Data.DHHM4)),
                                        new OracleParameter(":JHR4",GetString(Data.JHR4)),

                                        //SBSJ4,ZHCDDSJ4,XCJZ,XCJZ1,XCJZ0,GYXS,SQCBFL,SQRS0,
                                        new OracleParameter(":SBSJ4",GetDateTime(Data.SBSJ4)),
                                        new OracleParameter(":ZHCDDSJ4",GetDateTime(Data.ZHCDDSJ4)),
                                        new OracleParameter(":XCJZ",GetString(Data.XCJZ)),
                                        new OracleParameter(":XCJZ1",GetString(Data.XCJZ1)),
                                        new OracleParameter(":XCJZ0",GetString(Data.XCJZ0)),
                                        new OracleParameter(":GYXS",GetString(Data.GYXS)),
                                        new OracleParameter(":SQCBFL",GetString(Data.SQCBFL)),
                                        new OracleParameter(":SQRS0",GetString(Data.SQRS0)),

                                        //SQRS1,SQRS2,SQRS3,SQRS4,SQRS5,SQRS6,SQRS7,SQRS8,SQRS9,SQRS10,XZBM
                                        new OracleParameter(":SQRS1",GetString(Data.SQRS1)),
                                        new OracleParameter(":SQRS2",GetString(Data.SQRS2)),
                                        new OracleParameter(":SQRS3",GetString(Data.SQRS3)),
                                        new OracleParameter(":SQRS4",GetString(Data.SQRS4)),
                                        new OracleParameter(":SQRS5",GetString(Data.SQRS5)),
                                        new OracleParameter(":SQRS6",GetString(Data.SQRS6)),
                                        new OracleParameter(":SQRS7",GetString(Data.SQRS7)),
                                        new OracleParameter(":SQRS8",GetString(Data.SQRS8)),
                                        new OracleParameter(":SQRS9",GetString(Data.SQRS9)),
                                        new OracleParameter(":SQRS10",GetString(Data.SQRS10)),
                                        new OracleParameter(":XZBM",AreaCode),
                                   };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 联网调度关联表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(LWDDGLB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into LWDDGLB(RemoteLSH,RemoteDWBH,LocalLSH,DDLX,SGSB,XZBM)values(:RemoteLSH,:RemoteDWBH,:LocalLSH,:DDLX,:SGSB,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":RemoteLSH",GetString(Data.RemoteLSH)),
                                        new OracleParameter(":RemoteDWBH",GetString(Data.RemoteDWBH)),
                                        new OracleParameter(":LocalLSH",GetString(Data.LocalLSH)),
                                        new OracleParameter(":DDLX",GetNumber(Data.DDLX)),
                                        new OracleParameter(":SGSB",GetNumber(Data.SGSB)),
                                        new OracleParameter(":XZBM",AreaCode),
                                   };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 联网车辆同步对应表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(LWCLTBDYB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into LWCLTBDYB(LocalLSH,LocalCS,LocalCLBH,TargetLSH,TargetCS,TargetCLBH,TargetDWBH,XZBM)values(:LocalLSH,:LocalCS,:LocalCLBH,:TargetLSH,:TargetCS,:TargetCLBH,:TargetDWBH,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":LocalLSH",GetString(Data.LocalLSH)),
                                        new OracleParameter(":LocalCS",GetString(Data.LocalCS)),
                                        new OracleParameter(":LocalCLBH",GetString(Data.LocalCLBH)),
                                        new OracleParameter(":TargetLSH",GetString(Data.TargetLSH)),
                                        new OracleParameter(":TargetCS",GetString(Data.TargetCS)),
                                         new OracleParameter(":TargetCLBH",GetString(Data.TargetCLBH)),
                                          new OracleParameter(":TargetDWBH",GetString(Data.TargetDWBH)),
                                        new OracleParameter(":XZBM",AreaCode),
                                   };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(LWBLTBDYB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into LWBLTBDYB(LocalLSH,LocalRecordID,TargetLSH,TargetRecordID,TargetDWBH,XZBM)values(:LocalLSH,:LocalRecordID,:TargetLSH,:TargetRecordID,:TargetDWBH,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":LocalLSH",GetString(Data.LocalLSH)),
                                        new OracleParameter(":LocalRecordID",GetNumber(Data.LocalRecordID)),
                                        new OracleParameter(":TargetLSH",GetString(Data.TargetLSH)),
                                        new OracleParameter(":TargetRecordID",GetNumber(Data.TargetRecordID)),
                                        new OracleParameter(":TargetDWBH",GetString(Data.TargetDWBH)),
                                        new OracleParameter(":XZBM",AreaCode),
                                   };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(LWBLGXTBDYB Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into LWBLGXTBDYB(LocalLSH,LocalStatisticsID,TargetLSH,TargetStatisticsID,TargetDWBH,XZBM)values(:LocalLSH,:LocalStatisticsID,:TargetLSH,:TargetStatisticsID,:TargetDWBH,:XZBM)";
            OracleParameter[] par ={   new OracleParameter(":LocalLSH",GetString(Data.LocalLSH)),
                                        new OracleParameter(":LocalStatisticsID",GetNumber(Data.LocalStatisticsID)),
                                        new OracleParameter(":TargetLSH",GetString(Data.TargetLSH)),
                                        new OracleParameter(":TargetStatisticsID",GetNumber(Data.TargetStatisticsID)),
                                        new OracleParameter(":TargetDWBH",GetString(Data.TargetDWBH)),
                                        new OracleParameter(":XZBM",AreaCode),
                                   };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        //20151211 修改人:朱星汉 修改内容:获取时间时若为空时返回DBnull
        public static object GetDateTime(string Time)
        {
            DateTime dt = new DateTime();
            object dtempty = DBNull.Value;
            try
            {
                if (string.IsNullOrEmpty(Time))
                {
                    return dtempty;

                }
                else
                {
                    dt = (DateTime)Convert.ToDateTime(Time);
                    return dt;
                }
            }
            catch
            {
                return dtempty;
            }
        }
        //20151211 修改人:朱星汉 修改内容:获取字符串时若为空时返回DBnull
        public static object GetString(string name)
        {
            object dtempty = DBNull.Value;
            string str = "";
            if (string.IsNullOrEmpty(name))
            {
                return dtempty; 
            }
            else
            {
                str = name;
                return str;
            }
        }

        //20151211 修改人:朱星汉 修改内容:获取字符串时若为空时返回DBnull
        public static object GetNumber(string number)
        {
            object dtempty = DBNull.Value;
            double Double = 0;
            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return dtempty;
                }
                else
                {
                    Double = double.Parse(number);
                    return Double;
                }
            }
            catch
            {
                return dtempty;
            }
        }
    }

}
