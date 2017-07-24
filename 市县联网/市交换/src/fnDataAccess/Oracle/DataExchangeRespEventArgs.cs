using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model.DispatchFunction;

namespace ZIT.SJHServer.fnDataAccess.Oracle
{
    /// <summary>
    /// 数据交换应答
    /// </summary>
    public class DataExchangeRespEventArgs : EventArgs
    {
        /// <summary>
        /// 呼叫记录上报应答
        /// </summary>
        public CallRcordDataResp CallRcordDataRespMessage { get; private set; }
        /// <summary>
        /// Creates a new DataExchangeEventArgs object.
        /// </summary>
        /// <param name="message">Message object that is associated with this event</param>
        public DataExchangeRespEventArgs(CallRcordDataResp message)
        {
            CallRcordDataRespMessage = message;
        }
        /// <summary>
        /// 受理信息数据上报应答
        /// </summary>
        public DealDataResp DealDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(DealDataResp message)
        {
            DealDataRespMessage = message;
        }
        /// <summary>
        /// 调度分站记录上报应答
        /// </summary>
        public DispatchStationInfoDataResp DispatchStationInfoDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(DispatchStationInfoDataResp message)
        {
            DispatchStationInfoDataRespMessage = message;
        }
        /// <summary>
        /// 车辆状态应答
        /// </summary>
        public VehicleStatusResp VehicleStatusRespMessage { get; private set; }
        public DataExchangeRespEventArgs(VehicleStatusResp message)
        {
            VehicleStatusRespMessage = message;
        }
        /// <summary>
        /// 出车信息数据
        /// </summary>
        public DispatchVehicleDataResp DispatchVehicleDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(DispatchVehicleDataResp message)
        {
            DispatchVehicleDataRespMessage = message;
        }
        ///// <summary>
        ///// 请求获取报警电话位置
        ///// </summary>
        //public GetReportAlarmLocationInfo GetReportAlarmLocationInfoMessage { get; private set; }
        /// <summary>
        /// 急救人员急救车辆关系上报
        /// </summary>
        public PVRelationResp PVRelationRespMessage { get; private set; }
        public DataExchangeRespEventArgs(PVRelationResp message)
        {
            PVRelationRespMessage = message;
        }
        /// <summary>
        /// 患者病历信息数据上报
        /// </summary>
        public SuffererCaseHistoryDataResp SuffererCaseHistoryDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(SuffererCaseHistoryDataResp message)
        {
            SuffererCaseHistoryDataRespMessage = message;
        }
        /// <summary>
        /// 患者信息数据上报
        /// </summary>
        public SuffererDataResp SuffererDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(SuffererDataResp message)
        {
            SuffererDataRespMessage = message;
        }
        /// <summary>
        /// 系统人员信息上报
        /// </summary>
        public SysUserDataResp SysUserDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(SysUserDataResp message)
        {
            SysUserDataRespMessage = message;
        }
        /// <summary>
        /// 单位信息上报
        /// </summary>
        public UnitInfoDataResp UnitInfoDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(UnitInfoDataResp message)
        {
            UnitInfoDataRespMessage = message;
        }
        /// <summary>
        /// 车辆基础数据上报
        /// </summary>
        public VehicleDataResp VehicleDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(VehicleDataResp message)
        {
            VehicleDataRespMessage = message;
        }
        /// <summary>
        /// 大型事故数据上报
        /// </summary>
        public LargeSlipDataResp LargeSlipDataRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LargeSlipDataResp message)
        {
            LargeSlipDataRespMessage = message;
        }
        /// <summary>
        /// 病历填写项目
        /// </summary>
        public Web_MedicalProjectResp Web_MedicalProjectRespMessage { get; private set; }
        public DataExchangeRespEventArgs(Web_MedicalProjectResp message)
        {
            Web_MedicalProjectRespMessage = message;
        }
        /// <summary>
        /// 病历填写项目值
        /// </summary>
        public Web_MedicalProjectValueResp Web_MedicalProjectValueRespMessage { get; private set; }
        public DataExchangeRespEventArgs(Web_MedicalProjectValueResp message)
        {
            Web_MedicalProjectValueRespMessage = message;
        }
        /// <summary>
        /// 同步病历记录
        /// </summary>
        public Web_MedicalRecordsResp Web_MedicalRecordsRespMessage { get; private set; }
        public DataExchangeRespEventArgs(Web_MedicalRecordsResp message)
        {
            Web_MedicalRecordsRespMessage = message;
        }
        /// <summary>
        /// 病历填写项目与值对应关系数据
        /// </summary>
        public Web_MedicalStatisticsResp Web_MedicalStatisticsRespMessage { get; private set; }
        public DataExchangeRespEventArgs(Web_MedicalStatisticsResp message)
        {
            Web_MedicalStatisticsRespMessage = message;
        }

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        public BLJCXXBResp BLJCXXBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(BLJCXXBResp message)
        {
            BLJCXXBRespMessage = message;
        }
        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        public HJQYBResp HJQYBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(HJQYBResp message)
        {
            HJQYBRespMessage = message;
        }
        /// <summary>
        /// 来电类型表数据
        /// </summary>
        public LDLXBResp LDLXBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LDLXBResp message)
        {
            LDLXBRespMessage = message;
        }

        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        public ZBYXXBResp ZBYXXBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(ZBYXXBResp message)
        {
            ZBYXXBRespMessage = message;
        }
        /// <summary>
        /// 症状表数据
        /// </summary>
        public ZZBResp ZZBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(ZZBResp message)
        {
            ZZBRespMessage = message;
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系记录表数据
        /// </summary>
        public LWBLGXTBDELBResp LWBLGXTBDELBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LWBLGXTBDELBResp message)
        {
            LWBLGXTBDELBRespMessage = message;
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历关系记录表数据
        /// </summary>
        public LWBLTBDELBResp LWBLTBDELBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LWBLTBDELBResp message)
        {
            LWBLTBDELBRespMessage = message;
        }
        /// <summary>
        /// 大型事故表数据
        /// </summary>
        public DXSGBResp DXSGBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(DXSGBResp message)
        {
            DXSGBRespMessage = message;
        }

        /// <summary>
        /// 联网调度关联表数据
        /// </summary>
        public LWDDGLBResp LWDDGLBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LWDDGLBResp message)
        {
            LWDDGLBRespMessage = message;
        }

        /// <summary>
        /// 联网车辆同步对应表数据
        /// </summary>
        public LWCLTBDYBResp LWCLTBDYBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LWCLTBDYBResp message)
        {
            LWCLTBDYBRespMessage = message;
        }

        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        public LWBLTBDYBResp LWBLTBDYBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LWBLTBDYBResp message)
        {
            LWBLTBDYBRespMessage = message;
        }

        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        public LWBLGXTBDYBResp LWBLGXTBDYBRespMessage { get; private set; }
        public DataExchangeRespEventArgs(LWBLGXTBDYBResp message)
        {
            LWBLGXTBDYBRespMessage = message;
        }
    }
}
