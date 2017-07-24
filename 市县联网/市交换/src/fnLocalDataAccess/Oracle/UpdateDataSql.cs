using ZIT.SJHServer.Model;

namespace ZIT.SJHServer.fnLocalDataAccess.Oracle
{

    public  class UpdateDataSql
    {
        /// <summary>
        /// 车辆信息数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static string UpdateVehicleDataStr(string clbh)
        {
            string strSql = "update clxxb set isupdated=0 where clbh='" + clbh + "'";
            return strSql;
        }
        /// <summary>
        /// 系统人员数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static string UpdateSysUserDataStr(string RYBH)
        {
            string strSql = "update xtryb set isupdated=0 where RYBH='" + RYBH + "'";
            return strSql;
        }
        /// <summary>
        /// 人员关系数据上报isupdated=0
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public static string UpdatePVRelationDataStr(string xh)
        {
            string strSql = "update rykqb set isupdated=0 where xh='" + xh + "'";
            return strSql;
        }
        /// <summary>
        /// 受理信息数据上报isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string UpdateDealDataStr(string lsh)
        {
            string strSql = "update sljlb set isupdated=0 where lsh='" + lsh + "'";
            return strSql;
        }

        /// <summary>
        /// 出车信息数据上报isupdated=0
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static string UpdateDispatchVehicleStr(string lsh, string cs, string clbh)
        {
            string strSql = "update ccxxb set isupdated=0 where lsh='" + lsh + "' and cs='" + cs + "' and clbh='" + clbh + "'";
            return strSql;
        }
        /// <summary>
        /// 患者信息数据isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="czdh"></param>
        /// <returns></returns>
        public static string UpdateSuffererDataStr(string lsh, string HZXH)
        {
            string strSql = "update hzxxb set isupdated=0 where lsh='" + lsh + "' and XH='" + HZXH + "'";
            return strSql;
        }
        /// <summary>
        /// 更新患者病历信息isupdated=0
        /// </summary>
        /// <param name="czdh"></param>
        /// <param name="slh"></param>
        /// <returns></returns>
        public static string UpdateSuffererCaseHistoryDataStr(string HZXH, string slh)
        {
            string strSql = "update hzblb set isupdated=0 where XH='" + HZXH + "' and lsh='" + slh + "'";
            return strSql;
        }
        /// <summary>
        /// 呼叫记录信息数据isupdated=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string UpdateCallRcordDataStr(string lsh)
        {
            string strSql = "update hjjlb set isupdated=0 where lsh='" + lsh + "'";
            return strSql;
        }
        /// <summary>
        /// 单位信息数据isupdated=0
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public static string UpdateUnitInfoDataStr(string unitCode)
        {
            string strSql = "update dwxxb set isupdated=0 where dwbh='" + unitCode + "'";
            return strSql;
        }
        /// <summary>
        /// 大型事故信息数据isupdate=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string UpdateLargeSlipDataStr(string lsh)
        {
            string strSql = "update dxsgb set isupdated=0 where lsh='" + lsh + "'";
            return strSql;
        }
        /// <summary>
        /// 调度分站记录信息数据isupdate=0
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string UpdateDispatchStationInfoDataStr(string lsh, string ccdw)
        {
            string strSql = "update ddfzjlb set isupdated=0 where lsh='" + lsh + "' and ccdw='" + ccdw + "'";
            return strSql;
        }

        public static string UpdateWeb_MedicalProjectDataStr(string id)
        {
            string strSql = "update Web_MedicalProject set isupdated=0 where id='" + id + "'";
            return strSql;
        }
        public static string UpdateWeb_MedicalProjectValueDataStr(string id)
        {
            string strSql = "update Web_MedicalProjectValue set isupdated=0 where id='" + id + "'";
            return strSql;
        }
        public static string UpdateWeb_MedicalRecordsDataStr(string id)
        {
            string strSql = "update Web_MedicalRecords set isupdated=0  where id=" + id;
            return strSql;
        }
        public static string UpdateWeb_MedicalStatisticsDataStr(string id)
        {
            string strSql = "update Web_MedicalStatistics set isupdated=0  where id=" + id;
            return strSql;
        }

        public static string UpdateBLJCXXBDataStr(string lx,string mc)
        {
            string strSql = "update BLJCXXB set isupdated=0  where lx= '" + lx + "' and mc ='" + mc + "'";
            return strSql;
        }
        public static string UpdateHJQYBDataStr(string xh)
        {
            string strSql = "update HJQYB set isupdated=0  where xh=" + xh;
            return strSql;
        }
        public static string UpdateLDLXBDataStr(string xh)
        {
            string strSql = "update LDLXB set isupdated=0  where xh=" + xh;
            return strSql;
        }
        public static string UpdateZBYXXBDataStr(string id)
        {
            string strSql = "update ZBYXXB set isupdated=0  where id=" + id;
            return strSql;
        }
        public static string UpdateZZBDataStr(string xh)
        {
            string strSql = "update ZZB set isupdated=0  where xh=" + xh;
            return strSql;
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        public static string UpdateLWBLGXTBDELDataStr(string id)
        {
            string strSql = "update LWBLGXTBDELB set isupdated=0  where id=" + id;
            return strSql;
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        public static string UpdateLWBLTBDELDataStr(string id)
        {
            string strSql = "update LWBLTBDELB set isupdated=0  where id=" + id;
            return strSql;
        }
        public static string UpdateDXSGBDataStr(string LSH)
        {
            string strSql = "update DXSGB set isupdated=0  where lsh=" + LSH;
            return strSql;
        }

        public static string UpdateLWDDGLBDataStr(string RemoteLSH, string RemoteDWBH, string LocalLSH)
        {
            string strSql = "update LWDDGLB set isupdated=0  where RemoteLSH= '" + RemoteLSH + "' and RemoteDWBH ='" + RemoteDWBH + "' and LocalLSH ='" + LocalLSH + "'";
            return strSql;
        }

        public static string UpdateLWCLTBDYBDataStr(string LocalLSH, string LocalCS, string LocalCLBH)
        {
            string strSql = "update LWCLTBDYB set isupdated=0    where LocalLSH= '" + LocalLSH + "' and LocalCS ='" + LocalCS + "' and LocalCLBH ='" + LocalCLBH + "'";
            return strSql;
        }

        public static string UpdateLWBLTBDYBDataStr(string LocalLSH, string LocalRecordID)
        {
            string strSql = "update LWBLTBDYB set isupdated=0  where LocalLSH= '" + LocalLSH + "' and LocalRecordID =" + LocalRecordID;
            return strSql;
        }

        public static string UpdateLWBLGXTBDYBDataStr(string LocalLSH, string LocalStatisticsID)
        {
            string strSql = "update LWBLGXTBDYB set isupdated=0  where LocalLSH= '" + LocalLSH + "' and LocalStatisticsID =" + LocalStatisticsID;
            return strSql;
        }
    }
}
