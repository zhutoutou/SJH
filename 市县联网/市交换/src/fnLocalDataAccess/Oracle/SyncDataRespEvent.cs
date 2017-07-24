using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model.DispatchFunction;

namespace ZIT.SJHServer.fnLocalDataAccess.Oracle
{
    /// <summary>
    ///  /// <summary>
    /// 同步数据答应  映射到Mobile并通知上层
    /// </summary>
    /// </summary>
    public class SyncDataRespEvent
    {
        /// <summary>
        /// 出车信息数据答应
        /// </summary>
        public event EventHandler<SyncDataRespEventArgs> DispatchVehicleDataRespExchange;
        protected virtual void OnMessageDataExchange(DispatchVehicleDataResp message)
        {
            var handler = DispatchVehicleDataRespExchange;
            if (handler != null)
            {
                handler(this, new SyncDataRespEventArgs(message));
            }
        }
      

        /// <summary>
        /// 病历记录应答
        /// </summary>
        public event EventHandler<SyncDataRespEventArgs> Web_MedicalRecordsRespExchange;

        protected virtual void OnMessageDataExchange(Web_MedicalRecordsResp message)
        {
            var handler = Web_MedicalRecordsRespExchange;
            if (handler != null)
            {
                handler(this, new SyncDataRespEventArgs(message));
            }
        }

        /// <summary>
        /// 病历填写项目与值对应关系数据应答
        /// </summary>
         public event EventHandler<SyncDataRespEventArgs> Web_MedicalStatisticsRespExchange;
         protected virtual void OnMessageDataExchange(Web_MedicalStatisticsResp message)
         {
             var handler = Web_MedicalStatisticsRespExchange;
             if (handler != null)
             {
                 handler(this, new SyncDataRespEventArgs(message));
             }
         }
    }
}
