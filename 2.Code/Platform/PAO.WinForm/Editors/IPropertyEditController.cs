using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 接口：IPropertyEditor
    /// 属性编辑器
    /// 属性编辑器接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("属性编辑器")]
    [Description("属性编辑器接口")]
    public interface IPropertyEditController
    {
        /// <summary>
        /// 创建RepositoryItem
        /// </summary>
        /// <returns>RepositoryItem</returns>
        RepositoryItem CreateRepositoryItem();
    }
}
