using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IDockViewContainer
    /// 停靠视图容器
    /// 停靠视图容器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("停靠视图容器")]
    [Description("停靠视图容器")]
    public interface IDockViewContainer
    {
        /// <summary>
        /// 打开停靠视图
        /// </summary>
        /// <param name="dockView">停靠视图</param>
        void OpenDockView(IDockView dockView);
    }
}
