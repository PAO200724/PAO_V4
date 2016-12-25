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
    public class TextEditController : BaseDevEditController
    {
        #region 插件属性
        #endregion
        public TextEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemButtonEdit();
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            edit.Buttons.RemoveAt(0);
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
