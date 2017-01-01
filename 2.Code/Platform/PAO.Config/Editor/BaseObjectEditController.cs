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
using PAO.Config.Editor;

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
        #region 属性：PropertyEditorTypes
        /// <summary>
        /// 属性：PropertyEditorTypes
        /// 属性编辑器类型
        /// 自定义的属性编辑器类型列表，Key是属性名称，Value是编辑器（BaseEditor或者是BaseEditControl）
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("属性编辑器类型")]
        [Description("自定义的属性编辑器类型列表，Key是属性名称，Value是编辑器（BaseEditor或者是BaseEditControl）")]
        public Dictionary<string, BaseEditController> PropertyEditorTypes {
            get;
            set;
        }
        #endregion 属性：PropertyEditorTypes

        #region 属性：IsTypeEditController
        /// <summary>
        /// 属性：IsTypeEditController
        /// 是否类型编辑控制器
        /// 是否类型编辑控制器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("是否类型编辑控制器")]
        [Description("是否类型编辑控制器")]
        public bool IsTypeEditController {
            get;
            set;
        }
        #endregion 属性：IsTypeEditController
        #endregion

        public BaseObjectEditController() {
            IsTypeEditController = false;
        }


        /// <summary>
        /// 根据属性创建编辑控件
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Control CreateEditControl(Type objectType, string propertyName) {
            if (PropertyEditorTypes.IsNotNullOrEmpty()
                    && PropertyEditorTypes.ContainsKey(propertyName)) {
                var editController = PropertyEditorTypes[propertyName];
                return editController.CreateEditControl(objectType);
            }
            return null;
        }
        
        public override Control CreateEditControl(Type objectType) {
            var editControl = base.CreateEditControl(objectType) as BaseEditControl;
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
                    BaseEditControl editControl = CreateEditControl(objectType) as BaseEditControl;

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
