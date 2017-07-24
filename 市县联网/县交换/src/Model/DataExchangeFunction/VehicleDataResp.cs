using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 车辆基础数据上报的应答
    /// </summary>
    public class VehicleDataResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 车载编号
        /// </summary>
        public string VehicleCode { get; set; }
        /// <summary>
        /// 车辆发动机编号
        /// </summary>
        public string EngineNumber { get; set; }
        /// <summary>
        /// 上报结果
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因，如果成功则没有这段内容
        /// </summary>
        public string FailtureReason { get; set; }

    }
}
