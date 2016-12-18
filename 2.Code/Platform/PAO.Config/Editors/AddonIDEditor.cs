using PAO;
using PAO.Config.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;
using PAO.Config.EditControls;
using PAO.IO;
using DevExpress.XtraEditors;
using PAO.UI;
using PAO.Controls;
using PAO.WinForm.Editors;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：AddonFactoryIDEditor
    /// 插件ID编辑器
    /// 在全局插件列表中选择插件ID的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("插件ID编辑器")]
    [Description("在全局插件列表中选择插件ID的编辑器")]
    public class AddonIDEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public AddonIDEditor() {
        }

        public Type AddonType { get; set; }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemButtonEdit();
            WinFormPublic.AddClearButton(edit);
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.ButtonClick += Edit_ButtonClick;
            return edit;
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var edit = (ButtonEdit)sender;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) {
                var editValue = edit.EditValue;
                var editControl = new AddonSelectControl();

                var componentType = PropertyDescriptor.ComponentType;
                if (componentType.IsDerivedFrom(typeof(AddonFactory<>)))
                    AddonType = componentType.GetGenericArguments()[0];

                editControl.AddonFilter = (addon) =>
                {
                    // 匹配插件类型
                    if (AddonType == null || addon.GetType().IsDerivedFrom(AddonType))
                        return true;
                    return false;
                };

                editControl.SelectedObject = editValue;
                if (WinFormPublic.ShowDialog(editControl) == DialogReturn.OK) {
                    edit.EditValue = editControl.SelectedObject;
                }
            }
        }
    }
}
