using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 镇江市120派单给县市120的应答
    /// </summary>
    public class DispatchTaskRequestReinforcementResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 发送方网络单位ID
        /// </summary>
        public string SourceUnitID { get; set; }
        /// <summary>
        /// 数据接收方网络单位ID
        /// </summary>
        public string TargetUnitID { get; set; }
        /// <summary>
        /// 消息流水号
        /// </summary>
        public string SequenceNo { get; set; }
        /// <summary>
        /// 受理记录流水号
        /// </summary>
        public string DealRecordID { get; set; }
        /// <summary>
        /// 上报结果0x01:   上报成功0x00:   上报失败
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailtureReason { get; set; }
    }
}
