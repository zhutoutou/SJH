using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*CREATE TABLE "CD120NEW"."ZBYXXB" 
   (	"ID" NUMBER(6,0) NOT NULL ENABLE, 
	"XM" VARCHAR2(20), 
	"MM" VARCHAR2(20), 
	"BC" VARCHAR2(8), 
	"XTSF" VARCHAR2(16) NOT NULL ENABLE, 
	"DJRQ" DATE DEFAULT sysdate, 
	"ZXBZ" VARCHAR2(2) DEFAULT '否', 
	"ZXRQ" DATE, 
	"MS" VARCHAR2(50), 
	"LXFF" VARCHAR2(50), 
	 CONSTRAINT "ZBYXXB_XTSF_FK" FOREIGN KEY ("XTSF")
	  REFERENCES "CD120NEW"."XTSFB" ("SF") ENABLE
   )*/
    /// <summary>
    /// 值班员信息表
    /// </summary>
    public class ZBYXXB
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string XM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string XTSF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DJRQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZXBZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZXRQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LXFF { get; set; }

    }
}
