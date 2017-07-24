using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /*
     * CREATE TABLE "CD120NEW"."ZZB" 
   (	"XH" NUMBER(4,0), 
	"ZZ" VARCHAR2(40) NOT NULL ENABLE, 
	"ZZLB" VARCHAR2(40) NOT NULL ENABLE, 
	"ID" VARCHAR2(6), 
	"LX" VARCHAR2(20), 
	"KB" VARCHAR2(20), 
	"YY" VARCHAR2(30), 
	 CONSTRAINT "PK_ZZB_XH" PRIMARY KEY ("XH")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 163840 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE
   ) 
     */
    public class ZZB
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string XH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZZLB { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KB { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string YY { get; set; }
    }
}
