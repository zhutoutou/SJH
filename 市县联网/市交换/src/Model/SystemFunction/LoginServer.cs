using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.SystemFunction
{
    /// <summary>
    /// 网络单元登陆服务器
    /// </summary>
    public class LoginServer
    {
        /// <summary>
        /// ID
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UnitCode { get; set; }
        /// <summary>
        /// 台类型
        /// </summary>
        public string StationType { get; set; }
    }
}
