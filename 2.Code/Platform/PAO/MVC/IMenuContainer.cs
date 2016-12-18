using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.MVC
{
    /// <summary>
    /// 接口：IMenuContainer
    /// 菜单容器
    /// 可以容纳菜单的容器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("菜单容器")]
    [Description("可以容纳菜单的容器")]
    public interface IMenuContainer
    {
        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="menuItem">菜单项</param>
        void AddMenuItem(IUIItem menuItem);
    }
}
