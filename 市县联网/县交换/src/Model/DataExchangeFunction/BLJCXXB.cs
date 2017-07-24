using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /*
     * CREATE TABLE "CD120NEW"."BLJCXXB" 
   (	"XH" NUMBER(3,0), 
	"LX" VARCHAR2(10) NOT NULL ENABLE, 
	"MC" VARCHAR2(40) NOT NULL ENABLE, 
	"GPS" VARCHAR2(2), 
	"BH" NUMBER(4,0), 
	"YWLX" VARCHAR2(10), 
	"BZ" VARCHAR2(100)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 163840 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 
  CREATE UNIQUE INDEX "CD120NEW"."BLJCXXB_LX_MC_IDX" ON "CD120NEW"."BLJCXXB" ("LX", "MC") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 163840 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 
  ALTER TABLE "CD120NEW"."BLJCXXB" MODIFY ("LX" NOT NULL ENABLE);
 
  ALTER TABLE "CD120NEW"."BLJCXXB" MODIFY ("MC" NOT NULL ENABLE);
     */
    /// <summary>
    /// 病历基础信息表
    /// </summary>
    public class BLJCXXB
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
        /// 
        /// </summary>
        public string LX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GPS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string YWLX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BZ { get; set; }
    }
}
