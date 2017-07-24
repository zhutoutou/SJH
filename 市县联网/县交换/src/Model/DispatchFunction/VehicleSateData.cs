using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DispatchFunction
{
   public class VehicleSateData
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        public string CLID { get; set; }
        public string GZZT { get; set; }
        public string ZHFXSJ { get; set; }
        public string DXDDSJ { get; set; }
        public string SD { get; set; }
        public string FX { get; set; }
        public string JD { get; set; }
        public string WD { get; set; }
        public string LSH { get; set; }
        public string XZBM { get; set; }
    }
}
