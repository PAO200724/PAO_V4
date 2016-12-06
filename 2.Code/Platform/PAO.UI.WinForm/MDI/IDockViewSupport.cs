using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm.MDI
{
    /// <summary>
    /// 接口：IDcokViewSupport
    /// 停靠视图支持
    /// 停靠视图支持
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("停靠视图支持")]
    [Description("停靠视图支持")]
    public interface IDockViewSupport
    {
        /// <summary>
        /// 创建停靠视图
        /// </summary>
        IEnumerable<Control> GetDockViews();
    }
}
