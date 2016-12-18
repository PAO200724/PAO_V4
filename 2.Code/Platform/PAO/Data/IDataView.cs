using PAO.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Data
{
    /// <summary>
    /// 接口：IDataView
    /// 数据视图接口
    /// 用于显示数据的视图接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("数据视图接口")]
    [Description("用于显示数据的视图接口")]
    public interface IDataView : IView
    {
        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="dataSet">数据集</param>
        void SetDataSource(DataSet dataSet);
    }
}
