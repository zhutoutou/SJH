using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model.SystemFunction;
using ZIT.SJHServer.Model.DispatchFunction;
using ZIT.Utility;
using ZIT.LOG;
using ZIT.SJHServer.fnDataAccess;
using ZIT.SJHServer.fnLocalDataAccess;
using ZIT.SJHServer.fnDataAccess.Oracle;
using ZIT.SJHServer.bsController.DataSaved;
using ZIT.SJHServer.bsController.SJHServer;
using System.Threading;

namespace ZIT.SJHServer.bsController.DataSaved
{
    /// <summary>
    /// 负责将市120库的数据同步到市全局库中
    /// </summary>
    class SyncLocalData
    {
        /// <summary>
        /// 数据传送间隔，单位：毫秒
        /// </summary>
        int Interval;
        /// <summary>
        /// 120库查询数据对象
        /// </summary>
        IGetData LocalData;
        /// <summary>
        /// 120库更新数据对象
        /// </summary>
        IUpdateData LocalUpdateData;
        /// <summary>
        /// 本市的行政编码
        /// </summary>
        public static string LocalXZBM;
        
        public SyncLocalData()
        {
            LocalData = LocalDataAccess.GetDataAccess();
            LocalUpdateData = LocalDataAccess.UpdateDataAccess();
            Interval = 1000;
            string UnitCode = Controller.GetInstance().Args.args.UnitCode;
            TUnit unit = Controller.GetInstance().dicUnit[UnitCode];
            LocalXZBM = unit.UnitXZBM;
        }

        /// <summary>
        /// 开始同步市120本地数据到市全局库中
        /// </summary>
        public void StartSyncLocalData()
        {
            while (true)
            {
                //上传单位信息
                try
                {
                    List<UnitInfoData> UnitInfo = LocalData.GetUnitInfoData();
                    if (UnitInfo.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.UnitInfoDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_UnitInfoDataRespExchange);
                        Data.InsertUnitInfoData(UnitInfo, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }
                //上传车辆信息
                try
                {
                    List<VehicleData> VehicleInfo = LocalData.GetVehicleData();
                    if (VehicleInfo.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.VehicleDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_VehicleDataRespExchange);
                        Data.InsertVehicleData(VehicleInfo, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }
                //上传系统人员信息
                try
                {
                    List<SysUserData> SysUserInfo = LocalData.GetSysUserData();
                    if (SysUserInfo.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.SysUserDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_SysUserDataRespExchange);
                        Data.InsertSysUserData(SysUserInfo, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }
                // 上传呼叫记录信息
                try
                {
                    List<CallRcordData> CallRcordDataInfo = LocalData.GetCallRcordData();
                    if (CallRcordDataInfo.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.CallRcordDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_CallRcordDataRespExchange);
                        Data.InsertCallRcordData(CallRcordDataInfo, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }
                //上传受理记录信息
                try
                {
                    List<DealData> DealDataInfo = LocalData.GetDealData();
                    if (DealDataInfo.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.DealDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DealDataRespExchange);
                        Data.InsertDealData(DealDataInfo, LocalXZBM);
                       
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }
                //上传出车信息
                try
                {
                    List<DispatchVehicleData> DispatchVehicleInfo = LocalData.GetDispatchVehicleData();
                    if (DispatchVehicleInfo.Count > 0)
                    {
                        foreach (DispatchVehicleData item in DispatchVehicleInfo)
                        {
                            IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                            Data.DispatchVehicleDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DispatchVehicleDataRespExchange);
                            Data.InsertDispatchVehicleData(DispatchVehicleInfo, LocalXZBM);
                            Thread.Sleep(Interval);
                        }
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                //上传调度分站记录信息
                try
                {
                    List<DispatchStationInfoData> DispatchStationInfo = LocalData.GetDispatchStationInfoData();
                    if (DispatchStationInfo.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.DispatchStationInfoDataRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DispatchStationInfoDataRespExchange);
                        Data.InsertDispatchStationInfoData(DispatchStationInfo, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                //上传病历填写项目数据
                try
                {
                    List<Web_MedicalProject> list = LocalData.GetWeb_MedicalProjectData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.Web_MedicalProjectRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalProjectRespExchange);
                        Data.InsertWeb_MedicalProject(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                //上传病历填写项目值数据
                try
                {
                    List<Web_MedicalProjectValue> list = LocalData.GetWeb_MedicalProjectValueData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.Web_MedicalProjectValueRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalProjectValueRespExchange);
                        Data.InsertWeb_MedicalProjectValue(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                //上传病历记录数据
                try
                {
                    List<Web_MedicalRecords> list = LocalData.GetWeb_MedicalRecordsData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.Web_MedicalRecordsRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalRecordsRespExchange);
                        Data.InsertWeb_MedicalRecords(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                //上传病历填写项目与值对应数据
                try
                {
                    List<Web_MedicalStatistics> list = LocalData.GetWeb_MedicalStatisticsData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.Web_MedicalStatisticsRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_Web_MedicalStatisticsRespExchange);
                        Data.InsertWeb_MedicalStatistics(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                // 病历基础信息表数据
                try
                {
                    List<BLJCXXB> list = LocalData.GetBLJCXXBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.BLJCXXBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_BLJCXXBRespExchange);
                        Data.InsertBLJCXXB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                // 呼救区域表数据
                try
                {
                    List<HJQYB> list = LocalData.GetHJQYBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.HJQYBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_HJQYBRespExchange);
                        Data.InsertHJQYB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }
                /// 来电类型表数据
                try
                {
                    List<LDLXB> list = LocalData.GetLDLXBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.LDLXBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LDLXBRespExchange);
                        Data.InsertLDLXB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }
                // 值班员信息表数据
                try
                {
                    List<ZBYXXB> list = LocalData.GetZBYXXBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.ZBYXXBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_ZBYXXBRespExchange);
                        Data.InsertZBYXXB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                // 症状表数据
                try
                {
                    List<ZZB> list = LocalData.GetZZBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.ZZBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_ZZBRespExchange);
                        Data.InsertZZB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex) { LogHelper.WriteLog(ex.Message, ex); }

                //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
                // 病历删除记录表数据
                try
                {
                    List<LWBLTBDELB> list = LocalData.GetLWBLTBDELBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.LWBLTBDELBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWBLTBDELBRespExchange);
                        Data.DeleteWeb_MedicalRecords(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }
                //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
                // 病历关系删除记录表数据
                try
                {
                    List<LWBLGXTBDELB> list = LocalData.GetLWBLGXTBDELBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.LWBLGXTBDELBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWBLGXTBDELBRespExchange);
                        Data.DeleteWeb_MedicalStatistics(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }

                // 大型事故表数据
                try
                {
                    List<DXSGB> list = LocalData.GetDXSGBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.DXSGBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_DXSGBRespExchange);
                        Data.InsertDXSGB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }

                //  联网调度关联表数据
                try
                {
                    List<LWDDGLB> list = LocalData.GetLWDDGLBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.LWDDGLBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWDDGLBRespExchange);
                        Data.InsertLWDDGLB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }

                // 联网车辆同步对应表数据
                try
                {
                    List<LWCLTBDYB> list = LocalData.GetLWCLTBDYBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.LWCLTBDYBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWCLTBDYBRespExchange);
                        Data.InsertLWCLTBDYB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }

                // 联网病历同步对应表数据
                try
                {
                    List<LWBLTBDYB> list = LocalData.GetLWBLTBDYBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.LWBLTBDYBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWBLTBDYBRespExchange);
                        Data.InsertLWBLTBDYB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }

                // 联网病历关系同步对应表数据
                try
                {
                    List<LWBLGXTBDYB> list = LocalData.GetLWBLGXTBDYBData();
                    if (list.Count > 0)
                    {
                        IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
                        Data.LWBLGXTBDYBRespExchange += new EventHandler<DataExchangeRespEventArgs>(Data_LWBLGXTBDYBRespExchange);
                        Data.InsertLWBLGXTBDYB(list, LocalXZBM);
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                }

                finally { Thread.Sleep(10000); }
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
                LocalUpdateData.UpdateUnitInfoData(e.UnitInfoDataRespMessage.UnitCode);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
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
                LocalUpdateData.UpdateVehicleData(e.VehicleDataRespMessage.VehicleCode);
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
                LocalUpdateData.UpdateSysUserData(e.SysUserDataRespMessage.UserName);
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
                LocalUpdateData.UpdateCallRcordData(e.CallRcordDataRespMessage.CallID);
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
                LocalUpdateData.UpdateDealData(e.DealDataRespMessage.DealRecordID);
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
                LocalUpdateData.UpdateDispatchStationInfoData(e.DispatchStationInfoDataRespMessage.ID,e.DispatchStationInfoDataRespMessage.DispatchVehicleUnit);
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
        private void Data_DispatchVehicleDataRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateDispatchVehicle(e.DispatchVehicleDataRespMessage.DealRecordID, e.DispatchVehicleDataRespMessage.Times,e.DispatchVehicleDataRespMessage.VehicleCode);
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
                LocalUpdateData.UpdateLargeSlipData(e.LargeSlipDataRespMessage.ID);
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
                LocalUpdateData.UpdateSuffererData(e.SuffererDataRespMessage.DealRecordID,e.SuffererDataRespMessage.DispatchVehicleID);
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
                //LocalUpdateData.UpdateSuffererCaseHistoryData(e.SuffererCaseHistoryDataRespMessage.);
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
                
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }

        }

        /// <summary>
        /// 上传病历填写项目数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalProjectRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateWeb_MedicalProjectData(e.Web_MedicalProjectRespMessage.ID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 上传病历填写项目值数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalProjectValueRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateWeb_MedicalProjectValueData(e.Web_MedicalProjectValueRespMessage.ID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 上传病历记录数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalRecordsRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateWeb_MedicalRecordsData(e.Web_MedicalRecordsRespMessage.ID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 上传病历填写项目与值对应数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Web_MedicalStatisticsRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateWeb_MedicalStatisticsData(e.Web_MedicalStatisticsRespMessage.ID);
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
                LocalUpdateData.UpdateBLJCXXBData(e.BLJCXXBRespMessage.LX,e.BLJCXXBRespMessage.MC);
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
                LocalUpdateData.UpdateHJQYBData(e.HJQYBRespMessage.XH);
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
                LocalUpdateData.UpdateLDLXBData(e.LDLXBRespMessage.XH);
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
                LocalUpdateData.UpdateZBYXXBData(e.ZBYXXBRespMessage.ID);
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
                LocalUpdateData.UpdateZZBData(e.ZZBRespMessage.XH);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系记录删除表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWBLGXTBDELBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateLWBLGXTBDELData(e.LWBLGXTBDELBRespMessage.ID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历记录删除表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWBLTBDELBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateLWBLTBDELData(e.LWBLTBDELBRespMessage.ID);
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
                LocalUpdateData.UpdateDXSGBData(e.DXSGBRespMessage.LSH);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 联网调度关联表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWDDGLBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateLWDDGLBData(e.LWDDGLBRespMessage.RemoteLSH, e.LWDDGLBRespMessage.RemoteDWBH, e.LWDDGLBRespMessage.LocalLSH);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 联网车辆同步对应表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWCLTBDYBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateLWCLTBDYBData(e.LWCLTBDYBRespMessage.LocalLSH, e.LWCLTBDYBRespMessage.LocalCS, e.LWCLTBDYBRespMessage.LocalCLBH);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 联网病历同步对应表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWBLTBDYBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateLWBLTBDYBData(e.LWBLTBDYBRespMessage.LocalLSH, e.LWBLTBDYBRespMessage.LocalRecordID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        /// <summary>
        /// 联网病历关系同步对应表数据应答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_LWBLGXTBDYBRespExchange(object sender, DataExchangeRespEventArgs e)
        {
            try
            {
                LocalUpdateData.UpdateLWBLGXTBDYBData(e.LWBLGXTBDYBRespMessage.LocalLSH, e.LWBLGXTBDYBRespMessage.LocalStatisticsID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }
    }
}
