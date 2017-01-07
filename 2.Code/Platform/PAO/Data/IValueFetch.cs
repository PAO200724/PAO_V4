using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Data
{
    /// <summary>
    /// 接口：IValueFetch
    /// 值获取接口
    /// 获取单个值的接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("值获取接口")]
    [Description("获取单个值的接口")]
    public interface IValueFetch<T>
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns>值</returns>
        T Value { get; }
    }
}
