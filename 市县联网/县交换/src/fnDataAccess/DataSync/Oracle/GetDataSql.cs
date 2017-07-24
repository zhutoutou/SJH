using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using ZIT.XJHServer.fnArgs;

namespace ZIT.XJHServer.fnDataAccess.DataSync.Oracle
{
    internal class GetDataSql
    {
        private static int rownum = SystemArgs.GetInstance().args.ReadRowNumber;
        /// <summary>
        /// 系统人员数据上传
        /// 主键:人员编号(RYBH)
        /// </summary>
        /// <returns></returns>
        public static string GetSysUserDataStr()
        {
            string strSql = "select * from xtryb where isupdated=1 and rybh is not null and rownum<" + rownum ;
            return strSql;
        }
        /// <summary>
        /// 急救人员及急救车辆关系数据
        /// </summary>
        /// <returns></returns>
        public static string GetPVRelationDataStr()
        {
            //成都版本没有rybh
            //string strSql = "select t.*, a.id,t.rowid,CZDH from rykqb t,xtryb a,clxxb c where t.xm=a.xm and c.clbh=t.clbh and t.isupdated=1  and rownum<" + rownum + " order by xh desc";
            string strSql = "select t.*, a.id,a.rybh,t.rowid,CZDH from rykqb t,xtryb a,clxxb c where t.xm=a.xm and c.clbh=t.clbh and t.isupdated=1  and rownum<" + rownum ;
            return strSql;
        }

        /// <summary>
        /// 当前状态信息表
        /// </summary>
        /// <returns></returns>
        public static string GetDqclztxxbStr()
        {
            string strSql = "select ID,LSH,GZZT,zhfxsj,xslc from dqclztxxb";
            return strSql;
        }
        /// <summary>
        ///  受理信息数据上报
        ///  主键:流水号(LSH)
        /// </summary>
        /// <returns></returns>
        public static string GetDealDataStr()
        { 
            string strSql = "select * from sljlb where isupdated=1 and lsh is not null and rownum<" + rownum ;
            return strSql;
        }
        /// <summary>
        ///  出车信息数据上报
        ///  主键:出车车次(CS),流水号(LSH)  车辆编号(CLBH)不能为空
        /// </summary>
        /// <returns></returns>
        public static string GetDispatchVehicleDataStr()
        {
            string strSql = "select * from ccxxb where clbh is not null and lsh is not null and cs is not null and isupdated=1 and rownum<" + rownum;
            return strSql;
        }
        /// <summary>
        ///  患者信息数据
        ///  主键:流水号(LSH),车辆编号(CLBH),序号(XH)
        /// </summary>
        /// <returns></returns>
        public static string GetSuffererDataStr()
        {
            string strSql = "select * from hzxxb cc join clxxb cl on cc.clbh=cl.clbh where cc.isupdated=1 and cc.lsh is not null and cc.clbh is not null and cc.xh is not null and rownum<" + rownum;
            return strSql;
        }
        /// <summary>
        /// 患者病历信息数据
        /// 主键:流水号(LSH),车辆编号(CLBH),序号(XH)
        /// </summary>
        /// <returns></returns>
        public static string GetSuffererCaseHistoryDataStr()
        {
            string strSql = "select * from hzblb h join  clxxb c on h.clbh=c.clbh where h.isupdated=1 and h.lsh is not null and h.clbh is not null and h.xh is not null and rownum<" + rownum;
            return strSql;
        }
        /// <summary>
        /// 呼叫记录信息数据上传
        /// 主键:流水号(LSH)
        /// </summary>
        /// <returns></returns>
        public static string GetCallRcordDataStr()
        {
            string strSql = "select * from hjjlb where isupdated=1 and lsh is not null and floor(to_number(sysdate-ldsj)*24*60*60)>300 and rownum<" + rownum;
            return strSql;
        }
        /// <summary>
        /// 车辆信息表
        /// 主键：clbh
        /// </summary>
        /// <returns></returns>
        public static string GetVehicleDataStr()
        {
            string strSql = "select * from clxxb where isupdated =1 and clbh is not null and rownum<" + rownum ;
            return strSql;
        }
        /// <summary>
        /// 单位信息数据上传 主键：DWBH
        /// </summary>
        /// <returns></returns>
        public static string GetUnitInfoDataStr()
        {
            string strSql = "select * from dwxxb where dwbh is not null  and isupdated=1 and rownum<" + rownum;
            return strSql;
        }
        /// <summary>
        /// 大型事故信息数据
        /// 主键:流水号(LSH)
        /// </summary>
        /// <returns></returns>
        public static string GetLargeSlipDataStr()
        {
            string strSql = "select * from dxsgb where isupdated=1 and lsh is not null and rownum<" + rownum ;
            return strSql;
        }
        /// <summary>
        ///  调度分站记录信息数据
        ///  主键:流水号(LSH) 出车单位(CCDW)
        /// </summary>
        /// <returns></returns>
        public static string GetDispatchStationInfoDataStr()
        {
            string strSql = "select * from ddfzjlb where isupdated=1 and lsh is not null and ccdw is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        ///  病历填写项目表
        ///  主键:ID
        /// </summary>
        /// <returns></returns>
        public static string GetWeb_MedicalProjectStr()
        {
            string strSql = "select * from Web_MedicalProject where isupdated=1 and ID is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        /// 病历填写项目值表
        ///  主键:ID
        /// </summary>
        /// <returns></returns>
        public static string GetWeb_MedicalProjectValueStr()
        {
            string strSql = "select * from Web_MedicalProjectValue where isupdated=1 and ID is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        /// 病历记录表
        ///  主键:ID
        /// </summary>
        /// <returns></returns>
        public static string GetWeb_MedicalRecordsStr()
        {
            string strSql = "select * from Web_MedicalRecords where isupdated=1 and ID is not null and lsh is not null and cs is not null and clbh is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        /// 病历填写项目与值对应表
        ///  主键:ID
        /// </summary>
        /// <returns></returns>
        public static string GetWeb_MedicalStatisticsStr()
        {
            string strSql = "select t.*,m.lsh,m.cs,m.clbh from Web_MedicalStatistics t,Web_MedicalRecords m where m.id=t.medicalrecordsid and t.isupdated=1 and t.ID is not null and rownum<" + rownum;
            return strSql;
        }


        /// <summary>
        /// 病历基础信息表
        ///  主键:XH
        /// </summary>
        /// <returns></returns>
        public static string GetBLJCXXBStr()
        {
            string strSql = "select * from BLJCXXB where isupdated=1 and XH is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        /// 呼救区域表
        ///  主键:XH
        /// </summary>
        /// <returns></returns>
        public static string GetHJQYBStr()
        {
            string strSql = "select * from HJQYB where isupdated=1 and XH is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        /// 来电类型表
        ///  主键:XH
        /// </summary>
        /// <returns></returns>
        public static string GetLDLXBStr()
        {
            string strSql = "select * from LDLXB where isupdated=1 and XH is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        /// 值班员信息表
        ///  主键:ID
        /// </summary>
        /// <returns></returns>
        public static string GetZBYXXBStr()
        {
            string strSql = "select * from ZBYXXB where isupdated=1 and ID is not null and rownum<" + rownum;
            return strSql;
        }

        /// <summary>
        /// 症状表
        ///  主键:XH
        /// </summary>
        /// <returns></returns>
        public static string GetZZBStr()
        {
            string strSql = "select * from ZZB where isupdated=1 and XH is not null and rownum<" + rownum;
            return strSql;
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系记录删除表
        ///  
        /// </summary>
        /// <returns></returns>
        public static string GetLWBLGXTBDELBStr()
        {
            string strSql = "select * from LWBLGXTBDELB where isupdated=1 and ID is not null and rownum<" + rownum;
            return strSql;
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历关系记录删除表
        ///  
        /// </summary>
        /// <returns></returns>
        public static string GetLWBLTBDELBStr()
        {
            string strSql = "select * from LWBLTBDELB where isupdated=1 and ID is not null and rownum<" + rownum;
            return strSql;
        }
        /// <summary>
        /// 大型事故表
        ///  主键:LSH
        /// </summary>
        /// <returns></returns>
        public static string GetDXSGBStr()
        {
            string strSql = "select * from DXSGB where isupdated=1 and LSH is not null and rownum<" + rownum;
            return strSql;
        }
        
    }
}
