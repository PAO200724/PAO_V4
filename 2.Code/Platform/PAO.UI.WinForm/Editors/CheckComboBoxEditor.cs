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
    /// 类：CheckEditor
    /// 组合框式复选框
    /// 组合框式复选框
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("组合框式复选框")]
    [Description("组合框式复选框")]
    public class CheckComboBoxEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public CheckComboBoxEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemCheckedComboBoxEdit();
            return edit;
        }
    }
}
