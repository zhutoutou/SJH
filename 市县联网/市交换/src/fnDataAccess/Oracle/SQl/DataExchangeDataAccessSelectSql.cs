using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.fnArgs;
using ZIT.Utility;

namespace ZIT.SJHServer.fnDataAccess.Oracle.SQl
{
    //20151201 修改人:朱星汉 修改内容:全局库的主键应为原本的主键加上行政编码
    public class DataExchangeDataAccessSelectSql
    {
        /// <summary>
        /// 获取查询行政编码表语句
        /// </summary>
        /// <returns></returns>
        public string GetAllUnitXZBMSql()
        {
            string sql = "select * from xzbmb";
            return sql;
        }

        /// <summary>
        /// 车辆状态是否存在
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public bool GetBoolVehicleID(string ID ,string XZBM)
        {
            bool VehicleID = false;
            try
            {
                string sql = "select id from dqclztxxb where id='" + ID + "' and xzbm='" +XZBM +"'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    VehicleID = true;
                }
            }
            catch {}
            return VehicleID;
        }
        /// <summary>
        /// 获取车辆ID
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public string GetVehicleID(string Mobile,string XZBM)
        {
            string ID = "";
            try
            {
                string sql = "select ID from clxxb where CZDH='" + Mobile + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    ID = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetVehicleID", ex);
            }
            return ID;
        }
        /// <summary>
        /// 查询车辆编号
        /// </summary>
        /// <param name="DealRecordID">流水号</param>
        /// <param name="Mobile">手机号</param>
        /// <returns></returns>
        public string GetVehicleNo(string DealRecordID, string Mobile,string XZBM)
        {
            string clbh = "";
            try
            {
                string sql = "select cl.clbh from clxxb cl join ccxxb cc on cl.clbh=cc.clbh where lsh='" + DealRecordID + "' and cl.czdh='" + Mobile + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    clbh = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetVehicleNo", ex);
            }
            return clbh;
        }
        /// <summary>
        /// 查询车辆编号
        /// </summary>
        /// <param name="DealRecordID">流水号</param>
        /// <param name="Mobile">手机号</param>
        /// <returns></returns>
        public string GetVehicleNo(string Mobile,string XZBM)
        {
            string clbh = "";
            try
            {
                string sql = "select clbh from clxxb where CZDH='" + Mobile + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    clbh = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetVehicleNo", ex);
            }
            return clbh;
        }
        /// <summary>
        /// 查询车辆信息是否存在
        /// </summary>
        /// <param name="VehicleCode"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public bool GetBoolVehicleData(string clbh,string  XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select clbh from clxxb where clbh='" + clbh + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetBoolVehicleData", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 查询GPS车辆信息是否存在
        /// </summary>
        /// <param name="VehicleCode"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public bool GetBoolGpsVehicleData(string clbh,string XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select clbh from clzlb where clbh='" + clbh + "' and xzbm='" + XZBM + "'";
                object obj = GPSDBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetBoolVehicleData", ex);
            }
            return Vehicle;
        }
        public bool GetBoolBSSVehicleData(string clbh,string XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select clbh from clxxb where clbh='" + clbh + "' and xzbm='" + XZBM + "'";
                object obj = GPSDBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetBoolVehicleData", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 查询人员信息是否存在
        /// </summary>
        /// <param name="VehicleCode"></param>
        /// <returns></returns>
        public bool GetBoolSysUserData(string UserName,string XZBM)
        {
            bool SysUser = false;
            try
            {
                string sql = "select xm from xtryb t where rybh='" + UserName + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    SysUser = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetBoolSysUserData", ex);
            }
            return SysUser;
        }
        /// <summary>
        /// 查询受理记录是否存在
        /// </summary>
        /// <param name="DealRecordID"></param>
        /// <returns></returns>
        public bool GetBoolDealData(string DealRecordID, string XZBM)
        {
            bool DealData = false;
            try
            {
                string sql = "select lsh from sljlb t where lsh='" + DealRecordID + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    DealData = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetBoolDealData", ex);
            }
            return DealData;
        }
        /// <summary>
        /// 出车信息表
        /// </summary>
        /// <param name="DealRecordID"></param>
        /// <param name="VehicleNo"></param>
        /// <returns></returns>
        public bool GetDispatchVehicleData(string DealRecordID, string VehicleCode, string cs, string XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select lsh from CCXXB t where lsh='" + DealRecordID + "' and cs='" + cs + "' and clbh='" + VehicleCode + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetDispatchVehicleData", ex);
            }
            return Vehicle;

        }
        /// <summary>
        /// 患者信息表
        /// </summary>
        /// <param name="DealRecordID"></param>
        /// <param name="VehicleNo"></param>
        /// <returns></returns>
        public bool GetSuffererData(string DealRecordID, string VehicleNo, string XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select lsh from HZXXB t where lsh='" + DealRecordID + "'and clbh='" + VehicleNo + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetSuffererDataData", ex);
            }
            return Vehicle;

        }
        /// <summary>
        /// 患者病历信息表
        /// </summary>
        /// <param name="DealRecordID"></param>
        /// <param name="VehicleNo"></param>
        /// <returns></returns>
        public bool GetSuffererCaseHistoryData(string DealRecordID, string VehicleNo, string XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select lsh from HZBLB t where lsh='" + DealRecordID + "'and clbh='" + VehicleNo + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetSuffererCaseHistoryData", ex);
            }
            return Vehicle;

        }
        /// <summary>
        /// 呼叫记录表
        /// </summary>
        /// <param name="DealRecordID"></param>
        /// <returns></returns>
        public bool GetCallRcordData(string DealRecordID, string XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select lsh from HJJLB t where lsh='" + DealRecordID + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetCallRcordData", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 单位信息表
        /// </summary>
        /// <param name="UnitCode"></param>
        /// <returns></returns>
        public bool GetUnitInfoData(string UnitCode, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select DWBH from DWXXB t where DWBH='" + UnitCode + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetUnitInfoData", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 单位信息表
        /// </summary>
        /// <param name="UnitCode"></param>
        /// <returns></returns>
        public bool GetGpsUnitInfoData(string UnitCode, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select DWBH from DWXXB t where DWBH='" + UnitCode + "' and xzbm='" + XZBM + "'";
                object obj = GPSDBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetUnitInfoData", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 大型事故信息表
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool GetLargeSlipData(string ID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select lsh from DXSGB t where LSH='" + ID + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetLargeSlipData", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 调度分站记录信息表
        /// </summary>
        /// <param name="LSH"></param>
        /// <param name="CCDW"></param>
        /// <param name="XZBM"></param>
        /// <returns></returns>
        public bool GetDispatchStationInfoData(string LSH, string CCDW, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select lsh from DDFZJLB t where LSH='" + LSH + "' and CCDW='" + CCDW + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetDispatchStationInfoData", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 获取人员考勤表序号
        /// </summary>
        /// <returns></returns>
        public string GetNumber()
        {
            try
            {
                string sql = "select count(*)+1 from Rykqb where xh>=to_char(sysdate,'yyyyMMdd')||'0000'";
                string Number = DBHelperOracle.GetSingle(sql).ToString();
                string No = "";
                if (Number.Length == 1)
                {
                    No = DateTime.Now.ToString("yyyyMMdd")+"000" + Number;
                }
                else if (Number.Length == 2)
                {
                    No = DateTime.Now.ToString("yyyyMMdd") + "00" + Number;
                }
                else if (Number.Length == 3)
                {
                    No = DateTime.Now.ToString("yyyyMMdd") + "0" + Number;
                }
                else if (Number.Length == 4)
                {
                    No = DateTime.Now.ToString("yyyyMMdd") + Number;
                }
                return No;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 病历填写项目
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool GetWeb_MedicalProject(string ID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select id from Web_MedicalProject t where id='" + ID + "'  and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetWeb_MedicalProject", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 病历填写项目值
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool GetWeb_MedicalProjectValue(string ID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select id from Web_MedicalProjectValue t where id='" + ID + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetWeb_MedicalProjectValue", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 病历记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool GetWeb_MedicalRecords(string ID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select id from Web_MedicalRecords t where ID=" + ID + " and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetWeb_MedicalRecords", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 病历填写项目与值对应关系数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool GetWeb_MedicalStatistics(string ID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select id from Web_MedicalStatistics t where ID=" + ID + " and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetWeb_MedicalStatistics", ex);
            }
            return Vehicle;
        }

         /// <summary>
        /// 病历基础信息表数据
        /// </summary>
        public bool GetBLJCXXB(string LX,string MC, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select XH from BLJCXXB t where LX='" + LX + "'and MC ='" + MC + "'and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetBLJCXXB", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        public bool GetHJQYB(string XH, string XZBM)
      {

          bool Vehicle = false;
          try
          {
              string sql = "select XH from HJQYB t where XH=" + XH + " and xzbm='" + XZBM + "'";
              object obj = DBHelperOracle.GetSingle(sql);
              if (obj != null)
              {
                  Vehicle = true;
              }
          }
          catch (Exception ex)
          {
              LOG.LogHelper.WriteLog("GetHJQYB", ex);
          }
          return Vehicle;
      }
        /// <summary>
        /// 来电类型表数据
        /// </summary>
        public bool GetLDLXB(string XH, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select XH from LDLXB where XH=" + XH + " and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetLDLXB", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 值班员信息表数据
        /// </summary>
        public bool GetZBYXXB(string ID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select id from ZBYXXB where ID=" + ID + " and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetZBYXXB", ex);
            }
            return Vehicle;
        }
        /// <summary>
        /// 症状表数据
        /// </summary>
        public bool GetZZB(string XH, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select XH from ZZB  where XH=" + XH + " and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetZZB", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 大型事故表数据
        /// </summary>
        public bool GetDXSGB(string LSH, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select LSH from DXSGB  where LSH='" + LSH + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetDXSGB", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 联网调度关联表数据
        /// </summary>
        public bool GetLWDDGLB(string RemoteLSH, string RemoteDWBH, string LocalLSH, string XZBM)
        {
            bool Vehicle = false;
            try
            {
                string sql = "select RemoteLSH from LWDDGLB  where RemoteLSH= '" + RemoteLSH + "' and RemoteDWBH ='" + RemoteDWBH + "' and LocalLSH ='" + LocalLSH + "' and  xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetLWDDGLB", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 联网车辆同步对应表数据
        /// </summary>
        public bool GetLWCLTBDYB(string LocalLSH, string LocalCS, string LocalCLBH, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select LocalLSH from LWCLTBDYB  where  LocalLSH= '" + LocalLSH + "' and LocalCS ='" + LocalCS + "' and LocalCLBH ='" + LocalCLBH + "' and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetLWCLTBDYB", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 联网病历同步对应表数据
        /// </summary>
        public bool GetLWBLTBDYB(string LocalLSH, string LocalRecordID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select LocalLSH from LWBLTBDYB  where  LocalLSH= '" + LocalLSH + "' and LocalRecordID =" + LocalRecordID + "  and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetLWBLTBDYB", ex);
            }
            return Vehicle;
        }

        /// <summary>
        /// 联网病历关系同步对应表数据
        /// </summary>
        public bool GetLWBLGXTBDYB(string LocalLSH, string LocalStatisticsID, string XZBM)
        {

            bool Vehicle = false;
            try
            {
                string sql = "select LocalLSH from LWBLGXTBDYB  where LocalLSH= '" + LocalLSH + "' and LocalStatisticsID =" + LocalStatisticsID + " and xzbm='" + XZBM + "'";
                object obj = DBHelperOracle.GetSingle(sql);
                if (obj != null)
                {
                    Vehicle = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("GetLWBLGXTBDYB", ex);
            }
            return Vehicle;
        }
    }
}
