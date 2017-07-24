using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model
{
    //20160712 修改人：朱星汉 修改内容：添加定时重发机制
    /// <summary>
    /// 定时重发的机制
    /// </summary>
    public class ReSendMsg
    {
        /// <summary>
        /// 上一次发送时间
        /// </summary>
        public DateTime lastSendTime { get; set; }
        /// <summary>
        /// 重置发送的状态的SQL
        /// </summary>
        public string reUpdateSQL { get; set; }

        public ReSendMsg(DateTime dt, string sql)
        {
            this.lastSendTime = dt;
            this.reUpdateSQL = sql;
        }
        
        public ReSendMsg()
        {

        }
    }
}
