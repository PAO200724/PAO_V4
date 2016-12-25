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
    public class CheckComboBoxEditController : BaseDevEditController
    {
        #region 插件属性
        #endregion
        public CheckComboBoxEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemCheckedComboBoxEdit();
            return edit;
        }
    }
}
