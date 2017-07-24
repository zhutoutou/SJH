using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.fnArgs;
using ZIT.SJHServer.Model.DataExchangeFunction;
using System.Data.OracleClient;

namespace ZIT.SJHServer.fnLocalDataAccess.Oracle
{
    internal class SyncDataSql
    {
        private static int rownum = SystemArgs.GetInstance().args.ReadRowNumber;

        /// <summary>
        /// 更新出车信息数据
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="VehicleNo"></param>
        /// <returns></returns>
        public static ParameterSql GetUpadateCCXXBSql(DispatchVehicleData Data)
        {
            ParameterSql sqlpar = new ParameterSql();
            //20151210 修改人:朱星汉 修改内容:添加车辆信息状态字段
            sqlpar.StrSql = "update CCXXB set CCLX=:CCLX,SJ=:SJ,SCYS=:SCYS,SCHS=:SCHS,SCDJG=:SCDJG,PCSJ=:PCSJ,CCDD=:CCDD,CCSJ=:CCSJ,DDXCSJ=:DDXCSJ,SCSJ=:SCSJ,DDSJ=:DDSJ,WCSJ=:WCSJ,FZSJ=:FZSJ,CCYS=:CCYS,LTYS=:LTYS,XCYS=:XCYS,ZTYS=:ZTYS,ZHS=:ZHS,XSLC=:XSLC,TSSJ=:TSSJ,TSYY=:TSYY,TSSJSJ=:TSSJSJ,CLID=:CLID,SDXXSJ=:SDXXSJ,SWYY=:SWYY,ZT=:ZT,CCCC=:CCCC where LSH=:LSH and CS=:CS and CLBH=:CLBH ";
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
                             };
            sqlpar.OrclPar = par;
            return sqlpar;
        }


        /// <summary>
        /// 添加出车信息数据
        /// </summary>
        public static ParameterSql GetAddCCXXBSql(DispatchVehicleData Data)
        {
            ParameterSql sqlpar = new ParameterSql();
            //20151210 修改人:朱星汉 修改内容:添加车辆信息状态字段
            sqlpar.StrSql = "insert into CCXXB(LSH,CLBH,CS,CCLX,SJ,SCYS,SCHS,SCDJG,PCSJ,CCDD,CCSJ,DDXCSJ,SCSJ,DDSJ,WCSJ,FZSJ,CCYS,LTYS,XCYS,ZTYS,ZHS,XSLC,TSSJ,TSYY,TSSJSJ,CLID,SDXXSJ,SWYY,ZT,CCCC)values(:LSH,:CLBH,:CS,:CCLX,:SJ,:SCYS,:SCHS,:SCDJG,:PCSJ,:CCDD,:CCSJ,:DDXCSJ,:SCSJ,:DDSJ,:WCSJ,:FZSJ,:CCYS,:LTYS,:XCYS,:ZTYS,:ZHS,:XSLC,:TSSJ,:TSYY,:TSSJSJ,:CLID,:SDXXSJ,:SWYY,:ZT,:CCCC)";
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
                                    new OracleParameter(":ZT",GetString(Data.VehicleZT)),
                                    //20160106 修改人:朱星汉 修改内容:添加出车车次(CCCC)字段
                                    new OracleParameter(":CCCC",GetString(Data.VehicleCCCC)),
                             };
            sqlpar.OrclPar = par;
            return sqlpar;
        }


        /// <summary>
        /// 更新病历记录
        /// </summary>
        public static ParameterSql GetUpadateMedicalRecordsSql(Web_MedicalRecords Data)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update web_medicalrecords set JJYXM=:JJYXM,SXB=:SXB,APGAR=:APGAR,TAPGAR=:TAPGAR,MEDICALTYPE=:MEDICALTYPE,BRGJ=:BRGJ,BQSCTP=:BQSCTP,ZZLB=:ZZLB,ZZ=:ZZ,YY1=:YY1,BS=:BS,JJCS=:JJCS,HZZJ=:HZZJ,HZBZ=:HZBZ,SSDWMC=:SSDWMC,ZBCH=:ZBCH,BRXM=:BRXM,BRNL=:BRNL,BRXB=:BRXB,WJDD=:WJDD,SWDD=:SWDD,BZ=:BZ,DJR=:DJR,DJRQ=:DJRQ,BRID=:BRID,XBS=:XBS,GQXGS=:GQXGS,ZCYZD=:ZCYZD,YWGMS=:YWGMS,T=:T,P=:P,BP=:BP,ZTK=:ZTK,CBYX=:CBYX,XT=:XT,XYBHD=:XYBHD,XDTYX=:XDTYX,XDJHYX=:XDJHYX,BRMZ=:BRMZ,BRZY=:BRZY,BRJG=:BRJG,BRGZDW=:BRGZDW,XG_FLAG=:XG_FLAG,XG_YY=:XG_YY,XG_SHR=:XG_SHR,XG_SJ=:XG_SJ,FLAG=:FLAG,R=:R,ZBY=:ZBY,HJDH=:HJDH,WJDD_TJ=:WJDD_TJ,SWDD_TJ=:SWDD_TJ,HYZK=:HYZK,HR=:HR,YTK=:YTK,QT=:QT,GCS=:GCS,TI=:TI,ZDS=:ZDS,RZY=:RZY,RFBYL=:RFBYL,QTJC=:QTJC,SWZMBH=:SWZMBH,XDTYXFJ=:XDTYXFJ,XDJHYXFJ=:XDJHYXFJ,TIMPLATENAME=:TIMPLATENAME,TIMPLATEFLAG=:TIMPLATEFLAG,JZYS=:JZYS,TGCS=:TGCS,TTI=:TTI,TIMPLATEPY=:TIMPLATEPY,TIMPLATEPARENTID=:TIMPLATEPARENTID,READER=:READER where ID=:ID and LSH=:LSH and CS=:CS and CLBH=:CLBH";
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
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }


        /// <summary>
        ///添加病历记录
        /// </summary>
        public static ParameterSql GetAddMedicalRecordsSql(Web_MedicalRecords Data)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into web_medicalrecords(JJYXM,SXB,APGAR,TAPGAR,MEDICALTYPE,BRGJ,BQSCTP,ZZLB,ZZ,YY1,BS,JJCS,HZZJ,HZBZ,LSH,CS,CLBH,SSDWMC,ZBCH,BRXM,BRNL,BRXB,WJDD,SWDD,BZ,DJR,DJRQ,BRID,XBS,GQXGS,ZCYZD,YWGMS,T,P,BP,ZTK,CBYX,XT,XYBHD,XDTYX,XDJHYX,BRMZ,BRZY,BRJG,BRGZDW,XG_FLAG,XG_YY,XG_SHR,XG_SJ,FLAG,R,ZBY,HJDH,WJDD_TJ,SWDD_TJ,HYZK,HR,YTK,QT,GCS,TI,ZDS,RZY,RFBYL,QTJC,SWZMBH,XDTYXFJ,XDJHYXFJ,TIMPLATENAME,TIMPLATEFLAG,JZYS,TGCS,TTI,TIMPLATEPY,TIMPLATEPARENTID,READER) values(:JJYXM,:SXB,:APGAR,:TAPGAR,:MEDICALTYPE,:BRGJ,:BQSCTP,:ZZLB,:ZZ,:YY1,:BS,:JJCS,:HZZJ,:HZBZ,:LSH,:CS,:CLBH,:SSDWMC,:ZBCH,:BRXM,:BRNL,:BRXB,:WJDD,:SWDD,:BZ,:DJR,:DJRQ,:BRID,:XBS,:GQXGS,:ZCYZD,:YWGMS,:T,:P,:BP,:ZTK,:CBYX,:XT,:XYBHD,:XDTYX,:XDJHYX,:BRMZ,:BRZY,:BRJG,:BRGZDW,:XG_FLAG,:XG_YY,:XG_SHR,:XG_SJ,:FLAG,:R,:ZBY,:HJDH,:WJDD_TJ,:SWDD_TJ,:HYZK,:HR,:YTK,:QT,:GCS,:TI,:ZDS,:RZY,:RFBYL,:QTJC,:SWZMBH,:XDTYXFJ,:XDJHYXFJ,:TIMPLATENAME,:TIMPLATEFLAG,:JZYS,:TGCS,:TTI,:TIMPLATEPY,:TIMPLATEPARENTID,:READER)";
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
                                       // new OracleParameter(":ID",GetNumber(Data.ID)),
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
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }

        /// <summary>
        /// 病历填写项目与值对应关系数据
        /// </summary>
        public static ParameterSql GetUpadateMedicalStatisticsSql(Web_MedicalStatistics Data)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "update web_medicalstatistics set CONTROLID=:CONTROLID,CONTROLVALUE=:CONTROLVALUE,CONTROLPARENTID=:CONTROLPARENTID where ID=:ID and MEDICALRECORDSID=:MEDICALRECORDSID";
            OracleParameter[] par ={    
                                       new OracleParameter(":ID",GetNumber(Data.ID)),
                                        new OracleParameter(":CONTROLID",GetString(Data.CONTROLID)),
                                        new OracleParameter(":MEDICALRECORDSID",GetNumber(Data.MEDICALRECORDSID)),
                                        new OracleParameter(":CONTROLVALUE",GetNumber(Data.CONTROLVALUE)),
                                        new OracleParameter(":CONTROLPARENTID",GetString(Data.CONTROLPARENTID)),
                                    };
            sqlpar.OrclPar = par;
            return sqlpar;
        }


        /// <summary>
        ///病历填写项目与值对应关系数据
        /// </summary>
        public static ParameterSql GetAddMedicalStatisticsSql(Web_MedicalStatistics Data)
        {
            ParameterSql sqlpar = new ParameterSql();
            sqlpar.StrSql = "insert into web_medicalstatistics(CONTROLID,MEDICALRECORDSID,CONTROLVALUE,CONTROLPARENTID)values(:CONTROLID,:MEDICALRECORDSID,:CONTROLVALUE,:CONTROLPARENTID)";
            OracleParameter[] par ={   
                                       //new OracleParameter(":ID",GetNumber(Data.ID)),
                                        new OracleParameter(":CONTROLID",GetString(Data.CONTROLID)),
                                        new OracleParameter(":MEDICALRECORDSID",GetNumber(Data.MEDICALRECORDSID)),
                                        new OracleParameter(":CONTROLVALUE",GetNumber(Data.CONTROLVALUE)),
                                        new OracleParameter(":CONTROLPARENTID",GetString(Data.CONTROLPARENTID)),
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
