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
using PAO.Config.Controls.EditControls;
using System.Collections;
using PAO.UI.WinForm;

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
            DevExpressPublic.AddClearButton(edit);
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.ButtonClick += Edit_ButtonClick;
            return edit;
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var edit = (ButtonEdit)sender;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) {
                if (edit.EditValue.IsNull()) {
                    object newObject;
                    if (!ConfigPublic.CreateNewAddonValue(ObjectType, false, out newObject))
                        return;
                    edit.EditValue = newObject;
                }
                var editValue = edit.EditValue;
                Type objectEditorControlType = ConfigPublic.GetTypeEditorType(ObjectType);

                BaseEditControl editControl;
                if (editValue is IList) {
                    var listControl = new ListEditControl();
                    listControl.ListType = ObjectType;
                    editControl = listControl;
                }
                else if (editValue is IDictionary) {
                    var dictionaryControl = new DictionaryEditControl();
                    dictionaryControl.ListType = ObjectType;
                    editControl = dictionaryControl;
                } else if(objectEditorControlType != null) {
                    editControl = objectEditorControlType.CreateInstance() as ObjectEditControl;
                }
                else {
                    editControl = new ObjectEditControl();
                }
                if (edit.EditValue.IsNotNull()) {
                    editControl.SelectedObject = TextPublic.ObjectClone(editValue);
                    if (UIPublic.ShowDialog(editControl) == System.Windows.Forms.DialogResult.OK) {
                        edit.EditValue = editControl.SelectedObject;
                    }
                }
            }
        }
        
    }
}
