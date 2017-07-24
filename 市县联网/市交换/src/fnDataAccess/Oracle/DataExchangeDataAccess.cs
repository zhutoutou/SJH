using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.LOG;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.fnDataAccess.Oracle.SQl;
using System.Data;
using System.Collections;
using System.Configuration;
using ZIT.SJHServer.Model.DispatchFunction;
using ZIT.SJHServer.fnArgs;
using ZIT.Utility;

namespace ZIT.SJHServer.fnDataAccess.Oracle
{
    /// <summary>
    /// 数据交换数据入库和更新
    /// </summary>
    public class DataExchangeDataAccess : DataExchangeRespEvent, IDataExchangeDataAccess
    {
        private void ExchangeDataResp(VehicleStatusResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(VehicleDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(SysUserDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(PVRelationResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(DealDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(DispatchVehicleDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(SuffererDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(SuffererCaseHistoryDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(CallRcordDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(UnitInfoDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(LargeSlipDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(DispatchStationInfoDataResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(Web_MedicalProjectResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(Web_MedicalProjectValueResp message)
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
        private void ExchangeDataResp(BLJCXXBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(HJQYBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(LDLXBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(ZBYXXBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(ZZBResp message)
        {
            OnMessageDataExchange(message);
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        private void ExchangeDataResp(LWBLGXTBDELBResp message)
        {
            OnMessageDataExchange(message);
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        private void ExchangeDataResp(LWBLTBDELBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(DXSGBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(LWDDGLBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(LWCLTBDYBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(LWBLTBDYBResp message)
        {
            OnMessageDataExchange(message);
        }
        private void ExchangeDataResp(LWBLGXTBDYBResp message)
        {
            OnMessageDataExchange(message);
        }


        //20151201 修改人:朱星汉 修改内容:判断该信息在全局库是否存在添加行政编码
        public void InsertVehicleStatus(VehicleStatus VehicleStatus, string AreaCode)
        {
            try
            {
                DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                string ID = SelSql.GetVehicleID(VehicleStatus.Mobile,AreaCode);
                bool VehicleID = SelSql.GetBoolVehicleID(ID,AreaCode);
                if (VehicleID == true)
                {
                    string Sql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(VehicleStatus, ID, AreaCode);
                    int i = DBHelperOracle.ExecuteSql(Sql);
                    if (i > 0)
                    {
                        VehicleStatusResp Data = new VehicleStatusResp();
                        Data.CommandID = "VehicleStatusResp";
                        Data.DWBH = VehicleStatus.DWBH;
                        Data.Result = 1;
                        Data.Mobile = VehicleStatus.Mobile;
                        ExchangeDataResp(Data);
                    }
                    else
                    {
                        VehicleStatusResp Data = new VehicleStatusResp();
                        Data.CommandID = "VehicleStatusResp";
                        Data.DWBH = VehicleStatus.DWBH;
                        Data.Result = 0;
                        Data.FailtureReason = "更新失败";
                        Data.Mobile = VehicleStatus.Mobile;
                        ExchangeDataResp(Data);
                    }
                }
                else
                {
                    string Sql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(VehicleStatus, ID, AreaCode);
                    int i = DBHelperOracle.ExecuteSql(Sql);
                    if (i > 0)
                    {
                        VehicleStatusResp Data = new VehicleStatusResp();
                        Data.CommandID = "VehicleStatusResp";
                        Data.DWBH = VehicleStatus.DWBH;
                        Data.Result = 1;
                        Data.Mobile = VehicleStatus.Mobile;
                        ExchangeDataResp(Data);
                    }
                    else
                    {
                        VehicleStatusResp Data = new VehicleStatusResp();
                        Data.CommandID = "VehicleStatusResp";
                        Data.DWBH = VehicleStatus.DWBH;
                        Data.Result = 0;
                        Data.FailtureReason = "更新失败";
                        Data.Mobile = VehicleStatus.Mobile;
                        ExchangeDataResp(Data);
                    }
                }
            }
            catch (Exception ex)
            {
                VehicleStatusResp Data = new VehicleStatusResp();
                Data.CommandID = "VehicleStatusResp";
                Data.DWBH = VehicleStatus.DWBH;
                Data.Result = 0;
                Data.FailtureReason = ex.Message;
                Data.Mobile = VehicleStatus.Mobile;
                ExchangeDataResp(Data);
            }

        }
        /// <summary>
        /// 车辆基础数据
        /// </summary>
        public void InsertVehicleData(List<VehicleData> VehicleData, string AreaCode)
        {
            if (VehicleData.Count > 0)
            {
                foreach (VehicleData item in VehicleData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool VehicleNo = SelSql.GetBoolVehicleData(item.VehicleCode,AreaCode);
                        if (VehicleNo == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                VehicleDataResp(true, item);
                            }
                        }
                        else
                        {
                            //string VehicleNumber= SelSql.GetVehicleNo(item.Mobile);
                            string sql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(sql);
                            if (i > 0)
                            {
                                VehicleDataResp(true, item);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //失败
                        VehicleDataResp Data = new VehicleDataResp();
                        
                        Data.CommandID = item.CommandID + "Resp";
                        Data.EngineNumber = item.EngineNumber;
                        Data.VehicleCode = item.VehicleCode;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        OnMessageDataExchange(Data);
                        LogHelper.WriteLog("InsertVehicleData", ex);
                    }
                }
            }
        }
        private void GPSVehicleData(VehicleData item, DataExchangeDataAccessSelectSql SelSql, string ID, string AreaCode)
        {
            try
            {
                bool j = false;
                bool GpsVehicleNo = SelSql.GetBoolGpsVehicleData(item.VehicleCode,AreaCode);
                if (GpsVehicleNo == true)
                {
                    ArrayList ListSql = DataExchangeDataAccessUpdateSql.GetGpsVehicleDataAccessSql(item, ID);
                    j = GPSDBHelperOracle.ExecuteSqlTranResult(ListSql);
                }
                else
                {
                    ArrayList ListSql = DataExchangeDataAccessSql.GetGpsVehicleDataAccessSql(item, ID);
                    j = GPSDBHelperOracle.ExecuteSqlTranResult(ListSql);
                }
                VehicleDataResp(j, item);
            }
             catch (Exception ex) { LogHelper.WriteLog("" , ex); }
        }
        private void BSSVehicleData(VehicleData item, DataExchangeDataAccessSelectSql SelSql, string ID, string AreaCode)
        {
            try
            {
                bool j = false;
                bool BSSVehicleNo = SelSql.GetBoolBSSVehicleData(item.VehicleCode,AreaCode);
                if (BSSVehicleNo == true)
                {
                    ArrayList ListSql = DataExchangeDataAccessUpdateSql.GetBSSVehicleDataAccessSql(item, ID);
                    j = GPSDBHelperOracle.ExecuteSqlTranResult(ListSql);
                }
                else
                {
                    ArrayList ListSql = DataExchangeDataAccessSql.GetBSSVehicleDataAccessSql(item, ID);
                    j = GPSDBHelperOracle.ExecuteSqlTranResult(ListSql);
                }
                VehicleDataResp(j, item);
                
            }
            catch (Exception ex) { throw ex; }
        }
        private void VehicleDataResp(bool j, VehicleData item)
        {
            try
            {
                if (j == true)
                {
                    VehicleDataResp Data = new VehicleDataResp();
                    
                    Data.CommandID = item.CommandID + "Resp";
                    Data.EngineNumber = item.EngineNumber;
                    Data.VehicleCode = item.VehicleCode;
                    Data.Result = 1;
                    ExchangeDataResp(Data);
                }
                else
                {
                    VehicleDataResp Data = new VehicleDataResp();
                    
                    Data.CommandID = item.CommandID + "Resp";
                    Data.EngineNumber = item.EngineNumber;
                    Data.VehicleCode = item.VehicleCode;
                    Data.Result = 0;
                    Data.FailtureReason = "写入GPS库失败";
                    OnMessageDataExchange(Data);

                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        ///  系统人员数据
        /// </summary>
        public void InsertSysUserData(List<SysUserData> SysUserData, string AreaCode)
        {
            if (SysUserData.Count > 0)
            {
                foreach (SysUserData item in SysUserData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool SysUser = SelSql.GetBoolSysUserData(item.UserName, AreaCode);
                        if (SysUser == true)
                        {
                            ParameterSql sql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(sql.StrSql, sql.OrclPar);
                            if (i > 0)
                            {
                                SysUserDataResp Data = new SysUserDataResp();
                                
                                Data.CommandID = item.CommandID + "Resp";
                                Data.Name = item.Name;
                                Data.Result = 1;
                                Data.UserName = item.UserName;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql sql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(sql.StrSql, sql.OrclPar);
                            if (i > 0)
                            {
                                SysUserDataResp Data = new SysUserDataResp();
                                
                                Data.CommandID = item.CommandID + "Resp";
                                Data.Name = item.Name;
                                Data.Result = 1;
                                Data.UserName = item.UserName;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SysUserDataResp Data = new SysUserDataResp();
                        
                        Data.CommandID = item.CommandID + "Resp";
                        Data.Name = item.Name;
                        Data.Result = 0;
                        Data.UserName = item.UserName;
                        Data.FailtureReason = ex.Message;
                        //成功
                        ExchangeDataResp(Data);
                    }
                }
            }

        }
        /// <summary>
        /// 急救人员及急救车辆关系
        /// </summary>
        public void InsertPVRelation(List<PVRelation> PVRelation, string AreaCode)
        {
            if (PVRelation.Count > 0)
            {
                foreach (PVRelation item in PVRelation)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql selSql = new DataExchangeDataAccessSelectSql();
                        string VehicleNo = selSql.GetVehicleNo(item.Mobile,AreaCode);
                        if (VehicleNo == "")
                        {
                            PVRelationResp PVRResp = new PVRelationResp();
                            
                            PVRResp.CommandID = item.CommandID + "Resp";
                            PVRResp.Doctor = item.Doctor;
                            PVRResp.Driver = item.Driver;
                            PVRResp.FailtureReason = "车辆编号不存在";
                            PVRResp.Flag = int.Parse(item.Flag);
                            PVRResp.Mobile = item.Mobile;
                            PVRResp.Nurse = item.Nurse;
                            PVRResp.Result = 0;
                            PVRResp.StretcherPerson = item.StretcherPerson;
                            PVRResp.Index = item.Index;
                            OnMessageDataExchange(PVRResp);

                        }
                        else
                        {
                            ArrayList List = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, VehicleNo, AreaCode);
                            bool PVRel = DBHelperOracle.ExecuteSqlTranResult(List);
                            if (PVRel == true)
                            {
                                PVRelationResp PVRResp = new PVRelationResp();
                                PVRResp.CommandID = item.CommandID + "Resp";
                                PVRResp.Doctor = item.Doctor;
                                PVRResp.Driver = item.Driver;
                                PVRResp.Flag = int.Parse(item.Flag);
                                PVRResp.Mobile = item.Mobile;
                                PVRResp.Nurse = item.Nurse;
                                PVRResp.Result = 1;
                                PVRResp.StretcherPerson = item.StretcherPerson;
                                PVRResp.Index = item.Index;
                                OnMessageDataExchange(PVRResp);
                            }
                            else
                            {
                                PVRelationResp PVRResp = new PVRelationResp();
                                PVRResp.CommandID = item.CommandID + "Resp";
                                PVRResp.Doctor = item.Doctor;
                                PVRResp.Driver = item.Driver;
                                PVRResp.FailtureReason = "写入数据库失败";
                                PVRResp.Flag = int.Parse(item.Flag);
                                PVRResp.Mobile = item.Mobile;
                                PVRResp.Nurse = item.Nurse;
                                PVRResp.Result = 0;
                                PVRResp.StretcherPerson = item.StretcherPerson;
                                PVRResp.Index = item.Index;
                                OnMessageDataExchange(PVRResp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        PVRelationResp PVRResp = new PVRelationResp();
                        PVRResp.CommandID = item.CommandID + "Resp";
                        PVRResp.Doctor = item.Doctor;
                        PVRResp.Driver = item.Driver;
                        PVRResp.FailtureReason = ex.Message;
                        PVRResp.Flag = int.Parse(item.Flag);
                        PVRResp.Mobile = item.Mobile;
                        PVRResp.Nurse = item.Nurse;
                        PVRResp.Result = 0;
                        PVRResp.StretcherPerson = item.StretcherPerson;
                        PVRResp.Index = item.Index;
                        OnMessageDataExchange(PVRResp);
                    }
                }
            }
        }
        /// <summary>
        /// 受理信息数据
        /// </summary>
        public void InsertDealData(List<DealData> DealData, string AreaCode)
        {
            if (DealData.Count > 0)
            {
                foreach (DealData item in DealData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool DealRecord = SelSql.GetBoolDealData(item.DealRecordID,AreaCode);
                        if (DealRecord == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DealDataResp Data = new DealDataResp();
                                Data.CommandID = item.CommandID + "Resp";
                                Data.DealRecordID = item.DealRecordID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DealDataResp Data = new DealDataResp();
                                Data.CommandID = item.CommandID + "Resp";
                                Data.DealRecordID = item.DealRecordID;

                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DealDataResp Data = new DealDataResp();
                        
                        Data.CommandID = item.CommandID + "Resp";
                        Data.DealRecordID = item.DealRecordID;
                        Data.FailtureReason = ex.Message;
                        Data.Result = 0;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 出车信息数据
        /// </summary>
        public void InsertDispatchVehicleData(List<DispatchVehicleData> DispatchVehicleData, string AreaCode)
        {
            if (DispatchVehicleData.Count > 0)
            {
                foreach (DispatchVehicleData item in DispatchVehicleData)
                {
                    DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                    try
                    {
                        bool DispatchVehicle = SelSql.GetDispatchVehicleData(item.DealRecordID, item.VehicleCode, item.Times, AreaCode);
                        if (DispatchVehicle == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DispatchVehicleDataResp Data = new DispatchVehicleDataResp();
                                Data.CommandID = item.CommandID + "Resp";
                                Data.DealRecordID = item.DealRecordID;
                                Data.VehicleCode = item.VehicleCode;
                                Data.Times = item.Times;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DispatchVehicleDataResp Data = new DispatchVehicleDataResp();
                                Data.CommandID = item.CommandID + "Resp";
                                Data.DealRecordID = item.DealRecordID;
                                Data.VehicleCode = item.VehicleCode;
                                Data.Times = item.Times;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DispatchVehicleDataResp Data = new DispatchVehicleDataResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.DealRecordID = item.DealRecordID;
                        Data.VehicleCode = item.VehicleCode;
                        Data.Times = item.Times;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }

        }
        /// <summary>
        /// 患者信息数据
        /// </summary>
        public void InsertSuffererData(List<SuffererData> SuffererData, string AreaCode)
        {
            if (SuffererData.Count > 0)
            {
                foreach (SuffererData item in SuffererData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        //20151201 修改人:朱星汉 修改内容:不在通过车载电话判断车辆信息
                        //string VehicleNo = SelSql.GetVehicleNo(item.Mobile);
                        bool Vehicle = SelSql.GetBoolVehicleData(item.VehicleNo,AreaCode);
                        if (Vehicle == false)
                        {
                            SuffererDataResp Data = new SuffererDataResp();
                            
                            Data.CommandID = item.CommandID + "Resp";
                            Data.DealRecordID = item.DealRecordID;
                            Data.DispatchVehicleID = item.DispatchVehicleID;
                            //20151201 修改人:朱星汉 修改内容:添加车辆编号
                            Data.VehicleNo = item.VehicleNo;
                            Data.Mobile = item.Mobile;
                            Data.SuffererNo = item.SuffererNo;
                            Data.SuffererName = item.SuffererName;
                            Data.Result = 0;
                            Data.FailtureReason = "没有上传车辆编号信息";
                            ExchangeDataResp(Data);
                        }
                        else
                        {
                            bool Sufferer = SelSql.GetSuffererData(item.DealRecordID, item.VehicleNo,AreaCode);
                            if (Sufferer == true)
                            {
                                ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, item.VehicleNo, AreaCode);
                                int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                                if (i > 0)
                                {
                                    SuffererDataResp Data = new SuffererDataResp();
                                    
                                    Data.CommandID = item.CommandID + "Resp";
                                    Data.DealRecordID = item.DealRecordID;
                                    Data.DispatchVehicleID = item.DispatchVehicleID;
                                    //20151201 修改人:朱星汉 修改内容:添加车辆编号
                                    Data.VehicleNo = item.VehicleNo;
                                    Data.Mobile = item.Mobile;
                                    Data.SuffererNo = item.SuffererNo;
                                    Data.SuffererName = item.SuffererName;
                                    Data.Result = 1;
                                    ExchangeDataResp(Data);
                                }
                            }
                            else
                            {
                                ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, item.VehicleNo, AreaCode);
                                int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                                if (i > 0)
                                {
                                    SuffererDataResp Data = new SuffererDataResp();
                                    
                                    Data.CommandID = item.CommandID + "Resp";
                                    Data.DealRecordID = item.DealRecordID;
                                    Data.DispatchVehicleID = item.DispatchVehicleID;
                                    //20151201 修改人:朱星汉 修改内容:添加车辆编号
                                    Data.VehicleNo = item.VehicleNo;
                                    Data.Mobile = item.Mobile;
                                    Data.SuffererNo = item.SuffererNo;
                                    Data.SuffererName = item.SuffererName;
                                    Data.Result = 1;
                                    ExchangeDataResp(Data);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SuffererDataResp Data = new SuffererDataResp();
                        
                        Data.CommandID = item.CommandID + "Resp";
                        Data.DealRecordID = item.DealRecordID;
                        Data.DispatchVehicleID = item.DispatchVehicleID;
                        //20151201 修改人:朱星汉 修改内容:添加车辆编号
                        Data.VehicleNo = item.VehicleNo;
                        Data.Mobile = item.Mobile;
                        Data.SuffererNo = item.SuffererNo;
                        Data.SuffererName = item.SuffererName;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 患者病例信息
        /// </summary>
        public void InsertSuffererCaseHistoryData(List<SuffererCaseHistoryData> SuffererCaseHistoryData, string AreaCode)
        {
            if (SuffererCaseHistoryData.Count > 0)
            {
                foreach (SuffererCaseHistoryData item in SuffererCaseHistoryData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        //20151201 修改人:朱星汉 修改内容:不在通过车载电话判断车辆信息
                        //string VehicleNo = SelSql.GetVehicleNo(item.Mobile);
                        bool Vehicle = SelSql.GetBoolVehicleData(item.VehicleNo,AreaCode);
                        if (Vehicle == false)
                        {
                            SuffererCaseHistoryDataResp Data = new SuffererCaseHistoryDataResp();
                            
                            Data.CommandID = item.CommandID + "Resp";
                            Data.DealRecordID = item.DealRecordID;
                            Data.DispatchVehicleID = item.DispatchVehicleID;
                            //20151201 修改人:朱星汉 修改内容:添加车辆编号
                            Data.VehicleNo = item.VehicleNo;
                            Data.Mobile = item.Mobile;
                            Data.SuffererNo = item.SuffererNo;
                            Data.SuffererName = item.SuffererName;
                            Data.Result = 0;
                            Data.FailtureReason = "没有上传车辆编号信息";
                            ExchangeDataResp(Data);
                        }
                        else
                        {
                            bool SuffererCaseHistory = SelSql.GetSuffererCaseHistoryData(item.DealRecordID, item.VehicleNo,AreaCode);
                            if (SuffererCaseHistory == true)
                            {
                                ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, item.VehicleNo, AreaCode);
                                int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                                if (i > 0)
                                {
                                    SuffererCaseHistoryDataResp Data = new SuffererCaseHistoryDataResp();
                                    
                                    Data.CommandID = item.CommandID + "Resp";
                                    Data.DealRecordID = item.DealRecordID;
                                    Data.DispatchVehicleID = item.DispatchVehicleID;
                                    //20151201 修改人:朱星汉 修改内容:添加车辆编号
                                    Data.VehicleNo = item.VehicleNo;
                                    Data.Mobile = item.Mobile;
                                    Data.SuffererNo = item.SuffererNo;
                                    Data.SuffererName = item.SuffererName;
                                    Data.Result = 1;
                                    ExchangeDataResp(Data);
                                }
                            }
                            else
                            {
                                ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, item.VehicleNo, AreaCode);
                                int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                                if (i > 0)
                                {
                                    SuffererCaseHistoryDataResp Data = new SuffererCaseHistoryDataResp();
                                    
                                    Data.CommandID = item.CommandID + "Resp";
                                    Data.DealRecordID = item.DealRecordID;
                                    Data.DispatchVehicleID = item.DispatchVehicleID;
                                    //20151201 修改人:朱星汉 修改内容:添加车辆编号
                                    Data.VehicleNo = item.VehicleNo;
                                    Data.Mobile = item.Mobile;
                                    Data.SuffererNo = item.SuffererNo;
                                    Data.SuffererName = item.SuffererName;
                                    Data.Result = 1;
                                    ExchangeDataResp(Data);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SuffererCaseHistoryDataResp Data = new SuffererCaseHistoryDataResp();
                        
                        Data.CommandID = item.CommandID + "Resp";
                        Data.DealRecordID = item.DealRecordID;
                        Data.DispatchVehicleID = item.DispatchVehicleID;
                        //20151201 修改人:朱星汉 修改内容:添加车辆编号
                        Data.VehicleNo = item.VehicleNo;
                        Data.Mobile = item.Mobile;
                        Data.SuffererNo = item.SuffererNo;
                        Data.SuffererName = item.SuffererName;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 呼叫记录数据
        /// </summary>
        public void InsertCallRcordData(List<CallRcordData> CallRcordData, string AreaCode)
        {
            LogHelper.WriteLog("InsertCallRcordData开始.");
            if (CallRcordData.Count > 0)
            {
                foreach (CallRcordData item in CallRcordData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        LogHelper.WriteLog("操作Get开始.");
                        bool CallRcord = SelSql.GetCallRcordData(item.CallID,AreaCode);
                        LogHelper.WriteLog("操作Get结束.");
                        if (CallRcord == true)
                        {
                            
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            LogHelper.WriteLog("操作Update开始.");
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            LogHelper.WriteLog("操作Update结束.");
                            if (i > 0)
                            {
                                CallRcordDataResp Data = new CallRcordDataResp();
                                Data.CallID = item.CallID;
                                Data.CommandID = item.CommandID + "Resp";
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            LogHelper.WriteLog("操作Insert开始.");
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            LogHelper.WriteLog("操作Insert结束.");
                            if (i > 0)
                            {
                                CallRcordDataResp Data = new CallRcordDataResp();
                                Data.CallID = item.CallID;
                                Data.CommandID = item.CommandID + "Resp";
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CallRcordDataResp Data = new CallRcordDataResp();
                        Data.CallID = item.CallID;
                        Data.CommandID = item.CommandID + "Resp";
                        Data.FailtureReason = ex.Message;
                        Data.Result = 0;
                        ExchangeDataResp(Data);
                    }
                }
            }
            LogHelper.WriteLog("InsertCallRcordData结束.");
        }
        /// <summary>
        /// 单位信息上报
        /// </summary>
        public void InsertUnitInfoData(List<UnitInfoData> UnitInfoData, string AreaCode)
        {
            if (UnitInfoData.Count > 0)
            {
                foreach (UnitInfoData item in UnitInfoData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool UnitCode = SelSql.GetUnitInfoData(item.UnitCode,AreaCode);
                        if (UnitCode == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                UnitInfoResp(i, item);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                UnitInfoResp(i, item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        UnitInfoDataResp Data = new UnitInfoDataResp();
                        
                        Data.CommandID = item.CommandID + "Resp";
                        Data.UnitCode = item.UnitCode;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 更新BSS库单位信息
        /// </summary>
        /// <param name="item"></param>
        /// <param name="SelSql"></param>
        private void BSSUnitInfoData(UnitInfoData item, DataExchangeDataAccessSelectSql SelSql,string AreaCode)
        {
            try
            {
                int j = 0;
                bool BSSUnitCode = SelSql.GetGpsUnitInfoData(item.UnitCode,AreaCode);
                if (BSSUnitCode == true)
                {
                    string sql = DataExchangeDataAccessUpdateSql.GetBSSUnitInfoDataAccessSql(item);
                    j = GPSDBHelperOracle.ExecuteSql(sql);
                }
                else
                {
                    string GpsSql = DataExchangeDataAccessSql.GetBSSUnitInfoDataAccessSql(item);
                    j = GPSDBHelperOracle.ExecuteSql(GpsSql);
                }
                UnitInfoResp(j, item);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 更新GPS库单位信息
        /// </summary>
        /// <param name="item"></param>
        /// <param name="SelSql"></param>
        private void GSPUnitInfoData(UnitInfoData item, DataExchangeDataAccessSelectSql SelSql, string AreaCode)
        {
            try
            {
                int j = 0;
                bool GpsUnitCode = SelSql.GetGpsUnitInfoData(item.UnitCode,AreaCode);
                if (GpsUnitCode == true)
                {
                    string sql = DataExchangeDataAccessUpdateSql.GetGpsUnitInfoDataAccessSql(item);
                    j = GPSDBHelperOracle.ExecuteSql(sql);
                }
                else
                {
                    string GpsSql = DataExchangeDataAccessSql.GetGpsUnitInfoDataAccessSql(item);
                    j = GPSDBHelperOracle.ExecuteSql(GpsSql);
                }
                UnitInfoResp(j, item);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UnitInfoResp(int j, UnitInfoData item)
        {
            try
            {
                if (j > 0)
                {
                    UnitInfoDataResp Data = new UnitInfoDataResp();
                    Data.CommandID = item.CommandID + "Resp";
                    Data.UnitCode = item.UnitCode;
                    Data.Result = 1;
                    
                    ExchangeDataResp(Data);
                }
                else
                {
                    UnitInfoDataResp Data = new UnitInfoDataResp();
                    Data.CommandID = item.CommandID + "Resp";
                    Data.UnitCode = item.UnitCode;
                    Data.Result = 0;
                    
                    Data.FailtureReason = "上传失败";
                    ExchangeDataResp(Data);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 大型事故数据
        /// </summary>
        public void InsertLargeSlipData(List<LargeSlipData> LargeSlipData, string AreaCode)
        {
            if (LargeSlipData.Count > 0)
            {
                foreach (LargeSlipData item in LargeSlipData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool LargeSlip = SelSql.GetLargeSlipData(item.ID,AreaCode);
                        if (LargeSlip == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LargeSlipDataResp Data = new LargeSlipDataResp();
                                
                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LargeSlipDataResp Data = new LargeSlipDataResp();
                                
                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LargeSlipDataResp Data = new LargeSlipDataResp();
                        
                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 分站记录信息数据
        /// </summary>
        public void InsertDispatchStationInfoData(List<DispatchStationInfoData> DispatchStationInfoData, string AreaCode)
        {
            if (DispatchStationInfoData.Count > 0)
            {
                foreach (DispatchStationInfoData item in DispatchStationInfoData)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool StationInfo = SelSql.GetDispatchStationInfoData(item.ID, item.DispatchVehicleUnit, AreaCode);
                        if (StationInfo == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DispatchStationInfoDataResp Data = new DispatchStationInfoDataResp();
                                
                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DispatchStationInfoDataResp Data = new DispatchStationInfoDataResp();
                                
                                Data.ID = item.ID;
                                Data.CommandID = item.CommandID + "Resp";
                                Data.DispatchVehicleUnit = item.DispatchVehicleUnit;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DispatchStationInfoDataResp Data = new DispatchStationInfoDataResp();
                        
                        Data.ID = item.ID;
                        Data.CommandID = item.CommandID + "Resp";
                        Data.DispatchVehicleUnit = item.DispatchVehicleUnit;
                        Data.FailtureReason = ex.Message;
                        Data.Result = 0;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        ///  病历填写项目
        /// </summary>
        public void InsertWeb_MedicalProject(List<Web_MedicalProject> MedicalProject, string AreaCode)
        {
            if (MedicalProject.Count > 0)
            {
                foreach (Web_MedicalProject item in MedicalProject)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetWeb_MedicalProject(item.ID, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalProjectResp Data = new Web_MedicalProjectResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalProjectResp Data = new Web_MedicalProjectResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Web_MedicalProjectResp Data = new Web_MedicalProjectResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        ///  病历填写项目值
        /// </summary>
        public void InsertWeb_MedicalProjectValue(List<Web_MedicalProjectValue> MedicalProjectValue, string AreaCode)
        {
            if (MedicalProjectValue.Count > 0)
            {
                foreach (Web_MedicalProjectValue item in MedicalProjectValue)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetWeb_MedicalProjectValue(item.ID, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalProjectValueResp Data = new Web_MedicalProjectValueResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalProjectValueResp Data = new Web_MedicalProjectValueResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Web_MedicalProjectValueResp Data = new Web_MedicalProjectValueResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        /// 病历记录
        /// </summary>
        public void InsertWeb_MedicalRecords(List<Web_MedicalRecords> MedicalRecords, string AreaCode)
        {
            if (MedicalRecords.Count > 0)
            {
                foreach (Web_MedicalRecords item in MedicalRecords)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetWeb_MedicalRecords(item.ID, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalRecordsResp Data = new Web_MedicalRecordsResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalRecordsResp Data = new Web_MedicalRecordsResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Web_MedicalRecordsResp Data = new Web_MedicalRecordsResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        ///  病历填写项目与值对应关系数据
        /// </summary>
        public void InsertWeb_MedicalStatistics(List<Web_MedicalStatistics> MedicalStatistics, string AreaCode)
        {
            if (MedicalStatistics.Count > 0)
            {
                foreach (Web_MedicalStatistics item in MedicalStatistics)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetWeb_MedicalStatistics(item.ID, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalStatisticsResp Data = new Web_MedicalStatisticsResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                Web_MedicalStatisticsResp Data = new Web_MedicalStatisticsResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Web_MedicalStatisticsResp Data = new Web_MedicalStatisticsResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        public void InsertBLJCXXB(List<BLJCXXB> Bljcxxb, string AreaCode)
        {
            if (Bljcxxb.Count > 0)
            {
                foreach (BLJCXXB item in Bljcxxb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetBLJCXXB(item.LX,item.MC, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                BLJCXXBResp Data = new BLJCXXBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LX = item.LX;
                                Data.MC = item.MC;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                BLJCXXBResp Data = new BLJCXXBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LX = item.LX;
                                Data.MC = item.MC;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        BLJCXXBResp Data = new BLJCXXBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.LX = item.LX;
                        Data.MC = item.MC;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        public void InsertHJQYB(List<HJQYB> Hjqyb, string AreaCode)
        {
            if (Hjqyb.Count > 0)
            {
                foreach (HJQYB item in Hjqyb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetHJQYB(item.XH, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                HJQYBResp Data = new HJQYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.XH = item.XH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                HJQYBResp Data = new HJQYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.XH = item.XH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        HJQYBResp Data = new HJQYBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.XH = item.XH;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 来电类型表数据
        /// </summary>
        public void InsertLDLXB(List<LDLXB> Ldlxb, string AreaCode)
        {
            if (Ldlxb.Count > 0)
            {
                foreach (LDLXB item in Ldlxb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetLDLXB(item.XH, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LDLXBResp Data = new LDLXBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.XH = item.XH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LDLXBResp Data = new LDLXBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.XH = item.XH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LDLXBResp Data = new LDLXBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.XH = item.XH;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        public void InsertZBYXXB(List<ZBYXXB> Zbyxxxb, string AreaCode)
        {
            if (Zbyxxxb.Count > 0)
            {
                foreach (ZBYXXB item in Zbyxxxb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetZBYXXB(item.ID, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                ZBYXXBResp Data = new ZBYXXBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                ZBYXXBResp Data = new ZBYXXBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ZBYXXBResp Data = new ZBYXXBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        /// <summary>
        /// 症状表数据
        /// </summary>
        public void InsertZZB(List<ZZB> Zzb, string AreaCode)
        {
            if (Zzb.Count > 0)
            {
                foreach (ZZB item in Zzb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetZZB(item.XH, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                ZZBResp Data = new ZZBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.XH = item.XH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                ZZBResp Data = new ZZBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.XH = item.XH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ZZBResp Data = new ZZBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.XH = item.XH;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        ///病历关系删除表数据
        /// </summary>
        public void DeleteWeb_MedicalStatistics(List<LWBLGXTBDELB> lwblgxtbdel, string AreaCode)
        {
            if(lwblgxtbdel.Count>0)
            {

                foreach (LWBLGXTBDELB item in lwblgxtbdel)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetWeb_MedicalStatistics(item.ID, AreaCode);
                        if (exist == true)
                        {
                            
                            string sql = "delete from web_medicalstatistics where id=" + item.ID + " and XZBM ='" + AreaCode + "'";
                            int i = DBHelperOracle.ExecuteSql(sql);
                            if (i == 1)
                            {
                                LWBLGXTBDELBResp Data = new LWBLGXTBDELBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                            else if (i > 1)
                            {
                                LWBLGXTBDELBResp Data = new LWBLGXTBDELBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                                LogHelper.WriteLog("web_medicalstatistics删除多行有误,ID为" + item.ID + " 行政编码为" + AreaCode);
                            }
                        }
                        else 
                        {
                            LWBLGXTBDELBResp Data = new LWBLGXTBDELBResp();

                            Data.CommandID = item.CommandID + "Resp";
                            Data.ID = item.ID;
                            Data.Result = 1;
                            ExchangeDataResp(Data);
                            LogHelper.WriteLog("web_medicalstatistics删除没有该记录信息,ID为" + item.ID + " 行政编码为" + AreaCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        LWBLGXTBDELBResp Data = new LWBLGXTBDELBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }

            }
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        ///病历删除表数据
        /// </summary>
        public void DeleteWeb_MedicalRecords(List<LWBLTBDELB> lwbltbdel, string AreaCode)
        {
            if (lwbltbdel.Count > 0)
            {

                foreach (LWBLTBDELB item in lwbltbdel)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetWeb_MedicalRecords(item.ID, AreaCode);
                        if (exist == true)
                        {

                            string sql = "delete from web_medicalRecords where id=" + item.ID + " and XZBM ='" + AreaCode + "'";
                            int i = DBHelperOracle.ExecuteSql(sql);
                            if (i == 1)
                            {
                                //同时将该患者的statistics的值也删除了
                                sql = "delete from web_medicalStatistics where medicalrecordsid = " + item.ID + " and XZBM ='" + AreaCode + "'";
                                i = DBHelperOracle.ExecuteSql(sql);
                                if (i >0)
                                {
                                    LogHelper.WriteLog("删除患者信息同时也删除statistics值成功");
                                }
                                else
                                {
                                    LogHelper.WriteLog("删除患者信息时未能删除其对应的statistics值,ID为" + item.ID);
                                }
                                LWBLTBDELBResp Data = new LWBLTBDELBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                            else if (i > 1)
                            {
                                //同时将该患者的statistics的值也删除了
                                sql = "delete from web_medicalStatistics where medicalrecordsid = " + item.ID + " and XZBM ='" + AreaCode + "'";
                                i = DBHelperOracle.ExecuteSql(sql);
                                if (i == 1)
                                {
                                    LogHelper.WriteLog("删除患者信息同时也删除statistics值成功");
                                }
                                else
                                {
                                    LogHelper.WriteLog("删除患者信息时未能删除其对应的statistics值,ID为" + item.ID);
                                }
                                LWBLTBDELBResp Data = new LWBLTBDELBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.ID = item.ID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                                LogHelper.WriteLog("web_medicalrecords删除多行有误,ID为" + item.ID + " 行政编码为" + AreaCode);
                            }
                        }
                        else
                        {
                            LWBLTBDELBResp Data = new LWBLTBDELBResp();

                            Data.CommandID = item.CommandID + "Resp";
                            Data.ID = item.ID;
                            Data.Result = 1;
                            ExchangeDataResp(Data);
                            LogHelper.WriteLog("web_medicalrecords删除没有该记录信息,ID为" + item.ID + " 行政编码为" + AreaCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        LWBLTBDELBResp Data = new LWBLTBDELBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.ID = item.ID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }

            }
        }



        /// <summary>
        /// 获取所有的单位行政编码信息
        /// </summary>
        /// <returns></returns>
        public List<TUnit> GetAllUnitXZBM()
        {
            List<TUnit> units = new List<TUnit>();
            DataExchangeDataAccessSelectSql sql = new DataExchangeDataAccessSelectSql();
            DataTable dt = DBHelperOracle.GetRecord(sql.GetAllUnitXZBMSql());
            foreach (DataRow r in dt.Rows)
            {
                TUnit unit = new TUnit();
                unit.UnitXZQMC= r["xzqmc"].ToString();
                unit.UnitXZBM = r["xzqbm"].ToString();
                unit.UnitCode = r["jjdwbh"].ToString();
                units.Add(unit);
            }
            return units;
        }


        /// <summary>
        /// 大型事故表数据
        /// </summary>
        public void InsertDXSGB(List<DXSGB> Dxsgb, string AreaCode)
        {
            if (Dxsgb.Count > 0)
            {
                foreach (DXSGB item in Dxsgb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetDXSGB(item.LSH, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DXSGBResp Data = new DXSGBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LSH = item.LSH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                DXSGBResp Data = new DXSGBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LSH = item.LSH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DXSGBResp Data = new DXSGBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.LSH = item.LSH;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        /// 联网调度关联表数据
        /// </summary>
        public void InsertLWDDGLB(List<LWDDGLB> Lwddglb, string AreaCode)
        {
            if (Lwddglb.Count > 0)
            {
                foreach (LWDDGLB item in Lwddglb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetLWDDGLB(item.RemoteLSH, item.RemoteDWBH, item.LocalLSH, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWDDGLBResp Data = new LWDDGLBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.RemoteLSH = item.RemoteLSH;
                                Data.RemoteDWBH = item.RemoteDWBH;
                                Data.LocalLSH = item.LocalLSH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWDDGLBResp Data = new LWDDGLBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.RemoteLSH = item.RemoteLSH;
                                Data.RemoteDWBH = item.RemoteDWBH;
                                Data.LocalLSH = item.LocalLSH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LWDDGLBResp Data = new LWDDGLBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.RemoteLSH = item.RemoteLSH;
                        Data.RemoteDWBH = item.RemoteDWBH;
                        Data.LocalLSH = item.LocalLSH;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        /// 联网车辆同步对应表数据
        /// </summary>
        public void InsertLWCLTBDYB(List<LWCLTBDYB> Lwcltbdyb, string AreaCode)
        {
            if (Lwcltbdyb.Count > 0)
            {
                foreach (LWCLTBDYB item in Lwcltbdyb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetLWCLTBDYB(item.LocalLSH, item.LocalCS, item.LocalCLBH, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWCLTBDYBResp Data = new LWCLTBDYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LocalLSH = item.LocalLSH;
                                Data.LocalCS = item.LocalCS;
                                Data.LocalCLBH = item.LocalCLBH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWCLTBDYBResp Data = new LWCLTBDYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LocalLSH = item.LocalLSH;
                                Data.LocalCS = item.LocalCS;
                                Data.LocalCLBH = item.LocalCLBH;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LWCLTBDYBResp Data = new LWCLTBDYBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.LocalLSH = item.LocalLSH;
                        Data.LocalCS = item.LocalCS;
                        Data.LocalCLBH = item.LocalCLBH;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        public void InsertLWBLTBDYB(List<LWBLTBDYB> Lwbltbdyb, string AreaCode)
        {
            if (Lwbltbdyb.Count > 0)
            {
                foreach (LWBLTBDYB item in Lwbltbdyb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetLWBLTBDYB(item.LocalLSH, item.LocalRecordID, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWBLTBDYBResp Data = new LWBLTBDYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LocalLSH = item.LocalLSH;
                                Data.LocalRecordID = item.LocalRecordID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWBLTBDYBResp Data = new LWBLTBDYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LocalLSH = item.LocalLSH;
                                Data.LocalRecordID = item.LocalRecordID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LWBLTBDYBResp Data = new LWBLTBDYBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.LocalLSH = item.LocalLSH;
                        Data.LocalRecordID = item.LocalRecordID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }

        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        public void InsertLWBLGXTBDYB(List<LWBLGXTBDYB> lwblgxtbdyb, string AreaCode)
        {
            if (lwblgxtbdyb.Count > 0)
            {
                foreach (LWBLGXTBDYB item in lwblgxtbdyb)
                {
                    try
                    {
                        DataExchangeDataAccessSelectSql SelSql = new DataExchangeDataAccessSelectSql();
                        bool exist = SelSql.GetLWBLGXTBDYB(item.LocalLSH, item.LocalStatisticsID, AreaCode);
                        if (exist == true)
                        {
                            ParameterSql parSql = DataExchangeDataAccessUpdateSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWBLGXTBDYBResp Data = new LWBLGXTBDYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LocalLSH = item.LocalLSH;
                                Data.LocalStatisticsID = item.LocalStatisticsID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                        else
                        {
                            ParameterSql parSql = DataExchangeDataAccessSql.GetDataExchangeDataAccessSql(item, AreaCode);
                            int i = DBHelperOracle.ExecuteSql(parSql.StrSql, parSql.OrclPar);
                            if (i > 0)
                            {
                                LWBLGXTBDYBResp Data = new LWBLGXTBDYBResp();

                                Data.CommandID = item.CommandID + "Resp";
                                Data.LocalLSH = item.LocalLSH;
                                Data.LocalStatisticsID = item.LocalStatisticsID;
                                Data.Result = 1;
                                ExchangeDataResp(Data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LWBLGXTBDYBResp Data = new LWBLGXTBDYBResp();

                        Data.CommandID = item.CommandID + "Resp";
                        Data.LocalLSH = item.LocalLSH;
                        Data.LocalStatisticsID = item.LocalStatisticsID;
                        Data.Result = 0;
                        Data.FailtureReason = ex.Message;
                        ExchangeDataResp(Data);
                    }
                }
            }
        }
    
        
    }
}
