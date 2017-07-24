using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model
{
    /// <summary>
    /// 分中心状态
    /// </summary>
    public class DWLWSTATE
    {
        public string CommandID { get; set; }
        private List<SX> _SXS = new List<SX>();
        public List<SX> SXS
        {
            get { return _SXS; }
            set { _SXS = value; }
        }
    }
    public class SX
    {
        public string XZBM { get; set; }
        public string ZT { get; set; }
    }
}
