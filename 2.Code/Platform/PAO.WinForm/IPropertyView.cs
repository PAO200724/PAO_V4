using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.WinForm
{
    /// <summary>
    /// 接口：IPropertyView
    /// 属性视图
    /// 属性视图接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("属性视图")]
    [Description("属性视图接口")]
    public interface IPropertyView
    {
        object SelectedObject { get; set; }
    }
}
