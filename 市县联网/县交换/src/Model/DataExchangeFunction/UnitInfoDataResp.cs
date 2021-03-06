﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 单位信息上报的应答
    /// </summary>
    public class UnitInfoDataResp
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UnitCode { get; set; }
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
