using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.fnDataAccess.DataSync.Oracle
{
    public class ReSendSql
    {
        /// <summary>
        /// 车辆信息数据上报isupdated=1
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static string ReSendVehicleDataStr(string clbh)
        {
            string strSql = "update clxxb set isupdated=1 where isupdated=2 and clbh='" + clbh + "'";
            return strSql;
        }
        /// <summary>
        /// 系统人员数据上报isupdated=1
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static string ReSendSysUserDataStr(string RYBH)
        {
            string strSql = "update xtryb set isupdated=1 where isupdated=2 and RYBH='" + RYBH + "'";
            return strSql;
        }
        /// <summary>
        /// 人员关系数据上报isupdated=1
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public static string ReSendPVRelationDataStr(string xh)
        {
            string strSql = "update rykqb set isupdated=1 where isupdated=2 and xh='" + xh + "'";
            return strSql;
        }
        /// <summary>
        /// 受理信息数据上报isupdated=1
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string ReSendDealDataStr(string lsh)
        {
            string strSql = "update sljlb set isupdated=1 where isupdated=2 and lsh='" + lsh + "'";
            return strSql;
        }

        /// <summary>
        /// 出车信息数据上报isupdated=1
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static string ReSendDispatchVehicleStr(string lsh, string cs, string clbh)
        {
            string strSql = "update ccxxb set isupdated=1 where isupdated=2 and lsh='" + lsh + "' and cs='" + cs + "' and clbh='" + clbh + "'";
            return strSql;
        }
        /// <summary>
        /// 患者信息数据isupdated=1
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="czdh"></param>
        /// <returns></returns>
        public static string ReSendSuffererDataStr(string lsh, string HZXH)
        {
            string strSql = "update hzxxb set isupdated=1 where isupdated=2 and lsh='" + lsh + "' and XH='" + HZXH + "'";
            return strSql;
        }
        /// <summary>
        /// 更新患者病历信息isupdated=1
        /// </summary>
        /// <param name="czdh"></param>
        /// <param name="slh"></param>
        /// <returns></returns>
        public static string ReSendSuffererCaseHistoryDataStr(string HZXH, string slh)
        {
            string strSql = "update hzblb set isupdated=1 where isupdated=2 and XH='" + HZXH + "' and lsh='" + slh + "'";
            return strSql;
        }
        /// <summary>
        /// 呼叫记录信息数据isupdated=1
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string ReSendCallRcordDataStr(string lsh)
        {
            string strSql = "update hjjlb set isupdated=1 where isupdated=2 and lsh='" + lsh + "'";
            return strSql;
        }
        /// <summary>
        /// 单位信息数据isupdated=1
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public static string ReSendUnitInfoDataStr(string unitCode)
        {
            string strSql = "update dwxxb set isupdated=1 where isupdated=2 and dwbh='" + unitCode + "'";
            return strSql;
        }
        /// <summary>
        /// 大型事故信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string ReSendLargeSlipDataStr(string lsh)
        {
            string strSql = "update dxsgb set isupdated=1 where isupdated=2 and lsh='" + lsh + "'";
            return strSql;
        }
        /// <summary>
        /// 调度分站记录信息数据isupdated=2
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static string ReSendDispatchStationInfoDataStr(string lsh, string ccdw)
        {
            string strSql = "update ddfzjlb set isupdated=1 where isupdated=2 and lsh='" + lsh + "' and ccdw='" + ccdw + "'";
            return strSql;
        }

        public static string ReSendWeb_MedicalProjectDataStr(string id)
        {
            string strSql = "update Web_MedicalProject set isupdated=1 where isupdated=2 and id='" + id + "'";
            return strSql;
        }
        public static string ReSendWeb_MedicalProjectValueDataStr(string id)
        {
            string strSql = "update Web_MedicalProjectValue set isupdated=1 where isupdated=2 and id='" + id + "'";
            return strSql;
        }
        public static string ReSendWeb_MedicalRecordsDataStr(string id)
        {
            string strSql = "update Web_MedicalRecords set isupdated=1  where isupdated=2 and id=" + id;
            return strSql;
        }
        public static string ReSendWeb_MedicalStatisticsDataStr(string id)
        {
            string strSql = "update Web_MedicalStatistics set isupdated=1  where isupdated=2 and id=" + id;
            return strSql;
        }

        public static string ReSendBLJCXXBDataStr(string lx, string mc)
        {
            string strSql = "update BLJCXXB set isupdated=1  where isupdated=2 and lx= '" + lx + "'and mc ='" + mc + "'";
            return strSql;
        }
        public static string ReSendHJQYBDataStr(string xh)
        {
            string strSql = "update HJQYB set isupdated=1  where isupdated=2 and xh=" + xh;
            return strSql;
        }
        public static string ReSendLDLXBDataStr(string xh)
        {
            string strSql = "update LDLXB set isupdated=1  where isupdated=2 and xh=" + xh;
            return strSql;
        }
        public static string ReSendZBYXXBDataStr(string id)
        {
            string strSql = "update ZBYXXB set isupdated=1  where isupdated=2 and id=" + id;
            return strSql;
        }
        public static string ReSendZZBDataStr(string xh)
        {
            string strSql = "update ZZB set isupdated=1  where isupdated=2 and xh=" + xh;
            return strSql;
        }

        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        public static string ReSendLWBLGXTBDELDataStr(string id)
        {
            string strSql = "update LWBLGXTBDELB set isupdated=1  where isupdated=2 and id=" + id;
            return strSql;
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        public static string ReSendLWBLTBDELDataStr(string id)
        {
            string strSql = "update LWBLTBDELB set isupdated=1  where isupdated=2 and id=" + id;
            return strSql;
        }
        public static string ReSendDXSGBDataStr(string lsh)
        {
            string strSql = "update DXSGB set isupdated=1  where isupdated=2 and lsh=" + lsh ;
            return strSql;
        }

    }
}
