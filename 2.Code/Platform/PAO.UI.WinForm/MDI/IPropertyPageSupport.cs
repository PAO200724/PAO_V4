using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm.MDI
{
    /// <summary>
    /// 接口：IPropertyPageSupport
    /// 属性页支持
    /// 属性页支持
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("属性页支持")]
    [Description("属性页支持")]
    public interface IPropertyPageSupport
    {
        /// <summary>
        /// 获取属性页
        /// </summary>
        IEnumerable<Control> GetPropertyPages();
    }
}
