using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IPropertyPageSupport
    /// 属性页支持接口
    /// 属性页支持接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("属性页支持接口")]
    [Description("属性页支持接口")]
    public interface IPropertyPageSupport
    {
        /// <summary>
        /// 打开属性页
        /// </summary>
        /// <param name="propertyPage">属性页</param>
        void OpenPropertyPage(IPropertyPage propertyPage);
    }
}
