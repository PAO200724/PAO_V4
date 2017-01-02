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
using System.Diagnostics;

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

        #region 属性：PredefinedEditors
        /// <summary>
        /// 属性：PredefinedEditors
        /// 预定义编辑器
        /// 预定义编辑器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("预定义编辑器")]
        [Description("预定义编辑器")]
        public Dictionary<string, BaseEditController> PredefinedEditors {
            get;
            set;
        }
        #endregion 属性：PredefinedEditors        

        #endregion

        public BaseObjectEditController() {
        }
        public BaseObjectEditController(bool staticType) : base(staticType){
        }
        public override Control CreateEditControl(Type objectType = null) {
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
                    } else {
                        editControl.EditValue = null;
                    }
                    if (WinFormPublic.ShowDialog(editControl) == DialogReturn.OK) {
                        edit.EditValue = editControl.EditValue;
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

        /// <summary>
        /// 获取预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public BaseEditController GetPredefinedEditController(string propertyName) {
            if (PredefinedEditors.IsNotNullOrEmpty()
                    && PredefinedEditors.ContainsKey(propertyName)
                    && PredefinedEditors[propertyName] != null) {
                return PredefinedEditors[propertyName];
            }
            return null;
        }

        /// <summary>
        /// 获取预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public void RemovePredefinedEditController(string propertyName) {
            if (PredefinedEditors.IsNotNullOrEmpty()
                    && PredefinedEditors.ContainsKey(propertyName)) {
                PredefinedEditors.Remove(propertyName);
            }
        }

        /// <summary>
        /// 设置预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="editController">编辑控制器</param>
        public void SetPredfinedEditController(string propertyName, BaseEditController editController) {
            if (PredefinedEditors == null)
                PredefinedEditors = new Dictionary<string, BaseEditController>();

            if (PredefinedEditors.ContainsKey(propertyName)) {
                PredefinedEditors[propertyName] = editController;
            }
            else {
                PredefinedEditors.Add(propertyName, editController);
            }
        }
    }
}
