using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.HuaiAnFunction;

namespace ZIT.SJHServer.fnDataAccess
{
    /// <summary>
    /// 查询中心派受理单记录
    /// </summary>
   public interface IDispatchTaskSingleDataAccess
    {
       /// <summary>
        ///  /// <summary>
        /// 查询中心派受理单
        /// </summary>
        /// <param name="SelectData"></param>
       DispatchTaskSelectDataResp SelectDispatchTaskSelectSingle(DispatchTaskSelectData SelectData);
    }
}
