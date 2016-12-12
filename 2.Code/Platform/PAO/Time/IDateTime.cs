using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Time
{
    /// <summary>
    /// 接口：IDateTime
    /// 日期时间接口
    /// 获取系统当前日期和时间的接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("日期时间接口")]
    [Description("获取系统当前日期和时间的接口")]
    public interface IDateTime
    {
        /// <summary>
        /// 获取当前日期时间
        /// </summary>
        /// <returns>当前日期时间</returns>
        DateTime GetCurrentDateTime();
    }
}
