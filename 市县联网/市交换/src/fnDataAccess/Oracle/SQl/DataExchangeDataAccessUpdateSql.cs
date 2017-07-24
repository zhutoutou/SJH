using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model;
using System.Collections;
using ZIT.SJHServer.Model.DispatchFunction;
using System.Data.OracleClient;
//using Oracle.DataAccess.Client;

namespace ZIT.SJHServer.fnDataAccess.Oracle.SQl
{
    /// <summary>
    /// 更新语句
    /// </summary>
    public class DataExchangeDataAccessUpdateSql
    {
        public static string GetDataExchangeDataAccessSql(VehicleStatus Data, string ID, string AreaCode)
        {
            string sql = "update dqclztxxb set ZHFXSJ='" + GetDateTime(Data.StatusChangeTime) + "',DXDDSJ='" + GetDateTime(Data.StatusChangeTime) + "'," +
                "JD='" + Data.Longitude + "',WD='" + Data.Latitude + "',SD='" + Data.Speed + "',FX='" + Data.Direction + "',KJXS='" + Data.VisibleStar + "',GZXS='" + Data.TrackStar + "',TXZT='" + Data.AntennaStatus + "',GZZT='" + Data.WorkStatus + "',XSLC='" + Data.SteerMileage + "'  where id='" + ID + "' AND XZBM='" + AreaCode + "'";
            return sql;
        }
        /// <summary>
        /// 车辆信息表
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static ParameterSql GetDataExchangeDataAccessSql(VehicleData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update clxxb set  ID=:ID,CPH=:CPH,czdh=:CZDH,FDJHM=:FDJHM,MC=:MC,CLLX=:CLLX,SSDW=:SSDW,GZSJ=:GZSJ,SYSJ=:SYSJ,ZXBZ=:ZXBZ,BZ=:BZ where XZBM=:XZBM  AND CLBH =:CLBH ";
            OracleParameter[] par ={  
                                        new OracleParameter(":ID",Data.VehicleID),
                                        new OracleParameter(":CPH",Data.CarNumber),
                                        new OracleParameter(":CZDH",Data.Mobile),
                                        new OracleParameter(":FDJHM",Data.EngineNumber),
                                        new OracleParameter(":MC",Data.VehicleName ),
                                        new OracleParameter(":CLLX",Data.VehicleType),
                                        new OracleParameter(":SSDW",Data.UnitName),
                                        new OracleParameter(":GZSJ",GetDateTime(Data.PurchaseDate)),
                                        new OracleParameter(":SYSJ",GetDateTime(Data.UseDate)),
                                        new OracleParameter(":ZXBZ",Data.Cancel),
                                        new OracleParameter(":BZ",Data.Remark),
                                        new OracleParameter(":XZBM",AreaCode),
                                        new OracleParameter(":CLBH",Data.VehicleCode),
                                       // new OracleParameter(":CZDH",Data.Mobile),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 车辆信息表
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static ArrayList GetGpsVehicleDataAccessSql(VehicleData Data, string ID)
        {
            ArrayList SqlList = new ArrayList();
            string sql = "update dqclztxxb set id ='" + ID + "' where id='" + ID + "'";
            SqlList.Add(sql);
            sql = "update clzlb set  CPZ='" + Data.CarNumber + "',CZDH='" + Data.Mobile + "',CLLX='" + Data.VehicleType + "',SSDW='" + Data.UnitName + "',CLBH='" + Data.VehicleCode + "',CLMC='" + Data.VehicleName + "',YWLX='120' where ID='" + ID + "'";
            SqlList.Add(sql);
            return SqlList;
        }
        /// <summary>
        /// 更新120库车辆信息表（2合一模式120库与GPS为一个数据库）
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static ArrayList GetBSSVehicleDataAccessSql(VehicleData Data, string ID)
        {
            ArrayList SqlList = new ArrayList();
            string sql = "update dqclztxxb set id ='" + ID + "' where ID='" + ID + "'";
            SqlList.Add(sql);
            sql = "update clxxb set CPH='" + Data.CarNumber + "',CZDH='" + Data.Mobile + "',CLLX='" + Data.VehicleType + "',SSDW='" + Data.UnitName + "',CLBH='" + Data.VehicleCode + "',MC='" + Data.VehicleName + "',YWLX='120',GPS='是' where ID='" + ID + "'";
            SqlList.Add(sql);
            return SqlList;
        }
        /// <summary>
        /// 系统人员表
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static ParameterSql GetDataExchangeDataAccessSql(SysUserData Data, string XZBM)
        {
            ParameterSql sqlpar = new ParameterSql();
            //20151210 修改人:朱星汉 修改内容:添加系统人员密码
            sqlpar.StrSql = "update xtryb set XM=:XM,XB=:XB,SFZHM=:SFZHM,ZW=:ZW,ZN=:ZN,JSZC=:JSZC,XL=:XL,BYXX=:BYXX,ZY=:ZY,YGXS=:YGXS,BGDH=:BGDH,LXFS=:LXFS,JTDH=:JTDH,CSSJ=:CSSJ,BYSJ=:BYSJ,CJGZSJ=:CJGZSJ,RZRQ=:RZRQ,DJRQ=:DJRQ,ZXRQ=:ZXRQ,ZXBZ=:ZXBZ,BZ=:BZ,SSDW=:SSDW,MM=:MM where RYBH=:RYBH and XZBM=:XZBM";
            OracleParameter[] par ={
                                   new OracleParameter(":RYBH",GetString(Data.UserName)),
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
                                    new OracleParameter(":CSSJ", ""),
                                    new OracleParameter(":BYSJ",""),
                                    new OracleParameter(":CJGZSJ",""),
                                    new OracleParameter(":RZRQ",""),
                                    new OracleParameter(":DJRQ",GetDateTime(Data.RegisterDate)),
                                    new OracleParameter(":ZXRQ",""),
                                    new OracleParameter(":ZXBZ",GetString(Data.Cancel)),
                                    new OracleParameter(":BZ",GetString(Data.Remark)),
                                    new OracleParameter(":MM",GetString(Data.Password)),
                                    new OracleParameter(":XZBM",GetString(XZBM)), 
                             };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 受理记录
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static ParameterSql GetDataExchangeDataAccessSql(DealData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update SLJLB set XXLY=:XXLY,SLTH=:SLTH,ZBY=:ZBY,ZBBC=:ZBBC,SLSJ=:SLSJ,ZJHM=:ZJHM,HZ=:HZ,HJDZ=:HJDZ,HJQY=:HJQY,LDLX=:LDLX,HJR=:HJR,HCZLX=:HCZLX,LXDH=:LXDH,HZXM=:HZXM,HZXB=:HZXB,HZNL=:HZNL,HZGJ=:HZGJ,HZSF=:HZSF,GMYW=:GMYW,HZZZ=:HZZZ,HZBS=:HZBS,JCDZ=:JCDZ,SWDD=:SWDD,CZFS=:CZFS,HCBZ=:HCBZ,HCYY=:HCYY,GJSJ=:GJSJ,SLSC=:SLSC,DDKSSJ=:DDKSSJ,DDJSSJ=:DDJSSJ,DDSC=:DDSC,HJDZ_X=:HJDZ_X,HJDZ_Y=:HJDZ_Y,JCDZ_X=:JCDZ_X,JCDZ_Y=:JCDZ_Y,HJLX=:HJLX,SGLX=:SGLX,SGYY=:SGYY,SGMC=:SGMC,SLZT=:SLZT,PCYZ=:PCYZ,KJLM=:KJLM,SJGLLSH=:SJGLLSH,GXJD=:GXJD,GXYY=:GXYY,FBDD=:FBDD,TSAJBZ=:TSAJBZ,SBBZ=:SBBZ,HZRS=:HZRS  where LSH=:LSH AND XZBM=:XZBM";
            OracleParameter[] par ={
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
                                    new OracleParameter(":XZBM",AreaCode),
                                    new OracleParameter(":HZRS",GetString(Data.AffectNumber)),
                                    new OracleParameter(":LSH",GetString(Data.DealRecordID)),
                             };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 出车信息数据
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="VehicleNo"></param>
        /// <returns></returns>
        public static ParameterSql GetDataExchangeDataAccessSql(DispatchVehicleData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            //20151210 修改人:朱星汉 修改内容:添加车辆信息状态字段
            sqlpar.StrSql = "update CCXXB set LSH=:LSH,CLBH=:CLBH,CS=:CS,CCLX=:CCLX,SJ=:SJ,SCYS=:SCYS,SCHS=:SCHS,SCDJG=:SCDJG,PCSJ=:PCSJ,CCDD=:CCDD,CCSJ=:CCSJ,DDXCSJ=:DDXCSJ,SCSJ=:SCSJ,DDSJ=:DDSJ,WCSJ=:WCSJ,FZSJ=:FZSJ,CCYS=:CCYS,LTYS=:LTYS,XCYS=:XCYS,ZTYS=:ZTYS,ZHS=:ZHS,XSLC=:XSLC,TSSJ=:TSSJ,TSYY=:TSYY,TSSJSJ=:TSSJSJ,CLID=:CLID,SDXXSJ=:SDXXSJ,SWYY=:SWYY,ZT=:ZT,CCCC=:CCCC where LSH=:LSH and CS=:CS and CLBH=:CLBH AND XZBM=:XZBM";
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
                                    new OracleParameter(":CCYS",GetNumber(Data.StartoffUseTime)),
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
                                    new OracleParameter(":ZT",GetString(Data.VehicleZT)),
                                    //20160106 修改人:朱星汉 修改内容:添加出车车次(CCCC)字段
                                    new OracleParameter(":CCCC",GetString(Data.VehicleCCCC)),
                                    new OracleParameter(":XZBM",AreaCode),
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
            sqlpar.StrSql = "update HZXXB set XH=:XH,XM=:XM,XB=:XB,NL=:NL,GJ=:GJ,ZY=:ZY,DHHM=:DHHM,SWDD=:SWDD,CBZD=:CBZD,SSCD=:SSCD,XCQJ=:XCQJ,YXQJ=:YXQJ,JZJG=:JZJG,XCDD=:XCDD  where LSH=:LSH and CLBH=:CLBH AND XZBM=:XZBM";
            OracleParameter[] par ={
                                    new OracleParameter(":XH",Data.SuffererNo),
                                    new OracleParameter(":XM",Data.SuffererName),
                                    new OracleParameter(":XB",Data.SuffererSex),
                                    new OracleParameter(":NL",Data.SuffererAge),
                                    new OracleParameter(":GJ",Data.Nationality),
                                    new OracleParameter(":ZY",Data.Profession),

                                    new OracleParameter(":DHHM",Data.Telephone),
                                    new OracleParameter(":SWDD",Data.Hospital),
                                    //new OracleParameter(":HZZZ",Data.Symptom),
                                    new OracleParameter(":CBZD", Data.FirstDiag),
                                    new OracleParameter(":SSCD",Data.InjuredDegree),
                                    new OracleParameter(":XCQJ",Data.LocaleSalvage),
                                    new OracleParameter(":YXQJ",Data.ValidSalvage),
                                    new OracleParameter(":JZJG",Data.CureResult),
                                    new OracleParameter(":XCDD",Data.LocalePlace),
                                    new OracleParameter(":XZBM",XZBM), 

                                    new OracleParameter(":LSH",Data.DealRecordID),
                                    new OracleParameter(":CLBH",VehicleNo),
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
            sqlpar.StrSql = "update HZBLB set XH=:XH,BQ=:BQ,BS=:BS,XY=:XY,MB=:MB,HX=:HX,XL=:XL,TW=:TW,TK=:TK,DGFS=:DGFS,YBQK=:YBQK,SHZ=:SHZ,PF=:PF,XZ=:XZ,FB=:FB,FUB=:FUB,SZ=:SZ,TJB=:TJB,SJXT=:SJXT,JJXG=:JJXG,QT=:QT,XZBM=:XZBM where LSH=:LSH and CLBH=:CLBH";
            OracleParameter[] par ={
                                    new OracleParameter(":XH",Data.SuffererNo),
                                    new OracleParameter(":BQ",Data.IllnessState),
                                    new OracleParameter(":BS",Data.IllnessHistory),
                                    new OracleParameter(":XY",Data.BloodPressure),
                                    new OracleParameter(":MB",Data.Pulse),
                                    new OracleParameter(":HX",Data.Breath),
                                    new OracleParameter(":XL",Data.HeartRate),
                                    new OracleParameter(":TW",Data.AnimalHeat),
                                    new OracleParameter(":TK",Data.Pupil),
                                    new OracleParameter(":DGFS", Data.LightEcho),
                                    new OracleParameter(":YBQK",Data.CommonlyCircs),
                                    new OracleParameter(":SHZ",Data.Mind),
                                    new OracleParameter(":PF",Data.Skin),
                                    new OracleParameter(":XZ",Data.Heart),
                                    new OracleParameter(":FB",Data.Lung),
                                    new OracleParameter(":FUB", Data.Abdomen),
                                    new OracleParameter(":SZ",Data.Extremity),
                                    new OracleParameter(":TJB",Data.HeadNeck),
                                    new OracleParameter(":SJXT",Data.Neural),
                                    new OracleParameter(":JJXG",Data.FirstAidPurpose),
                                    new OracleParameter(":QT",Data.Other),
                                     new OracleParameter(":XZBM",XZBM),
                                    new OracleParameter(":LSH",Data.DealRecordID),
                                    new OracleParameter(":CLBH",VehicleNo),
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
            sqlpar.StrSql = "update hjjlb set ZJHM=:ZJHM,ZJLX=:ZJLX,HJZT=:HJZT,LDSJ=:LDSJ,SLSJ=:SLSJ,DDSC=:DDSC,GJSJ=:GJSJ,SLSC=:SLSC,DDKSSJ=:DDKSSJ,DDJSSJ=:DDJSSJ,DDUSC=:DDUSC,SLTH=:SLTH,XXLY=:XXLY where LSH=:LSH AND XZBM=:XZBM";
            OracleParameter[] par ={new OracleParameter(":LSH",GetString(Data.CallID)),
                                    new OracleParameter(":ZJHM",GetString(Data.CallNumber)),
                                    new OracleParameter(":ZJLX",GetString(Data.CallType)),
                                    new OracleParameter(":HJZT",GetString(Data.DealType)),
                                    new OracleParameter(":LDSJ",GetDateTime(Data.CallTime)),
                                    new OracleParameter(":SLSJ", GetDateTime(Data.RespTime)),
                                    new OracleParameter(":DDSC", GetNumber(Data.WaitTime)),
                                    new OracleParameter(":GJSJ",GetDateTime(Data.HangupTime)),
                                    new OracleParameter(":SLSC", GetNumber(Data.TalkTime)),
                                    new OracleParameter(":DDKSSJ",GetDateTime(Data.AttempeStartTime)),
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
            sqlpar.StrSql = "update DWXXB set XH=:XH,DWMC=:DWMC,PY=:PY,DWLX=:DWLX,SJDW=:SJDW,LX=:LX,FZHM=:FZHM where DWBH=:DWBH AND XZBM=:XZBM";
            OracleParameter[] par ={   
                                        new OracleParameter(":XH",Data.SequenceNO),
                                        new OracleParameter(":DWMC",Data.UnitName),
                                        
                                        new OracleParameter(":PY",Data.Spelling),
                                        new OracleParameter(":DWLX",Data.UnitTypeID),
                                        new OracleParameter(":SJDW",Data.SuperiorUnitName),
                                        //new OracleParameter(":SSQY",Data.CenterWatcher),
                                        new OracleParameter(":LX",Data.StationType),
                                        new OracleParameter(":FZHM",Data.Telephone),
                                        new OracleParameter(":DWBH",Data.UnitCode),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }
        /// <summary>
        /// 跟新GPS库单位信息表
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string GetGpsUnitInfoDataAccessSql(UnitInfoData Data)
        {

            string sql = "update DWXXB set dwmc='" + Data.UnitName + "' where dwbh='" + Data.UnitCode + "'";
            return sql;
        }
        /// <summary>
        /// 跟新BSS库单位信息表（二合一 BSS库与GPS库为一个库）
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string GetBSSUnitInfoDataAccessSql(UnitInfoData Data)
        {

            string sql = "update DWXXB set dwmc='" + Data.UnitName + "',XH='" + Data.SequenceNO + "',PY='" + Data.Spelling + "',DWLX='" + Data.UnitTypeID + "',SJDW='" + Data.SuperiorUnitName + "',LX='" + Data.StationType + "',FZHM='" + Data.Telephone + "' where dwbh='" + Data.UnitCode + "'";
            return sql;
        }
        /// <summary>
        /// 大型事故数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(LargeSlipData Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update DXSGB set LSH=:LSH,SGMC=:SGMC,SGLX=:SGLX,SBBM1=:SBBM1,DHHM1=:DHHM1,JHR1=:JHR1,SBSJ1=:SBSJ1,ZHCDDSJ1=:ZHCDDSJ1,SBBM2=:SBBM2,DHHM2=:DHHM2,JHR2=:JHR2,SBSJ2=:SBSJ2,ZHCDDSJ2=:ZHCDDSJ2,SBBM3=:SBBM3,DHHM3=:DHHM3,JHR3=:JHR3,SBSJ3=:SBSJ3,ZHCDDSJ3=:ZHCDDSJ3,XJ=:XJ where LSH=:LSH AND XZBM=:XZBM ";
            OracleParameter[] par ={   new OracleParameter(":LSH",GetString(Data.ID)),
                                        new OracleParameter(":SGMC",GetString(Data.SlipName)),
                                        new OracleParameter(":SGLX",Data.SlipType  ),

                                        new OracleParameter(":SBBM1",Data.ReportDepartment1),
                                        new OracleParameter(":DHHM1",Data.Telephone1),
                                        new OracleParameter(":JHR1",Data.CalledPerson1),
                                        
                                        new OracleParameter(":SBSJ1",GetDateTime(Data.ReportTime1)),
                                      
                                        new OracleParameter(":ZHCDDSJ1", GetDateTime(Data.ArriveTime1)),

                                        new OracleParameter(":SBBM2",Data.ReportDepartment2 ),
                                        new OracleParameter(":DHHM2",Data.Telephone2),
                                        new OracleParameter(":JHR2",Data.CalledPerson2),
                                        new OracleParameter(":SBSJ2",GetDateTime(Data.ReportTime2)),
                                        new OracleParameter(":ZHCDDSJ2",GetDateTime(Data.ArriveTime2)),

                                        new OracleParameter(":SBBM3",Data.ReportDepartment3),
                                        new OracleParameter(":DHHM3",Data.Telephone3 ),
                                        new OracleParameter(":JHR3",Data.CalledPerson3),
                                        new OracleParameter(":SBSJ3",GetDateTime(Data.ReportTime3)),
                                        new OracleParameter(":ZHCDDSJ3",GetDateTime(Data.ArriveTime3)),

                                         new OracleParameter(":XJ",Data.Remark),
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
            sqlpar.StrSql = "update DDFZJLB set FZZBY=:FZZBY,FZDDSJ=:FZDDSJ,FZFKSJ=:FZFKSJ,ZXZBY=:ZXZBY where LSH=:LSH and CCDW=:CCDW AND XZBM=:XZBM ";
            OracleParameter[] par ={    
                                        new OracleParameter(":FZZBY",Data.BranchWatcher ),
                                       
                                        new OracleParameter(":FZDDSJ",GetDateTime(Data.DispatchTime)),
                                        new OracleParameter(":FZFKSJ",GetDateTime(Data.FeedbackTime)),
                                        new OracleParameter(":ZXZBY",Data.CenterWatcher),
                                         new OracleParameter(":XZBM",AreaCode),
                                         new OracleParameter(":LSH",Data.ID),
                                        new OracleParameter(":CCDW",Data.DispatchVehicleUnit),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 病历填写项目
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalProject Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update web_medicalproject set NAME=:NAME,TYPE=:TYPE,STATISTICS=:STATISTICS,CANCELLATION=:CANCELLATION,CODENAME=:CODENAME where ID=:ID  AND XZBM=:XZBM ";
            OracleParameter[] par ={    
                                       new OracleParameter(":ID",GetString(Data.ID)),
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
        /// 病历填写项目值
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalProjectValue Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update web_medicalprojectvalue set MEDICALPROJECTID=:MEDICALPROJECTID,NAME=:NAME,CANCELLATION=:CANCELLATION where ID=:ID AND XZBM=:XZBM ";
            OracleParameter[] par ={    
                                        new OracleParameter(":ID",GetString(Data.ID)),
                                        new OracleParameter(":MEDICALPROJECTID",GetNumber(Data.MEDICALPROJECTID)),
                                        new OracleParameter(":NAME",GetString(Data.NAME)),
                                        new OracleParameter(":CANCELLATION",GetNumber(Data.CANCELLATION)),
                                        new OracleParameter(":XZBM",AreaCode),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 病历记录
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalRecords Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
//            sqlpar.StrSql = @"update web_medicalrecords
//                            set JJYXM=:JJYXM,
//                            SXB=:SXB,
//                            APGAR=:APGAR,
//                            TAPGAR=:TAPGAR,
//                            MEDICALTYPE=:MEDICALTYPE,
//                            BRGJ=:BRGJ,
//                            BQSCTP=:BQSCTP,
//                            ZZLB=:ZZLB,
//                            ZZ=:ZZ,
//                            YY1=:YY1,
//                            BS=:BS,
//                            JJCS=:JJCS,
//                            HZZJ=:HZZJ,
//                            HZBZ=:HZBZ,
//                            LSH=:LSH,
//                            CS=:CS,
//                            CLBH=:CLBH,
//                            SSDWMC=:SSDWMC,
//                            ZBCH=:ZBCH,
//                            BRXM=:BRXM,
//                            BRNL=:BRNL,
//                            BRXB=:BRXB,
//                            WJDD=:WJDD,
//                            SWDD=:SWDD,
//                            BZ=:BZ,
//                            DJR=:DJR,
//                            DJRQ=:DJRQ,
//                            BRID=:BRID,
//                            XBS=:XBS,
//                            GQXGS=:GQXGS,
//                            ZCYZD=:ZCYZD,
//                            YWGMS=:YWGMS,
//                            T=:T,
//                            P=:P,
//                            BP=:BP,
//                            ZTK=:ZTK,
//                            CBYX=:CBYX,
//                            XT=:XT,
//                            XYBHD=:XYBHD,
//                            XDTYX=:XDTYX,
//                            XDJHYX=:XDJHYX,
//                            BRMZ=:BRMZ,
//                            BRZY=:BRZY,
//                            BRJG=:BRJG,
//                            BRGZDW=:BRGZDW,
//                            XG_FLAG=:XG_FLAG,
//                            XG_YY=:XG_YY,
//                            XG_SHR=:XG_SHR,
//                            XG_SJ=:XG_SJ,
//                            FLAG=:FLAG,
//                            R=:R,
//                            ZBY=:ZBY,
//                            HJDH=:HJDH,
//                            WJDD_TJ=:WJDD_TJ,
//                            SWDD_TJ=:SWDD_TJ,
//                            HYZK=:HYZK,
//                            HR=:HR,
//                            YTK=:YTK,
//                            QT=:QT,
//                            GCS=:GCS,
//                            TI=:TI,
//                            ZDS=:ZDS,
//                            RZY=:RZY,
//                            RFBYL=:RFBYL,
//                            QTJC=:QTJC,
//                            SWZMBH=:SWZMBH,
//                            XDTYXFJ=:XDTYXFJ,
//                            XDJHYXFJ=:XDJHYXFJ,
//                            TIMPLATENAME=:TIMPLATENAME,
//                            TIMPLATEFLAG=:TIMPLATEFLAG,
//                            JZYS=:JZYS,
//                            TGCS=:TGCS,
//                            TTI=:TTI,
//                            TIMPLATEPY=:TIMPLATEPY,
//                            TIMPLATEPARENTID=:TIMPLATEPARENTID,
//                            READER=:READER
//                            where XZBM=:XZBM and ID=:ID";
            sqlpar.StrSql = "update web_medicalrecords set JJYXM=:JJYXM,SXB=:SXB,APGAR=:APGAR,TAPGAR=:TAPGAR,MEDICALTYPE=:MEDICALTYPE,BRGJ=:BRGJ,BQSCTP=:BQSCTP,ZZLB=:ZZLB,ZZ=:ZZ,YY1=:YY1,BS=:BS,JJCS=:JJCS,HZZJ=:HZZJ,HZBZ=:HZBZ,LSH=:LSH,CS=:CS,CLBH=:CLBH,SSDWMC=:SSDWMC,ZBCH=:ZBCH,BRXM=:BRXM,BRNL=:BRNL,BRXB=:BRXB,WJDD=:WJDD,SWDD=:SWDD,BZ=:BZ,DJR=:DJR,DJRQ=:DJRQ,BRID=:BRID,XBS=:XBS,GQXGS=:GQXGS,ZCYZD=:ZCYZD,YWGMS=:YWGMS,T=:T,P=:P,BP=:BP,ZTK=:ZTK,CBYX=:CBYX,XT=:XT,XYBHD=:XYBHD,XDTYX=:XDTYX,XDJHYX=:XDJHYX,BRMZ=:BRMZ,BRZY=:BRZY,BRJG=:BRJG,BRGZDW=:BRGZDW,XG_FLAG=:XG_FLAG,XG_YY=:XG_YY,XG_SHR=:XG_SHR,XG_SJ=:XG_SJ,FLAG=:FLAG,R=:R,ZBY=:ZBY,HJDH=:HJDH,WJDD_TJ=:WJDD_TJ,SWDD_TJ=:SWDD_TJ,HYZK=:HYZK,HR=:HR,YTK=:YTK,QT=:QT,GCS=:GCS,TI=:TI,ZDS=:ZDS,RZY=:RZY,RFBYL=:RFBYL,QTJC=:QTJC,SWZMBH=:SWZMBH,XDTYXFJ=:XDTYXFJ,XDJHYXFJ=:XDJHYXFJ,TIMPLATENAME=:TIMPLATENAME,TIMPLATEFLAG=:TIMPLATEFLAG,JZYS=:JZYS,TGCS=:TGCS,TTI=:TTI,TIMPLATEPY=:TIMPLATEPY,TIMPLATEPARENTID=:TIMPLATEPARENTID,READER=:READER where XZBM=:XZBM and ID=:ID";
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
        /// 病历填写项目与值对应关系数据
        /// </summary>
        public static ParameterSql GetDataExchangeDataAccessSql(Web_MedicalStatistics Data, string AreaCode)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update web_medicalstatistics set CONTROLID=:CONTROLID,MEDICALRECORDSID=:MEDICALRECORDSID,CONTROLVALUE=:CONTROLVALUE,CONTROLPARENTID=:CONTROLPARENTID where ID=:ID  AND XZBM=:XZBM ";
            OracleParameter[] par ={    
                                       new OracleParameter(":ID",GetNumber(Data.ID)),
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
            sqlpar.StrSql = "update BLJCXXB set XH=:XH,LX=:LX,MC=:MC,GPS=:GPS,BH=:BH,YWLX=:YWLX,BZ=:BZ where LX=:LX AND MC=:MC AND XZBM=:XZBM ";
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
            sqlpar.StrSql = "update HJQYB set HJQY=:HJQY,JD=:JD where XH=:XH and XZBM=:XZBM";
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
            sqlpar.StrSql = "update LDLXB set LX=:LX,RJ=:RJ,PCBZ=:PCBZ where XH=:XH and XZBM=:XZBM";
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
            sqlpar.StrSql = "update ZBYXXB set XM=:XM,MM=:MM,BC=:BC,XTSF=:XTSF,DJRQ=:DJRQ,ZXBZ=:ZXBZ,ZXRQ=:ZXRQ,MS=:MS,LXFF=:LXFF where ID=:ID and XZBM=:XZBM";
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
            sqlpar.StrSql = "update ZZB SET ZZ=:ZZ,ZZLB=:ZZLB,ID=:ID,LX=:LX,KB=:KB,YY=:YY where XH=:XH and XZBM=:XZBM";
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
            sqlpar.StrSql = @"UPDATE DXSGB SET SGLV=:SGLV,SGMC=:SGMC,SGLX=:SGLX,SBBM1=:SBBM1,DHHM1=:DHHM1,JHR1=:JHR1,SBSJ1=:SBSJ1,ZHCDDSJ1=:ZHCDDSJ1,SBBM2=:SBBM2,DHHM2=:DHHM2,JHR2=:JHR2,SBSJ2=:SBSJ2,
				             ZHCDDSJ2=:ZHCDDSJ2,SBBM3=:SBBM3,DHHM3=:DHHM3,JHR3=:JHR3,SBSJ3=:SBSJ3,ZHCDDSJ3=:ZHCDDSJ3,XJ=:XJ,
				            DDXCBZ1=:DDXCBZ1,DDXCBZ2=:DDXCBZ2,DDXCBZ3=:DDXCBZ3,SGYY=:SGYY,XXSBBZ=:XXSBBZ,XXSBZBYID=:XXSBZBYID,SBBM4=:SBBM4,DHHM4=:DHHM4,JHR4=:JHR4,
				            SBSJ4=:SBSJ4,ZHCDDSJ4=:ZHCDDSJ4,XCJZ=:XCJZ,XCJZ1=:XCJZ1,XCJZ0=:XCJZ0,GYXS=:GYXS,SQCBFL=:SQCBFL,SQRS0=:SQRS0,
				            SQRS1=:SQRS1,SQRS2=:SQRS2,SQRS3=:SQRS3,SQRS4=:SQRS4,SQRS5=:SQRS5,SQRS6=:SQRS6,SQRS7=:SQRS7,SQRS8=:SQRS8,SQRS9=:SQRS9,SQRS10=:SQRS10
				            WHERE LSH=:LSH AND XZBM=:XZBM";
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
            sqlpar.StrSql = "update  LWDDGLB set DDLX=:DDLX,SGSB=:SGSB where RemoteLSH=:RemoteLSH AND RemoteDWBH=:RemoteDWBH AND LocalLSH=:LocalLSH AND XZBM=:XZBM";
            OracleParameter[] par ={   
                                        new OracleParameter(":RemoteLSH",GetString(Data.RemoteLSH)),
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
            sqlpar.StrSql = "UPDATE LWCLTBDYB SET TargetLSH=:TargetLSH,TargetCS=:TargetCS,TargetCLBH=:TargetCLBH,TargetDWBH=:TargetDWBH WHERE LocalLSH=:LocalLSH AND LocalCS=:LocalCS AND LocalCLBH=:LocalCLBH AND XZBM=:XZBM";
            OracleParameter[] par ={  
                                       new OracleParameter(":LocalLSH",GetString(Data.LocalLSH)),
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
            sqlpar.StrSql = "UPDATE  LWBLTBDYB SET TargetLSH=:TargetLSH,TargetRecordID=:TargetRecordID,TargetDWBH=:TargetDWBH WHERE LocalLSH=:LocalLSH AND LocalRecordID=:LocalRecordID AND XZBM=:XZBM";
            OracleParameter[] par ={  
                                       new OracleParameter(":LocalLSH",GetString(Data.LocalLSH)),
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
            sqlpar.StrSql = "UPDATE  LWBLGXTBDYB SET TargetLSH=:TargetLSH,TargetStatisticsID=:TargetStatisticsID,TargetDWBH=:TargetDWBH WHERE LocalLSH=:LocalLSH AND LocalStatisticsID=:LocalStatisticsID AND XZBM=:XZBM";
            OracleParameter[] par ={   
                                       new OracleParameter(":LocalLSH",GetString(Data.LocalLSH)),
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
            DateTime? dt = null;
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
