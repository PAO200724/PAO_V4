using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Editor;
using PAO.WinForm;
using PAO.IO;
using PAO.UI;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：BaseObjectEditController
    /// 对象编辑控制器基类
    /// 对象编辑控制器基类
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("对象编辑控制器基类")]
    [Description("对象编辑控制器基类")]
    public abstract class BaseObjectEditController : BaseEditController
    {
        #region 插件属性
        #endregion
        public BaseObjectEditController() {
        }

        protected abstract BaseEditControl OnCreateEditControl();

        public override Control CreateEditControl() {
            return OnCreateEditControl();
        }

        public override RepositoryItem CreateRepositoryItem() {
            var edit = new RepositoryItemButtonEdit();
            WinFormPublic.AddClearButton(edit);
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.ButtonClick += Edit_ButtonClick;
            edit.CustomDisplayText += Edit_CustomDisplayText;
            return edit;
        }

        private void Edit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e) {
            if (e.Value.IsNull()) {
                e.DisplayText = "[空]";
            }
            else if (e.Value.GetType().IsAddonListType() || e.Value.GetType().IsAddonDictionaryType()) {
                e.DisplayText = e.Value.GetType().GetTypeString();
            }
            else {
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
                if (PropertyDescriptor == null) {
                    objectType = editValue.GetType();
                }
                else {
                    objectType = PropertyDescriptor.PropertyType;
                }
                if (objectType == null) {
                    // 如果无法确定对象类型，则退出
                    return;
                }
                
                BaseEditControl editControl;
                if (AddonPublic.IsAddonDictionaryType(objectType)) {
                    // 如果是插件，默认创建列表控件
                    editControl = new DictionaryEditControl();
                }
                else if (AddonPublic.IsAddonListType(objectType)) {
                    // 如果是列表，默认创建列表控件
                    editControl = new ListEditControl();
                } else {
                    editControl = OnCreateEditControl();
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
