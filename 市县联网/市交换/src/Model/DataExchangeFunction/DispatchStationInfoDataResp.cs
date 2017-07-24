using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 调度分站记录信息上报的应答
    /// </summary>
    public class DispatchStationInfoDataResp
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 出车单位名称
        /// </summary>
        public string DispatchVehicleUnit { get; set; }
        /// <summary>
        /// 上报结果1:上报成功 0:上报失败
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因，如果成功则没有这段内容
        /// </summary>
        public string FailtureReason { get; set; }
    }
}
