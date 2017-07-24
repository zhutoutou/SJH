using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*
     CREATE TABLE "CD120NEW"."LWDDGLB" 
   (	"REMOTELSH" VARCHAR2(19) NOT NULL ENABLE, 
	"REMOTEDWBH" VARCHAR2(6) NOT NULL ENABLE, 
	"LOCALLSH" VARCHAR2(19) NOT NULL ENABLE, 
	"DDLX" NUMBER(1,0), 
	"SGSB" NUMBER(1,0), 
	 CONSTRAINT "LWDDGLB_IDX" UNIQUE ("REMOTELSH", "REMOTEDWBH", "LOCALLSH")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE
   );
 
  ALTER TABLE "CD120NEW"."LWDDGLB" MODIFY ("REMOTELSH" NOT NULL ENABLE);
 
  ALTER TABLE "CD120NEW"."LWDDGLB" MODIFY ("REMOTEDWBH" NOT NULL ENABLE);
 
  ALTER TABLE "CD120NEW"."LWDDGLB" MODIFY ("LOCALLSH" NOT NULL ENABLE);
 
   COMMENT ON COLUMN "CD120NEW"."LWDDGLB"."REMOTELSH" IS '对方的流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWDDGLB"."REMOTEDWBH" IS '对方单位的单位编号';
 
   COMMENT ON COLUMN "CD120NEW"."LWDDGLB"."LOCALLSH" IS '本地对应的流水号';
 
   COMMENT ON COLUMN "CD120NEW"."LWDDGLB"."DDLX" IS '调度类型/所在的单位0为被调度,1为调度,2为非联网调度';
 
   COMMENT ON COLUMN "CD120NEW"."LWDDGLB"."SGSB" IS '突发事件上报标识,1为突发事故上报';
     */
    /// <summary>
    /// 联网调度关联表
    /// </summary>
    public class LWDDGLB
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 对方的流水号
        /// </summary>
        public string RemoteLSH { get; set; }
        /// <summary>
        /// 对方单位的单位编号
        /// </summary>
        public string RemoteDWBH { get; set; }
        /// <summary>
        /// 本地对应的流水号
        /// </summary>
        public string LocalLSH { get; set; }
        /// <summary>
        /// 调度类型/所在的单位0为被调度,1为调度,2为非联网调度
        /// </summary>
        public string DDLX { get; set; }
        /// <summary>
        /// 突发事件上报标识,1为突发事故上报
        /// </summary>
        public string SGSB { get; set; }
    }
}
