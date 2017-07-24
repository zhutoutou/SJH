using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 出车信息数据上报的应答
    /// </summary>
    public class DispatchVehicleDataResp
    {
        /// <summary>
        ///消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        ///车辆编号 
        /// </summary>
        public string VehicleCode { get; set; }
        /// <summary>
        /// 与本次出车所对应的受理记录流水号
        /// </summary>
        public string DealRecordID { get; set; }
        /// <summary>
        /// 出车车次
        /// </summary>
        public string Times { get; set; }
        /// <summary>
        /// 上报结果1:   上报成功0:   上报失败
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因，如果成功则没有这段内容
        /// </summary>
        public string FailtureReason { get; set; }
    }
}
