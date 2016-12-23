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
    /// 类：ObjectLayoutEditorController
    /// 布局式对象编辑器控制器
    /// 布局控件形式的对象编辑器控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("布局式对象编辑器控制器")]
    [Description("布局控件形式的对象编辑器控制器")]
    public class ObjectLayoutEditorController : TypeEditorController
    {
        #region 插件属性

        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 布局数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData

        #endregion
        public ObjectLayoutEditorController() {
        }
    }
}
