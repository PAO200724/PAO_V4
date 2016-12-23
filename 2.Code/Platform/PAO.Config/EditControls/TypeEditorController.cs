using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 类：TypeEditController
    /// 类型编辑控制器
    /// 类型编辑的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("类型编辑控制器")]
    [Description("类型编辑的控制器")]
    public class TypeEditorController : PaoObject
    {
        #region 插件属性
        #region 属性：Type
        /// <summary>
        /// 属性：Type
        /// 类型
        /// 待编辑类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("类型")]
        [Description("待编辑类型")]
        public Type Type {
            get;
            set;
        }
        #endregion 属性：Type

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
        public TypeEditorController() {
        }
    }
}
