using PAO;
using PAO.WinForm;
using PAO.WinForm.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.Config
{
    /// <summary>
    /// 类：LayoutControlData
    /// 布局控件数据
    /// 布局式编辑控件的布局数据
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("布局控件数据")]
    [Description("布局式编辑控件的布局数据")]
    public class LayoutEditControlData : PaoObject
    {
        #region 插件属性

        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 布局控件的数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("布局控件的数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData

        #region 属性：CustomeEditorTypes
        /// <summary>
        /// 属性：CustomeEditorTypes
        /// 自定义编辑器类型
        /// 自定义的属性编辑器类型列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("自定义编辑器")]
        [Description("自定义的属性编辑器列表")]
        public Dictionary<string, Type> CustomeEditorTypes {
            get;
            set;
        }
        #endregion 属性：CustomeEditors

        #endregion
        public LayoutEditControlData() {
        }

        public Control CreateEditControl(string propertyName) {
            if (CustomeEditorTypes.IsNotNullOrEmpty()
                    && CustomeEditorTypes.ContainsKey(propertyName)) {
                var editorType = CustomeEditorTypes[propertyName];
                // 创建控件
                var editor = editorType.CreateInstance();
                if(editor is BaseEditControl) {
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
