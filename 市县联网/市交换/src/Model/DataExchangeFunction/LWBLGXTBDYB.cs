using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*
        CREATE TABLE "CD120NEW"."LWBLGXTBDYB" 
   (	"LOCALLSH" VARCHAR2(19), 
	"LOCALSTATISTICSID" NUMBER(8,0), 
	"TARGETLSH" VARCHAR2(19), 
	"TARGETSTATISTICSID" NUMBER(8,0), 
	"TARGETDWBH" VARCHAR2(6)
   ) ;
 
   COMMENT ON COLUMN "CD120NEW"."LWBLGXTBDYB"."LOCALLSH" IS '本地的流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLGXTBDYB"."LOCALSTATISTICSID" IS '本地病历关系ID号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLGXTBDYB"."TARGETLSH" IS '对方流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLGXTBDYB"."TARGETSTATISTICSID" IS '对方病历关系ID号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLGXTBDYB"."TARGETDWBH" IS '对方单位编号';
     */
    /// <summary>
    /// 联网病历关系同步对应表
    /// </summary>
    public class LWBLGXTBDYB
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 本地的流水号
        /// </summary>
        public string LocalLSH { get; set; }
        /// <summary>
        /// 本地病历关系ID号
        /// </summary>
        public string LocalStatisticsID { get; set; }
        /// <summary>
        /// 对方流水号
        /// </summary>
        public string TargetLSH { get; set; }
        /// <summary>
        /// 对方病历关系ID号
        /// </summary>
        public string TargetStatisticsID { get; set; }
        /// <summary>
        /// 对方单位编号
        /// </summary>
        public string TargetDWBH { get; set; }
    }
}
