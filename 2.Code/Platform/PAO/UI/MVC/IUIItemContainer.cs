using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IFunctionItemContainer
    /// 功能项容器
    /// 功能项容器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("功能项容器")]
    [Description("功能项容器")]
    public interface IUIItemContainer
    {
        /// <summary>
        /// 打开功能项
        /// </summary>
        /// <param name="functionItem">界面项目</param>
        void OpenUIItem(IUIItem uiItem);
    }
}
