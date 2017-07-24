using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.SystemFunction
{
    /// <summary>
    /// 网络单元连接务服务器
    /// </summary>
   public class ConnectServer
    {
       /// <summary>
       /// ID
       /// </summary>
       public string CommandID { get; set; }
       /// <summary>
       /// 连接端机器主机名
       /// </summary>
       public string HostName { get; set; }
    }
}
