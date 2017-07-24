using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /*
    CREATE TABLE "CD120NEW"."DXSGB" 
   (	"LSH" VARCHAR2(19) NOT NULL ENABLE, 
	"SGMC" VARCHAR2(100), 
	"SGLX" VARCHAR2(20), 
	"SBBM1" VARCHAR2(40), 
	"DHHM1" VARCHAR2(20), 
	"JHR1" VARCHAR2(10), 
	"SBSJ1" DATE, 
	"ZHCDDSJ1" DATE, 
	"SBBM2" VARCHAR2(40), 
	"DHHM2" VARCHAR2(20), 
	"JHR2" VARCHAR2(10), 
	"SBSJ2" DATE, 
	"ZHCDDSJ2" DATE, 
	"SBBM3" VARCHAR2(40), 
	"DHHM3" VARCHAR2(20), 
	"JHR3" VARCHAR2(10), 
	"SBSJ3" DATE, 
	"ZHCDDSJ3" DATE, 
	"XJ" VARCHAR2(4000), 
	"DDXCBZ1" VARCHAR2(2), 
	"DDXCBZ2" VARCHAR2(2), 
	"DDXCBZ3" VARCHAR2(2), 
	"SGYY" VARCHAR2(20), 
	"XXSBBZ" VARCHAR2(2), 
	"XXSBZBYID" VARCHAR2(20), 
	"SBBM4" VARCHAR2(40), 
	"DHHM4" VARCHAR2(20), 
	"JHR4" VARCHAR2(10), 
	"SBSJ4" DATE, 
	"ZHCDDSJ4" DATE, 
	"XCJZ" VARCHAR2(10), 
	"XCJZ1" VARCHAR2(10), 
	"XCJZ0" VARCHAR2(10), 
	"GYXS" VARCHAR2(4000), 
	"SQCBFL" VARCHAR2(4000), 
	"SQRS0" VARCHAR2(10), 
	"SQRS1" VARCHAR2(10), 
	"SQRS2" VARCHAR2(10), 
	"SQRS3" VARCHAR2(10), 
	"SQRS4" VARCHAR2(10), 
	"SQRS5" VARCHAR2(10), 
	"SQRS6" VARCHAR2(10), 
	"SQRS7" VARCHAR2(10), 
	"SQRS8" VARCHAR2(10), 
	"SQRS9" VARCHAR2(10), 
	"SQRS10" VARCHAR2(10), 
	"ISUPDATEDYJ" NUMBER(1,0), 
	"ISUPDATED" VARCHAR2(8), 
	"XZBM" VARCHAR2(100)
   ) ;
 
  ALTER TABLE "CD120NEW"."DXSGB" MODIFY ("LSH" NOT NULL ENABLE);
     */
    /// <summary>
    /// 大型事故表
    /// </summary>
    public class DXSGB
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        public string LSH { get; set; }
        //20160727 修改人:朱星汉 修改内容：添加突发公共事件等级
        public string SGLV { get; set; }

        public string SGMC { get; set; }
        public string SGLX { get; set; }
        public string SBBM1 { get; set; }
        public string DHHM1 { get; set; }
        public string JHR1 { get; set; }
        public string SBSJ1 { get; set; }
        public string ZHCDDSJ1 { get; set; }
        public string SBBM2 { get; set; }
        public string DHHM2 { get; set; }
        public string JHR2 { get; set; }
        public string SBSJ2 { get; set; }
        public string ZHCDDSJ2 { get; set; }
        public string SBBM3 { get; set; }
        public string DHHM3 { get; set; }
        public string JHR3 { get; set; }
        public string SBSJ3 { get; set; }
        public string ZHCDDSJ3 { get; set; }
        public string XJ { get; set; }
        public string DDXCBZ1 { get; set; }
        public string DDXCBZ2 { get; set; }
        public string DDXCBZ3 { get; set; }
        public string SGYY { get; set; }
        public string XXSBBZ { get; set; }
        public string XXSBZBYID { get; set; }
        public string SBBM4 { get; set; }
        public string DHHM4 { get; set; }
        public string JHR4 { get; set; }
        public string SBSJ4 { get; set; }
        public string ZHCDDSJ4 { get; set; }
        public string XCJZ { get; set; }
        public string XCJZ1 { get; set; }
        public string XCJZ0 { get; set; }
        public string GYXS { get; set; }
        public string SQCBFL { get; set; }
        public string SQRS0 { get; set; }
        public string SQRS1 { get; set; }
        public string SQRS2 { get; set; }
        public string SQRS3 { get; set; }
        public string SQRS4 { get; set; }
        public string SQRS5 { get; set; }
        public string SQRS6 { get; set; }
        public string SQRS7 { get; set; }
        public string SQRS8 { get; set; }
        public string SQRS9 { get; set; }
        public string SQRS10 { get; set; }
    }
}
