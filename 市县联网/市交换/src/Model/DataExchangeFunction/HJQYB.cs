using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*
    CREATE TABLE "CD120NEW"."HJQYB" 
   (	"XH" NUMBER(4,0), 
	"HJQY" VARCHAR2(40) NOT NULL ENABLE, 
	"JD" VARCHAR2(40)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 163840 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 
  CREATE INDEX "CD120NEW"."HJQYB_XH_IDX" ON "CD120NEW"."HJQYB" ("XH") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 163840 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 
  ALTER TABLE "CD120NEW"."HJQYB" MODIFY ("HJQY" NOT NULL ENABLE);
    */
    /// <summary>
    /// 呼救区域表
    /// </summary>
    public class HJQYB
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
        /// 呼救区域
        /// </summary>
        public string HJQY { get; set; }
        public string JD { get; set; }
    }
}
