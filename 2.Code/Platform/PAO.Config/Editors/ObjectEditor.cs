using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.Config.Controls;
using PAO.UI;
using PAO.IO.Text;
using DevExpress.XtraEditors;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：ObjectEditor
    /// 对象编辑器
    /// 编辑对象的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("对象编辑器")]
    [Description("编辑对象的编辑器")]
    public class ObjectEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public ObjectEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemButtonEdit();
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.CustomDisplayText += Edit_CustomDisplayText;
            edit.ButtonClick += Edit_ButtonClick;
            return edit;
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var edit = (ButtonEdit)sender;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) {
                var objectTreeControl = new ObjectTreeControl();
                if(edit.EditValue.IsNotNull()) {
                    objectTreeControl.SelectedObject = TextPublic.ObjectClone(edit.EditValue);
                    if(UIPublic.ShowDialog(objectTreeControl) == System.Windows.Forms.DialogResult.OK) {
                        edit.EditValue = objectTreeControl.SelectedObject;
                    }
                }
            }
        }

        private void Edit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e) {
            if (e.Value.IsNull())
                e.DisplayText = null;
            else {
                e.DisplayText = e.Value.ObjectToString();
            }
        }
    }
}
