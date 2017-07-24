using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*
    CREATE TABLE "CD120NEW"."LWCLTBDYB" 
   (	"LOCALLSH" VARCHAR2(19), 
	"LOCALCS" VARCHAR2(12), 
	"LOCALCLBH" VARCHAR2(20), 
	"TARGETLSH" VARCHAR2(19), 
	"TARGETCS" VARCHAR2(12), 
	"TARGETCLBH" VARCHAR2(20), 
	"TARGETDWBH" VARCHAR2(6)
   )  ;
 
   COMMENT ON COLUMN "CD120NEW"."LWCLTBDYB"."LOCALLSH" IS '本地车次';
 
   COMMENT ON COLUMN "CD120NEW"."LWCLTBDYB"."LOCALCS" IS '本地的流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWCLTBDYB"."LOCALCLBH" IS '本地的车辆编号';
 
   COMMENT ON COLUMN "CD120NEW"."LWCLTBDYB"."TARGETLSH" IS '对方流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWCLTBDYB"."TARGETCS" IS '对方车次';
 
   COMMENT ON COLUMN "CD120NEW"."LWCLTBDYB"."TARGETCLBH" IS '对方车辆编号';
 
   COMMENT ON COLUMN "CD120NEW"."LWCLTBDYB"."TARGETDWBH" IS '对方单位编号';
     */
    /// <summary>
    /// 联网车辆同步对应表
    /// </summary>
    public class LWCLTBDYB
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 本地车次
        /// </summary>
        public string LocalLSH { get; set; }
        /// <summary>
        /// 本地的流水号
        /// </summary>
        public string LocalCS { get; set; }
        /// <summary>
        /// 本地的车辆编号
        /// </summary>
        public string LocalCLBH { get; set; }
        /// <summary>
        /// 对方流水号
        /// </summary>
        public string TargetLSH { get; set; }
        /// <summary>
        /// 对方车次
        /// </summary>
        public string TargetCS { get; set; }
        /// <summary>
        /// 对方车辆编号
        /// </summary>
        public string TargetCLBH { get; set; }
        /// <summary>
        /// 对方单位编号
        /// </summary>
        public string TargetDWBH { get; set; }
    }
}
