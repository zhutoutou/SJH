using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.Utility;

namespace ZIT.SJHServer.fnLocalDataAccess.Oracle
{
    internal class UpdateData : IUpdateData
    { 
        /// <summary>
        /// 车辆信息数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public int UpdateVehicleData(string clbh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateVehicleDataStr(clbh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 系统人员数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public int UpdateSysUserData(string RYBH)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateSysUserDataStr(RYBH));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 人员关系数据上报isupdated=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdatePVRelationData(string xh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdatePVRelationDataStr(xh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 受理信息数据上报isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public int UpdateDealData(string lsh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateDealDataStr(lsh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 出车信息数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public int UpdateDispatchVehicle(string lsh, string cs, string clbh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateDispatchVehicleStr(lsh, cs, clbh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 患者信息数据isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="czdh"></param>
        /// <returns></returns>
        public int UpdateSuffererData(string lsh, string HZXH)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateSuffererDataStr(lsh, HZXH));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新患者病历信息isupdated=0
        /// </summary>
        /// <param name="czdh"></param>
        /// <param name="slh"></param>
        /// <returns></returns>
        public int UpdateSuffererCaseHistoryData(string HZXH, string slh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateSuffererCaseHistoryDataStr(HZXH, slh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 呼叫记录信息数据isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public int UpdateCallRcordData(string lsh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateCallRcordDataStr(lsh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 单位信息数据isupdated=0
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public int UpdateUnitInfoData(string unitCode)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateUnitInfoDataStr(unitCode));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 大型事故信息数据isupdate=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public int UpdateLargeSlipData(string lsh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLargeSlipDataStr(lsh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 调度分站记录信息数据isupdate=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public int UpdateDispatchStationInfoData(string lsh, string ccdw)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateDispatchStationInfoDataStr(lsh, ccdw));
                return i;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 病历填写项目数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateWeb_MedicalProjectData(string id)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateWeb_MedicalProjectDataStr(id));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 病历填写项目值数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateWeb_MedicalProjectValueData(string id)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateWeb_MedicalProjectValueDataStr(id));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 病历记录数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateWeb_MedicalRecordsData(string id)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateWeb_MedicalRecordsDataStr(id));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 病历填写项目与值对应数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateWeb_MedicalStatisticsData(string id)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateWeb_MedicalStatisticsDataStr(id));
                return i;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 病历基础信息表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateBLJCXXBData(string lx,string mc)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateBLJCXXBDataStr(lx,mc));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 呼救区域表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateHJQYBData(string xh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateHJQYBDataStr(xh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 来电类型表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateLDLXBData(string xh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLDLXBDataStr(xh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 值班员信息表数据isupdate=0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateZBYXXBData(string id)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateZBYXXBDataStr(id));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 症状表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateZZBData(string xh)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateZZBDataStr(xh));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关联删除表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateLWBLGXTBDELData(string id)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLWBLGXTBDELDataStr(id));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        //20160106修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历删除表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateLWBLTBDELData(string id)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLWBLTBDELDataStr(id));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 大型事故表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateDXSGBData(string LSH)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateDXSGBDataStr(LSH));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 联网调度关联表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateLWDDGLBData(string RemoteLSH, string RemoteDWBH, string LocalLSH)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLWDDGLBDataStr(RemoteLSH, RemoteDWBH, LocalLSH));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 联网车辆同步对应表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateLWCLTBDYBData(string LocalLSH, string LocalCS, string LocalCLBH)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLWCLTBDYBDataStr(LocalLSH, LocalCS, LocalCLBH));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 联网病历同步对应表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateLWBLTBDYBData(string LocalLSH, string LocalRecordID)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLWBLTBDYBDataStr(LocalLSH, LocalRecordID));
                return i;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 联网病历关系同步对应表数据isupdate=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public int UpdateLWBLGXTBDYBData(string LocalLSH, string LocalStatisticsID)
        {
            try
            {
                int i = DB120Help.OperationRecord(UpdateDataSql.UpdateLWBLGXTBDYBDataStr(LocalLSH, LocalStatisticsID));
                return i;
            }
            catch
            {
                return 0;
            }
        }
    }
}
