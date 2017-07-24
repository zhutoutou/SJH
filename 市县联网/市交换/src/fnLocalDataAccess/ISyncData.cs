using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.fnLocalDataAccess.Oracle;


namespace ZIT.SJHServer.fnLocalDataAccess
{
   /// <summary>
   /// 负责将联网调度单的分中心出车及患者信息同步到市本地库中
   /// </summary>
   public interface ISyncData
    {
        /// <summary>
        /// 同步出车信息数据
        /// </summary>
       void SyncDispatchVehicleData(DispatchVehicleData DispatchVehicle, string UnitCode);

        /// <summary>
        /// 同步病历记录
        /// </summary>
       void SyncWeb_MedicalRecords(Web_MedicalRecords MedicalRecords, string UnitCode);

        /// <summary>
        ///  同步病历填写项目与值对应关系数据
        /// </summary>
       void SyncWeb_MedicalStatistics(Web_MedicalStatistics MedicalStatistics, string UnitCode);
       //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
       /// <summary>
       ///  病历关系记录删除数据
       /// </summary>
       void SyncLWBLGXTBDELB(LWBLGXTBDELB lwblgxtbdel, string UnitCode);
       //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
       /// <summary>
       ///  病历记录删除数据
       /// </summary>
       void SyncLWBLTBDELB(LWBLTBDELB lwblgxtbdel, string UnitCode);

       /// <summary>
       /// 病历记录应答
       /// </summary>
       event EventHandler<SyncDataRespEventArgs> DispatchVehicleDataRespExchange;

       /// <summary>
       /// 病历记录应答
       /// </summary>
       event EventHandler<SyncDataRespEventArgs> Web_MedicalRecordsRespExchange;

       /// <summary>
       /// 病历填写项目与值对应关系数据应答
       /// </summary>
       event EventHandler<SyncDataRespEventArgs> Web_MedicalStatisticsRespExchange;

    }
}
