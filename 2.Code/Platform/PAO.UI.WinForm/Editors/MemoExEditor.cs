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
    /// 类：MemoExEditor
    /// 下拉式多行文本编辑器
    /// 下拉式用于编辑多行文本的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("下拉式多行文本编辑器")]
    [Description("下拉式用于编辑多行文本的编辑器")]
    public class MemoExEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public MemoExEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemMemoExEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
