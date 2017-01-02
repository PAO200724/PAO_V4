using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.WinForm;
using System.Windows.Forms;
using PAO.WinForm.Editor;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ObjectLayoutEditController
    /// 布局式编辑控制器
    /// 布局式对象编辑器的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("布局式编辑控制器")]
    [Description("布局式对象编辑器的控制器")]
    public class ObjectLayoutEditController : BaseObjectEditController
    {
        #region 插件属性
        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 编辑器的布局数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("编辑器的布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData

        #region 属性：StaticType
        /// <summary>
        /// 属性：StaticType
        /// 固定类型
        /// 此控制器对应的固定类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("固定类型")]
        [Description("此控制器对应的固定类型")]
        public bool StaticType {
            get;
            set;
        }
        #endregion 属性：StaticType
        #endregion
        public ObjectLayoutEditController() {
            StaticType = true;
        }
        public ObjectLayoutEditController(bool staticType) {
            StaticType = staticType;
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new ObjectLayoutEditControl();
            return editControl;
        }
    }
}
