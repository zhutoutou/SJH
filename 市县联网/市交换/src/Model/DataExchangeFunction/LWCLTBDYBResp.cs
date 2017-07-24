using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    public class LWCLTBDYBResp
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 本地车次
        /// </summary>
        public string LocalLSH { get; set; }
        /// <summary>
        /// 本地的流水号
        /// </summary>
        public string LocalCS { get; set; }
        /// <summary>
        /// 本地的车辆编号
        /// </summary>
        public string LocalCLBH { get; set; }
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
