using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model
{
    /// <summary>
    /// 分中心120业务服务器握手，上传到市中心，用来判断分中心是否在线
    /// </summary>
    public class SubCenterBssHandShark
    {
        /// <summary>
        /// 消息号
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DWBH { get; set; }
    }
}
