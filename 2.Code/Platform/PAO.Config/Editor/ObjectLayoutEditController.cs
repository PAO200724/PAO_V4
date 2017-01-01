using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.WinForm;
using System.Windows.Forms;

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
        public static ObjectLayoutEditController DefaultTypeEditController = new ObjectLayoutEditController() { IsTypeEditController = true };
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
        #endregion
        public ObjectLayoutEditController() {
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new ObjectLayoutEditControl();
            return editControl;
        }

        public static ObjectLayoutEditControl CreateTypeEditControl() {
            return DefaultTypeEditController.CreateEditControl(null) as ObjectLayoutEditControl;
        }
    }
}
