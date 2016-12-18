using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 类：ColorEditor
    /// 颜色编辑器
    /// 颜色编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("颜色编辑器")]
    [Description("颜色编辑器")]
    public class ColorEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public ColorEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemColorEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
