using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.App
{
    /// <summary>
    /// 接口：IClientFilter
    /// 客户端过滤器
    /// 过滤客户端ID、用户等
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("配置过滤器")]
    [Description("配置过滤器")]
    public interface IClientFilter
    {
        /// <summary>
        /// 根据用户ID和客户端ID过滤
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="computerID">客户端ID</param>
        /// <returns>过滤成功</returns>
        bool Predicate(string userID, string computerID);
    }
}
