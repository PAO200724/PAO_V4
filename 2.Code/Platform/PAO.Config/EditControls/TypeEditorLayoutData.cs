using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using System.Windows.Forms;
using PAO.WinForm;
using PAO.WinForm.Editors;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 类：TypeEditController
    /// 类型编辑器布局数据
    /// 类型编辑的布局数据
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("类型编辑器布局数据")]
    [Description("类型编辑的布局数据")]
    public class TypeEditorLayoutData : PaoObject
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
        public Dictionary<string, Type> PropertyEditorTypes {
            get;
            set;
        }
        #endregion 属性：PropertyEditorTypes
        #endregion
        public TypeEditorLayoutData() {
        }

        public Control CreateEditControl(string propertyName) {
            if (PropertyEditorTypes.IsNotNullOrEmpty()
                    && PropertyEditorTypes.ContainsKey(propertyName)) {
                var editorType = PropertyEditorTypes[propertyName];
                // 创建控件
                var editor = editorType.CreateInstance();
                if (editor is BaseEditControl) {
                    return editor as BaseEditControl;
                }
                else if (editor is BaseEditor) {
                    return editor.As<BaseEditor>().CreateEditControl();
                }
                else {
                    throw new Exception("设置了不支持的编辑器类型").AddExceptionData("EditorType", editorType);
                }
            }
            return null;
        }
    }
}
