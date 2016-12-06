using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IMenuItem
    /// 菜单项
    /// 菜单项
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("菜单项")]
    [Description("菜单项")]
    public interface IMenuItem : IUIItem
    {
        /// <summary>
        /// 子菜单项
        /// </summary>
        IEnumerable<IUIItem> ChildMenuItems { get; }
    }
}
