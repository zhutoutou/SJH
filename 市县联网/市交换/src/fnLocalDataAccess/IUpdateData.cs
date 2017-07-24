using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.fnLocalDataAccess
{
   public interface IUpdateData
    {
        /// <summary>
        /// 车辆信息数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        int UpdateVehicleData(string clbh);

        /// <summary>
        /// 系统人员数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        int UpdateSysUserData(string RYBH);

        /// <summary>
        /// 人员关系数据上报isupdated=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdatePVRelationData(string xh);

        /// <summary>
        /// 受理信息数据上报isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        int UpdateDealData(string lsh);

        /// <summary>
        /// 出车信息数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        int UpdateDispatchVehicle(string lsh, string cs, string clbh);

        /// <summary>
        /// 患者信息数据isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="czdh"></param>
        /// <returns></returns>
        int UpdateSuffererData(string lsh, string HZXH);

        /// <summary>
        /// 更新患者病历信息isupdated=0
        /// </summary>
        /// <param name="czdh"></param>
        /// <param name="slh"></param>
        /// <returns></returns>
        int UpdateSuffererCaseHistoryData(string czdh, string HZXH);

        /// <summary>
        /// 呼叫记录信息数据isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        int UpdateCallRcordData(string lsh);

        /// <summary>
        /// 单位信息数据isupdated=0
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        int UpdateUnitInfoData(string unitCode);

        /// <summary>
        /// 大型事故信息数据isupdate=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        int UpdateLargeSlipData(string lsh);

        /// <summary>
        /// 调度分站记录信息数据isupdate=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        int UpdateDispatchStationInfoData(string lsh, string ccdw);

        /// <summary>
        /// 病历填写项目数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateWeb_MedicalProjectData(string id);
        /// <summary>
        /// 病历填写项目值数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateWeb_MedicalProjectValueData(string id);
        /// <summary>
        /// 病历记录数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateWeb_MedicalRecordsData(string id);
        /// <summary>
        /// 病历填写项目与值对应数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateWeb_MedicalStatisticsData(string id);
        /// <summary>
        /// 病历基础信息表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateBLJCXXBData(string lx,string mc);
        /// <summary>
        /// 呼救区域表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateHJQYBData(string xh);
        /// <summary>
        /// 来电类型表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateLDLXBData(string xh);
        /// <summary>
        /// 值班员信息表数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateZBYXXBData(string id);
        /// <summary>
        /// 症状表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateZZBData(string xh);
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关联删除表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateLWBLGXTBDELData(string id);
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历删除表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateLWBLTBDELData(string id);

        /// <summary>
        /// 大型事故表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateDXSGBData(string LSH);
        /// <summary>
        /// 联网调度关联表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateLWDDGLBData(string RemoteLSH, string RemoteDWBH, string LocalLSH);
        /// <summary>
        /// 联网车辆同步对应表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateLWCLTBDYBData(string LocalLSH, string LocalCS, string LocalCLBH);
        /// <summary>
        /// 联网病历同步对应表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateLWBLTBDYBData(string LocalLSH, string LocalRecordID);
        /// <summary>
        /// 联网病历关系同步对应表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        int UpdateLWBLGXTBDYBData(string LocalLSH, string LocalStatisticsID);

    }
}
