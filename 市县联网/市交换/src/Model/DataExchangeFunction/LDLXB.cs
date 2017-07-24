using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*
     * CREATE TABLE "CD120NEW"."LDLXB" 
   (	"XH" NUMBER(2,0), 
	"LX" VARCHAR2(20) NOT NULL ENABLE, 
	"RJ" VARCHAR2(10), 
	"PCBZ" VARCHAR2(2) DEFAULT '否'   ) 
 
  ALTER TABLE "CD120NEW"."LDLXB" MODIFY ("LX" NOT NULL ENABLE);
     */
    /// <summary>
    /// 来电类型表
    /// </summary>
    public class LDLXB
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string LX { get; set; }
        /// <summary>
        /// 热键
        /// </summary>
        public string RJ { get; set; }
        /// <summary>
        /// 派车标志
        /// </summary>
        public string PCBZ { get; set; }
    }
}
