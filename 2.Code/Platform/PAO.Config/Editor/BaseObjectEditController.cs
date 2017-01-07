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
using PAO.Config.Editor;
using PAO.WinForm;
using PAO.IO;
using PAO.UI;
using System.Diagnostics;

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

        #region 属性：PredefinedEditorTypes
        /// <summary>
        /// 属性：PredefinedEditorTypes
        /// 预定义编辑器
        /// 预定义编辑控制器类型列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("预定义编辑器")]
        [Description("预定义编辑器")]
        public Dictionary<string, Type> PredefinedEditorTypes {
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
        /// <param name="objectType">对象类型</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public BaseEditController GetPredefinedEditController(Type objectType, string propertyName) {
            if (PredefinedEditorTypes.IsNotNullOrEmpty()
                    && PredefinedEditorTypes.ContainsKey(propertyName)
                    && PredefinedEditorTypes[propertyName] != null) {

                return EditorPublic.GetOrCreateEditControllerFromStorage(objectType, PredefinedEditorTypes[propertyName]);
            }
            return null;
        }

        /// <summary>
        /// 清除所有预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public void ClearPredefinedEditControllers() {
            if (PredefinedEditorTypes.IsNotNullOrEmpty()) {
                PredefinedEditorTypes.Clear();
            }
        }

        /// <summary>
        /// 获取预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>编辑控制器</returns>
        public void RemovePredefinedEditController(string propertyName) {
            if (PredefinedEditorTypes.IsNotNullOrEmpty()
                    && PredefinedEditorTypes.ContainsKey(propertyName)) {
                PredefinedEditorTypes.Remove(propertyName);
            }
        }

        /// <summary>
        /// 设置预定义的编辑控制器
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="editControllerType">编辑控制器类型</param>
        public void SetPredfinedEditController(string propertyName, Type editControllerType) {
            if (PredefinedEditorTypes == null)
                PredefinedEditorTypes = new Dictionary<string, Type>();

            if (PredefinedEditorTypes.ContainsKey(propertyName)) {
                PredefinedEditorTypes[propertyName] = editControllerType;
            }
            else {
                PredefinedEditorTypes.Add(propertyName, editControllerType);
            }
        }
    }
}
