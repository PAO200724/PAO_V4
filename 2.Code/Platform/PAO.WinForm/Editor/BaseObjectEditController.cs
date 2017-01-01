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

namespace PAO.WinForm.Editor
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
        
        public override Control CreateEditControl(Type objectType) {
            var editControl = base.CreateEditControl(objectType) as BaseObjectEditControl;
            if(editControl != null)
                editControl.Controller = this;
            return editControl;
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var repositoryItem = new RepositoryItemButtonEdit();
            WinFormPublic.AddClearButton(repositoryItem);
            repositoryItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItem.ButtonClick += (sender, e) =>
            {
                var edit = (ButtonEdit)sender;
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) {
                    var editValue = edit.EditValue;
                    BaseObjectEditControl editControl = CreateEditControl(objectType) as BaseObjectEditControl;

                    if (edit.EditValue.IsNotNull()) {
                        editControl.EditValue = IOPublic.ObjectClone(editValue);
                        if (WinFormPublic.ShowDialog(editControl) == DialogReturn.OK) {
                            edit.EditValue = editControl.EditValue;
                        }
                    }
                }
            };
            repositoryItem.CustomDisplayText += (sender, e) => {
                if (e.Value.IsNull()) {
                    e.DisplayText = "[空]";
                }
                else if (e.Value.GetType().IsAddonListType() || e.Value.GetType().IsAddonDictionaryType()) {
                    e.DisplayText = e.Value.GetType().GetTypeString();
                }
                else {
                    e.DisplayText = e.Value.ToString();
                }
            };
            return repositoryItem;
        }
    }
}
