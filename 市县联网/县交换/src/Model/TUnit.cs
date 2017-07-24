using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ZIT.XJHServer.Model
{
    //网络单元属性结构数组
    public struct TUnit
    {
        public string UnitIP;
        public string UnitPort;
        public string UnitType;
        public string UnitID;
        public string UnitSSDW;
        public string UnitMC;
        public string UnitState;
        public string UnitConnTime;
        public string UnitZBY;
        public Socket UnitTcpClient;
        public IntPtr UnitTcpHandle;
    }
}
