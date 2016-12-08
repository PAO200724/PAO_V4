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
        /// 获取数据
        /// </summary>
        /// <param name="parameterValues">参数值</param>
        /// <returns>数据集</returns>
        DataSet FetchData(params DataField[] parameterValues);
    }
}
