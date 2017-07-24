using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.fnDataAccess.DataSync
{
    public interface IUpdateMidState
    {
        /// <summary>
        /// 车辆信息数据上报isupdated=2
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        string UpdateVehicleData(string clbh);

        /// <summary>
        /// 系统人员数据上报isupdated=2
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        string UpdateSysUserData(string RYBH);

        /// <summary>
        /// 人员关系数据上报isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdatePVRelationData(string xh);

        /// <summary>
        /// 受理信息数据上报isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        string UpdateDealData(string lsh);

        /// <summary>
        /// 出车信息数据上报isupdated=2
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        string UpdateDispatchVehicle(string lsh, string cs, string clbh);

        /// <summary>
        /// 患者信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="czdh"></param>
        /// <returns></returns>
        string UpdateSuffererData(string lsh, string HZXH);

        /// <summary>
        /// 更新患者病历信息isupdated=2
        /// </summary>
        /// <param name="czdh"></param>
        /// <param name="slh"></param>
        /// <returns></returns>
        string UpdateSuffererCaseHistoryData(string czdh, string HZXH);

        /// <summary>
        /// 呼叫记录信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        string UpdateCallRcordData(string lsh);

        /// <summary>
        /// 单位信息数据isupdated=2
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        string UpdateUnitInfoData(string unitCode);

        /// <summary>
        /// 大型事故信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        string UpdateLargeSlipData(string lsh);

        /// <summary>
        /// 调度分站记录信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        string UpdateDispatchStationInfoData(string lsh, string ccdw);

        /// <summary>
        /// 病历填写项目数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string UpdateWeb_MedicalProjectData(string id);
        /// <summary>
        /// 病历填写项目值数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string UpdateWeb_MedicalProjectValueData(string id);
        /// <summary>
        /// 病历记录数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string UpdateWeb_MedicalRecordsData(string id);
        /// <summary>
        /// 病历填写项目与值对应数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string UpdateWeb_MedicalStatisticsData(string id);

        /// <summary>
        /// 病历基础信息表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdateBLJCXXBData(string lx, string mc);
        /// <summary>
        /// 呼救区域表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdateHJQYBData(string xh);
        /// <summary>
        /// 来电类型表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdateLDLXBData(string xh);
        /// <summary>
        /// 值班员信息表数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string UpdateZBYXXBData(string id);
        /// <summary>
        /// 症状表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdateZZBData(string xh);
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关联删除表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdateLWBLGXTBDELData(string id);
        //20160106修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历删除表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdateLWBLTBDELData(string id);

        /// <summary>
        /// 大型事故表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        string UpdateDXSGBData(string LSH);

    }
}
