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
using PAO.IO;
using DevExpress.XtraEditors;
using PAO.Config.EditControls;
using System.Collections;
using PAO.WinForm;
using PAO.WinForm.Editors;

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

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemButtonEdit();
            WinFormPublic.AddClearButton(edit);
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.ButtonClick += Edit_ButtonClick;
            edit.CustomDisplayText += Edit_CustomDisplayText;
            return edit;
        }

        private void Edit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e) {
            if(e.Value.IsNull()) {
                e.DisplayText = "[空]";
            } else if(e.Value.GetType().IsAddonListType() || e.Value.GetType().IsAddonDictionaryType()){
                e.DisplayText = e.Value.GetType().GetTypeString();
            } else {
                e.DisplayText = e.Value.ToString();
            }
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var edit = (ButtonEdit)sender;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) {
                if (edit.EditValue.IsNull() && PropertyDescriptor != null) {
                    object newObject;
                    if (!ConfigPublic.CreateNewAddonValue(PropertyDescriptor.PropertyType, false, out newObject))
                        return;
                    edit.EditValue = newObject;
                }
                var editValue = edit.EditValue;
                Type objectType = null;
                if(PropertyDescriptor == null) {
                    objectType = editValue.GetType();
                } else {
                    objectType = PropertyDescriptor.PropertyType;
                }
                if (objectType == null) {
                    // 如果无法确定对象类型，则退出
                    return;
                }
                BaseEditControl editControl = null;
                Type objectEditorControlType = ConfigPublic.GetEditControlType(objectType);
                if (objectEditorControlType != null) {
                    // 以预定义的编辑器对象优先
                    editControl = objectEditorControlType.CreateInstance() as BaseEditControl;
                }
                else if (editValue is IList) {
                    editControl = new ListEditControl();
                }
                else if (editValue is IDictionary) {
                    editControl = new DictionaryEditControl();
                }
                else {
                    editControl = new ObjectEditControl();
                }

                if (edit.EditValue.IsNotNull()) {
                    editControl.EditValue = IOPublic.ObjectClone(editValue);
                    if (WinFormPublic.ShowDialog(editControl) == DialogReturn.OK) {
                        edit.EditValue = editControl.EditValue;
                    }
                }
            }
        }
        
    }
}
