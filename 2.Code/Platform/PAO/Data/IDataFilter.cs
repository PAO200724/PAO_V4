using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Data
{
    /// <summary>
    /// 接口:IDataFilter
    /// 数据过滤器
    /// 过滤数据的对象
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    [Addon]
    public interface IDataFilter
    {
        /// <summary>
        /// 获取过滤字符串
        /// </summary>
        /// <param name="paramValues">参数值</param>
        /// <returns>过滤字符串</returns>
        string GetFilterString(DataField[] paramValues);

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <returns>数据过滤器的参数列表</returns>
        DataField[] GetParameters();
    }
}
