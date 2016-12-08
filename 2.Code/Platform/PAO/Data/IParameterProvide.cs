using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Data
{
    /// <summary>
    /// 接口：IParameterProvide
    /// 参数提供接口
    /// 此接口用于提供数据查询所需的参数
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("参数提供接口")]
    [Description("此接口用于提供数据查询所需的参数")]
    public interface IParameterProvide
    {
        /// <summary>
        /// 参数对应的表名
        /// </summary>
        string ParameterTableName { get; }
        /// <summary>
        /// 参数值
        /// </summary>
        IEnumerable<DataField> ParameterValues { get; }
    }
}
