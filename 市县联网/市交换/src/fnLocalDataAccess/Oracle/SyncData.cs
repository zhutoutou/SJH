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
    /// <summary>
    /// 负责将联网调度单的分中心出车及患者信息同步到市本地库中
    /// </summary>
    public class SyncData : SyncDataRespEvent,ISyncData
    {

        private void ExchangeDataResp(DispatchVehicleDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(Web_MedicalRecordsResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(Web_MedicalStatisticsResp message)
        {
            OnMessageDataExchange(message);
        }


        public static string DWBH = SystemArgs.GetInstance().args.UnitCode;
        /// <summary>
        /// 同步出车信息数据
        /// </summary>
        public void SyncDispatchVehicleData(DispatchVehicleData DispatchVehicle, string UnitCode)
        {

            
            try
            {
                string strLcoalLSH = "";
                string strTargetLSH = DispatchVehicle.DealRecordID;
                string strTargetCS = DispatchVehicle.Times;
                string strTargetCLBH = DispatchVehicle.VehicleCode;
                if (IsLWDD(DispatchVehicle.DealRecordID, UnitCode, ref strLcoalLSH))
                {
                    LogHelper.WriteLog("联网单需要更新CCXX，LSH：" + strLcoalLSH);
                    CheckDispatchRecord(strLcoalLSH, DispatchVehicle.DispatchVehicleTime, UnitCode);
                    CheckHJQY(strLcoalLSH, UnitCode);
                    string strLocalCS = "";
                    string strLocalCLBH = "";
                    if (HasVehicleMatchRecord(DispatchVehicle.DealRecordID, DispatchVehicle.VehicleCode, DispatchVehicle.Times,
                        UnitCode, ref strLocalCS, ref strLocalCLBH))
                    {
                        LogHelper.WriteLog("进入HasVehicleMatchRecord=true，LSH:" + strLcoalLSH);
                        string sql = "select * from ccxxb where  lsh = '" + strLcoalLSH + "' and cs = '" + strLocalCS + "' and clbh = '" + strLocalCLBH + "'";
                        object obj = DB120Help.GetSingle(sql);
                        //如果已经存在记录更新当前出车信息
                        if (obj != null)
                        {
                            DispatchVehicle.VehicleCode = strLocalCLBH;
                            DispatchVehicle.DealRecordID = strLcoalLSH;
                            DispatchVehicle.Times = strLocalCS;

                            LogHelper.WriteLog("更新CCXXB，LSH:" + strLcoalLSH + ",CLBH:" + strLocalCLBH + "，CS:" + strLocalCS);
                            ParameterSql parSql = SyncDataSql.GetUpadateCCXXBSql(DispatchVehicle);
                            int i = DB120Help.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i == 0)
                            {
                                LogHelper.WriteLog("车辆信息数据更新本地库失败本地流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH);
                            }
                            else
                            //成功更新车辆信息表中的车辆状态
                            {
                                sql = "update clxxb set clzt ='" + DispatchVehicle.VehicleZT + "' where clbh= '" + strLocalCLBH + "'";
                                i = DB120Help.ExecuteSql(sql);
                                if (i != 0)
                                {
                                    LogHelper.WriteLog("车辆状态更新成功 车辆编号:" + strLocalCLBH);
                                }

                                DispatchVehicleDataResp Data = new DispatchVehicleDataResp();
                                Data.CommandID = DispatchVehicle.CommandID + "Resp";
                                Data.DealRecordID = strTargetLSH;
                                Data.VehicleCode = strTargetCLBH;
                                Data.Times = strTargetCS;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }

                    }
                    //未在联网信息关联表关联主键 需要插入记录,同时虚拟该车的车辆
                    else
                    {
                        LogHelper.WriteLog("进入HasVehicleMatchRecord=false，LSH:" + strLcoalLSH);
                        strTargetLSH = DispatchVehicle.DealRecordID;
                        strTargetCS = DispatchVehicle.Times;
                        strTargetCLBH = DispatchVehicle.VehicleCode;
                        if (hasInsertedDispatchVehicleRecord(DispatchVehicle, UnitCode, strLcoalLSH, ref  strLocalCLBH, ref  strLocalCS))
                        {

                            //成功更新车辆信息表中的车辆状态
                            string sql = "update clxxb set clzt ='" + DispatchVehicle.VehicleZT + "' where clbh= '" + strLocalCLBH + "'";
                            int i = DB120Help.ExecuteSql(sql);
                            if (i != 0)
                            {
                                LogHelper.WriteLog("车辆状态更新成功 车辆编号:" + strLocalCLBH);
                            }
                            //主键关联
                            sql = "insert into LWCLTBDYB (locallsh,localCS,localCLBH,TargetLSH,TargetCS,TargetCLBH,TargetDWBH) values ('"
                                + strLcoalLSH + "','" + strLocalCS + "','" + strLocalCLBH + "','"
                                + strTargetLSH + "','" + strTargetCS + "','" + strTargetCLBH + "','" + UnitCode + "')";
                            i = DB120Help.ExecuteSql(sql);
                            if (i > 0)
                            {
                                LogHelper.WriteLog("车辆信息表主键关联成功本地流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                            }
                            else
                            {
                                LogHelper.WriteLog("车辆信息表主键关联失败本地流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                            }

                            DispatchVehicleDataResp Data = new DispatchVehicleDataResp();
                            Data.CommandID = DispatchVehicle.CommandID + "Resp";
                            Data.DealRecordID = strTargetLSH;
                            Data.VehicleCode = strTargetCLBH;
                            Data.Times = strTargetCS;
                            Data.Result = 1;
                            ExchangeDataResp(Data);
                        }
                    }
                }
                //非联网单直接更新不需要重发消息
                else
                {
                    DispatchVehicleDataResp Data = new DispatchVehicleDataResp();
                    Data.CommandID = DispatchVehicle.CommandID + "Resp";
                    Data.DealRecordID = strTargetLSH;
                    Data.VehicleCode = strTargetCLBH;
                    Data.Times = strTargetCS;
                    Data.Result = 1;
                    ExchangeDataResp(Data);
                }
            }
            catch (Exception ex)
            {
                DispatchVehicleDataResp Data = new DispatchVehicleDataResp();

                Data.CommandID = DispatchVehicle.CommandID + "Resp";
                Data.DealRecordID = DispatchVehicle.DealRecordID;
                Data.VehicleCode = DispatchVehicle.VehicleCode;
                Data.Times = DispatchVehicle.Times;
                Data.Result = 0;
                Data.FailtureReason = ex.Message;
                ExchangeDataResp(Data);
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 同步病历记录
        /// </summary>
        public void SyncWeb_MedicalRecords(Web_MedicalRecords MedicalRecords, string UnitCode)
        {
            try
            {
                string strLcoalLSH = "";
                string strLocalCS = "";
                string strLocalCLBH = "";
                string strLocalRecordId = "";
                string strTargetLSH = MedicalRecords.LSH;
                string strTargetCS = MedicalRecords.CS;
                string strTargetCLBH = MedicalRecords.CLBH;
                string strTargetRecordId = MedicalRecords.ID;

                if (IsLWDD(MedicalRecords.LSH, UnitCode, ref strLcoalLSH))
                {


                    //需要添加一条虚拟出车记录
                    if (!HasVehicleMatchRecord(MedicalRecords.LSH, MedicalRecords.CLBH, MedicalRecords.CS,
                        UnitCode, ref strLocalCS, ref strLocalCLBH))
                    {
                        //如果还未有出车记录的话不再虚拟，不插入等待重新插入
                        LogHelper.WriteLog("SyncWeb_MedicalRecords无出车记录，不插入患者信息。本地流水号:" + strLcoalLSH + " ID:" + strTargetRecordId + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                        return;
                        ////出车信息尚未关联,需先往出车信息表,生成一条记录
                        //DispatchVehicleData Dispatchdata = new DispatchVehicleData();

                        //if (hasInsertedDispatchVehicleRecord(Dispatchdata, UnitCode, strLcoalLSH, ref  strLocalCLBH, ref  strLocalCS))
                        //{
                        //    //主键关联
                        //    string sql = "insert into LWCLTBDYB (locallsh,localCS,localCLBH,TargetLSH,TargetCS,TargetCLBH,TargetDWBH) values ('"
                        //        + strLcoalLSH + "','" + strLocalCS + "','" + strLocalCLBH + "','"
                        //        + strTargetLSH + "','" + strTargetCS + "','" + strTargetCLBH + "','" + UnitCode + "')";
                        //    int i = DB120Help.ExecuteSql(sql);
                        //    if (i > 0)
                        //    {
                        //        LogHelper.WriteLog("车辆信息表主键关联成功本地流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                        //    }
                        //    else
                        //    {
                        //        LogHelper.WriteLog("车辆信息表主键关联失败本地流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                        //    }
                        //}
                        //else
                        //{
                        //    return;
                        //}
                    }

                    if (hasMedicalMatchRecords(strTargetRecordId, UnitCode, strTargetLSH, ref strLocalRecordId))
                    {
                        MedicalRecords.ID = strLocalRecordId;
                        MedicalRecords.CLBH = strLocalCLBH;
                        MedicalRecords.LSH = strLcoalLSH;
                        MedicalRecords.CS = strLocalCS;
                        ParameterSql parSql = SyncDataSql.GetUpadateMedicalRecordsSql(MedicalRecords);
                        int i = DB120Help.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                        if (i == 0)
                        {
                            LogHelper.WriteLog("病历记录数据更新本地库失败本地ID:" + MedicalRecords.ID + " 流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH);
                            return;
                        }

                        Web_MedicalRecordsResp Data = new Web_MedicalRecordsResp();
                        Data.CommandID = MedicalRecords.CommandID + "Resp";
                        Data.ID = strTargetRecordId;
                        Data.Result = 1;
                        ExchangeDataResp(Data);
                    }
                    //需要添加患者记录
                    else
                    {
                        if (hasInsertedMedicalRecords(MedicalRecords, strLcoalLSH, strLocalCS, strLocalCLBH, ref strLocalRecordId))
                        {
                            //将患者信息关联起来
                            string Sql = "insert into LWBLTBDYB (locallsh,localRecordId,TargetLSH,TargetRecordId,TargetDWBH) values (" +
                                strLcoalLSH + ",'" + strLocalRecordId + "','" + strTargetLSH + "','" + strTargetRecordId + "','" + UnitCode + "')";
                            int i = DB120Help.ExecuteSql(Sql);
                            if (i > 0)
                            {
                                LogHelper.WriteLog("患者病历记录主键关联成功");
                            }
                            else
                            {
                                LogHelper.WriteLog("患者病历记录主键关联失败");
                            }
                            Web_MedicalRecordsResp Data = new Web_MedicalRecordsResp();
                            Data.CommandID = MedicalRecords.CommandID + "Resp";
                            Data.ID = strTargetRecordId;
                            Data.Result = 1;
                            ExchangeDataResp(Data);
                        }
                    }
                }
                else
                {
                    Web_MedicalRecordsResp Data = new Web_MedicalRecordsResp();
                    Data.CommandID = MedicalRecords.CommandID + "Resp";
                    Data.ID = strTargetRecordId;
                    Data.Result = 1;
                    ExchangeDataResp(Data);
                }
            }
            catch (Exception ex)
            {
                Web_MedicalRecordsResp Data = new Web_MedicalRecordsResp();

                Data.CommandID = MedicalRecords.CommandID + "Resp";
                Data.ID = MedicalRecords.ID;
                Data.Result = 0;
                Data.FailtureReason = ex.Message;
                ExchangeDataResp(Data);
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        ///  同步病历填写项目与值对应关系数据
        /// </summary>
        public void SyncWeb_MedicalStatistics(Web_MedicalStatistics MedicalStatistics, string UnitCode)
        {
            try
            {
                string strLcoalLSH = "";
                string strLocalCS = "";
                string strLocalCLBH = "";
                string strLocalRecordId = "";
                string strLocalStatisticsId = "";
                string strTargetLSH = MedicalStatistics.LSH;
                string strTargetCS = MedicalStatistics.CS;
                string strTargetCLBH = MedicalStatistics.CLBH;
                string strTargetStatisticsId = MedicalStatistics.ID;
                string strTargetRecordId = MedicalStatistics.MEDICALRECORDSID;

                if (IsLWDD(MedicalStatistics.LSH, UnitCode, ref strLcoalLSH))
                {


                    //如果不存在出车对应记录，需要添加一条虚拟出车记录
                    if (!HasVehicleMatchRecord(MedicalStatistics.LSH, MedicalStatistics.CLBH, MedicalStatistics.CS,
                        UnitCode, ref strLocalCS, ref strLocalCLBH))
                    {
                        //如果还未有出车记录的话不再虚拟，不插入等待重新插入
                        LogHelper.WriteLog("SyncWeb_MedicalStatistics无出车记录，不插入患者信息。本地流水号:" + strLcoalLSH + " ID:" + strTargetRecordId + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                        return;
                        ////出车信息尚未关联,需先往出车信息表,生成一条记录
                        //DispatchVehicleData Dispatchdata = new DispatchVehicleData();

                        //if (hasInsertedDispatchVehicleRecord(Dispatchdata, UnitCode, strLcoalLSH, ref  strLocalCLBH, ref  strLocalCS))
                        //{
                        //    //主键关联
                        //    string sql = "insert into LWCLTBDYB (locallsh,localCS,localCLBH,TargetLSH,TargetCS,TargetCLBH,TargetDWBH) values ('"
                        //        + strLcoalLSH + "','" + strLocalCS + "','" + strLocalCLBH + "','"
                        //        + strTargetLSH + "','" + strTargetCS + "','" + strTargetCLBH + "','" + UnitCode + "')";
                        //    int i = DB120Help.ExecuteSql(sql);
                        //    if (i > 0)
                        //    {
                        //        LogHelper.WriteLog("车辆信息表主键关联成功本地流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                        //    }
                        //    else
                        //    {
                        //        LogHelper.WriteLog("车辆信息表主键关联失败本地流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                        //    }
                        //}
                        //else
                        //{
                        //    return;
                        //}
                    }
                    //如果不存在患者对应记录，需要添加一条虚拟患者记录
                    if (!hasMedicalMatchRecords(strTargetRecordId, UnitCode, strTargetLSH, ref strLocalRecordId))
                    {
                        LogHelper.WriteLog("SyncWeb_MedicalStatistics无出车记录，不插入患者信息。本地流水号:" + strLcoalLSH + " ID:" + strTargetRecordId + "  关联的流水号:" + strTargetLSH + " 车次:" + strTargetCS + " 车辆编号:" + strTargetCLBH);
                        return;
                        ////需要添加患者记录
                        //Web_MedicalRecords MedicalRecords = new Web_MedicalRecords();
                        //if (hasInsertedMedicalRecords(MedicalRecords, strLcoalLSH, strLocalCS, strLocalCLBH, ref strLocalRecordId))
                        //{
                        //    //将患者信息关联起来
                        //    string Sql = "insert into LWBLTBDYB (locallsh,localRecordId,TargetLSH,TargetRecordId,TargetDWBH) values (" +
                        //        strLcoalLSH + ",'" + strLocalRecordId + "','" + strTargetLSH + "','" + strTargetRecordId + "','" + UnitCode + "')";
                        //    int i = DB120Help.ExecuteSql(Sql);
                        //    if (i > 0)
                        //    {
                        //        LogHelper.WriteLog("患者病历记录主键关联成功");
                        //    }
                        //    else
                        //    {
                        //        LogHelper.WriteLog("患者病历记录主键关联失败");
                        //    }
                        //}
                        //else
                        //{
                        //    return;
                        //}
                    }
                    //是否存在病历项目-值对应数据
                    if (hasMedicalMatchStatistics(strTargetStatisticsId, UnitCode, strTargetLSH, ref strLocalStatisticsId))
                    {
                        MedicalStatistics.ID = strLocalStatisticsId;
                        MedicalStatistics.MEDICALRECORDSID = strLocalRecordId;
                        MedicalStatistics.CLBH = strLocalCLBH;
                        MedicalStatistics.LSH = strLcoalLSH;
                        MedicalStatistics.CS = strLocalCS;
                        ParameterSql parSql = SyncDataSql.GetUpadateMedicalStatisticsSql(MedicalStatistics);
                        int i = DB120Help.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                        if (i == 0)
                        {
                            LogHelper.WriteLog("病历记录数据更新本地库失败本地ID:" + MedicalStatistics.ID + " 流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH);

                        }
                        else
                        {
                            Web_MedicalStatisticsResp Data = new Web_MedicalStatisticsResp();

                            Data.CommandID = MedicalStatistics.CommandID + "Resp";
                            Data.ID = strTargetStatisticsId;
                            Data.Result = 1;
                            ExchangeDataResp(Data);
                        }
                    }
                    //需要添加病历项目-值对应数据
                    else
                    {
                        MedicalStatistics.CLBH = strLocalCLBH;
                        MedicalStatistics.LSH = strLcoalLSH;
                        MedicalStatistics.CS = strLocalCS;
                        MedicalStatistics.MEDICALRECORDSID = strLocalRecordId;
                        ParameterSql parSql = SyncDataSql.GetAddMedicalStatisticsSql(MedicalStatistics);
                        int i = DB120Help.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                        if (i <= 0)
                        {
                            LogHelper.WriteLog("病历项目-值对应数据更新本地库失败流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH);
                        }
                        else
                        {
                            //插入成功,则获取当前的ID
                            //string Sql = "select max(ID) from web_medicalstatistics where MEDICALRECORDSID='" + strLocalRecordId + "'";
                            string Sql = "select max(ID) from web_medicalstatistics where MEDICALRECORDSID='" + strLocalRecordId + "' and CONTROLID = '" + MedicalStatistics.CONTROLID + "'";
                            object obj = DB120Help.GetSingle(Sql);
                            strLocalStatisticsId = obj.ToString();
                            LogHelper.WriteLog("病历项目-值对应数据更新本地库成功本地ID:" + strLocalStatisticsId + " 流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH);

                            //create table LWBLGXTBDYB
                            //(
                            //    locallsh	   		本地流水号
                            //    localStatisticsID 	本地病历关系ID号
                            //    TargetLSH	   		对方流水号
                            //    TargetStatisticsID 	对方病历关系ID号
                            //    TargetDWBH	   		对方单位编号
                            // )

                            //将病历项目-值对应数据关联起来
                            Sql = "insert into LWBLGXTBDYB (locallsh,localStatisticsID,TargetLSH,TargetStatisticsID,TargetDWBH) values (" +
                                strLcoalLSH + ",'" + strLocalStatisticsId + "','" + strTargetLSH + "','" + strTargetStatisticsId + "','" + UnitCode + "')";
                            i = DB120Help.ExecuteSql(Sql);
                            if (i > 0)
                            {
                                LogHelper.WriteLog("病历项目-值对应数据主键关联成功");
                            }
                            else
                            {
                                LogHelper.WriteLog("病历项目-值对应数据主键关联失败");
                            }

                            Web_MedicalStatisticsResp Data = new Web_MedicalStatisticsResp();

                            Data.CommandID = MedicalStatistics.CommandID + "Resp";
                            Data.ID = strTargetStatisticsId;
                            Data.Result = 1;
                            ExchangeDataResp(Data);
                        }
                    }
                }
                else
                {
                    Web_MedicalStatisticsResp Data = new Web_MedicalStatisticsResp();

                    Data.CommandID = MedicalStatistics.CommandID + "Resp";
                    Data.ID = strTargetStatisticsId;
                    Data.Result = 1;
                    ExchangeDataResp(Data);
                }
            }
            catch (Exception ex)
            {
                Web_MedicalStatisticsResp Data = new Web_MedicalStatisticsResp();

                Data.CommandID = MedicalStatistics.CommandID + "Resp";
                Data.ID = MedicalStatistics.ID;
                Data.Result = 0;
                Data.FailtureReason = ex.Message;
                ExchangeDataResp(Data);
                LogHelper.WriteLog("", ex);
            }
        }

        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        ///  病历关系记录删除数据
        /// </summary>
        public void SyncLWBLGXTBDELB(LWBLGXTBDELB lwblgxtbdel, string UnitCode)
        {
            string strLocalStatisticsId = "";
            string strTargetStatisticsId = lwblgxtbdel.ID;
            string strsql = "select localStatisticsID from LWBLGXTBDYB where Targetdwbh= '" + UnitCode + "' and TargetStatisticsID = " + strTargetStatisticsId;
            object obj = DB120Help.GetSingle(strsql);
            if (obj != null)
            {
                strLocalStatisticsId = obj.ToString();
                strsql = "delete from web_medicalstatistics where id=" + strLocalStatisticsId + " and medicalrecordsid in (select localrecordid from lwbltbdyb)";
                int i = DB120Help.ExecuteSql(strsql);
                if (i > 0)
                {
                    LogHelper.WriteLog("病历关联信息删除成功");
                    strsql = "delete from lwblgxtbdyb where localStatisticsID =" + strLocalStatisticsId + " and Targetdwbh='" + UnitCode + "'";
                    i = DB120Help.ExecuteSql(strsql);
                    if (i > 0)
                    {
                        LogHelper.WriteLog("病历关联信息对应记录删除成功");
                    }
                }

            }



        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        ///  病历记录删除数据
        /// </summary>
        public void SyncLWBLTBDELB(LWBLTBDELB lwbltbdel, string UnitCode)
        {
            string strLocalRecordId = "";
            string strTargetRecordId = lwbltbdel.ID;
            string strsql = "select localRecordID from LWBLTBDYB where Targetdwbh= '" + UnitCode + "' and TargetRecordID = " + strTargetRecordId;
            object obj = DB120Help.GetSingle(strsql);
            if (obj != null)
            {
                strLocalRecordId = obj.ToString();
                strsql = "delete from web_medicalrecords where id=" + strLocalRecordId + " and lsh in (select locallsh from lwbltbdyb)";
                int i = DB120Help.ExecuteSql(strsql);
                if (i > 0)
                {
                    LogHelper.WriteLog("病历信息删除成功");
                    strsql = "delete from web_medicalStatistics where medicalrecordsid=" + strLocalRecordId;
                    i = DB120Help.ExecuteSql(strsql);
                    if (i > 0)
                    {
                        LogHelper.WriteLog("删除病历信息同时删除statistic值");
                    }
                    strsql = "delete from lwbltbdyb where localRecordID =" + strLocalRecordId + " and Targetdwbh='" + UnitCode + "'";
                    i = DB120Help.ExecuteSql(strsql);
                    if (i > 0)
                    {
                        LogHelper.WriteLog("病历信息对应记录删除成功");
                    }
                }

            }



        }


        /// <summary>
        /// 是否为联网调度单
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="dwbh"></param>
        /// <returns></returns>
        private bool IsLWDD(string lsh, string dwbh, ref string localLsh)
        {
            localLsh = "";
            bool result = false;
            try
            {
                string sql = "select LocalLSH from LWDDGLB where DDLX= '1' and RemoteLSH= '" + lsh + "' and RemoteDWBH = '" + dwbh + "' or sgsb='1' and RemoteLSH= '" + lsh + "' and RemoteDWBH = '" + dwbh + "'";
                object obj = DB120Help.GetSingle(sql);

                if (obj != null)
                {
                    localLsh = obj.ToString();
                    result = true;
                }
            }
            catch(Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            return result;
        }

        /// <summary>
        /// 是否已有车辆对应记录
        /// </summary>
        /// <param name="TargetLSH"></param>
        /// <param name="TargetCLBH"></param>
        /// <param name="TargetCS"></param>
        /// <param name="TargetDWBH"></param>
        /// <param name="LocalCS"></param>
        /// <param name="LocalCLBH"></param>
        /// <returns></returns>
        private bool HasVehicleMatchRecord(string TargetLSH, string TargetCLBH, string TargetCS, string TargetDWBH,
            ref string LocalCS, ref string LocalCLBH)
        {
            LocalCS = "";
            LocalCLBH = "";
            bool result = false;
            try
            {
                string sql = "select * from LWCLTBDYB where TargetLSH = '" + TargetLSH + "' and TargetCS = '" + TargetCS
                    + "' and TargetCLBH = '" + TargetCLBH + "' and TargetDWBH = '" + TargetDWBH + "'";
                DataTable dt = DB120Help.GetRecord(sql);
                if (dt.Rows.Count > 0)
                {
                    LocalCS = dt.Rows[0]["localCS"].ToString();
                    LocalCLBH = dt.Rows[0]["localCLBH"].ToString();
                    result = true;
                }
            }
            catch(Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            return result;
        }
        /// <summary>
        /// 出车同步同时检测调度分站记录
        /// </summary>
        /// <param name="LocalLSH"></param>
        /// <param name="PCSJ"></param>
        /// <param name="DWBH"></param>
        /// <returns></returns>
        private void CheckDispatchRecord(string LSH,string PCSJ,string dwbh)
        {

            try
            {   
                string zxzby="";
                string dwmc="";
                string sql = "select dwmc from dwxxb where dwbh='" + dwbh + "'";
                object obj = DB120Help.GetSingle(sql);
                if (obj != null)
                {
                    dwmc = obj.ToString();
                    sql = "select ZBY from sljlb where lsh='" + LSH + "'";
                    obj = DB120Help.GetSingle(sql);
                    if (obj != null)
                    {
                        zxzby = obj.ToString();
                    }
                    sql = "select lsh from ddfzjlb where lsh='" + LSH + "' and ccdw='" + dwmc + "'";
                    obj = DB120Help.GetSingle(sql);
                    if (obj == null)
                    {
                        sql = "insert into ddfzjlb (lsh,ccdw,fzddsj,zxzby) values ('" + LSH + "','" + dwmc + "',to_date('" + PCSJ + "','YYYY-MM-DD HH24:MI:SS'),'" + zxzby + "')";
                        int i = DB120Help.ExecuteSql(sql);
                        if (i > 0)
                        {
                            LOG.LogHelper.WriteLog("该分站调度记录插入成功:" + dwmc);
                        }
                        else
                        {
                            LOG.LogHelper.WriteLog("该分站调度记录插入失败:" + dwmc);
                        }
                    }
                }
                else
                {
                    LOG.LogHelper.WriteLog("该单位编号有问题:" + dwbh);
                }
            }
            catch(Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 出车同步同时检测呼救区域记录
        /// </summary>
        /// <param name="LocalLSH"></param>
        /// <param name="DWBH"></param>
        /// <returns></returns>
        private void CheckHJQY(string LSH, string dwbh)
        {
            try
            {
                string sql = "";
                //20160104 修改人:朱星汉 修改内容:添加hjqy与dwmc
                sql = "select sl.hjqy,sl.gxyy,lw.sgsb from lwddglb lw,sljlb sl where lw.locallsh='" + LSH + "' and sl.lsh=lw.locallsh";
                DataTable dt = DB120Help.GetRecord(sql);
                foreach (DataRow r in dt.Rows)
                {
                    if (r["sgsb"].ToString() == "1" && r["HJQY"].ToString() == "" && r["GXYY"].ToString() == "")
                    {
                        sql = "select * from dwxxb where dwbh = '" + dwbh + "'";
                        dt = DB120Help.GetRecord(sql);
                        foreach (DataRow k in dt.Rows)
                        {
                            string hjqy = k["SSQY"].ToString();
                            string gxyy = k["DWMC"].ToString();
                            sql = "update sljlb set hjqy='" + hjqy + "',gxyy='" + gxyy + "' where lsh='" + LSH + "'";
                            int i = DB120Help.ExecuteSql(sql);
                            if (i > 0)
                            {
                                LOG.LogHelper.WriteLog("突发公共事件呼救区域修改成功,该记录流水号:" + LSH);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 是否已成功插入出车信息表数据
        /// </summary>
        /// <param name="DispatchVehicle"></param>
        /// <param name="UnitCode"></param>
        /// <param name="strLcoalLSH"></param>
        /// <param name="strLocalCLBH"></param>
        /// <param name="strLocalCS"></param>
        /// <returns></returns>
        private bool hasInsertedDispatchVehicleRecord(DispatchVehicleData DispatchVehicle, string UnitCode, string strLcoalLSH, ref string strLocalCLBH, ref string strLocalCS)
        {
            bool result = false;
            try
            {
                //选取对应的虚拟车辆
                string sql = "select clbh from (select clbh,0 as zt from clxxb where ssdw= (select DWMC from dwxxb where dwbh='" + UnitCode + "') and (clzt = '任务完成' or clzt='待命') union select clbh,1 as zt from clxxb where ssdw=(select DWMC from dwxxb where dwbh='" + UnitCode + "')and clzt<>'待命' and clzt<>'任务完成')a order by a.zt";
                object obj = DB120Help.GetSingle(sql);
                if (obj != null)
                {
                    strLocalCLBH = obj.ToString();
                    //在本地库选取对应的车次
                    sql = "select nvl(max(cs),'00') from ccxxb where lsh ='" + strLcoalLSH + "'";
                    obj = DB120Help.GetSingle(sql);
                    strLocalCS = (int.Parse(obj.ToString()) + 1).ToString("00");
                    //将取出对应的本地流水号,车次,车辆编号已经本身的业务信息插入本地库,同时插入后将对应的主键在联网信息表中进行关联

                    DispatchVehicle.VehicleCode = strLocalCLBH;
                    DispatchVehicle.DealRecordID = strLcoalLSH;
                    DispatchVehicle.Times = strLocalCS;

                    LogHelper.WriteLog("新增CCXXB，LSH:" + strLcoalLSH + ",CLBH:" + strLocalCLBH + "，CS:" + strLocalCS);
                    ParameterSql parSql = SyncDataSql.GetAddCCXXBSql(DispatchVehicle);
                    int i = DB120Help.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                    if (i > 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    LogHelper.WriteLog("本地库没有" + UnitCode + "的车辆");
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            return result;
        }


        /// <summary>
        /// 是否已有病历对应记录
        /// </summary>
        /// <param name="strTargetRecordId"></param>
        /// <param name="TargetDWBH"></param>
        /// <param name="strLocalRecordId"></param>
        /// <returns></returns>
        private bool hasMedicalMatchRecords(string strTargetRecordId, string TargetDWBH, string strTargetLSH, ref string strLocalRecordId)
        {
            bool result = false;
            try
            {
                string Sql = "select * from LWBLTBDYB where TargetRecordId =" + strTargetRecordId + " and TargetLSH = '" + strTargetLSH + "' and TargetDWBH = '" + TargetDWBH + "' ";
                DataTable dt = DB120Help.GetRecord(Sql);
                //判断是否已经关联患者病历信息
                if (dt.Rows.Count > 0)
                {
                    strLocalRecordId = dt.Rows[0]["localRecordId"].ToString();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            return result;
        }


        /// <summary>
        /// 是否已成功插入病历记录表数据
        /// </summary>
        /// <returns></returns>
        private bool hasInsertedMedicalRecords(Web_MedicalRecords MedicalRecords, string strLcoalLSH, string strLocalCS, string strLocalCLBH, ref string strLocalRecordId)
        {
            bool result = false;
            try
            {
                MedicalRecords.CLBH = strLocalCLBH;
                MedicalRecords.LSH = strLcoalLSH;
                MedicalRecords.CS = strLocalCS;
                //20151215 修改人:朱星汉 修改内容:TIMPLATEFLAG,MEDICALTYPE字段不能为空,默认值为0
                if (MedicalRecords.TIMPLATEFLAG ==null ||MedicalRecords.TIMPLATEFLAG=="")
                {
                    MedicalRecords.TIMPLATEFLAG = "0";
                }
                if (MedicalRecords.MEDICALTYPE == null|| MedicalRecords.MEDICALTYPE=="")
                {
                    MedicalRecords.MEDICALTYPE = "0";
                }
                ParameterSql parSql = SyncDataSql.GetAddMedicalRecordsSql(MedicalRecords);
                int i = DB120Help.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                if (i <= 0)
                {
                    LogHelper.WriteLog("病历记录数据更新本地库失败流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH);
                }
                else
                {
                    //插入成功,则获取当前的ID
                    string Sql = "select max(ID) from web_medicalrecords where lsh='" + strLcoalLSH + "' and cs='" + strLocalCS + "' and clbh ='" + strLocalCLBH + "'";
                    object obj = DB120Help.GetSingle(Sql);
                    strLocalRecordId = obj.ToString();
                    LogHelper.WriteLog("病历记录数据更新本地库成功本地ID:" + strLocalRecordId + " 流水号:" + strLcoalLSH + " 车次:" + strLocalCS + " 车辆编号:" + strLocalCLBH);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            return result;
        }

        /// <summary>
        /// 是否已有病历项目-值对应记录的对应记录
        /// </summary>
        /// <param name="strTargetStatisticsId"></param>
        /// <param name="TargetDWBH"></param>
        /// <param name="strTargetLSH"></param>
        /// <param name="strStatisticsId"></param>
        /// <returns></returns>
        private bool hasMedicalMatchStatistics(string strTargetStatisticsId, string TargetDWBH, string strTargetLSH, ref string strLocalStatisticsId)
        {
            //5.LWBLGXTBDYB 联网病历关系同步对应表
            //create table LWBLGXTBDYB
            //(
            //    locallsh	   		本地流水号
            //    localStatisticsID 	本地病历关系ID号
            //    TargetLSH	   		对方流水号
            //    TargetStatisticsID 	对方病历关系ID号
            //    TargetDWBH	   		对方单位编号
            // )
            bool result = false;
            try
            {
                string Sql = "select * from LWBLGXTBDYB where TargetStatisticsID =" + strTargetStatisticsId + " and TargetLSH = '" + strTargetLSH + "' and TargetDWBH = '" + TargetDWBH + "' ";
                DataTable dt = DB120Help.GetRecord(Sql);
                //判断是否已经关联患者病历信息
                if (dt.Rows.Count > 0)
                {
                    strLocalStatisticsId = dt.Rows[0]["localStatisticsID"].ToString();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            return result;
        }
    }
}
