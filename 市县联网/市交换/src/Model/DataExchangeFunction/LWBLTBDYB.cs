using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*
   CREATE TABLE "CD120NEW"."LWBLTBDYB" 
   (	"LOCALLSH" VARCHAR2(19), 
	"LOCALRECORDID" NUMBER(8,0), 
	"TARGETLSH" VARCHAR2(19), 
	"TARGETRECORDID" NUMBER(8,0), 
	"TARGETDWBH" VARCHAR2(6)
   )  ;
 
   COMMENT ON COLUMN "CD120NEW"."LWBLTBDYB"."LOCALLSH" IS '本地的流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLTBDYB"."LOCALRECORDID" IS '本地病历记录ID号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLTBDYB"."TARGETLSH" IS '对方流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLTBDYB"."TARGETRECORDID" IS '对应病历记录ID号';
 
   COMMENT ON COLUMN "CD120NEW"."LWBLTBDYB"."TARGETDWBH" IS '对方单位编号';
     */
    /// <summary>
    /// 联网病历同步对应表
    /// </summary>
    public class LWBLTBDYB
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
        /// 本地病历记录ID号
        /// </summary>
        public string LocalRecordID { get; set; }
        /// <summary>
        /// 对方流水号
        /// </summary>
        public string TargetLSH { get; set; }
        /// <summary>
        /// 对应病历记录ID号
        /// </summary>
        public string TargetRecordID { get; set; }
        /// <summary>
        /// 对方单位编号
        /// </summary>
        public string TargetDWBH { get; set; }

    }
}
