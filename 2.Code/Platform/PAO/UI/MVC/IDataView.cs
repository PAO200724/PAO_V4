using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IDataView
    /// 数据视图
    /// 支持数据绑定的视图
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("数据视图")]
    [Description("支持数据绑定的视图")]
    public interface IDataView : IView
    {
        /// <summary>
        /// 数据源
        /// </summary>
        object DataSource { get; set; }
        /// <summary>
        /// 数据成员
        /// </summary>
        string DataMember { get; set; }
    }
}
