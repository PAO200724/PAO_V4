using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.UI.WinForm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：GuidEdit
    /// GUID编辑器
    /// GUID编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("GUID编辑器")]
    [Description("GUID编辑器")]
    public class GuidEdit : BaseEditor
    {
        #region 插件属性
        #endregion
        public GuidEdit() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemButtonEdit();
            edit.ButtonClick += Edit_ButtonClick;
            DevExpressPublic.AddClearButton(edit);
            return edit;
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            if(e.Button.Kind == ButtonPredefines.Ellipsis) {
                var edit = sender as ButtonEdit;
                edit.EditValue = Guid.NewGuid().ToString();
            }
        }
    }
}
