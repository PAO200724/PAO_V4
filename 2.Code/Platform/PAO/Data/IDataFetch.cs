using PAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Data
{
    /// <summary>
    /// 接口：IDataFetch
    /// 数据获取接口
    /// 数据获取接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("数据获取接口")]
    [Description("数据获取接口")]
    public interface IDataFetch
    {
        /// <summary>
        /// 表名
        /// </summary>
        string TableName { get; }
        /// <summary>
        /// 获取数据格式
        /// </summary>
        /// <returns>数据格式</returns>
        DataTable GetDataSchema();
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="startIndex">其实索引</param>
        /// <param name="count">数量</param>
        /// <param name="parameterValues">参数值</param>
        /// <returns>数据表</returns>
        DataTable FetchData(int startIndex, int count, params DataField[] parameterValues);
    }
}
