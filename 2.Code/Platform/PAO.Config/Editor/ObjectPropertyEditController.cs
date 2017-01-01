using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.Config.Controls;
using PAO.UI;
using PAO.IO;
using DevExpress.XtraEditors;
using PAO.Config.Editor;
using System.Collections;
using PAO.WinForm;
using PAO.WinForm.Editor;
using System.Windows.Forms;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ObjectEditor
    /// 插件编辑控制器
    /// 插件编辑控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("插件编辑控制器")]
    [Description("插件编辑控制器")]
    public class ObjectPropertyEditController : BaseObjectEditController
    {
        public static ObjectPropertyEditController DefaultTypeEditController = new ObjectPropertyEditController() { IsTypeEditController = true };

        #region 插件属性
        #endregion

        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 布局数据
        /// </summary>
        [Browsable(false)]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }

        public ObjectPropertyEditController() {
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new ObjectPropertyEditControl();
            return editControl;
        }

        public static ObjectPropertyEditControl CreateTypeEditControl() {
            return DefaultTypeEditController.CreateEditControl(null) as ObjectPropertyEditControl;
        }
    }
}
