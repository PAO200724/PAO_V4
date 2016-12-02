using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.UI.WinForm;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：CheckEditor
    /// 复选框编辑器
    /// 复选框编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("下拉式多行文本编辑器")]
    [Description("下拉式用于编辑多行文本的编辑器")]
    public class CheckEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public CheckEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemCheckEdit();
            return edit;
        }
    }
}
