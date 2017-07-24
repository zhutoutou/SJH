using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;

namespace ZIT.SJHServer.fnLocalDataAccess
{
    public interface IGetData
    {
        /// <summary>
        /// 车辆基础信息
        /// </summary>
        /// <returns></returns>
        List<VehicleData> GetVehicleData();
        /// <summary>
        /// 系统人员信息
        /// </summary>
        /// <returns></returns>
        List<SysUserData> GetSysUserData();
        /// <summary>
        /// 单位信息数据
        /// </summary>
        /// <returns></returns>
        List<UnitInfoData> GetUnitInfoData();


        /// <summary>
        /// 呼叫记录表
        /// </summary>
        /// <returns></returns>
        List<CallRcordData> GetCallRcordData();
        /// <summary>
        /// 受理数据信息
        /// </summary>
        /// <returns></returns>
        List<DealData> GetDealData();
        /// <summary>
        /// 调度分站记录信息数据
        /// </summary>
        /// <returns></returns>
        List<DispatchStationInfoData> GetDispatchStationInfoData();
        /// <summary>
        /// 出车信息数据
        /// </summary>
        /// <returns></returns>
        List<DispatchVehicleData> GetDispatchVehicleData();
        /// <summary>
        /// 病历填写项目数据
        /// </summary>
        /// <returns></returns>
        List<Web_MedicalProject> GetWeb_MedicalProjectData();
        /// <summary>
        /// 病历填写项目值数据
        /// </summary>
        /// <returns></returns>
        List<Web_MedicalProjectValue> GetWeb_MedicalProjectValueData();
        /// <summary>
        /// 病历记录数据
        /// </summary>
        /// <returns></returns>
        List<Web_MedicalRecords> GetWeb_MedicalRecordsData();
        /// <summary>
        /// 病历填写项目与值对应数据
        /// </summary>
        /// <returns></returns>
        List<Web_MedicalStatistics> GetWeb_MedicalStatisticsData();

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        /// <returns></returns>
        List<BLJCXXB> GetBLJCXXBData();

        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        /// <returns></returns>
        List<HJQYB> GetHJQYBData();

        /// <summary>
        /// 来电类型表数据
        /// </summary>
        /// <returns></returns>
        List<LDLXB> GetLDLXBData();

        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        /// <returns></returns>
        List<ZBYXXB> GetZBYXXBData();

        /// <summary>
        /// 症状表数据
        /// </summary>
        /// <returns></returns>
        List<ZZB> GetZZBData();
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 症状关系删除表数据
        /// </summary>
        /// <returns></returns>
        List<LWBLGXTBDELB> GetLWBLGXTBDELBData();
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 症状删除表数据
        /// </summary>
        /// <returns></returns>
        List<LWBLTBDELB> GetLWBLTBDELBData();
          
        /// <summary>
        /// 大型事故表数据
        /// </summary>
        /// <returns></returns>
        List<DXSGB> GetDXSGBData();

                
        /// <summary>
        /// 联网调度关联表数据
        /// </summary>
        /// <returns></returns>
        List<LWDDGLB> GetLWDDGLBData();

                
        /// <summary>
        /// 联网车辆同步对应表数据
        /// </summary>
        /// <returns></returns>
        List<LWCLTBDYB> GetLWCLTBDYBData();

              
        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        /// <returns></returns>
        List<LWBLTBDYB> GetLWBLTBDYBData();
                
        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        /// <returns></returns>
        List<LWBLGXTBDYB> GetLWBLGXTBDYBData();

    }
}
