﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    public class LWBLTBDELBResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 删除的病历表中的ID
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
