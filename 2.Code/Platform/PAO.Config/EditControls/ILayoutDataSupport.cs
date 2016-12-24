using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 接口：ILayoutDataSupport
    /// 布局数据支持
    /// 布局数据支持接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("布局数据支持")]
    [Description("布局数据支持接口")]
    public interface ILayoutDataSupport
    {
        /// <summary>
        /// 布局数据
        /// </summary>
        object LayoutData { get; set; }
    }
}
