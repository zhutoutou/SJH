using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ZIT.SJHServer.Model
{
    public class TCPDrainage
    {
        public Socket Socket;
        public string IPAddress;
        public int Port;
        /// <summary>
        /// ZIT代表自己公司，Other代表其它公司数据
        /// </summary>
        public string Type;
        public List<UnitInfo> UnitList;
        public string UnitName;
        public string UnitCode;
    }
}
