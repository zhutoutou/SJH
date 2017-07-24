using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.SystemFunction
{
    /// <summary>
    /// 网络单元连接服务器的应答
    /// </summary>
    public class ConnectServerResp
    {
        /// <summary>
        /// ID
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 连接是否成功 1:   连接服务器成功 0:   连接失败
        /// </summary>
        public int ConnectResult { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailtureReason { get; set; }


    }
}
