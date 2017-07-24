using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.fnDataAccess.Oracle;
using ZIT.SJHServer.Model.DispatchFunction;


namespace ZIT.SJHServer.fnDataAccess
{
    /// <summary>
    /// 数据交换接口
    /// </summary>
    public interface IDataExchangeDataAccess
    {
        void InsertVehicleStatus(VehicleStatus VehicleStatus, string AreaCode);
        /// <summary>
        /// 车辆基础数据
        /// </summary>
        void InsertVehicleData(List<VehicleData> VehicleData, string AreaCode);
        /// <summary>
        ///  系统人员数据
        /// </summary>
        void InsertSysUserData(List<SysUserData> SysUserData, string AreaCode);
        /// <summary>
        /// 急救人员及急救车辆关系
        /// </summary>
        void InsertPVRelation(List<PVRelation> PVRelation, string AreaCode);
        /// <summary>
        /// 受理信息数据
        /// </summary>
        void InsertDealData(List<DealData> DealData, string AreaCode);
        /// <summary>
        /// 出车信息数据
        /// </summary>
        void InsertDispatchVehicleData(List<DispatchVehicleData> DispatchVehicleData, string AreaCode);
        /// <summary>
        /// 患者信息数据
        /// </summary>
        void InsertSuffererData(List<SuffererData> SuffererData,string AreaCode);
        /// <summary>
        /// 患者病例信息
        /// </summary>
        void InsertSuffererCaseHistoryData(List<SuffererCaseHistoryData> SuffererCaseHistoryData, string AreaCode);
        /// <summary>
        /// 呼叫记录数据
        /// </summary>
        void InsertCallRcordData(List<CallRcordData> CallRcordData, string AreaCode);
        /// <summary>
        /// 单位信息上报
        /// </summary>
        void InsertUnitInfoData(List<UnitInfoData> UnitInfoData, string AreaCode);
        /// <summary>
        /// 大型事故数据
        /// </summary>
        void InsertLargeSlipData(List<LargeSlipData> LargeSlipData, string AreaCode);
        /// <summary>
        /// 分站记录信息数据
        /// </summary>
        void InsertDispatchStationInfoData(List<DispatchStationInfoData> DispatchStationInfoData, string AreaCode);

        /// <summary>
        /// 获取所有的单位行政编码信息
        /// </summary>
        /// <returns></returns>
        List<TUnit> GetAllUnitXZBM();

        /// <summary>
        ///  病历填写项目
        /// </summary>
        void InsertWeb_MedicalProject(List<Web_MedicalProject> MedicalProject, string AreaCode);

        /// <summary>
        ///  病历填写项目值
        /// </summary>
        void InsertWeb_MedicalProjectValue(List<Web_MedicalProjectValue> MedicalProjectValue, string AreaCode);

        /// <summary>
        /// 病历记录
        /// </summary>
        void InsertWeb_MedicalRecords(List<Web_MedicalRecords> MedicalRecords, string AreaCode);

        /// <summary>
        ///  病历填写项目与值对应关系数据
        /// </summary>
        void InsertWeb_MedicalStatistics(List<Web_MedicalStatistics> MedicalStatistics, string AreaCode);

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        void InsertBLJCXXB(List<BLJCXXB> Bljcxxb, string AreaCode);
        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        void InsertHJQYB(List<HJQYB> Hjqyb, string AreaCode);
        /// <summary>
        /// 来电类型表数据
        /// </summary>
        void InsertLDLXB(List<LDLXB> Ldlxb, string AreaCode);
        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        void InsertZBYXXB(List<ZBYXXB> Zbyxxxb, string AreaCode);
        /// <summary>
        /// 症状表数据
        /// </summary>
        void InsertZZB(List<ZZB> Zzb, string AreaCode);
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系删除表数据
        /// </summary>
        void DeleteWeb_MedicalStatistics(List<LWBLGXTBDELB> lwblgxtbdel, string AreaCode);
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历删除表数据
        /// </summary>
        void DeleteWeb_MedicalRecords(List<LWBLTBDELB> lwblgxtbdel, string AreaCode);
        
        /// <summary>
        /// 大型事故表数据
        /// </summary>
        void InsertDXSGB(List<DXSGB> Dxsgb, string AreaCode);

        /// <summary>
        /// 联网调度关联表数据
        /// </summary>
        void InsertLWDDGLB(List<LWDDGLB> Lwddglb, string AreaCode);

        /// <summary>
        /// 联网车辆同步对应表数据
        /// </summary>
        void InsertLWCLTBDYB(List<LWCLTBDYB> Lwcltbdyb, string AreaCode);

        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        void InsertLWBLTBDYB(List<LWBLTBDYB> Lwbltbdyb, string AreaCode);

        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        void InsertLWBLGXTBDYB(List<LWBLGXTBDYB> lwblgxtbdyb, string AreaCode);

        /// <summary>
        /// 呼叫记录信息数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> CallRcordDataRespExchange;
        /// <summary>
        /// 受理信息数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> DealDataRespExchange;
        /// <summary>
        /// 调度分站记录信息答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> DispatchStationInfoDataRespExchange;
        /// <summary>
        /// 车辆状态
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> VehicleStatusRespExchange;
        /// <summary>
        /// 出车信息数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> DispatchVehicleDataRespExchange;
        /// <summary>
        /// 急救人员及急救车辆数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> PVRelationRespExchange;
        /// <summary>
        /// 患者病历信息数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> SuffererCaseHistoryDataRespExchange;
        /// <summary>
        /// 患者信息数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> SuffererDataRespExchange;
        /// <summary>
        /// 系统人员数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> SysUserDataRespExchange;
        /// <summary>
        /// 单位信息数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> UnitInfoDataRespExchange;
        /// <summary>
        /// 车辆基础数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> VehicleDataRespExchange;
        /// <summary>
        /// 大型事故数据答应
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LargeSlipDataRespExchange;

        /// <summary>
        /// 病历填写项目应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> Web_MedicalProjectRespExchange;

        /// <summary>
        /// 病历填写项目值应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> Web_MedicalProjectValueRespExchange;

        /// <summary>
        /// 病历记录应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> Web_MedicalRecordsRespExchange;

        /// <summary>
        /// 病历填写项目与值对应关系数据应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> Web_MedicalStatisticsRespExchange;

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> BLJCXXBRespExchange;
        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> HJQYBRespExchange;
        /// <summary>
        /// 来电类型表数据
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LDLXBRespExchange;
        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> ZBYXXBRespExchange;
        /// <summary>
        /// 症状表数据
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> ZZBRespExchange;
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系删除表数据应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LWBLGXTBDELBRespExchange;
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历删除表数据应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LWBLTBDELBRespExchange;
        /// <summary>
        /// 大型事故表数据应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> DXSGBRespExchange;
        /// <summary>
        /// 联网调度关联表数据应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LWDDGLBRespExchange;
        /// <summary>
        /// 联网车辆同步对应表数据应答
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LWCLTBDYBRespExchange;
        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LWBLTBDYBRespExchange;
        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        event EventHandler<DataExchangeRespEventArgs> LWBLGXTBDYBRespExchange;

    }
}
