using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.UI.WinForm;

namespace PAO.UI.WinForm.Editors
{
    /// <summary>
    /// 类：TextEditor
    /// 文本编辑器
    /// 用于编辑文本的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("文本编辑器")]
    [Description("用于编辑文本的编辑器")]
    public class TextEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public TextEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemButtonEdit();
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            edit.Buttons.RemoveAt(0);
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
