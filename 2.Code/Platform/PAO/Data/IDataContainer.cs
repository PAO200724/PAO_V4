using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Data
{
    /// <summary>
    /// 接口：IDataContainer
    /// 数据容器
    /// 可以容纳数据的容器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("数据容器")]
    [Description("可以容纳数据的容器")]
    public interface IDataContainer
    {
        /// <summary>
        /// 数据格式
        /// </summary>
        DataSet DataSchema { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        DataSet DataSource { get; set; }
    }
}
