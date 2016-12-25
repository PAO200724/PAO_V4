using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 接口：ITypeEditor
    /// 类型编辑器
    /// 类型编辑器接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("类型编辑器")]
    [Description("类型编辑器接口")]
    public interface ITypeEditController
    {
        /// <summary>
        /// 创建编辑控件
        /// </summary>
        /// <returns>编辑控件</returns>
        Control CreateEditControl();
    }
}
