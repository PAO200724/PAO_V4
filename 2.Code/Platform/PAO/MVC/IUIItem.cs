using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PAO.MVC
{
    /// <summary>
    /// 接口：IUIItem
    /// UI项目
    /// 用户界面项目
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("UI项目")]
    [Description("用户界面项目")]
    public interface IUIItem
    {
        /// <summary>
        /// 文档唯一标识
        /// </summary>
        string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        string Caption { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        Image Icon { get; set; }
        /// <summary>
        /// 大图标
        /// </summary>
        Image LargeIcon { get; set; }
    }
}
