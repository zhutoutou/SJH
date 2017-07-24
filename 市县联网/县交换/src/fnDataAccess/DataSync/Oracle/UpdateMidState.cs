using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.LOG;

namespace ZIT.XJHServer.fnDataAccess.DataSync.Oracle
{
    internal class UpdateMidState : IUpdateMidState
    {
        /// <summary>
        /// 车辆信息数据上报isupdated=2
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public string UpdateVehicleData(string clbh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateVehicleDataStr(clbh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendVehicleDataStr(clbh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 系统人员数据上报isupdated=2
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public string UpdateSysUserData(string RYBH)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateSysUserDataStr(RYBH));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendSysUserDataStr(RYBH);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 人员关系数据上报isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdatePVRelationData(string xh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdatePVRelationDataStr(xh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendPVRelationDataStr(xh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 受理信息数据上报isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public string UpdateDealData(string lsh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateDealDataStr(lsh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                
                string strReSendSql = ReSendSql.ReSendDealDataStr(lsh);
                LogHelper.WriteLog(UpdateMidStateSql.UpdateDealDataStr(lsh) + " 影响行数: " + i + "并且返回SQL：" + strReSendSql);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 出车信息数据上报isupdated=2
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public string UpdateDispatchVehicle(string lsh, string cs, string clbh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateDispatchVehicleStr(lsh, cs, clbh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendDispatchVehicleStr(lsh,cs,clbh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 患者信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="czdh"></param>
        /// <returns></returns>
        public string UpdateSuffererData(string lsh, string HZXH)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateSuffererDataStr(lsh, HZXH));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendSuffererDataStr(lsh,HZXH);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 更新患者病历信息isupdated=2
        /// </summary>
        /// <param name="czdh"></param>
        /// <param name="slh"></param>
        /// <returns></returns>
        public string  UpdateSuffererCaseHistoryData(string HZXH, string lsh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateSuffererCaseHistoryDataStr(HZXH, lsh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendSuffererCaseHistoryDataStr(HZXH,lsh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 呼叫记录信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public string UpdateCallRcordData(string lsh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateCallRcordDataStr(lsh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendCallRcordDataStr(lsh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 单位信息数据isupdated=2
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public string UpdateUnitInfoData(string unitCode)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateUnitInfoDataStr(unitCode));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendUnitInfoDataStr(unitCode);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 大型事故信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public string UpdateLargeSlipData(string lsh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateLargeSlipDataStr(lsh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendLargeSlipDataStr(lsh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 调度分站记录信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public string UpdateDispatchStationInfoData(string lsh, string ccdw)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateDispatchStationInfoDataStr(lsh, ccdw));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendDispatchStationInfoDataStr(lsh,ccdw);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 病历填写项目数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UpdateWeb_MedicalProjectData(string id)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateWeb_MedicalProjectDataStr(id));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendWeb_MedicalProjectDataStr(id);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 病历填写项目值数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UpdateWeb_MedicalProjectValueData(string id)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateWeb_MedicalProjectValueDataStr(id));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendWeb_MedicalProjectValueDataStr(id);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 病历记录数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UpdateWeb_MedicalRecordsData(string id)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateWeb_MedicalRecordsDataStr(id));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendWeb_MedicalRecordsDataStr(id);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 病历填写项目与值对应数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UpdateWeb_MedicalStatisticsData(string id)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateWeb_MedicalStatisticsDataStr(id));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendWeb_MedicalStatisticsDataStr(id);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 病历基础信息表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdateBLJCXXBData(string lx, string mc)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateBLJCXXBDataStr(lx, mc));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendBLJCXXBDataStr(lx,mc);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 呼救区域表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdateHJQYBData(string xh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateHJQYBDataStr(xh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendHJQYBDataStr(xh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 来电类型表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdateLDLXBData(string xh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateLDLXBDataStr(xh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendLDLXBDataStr(xh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 值班员信息表数据isupdated=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UpdateZBYXXBData(string id)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateZBYXXBDataStr(id));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendZBYXXBDataStr(id);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 症状表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdateZZBData(string xh)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateZZBDataStr(xh));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendZZBDataStr(xh);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关联删除表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdateLWBLGXTBDELData(string id)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateLWBLGXTBDELDataStr(id));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendLWBLGXTBDELDataStr(id);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历删除表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdateLWBLTBDELData(string id)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateLWBLTBDELDataStr(id));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendLWBLTBDELDataStr(id);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 大型事故表数据isupdated=2
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public string UpdateDXSGBData(string LSH)
        {
            try
            {
                int i = OraclHelp.OperationRecord(UpdateMidStateSql.UpdateDXSGBDataStr(LSH));
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                string strReSendSql = ReSendSql.ReSendDXSGBDataStr(LSH);
                return strReSendSql;
            }
            catch
            {
                return "";
            }
        }
    }
}
