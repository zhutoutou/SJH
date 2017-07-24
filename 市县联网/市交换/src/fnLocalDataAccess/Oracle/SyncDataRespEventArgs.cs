using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model.DispatchFunction;

namespace ZIT.SJHServer.fnLocalDataAccess.Oracle
{
    /// <summary>
    /// 数据交换应答
    /// </summary>
    public class SyncDataRespEventArgs : EventArgs
    {
 
        /// <summary>
        /// 出车信息数据
        /// </summary>
        public DispatchVehicleDataResp DispatchVehicleDataRespMessage { get; private set; }
        public SyncDataRespEventArgs(DispatchVehicleDataResp message)
        {
            DispatchVehicleDataRespMessage = message;
        }
  
        /// <summary>
        /// 同步病历记录
        /// </summary>
        public Web_MedicalRecordsResp Web_MedicalRecordsRespMessage { get; private set; }
        public SyncDataRespEventArgs(Web_MedicalRecordsResp message)
        {
            Web_MedicalRecordsRespMessage = message;
        }
        /// <summary>
        /// 病历填写项目与值对应关系数据
        /// </summary>
        public Web_MedicalStatisticsResp Web_MedicalStatisticsRespMessage { get; private set; }
        public SyncDataRespEventArgs(Web_MedicalStatisticsResp message)
        {
            Web_MedicalStatisticsRespMessage = message;
        }
     
    }
}
