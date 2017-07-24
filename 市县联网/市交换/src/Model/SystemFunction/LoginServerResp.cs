using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.SystemFunction
{
    /// <summary>
    /// 网络单元登陆服务器的应答
    /// </summary>
   public class LoginServerResp
    {
       /// <summary>
        /// ID
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 1成功、0失败
        /// </summary>
        public int LoginResult { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailtureReason { get; set; }

    }
}
