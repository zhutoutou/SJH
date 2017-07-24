using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.HuaiAnFunction;
using ZIT.SJHServer.fnDataAccess.Oracle.SQl;
using System.Data;
using ZIT.SJHServer.fnArgs;
using ZIT.Utility;

namespace ZIT.SJHServer.fnDataAccess.Oracle
{
    /// <summary>
    /// 查询中心派受理单记录
    /// </summary>
    public class DispatchTaskSelectSingle : IDispatchTaskSingleDataAccess
    {
        /// <summary>
        /// 查询中心派受理单
        /// </summary>
        /// <param name="SelectData"></param>
        /// <returns></returns>
       public DispatchTaskSelectDataResp SelectDispatchTaskSelectSingle(DispatchTaskSelectData SelectData)
        {
            try
            {
                DispatchTaskSelectDataResp Data = new DispatchTaskSelectDataResp();
                DataSet ds = DBHelperOracle.Query(DispatchTaskSelectSingleSql.GetRecordSql(SelectData.DDHM));
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count >= 1)
                {
                    int i=DBHelperOracle.ExecuteSql(DispatchTaskSelectSingleSql.SetRecordFlagSql(SelectData.DDHM,SelectData.LSH));
                    if (i > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Data.CommandID = Data.GetType().Name;
                            Data.ZXLSH = row["ZXLSH"].ToString();
                            Data.HJDZ = row["HJDZ"].ToString();
                            Data.ZJXM = row["HZ"].ToString();
                            Data.ZJHM = row["ZJHM"].ToString();
                            Data.FZXLSH = SelectData.LSH;
                            Data.FZXSLTH = SelectData.SLTH;
                            Data.DWBH = SelectData.DWBH;
                        }
                    }
                }
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
