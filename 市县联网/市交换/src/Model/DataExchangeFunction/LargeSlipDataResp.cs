﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 大型事故上报应答
    /// </summary>
    public class LargeSlipDataResp
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string ID { get; set; }
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
