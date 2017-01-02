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
        #region 插件属性
        #region LayoutData
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
        #endregion

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

        public ObjectPropertyEditController() {
            StaticType = true;
        }
        public ObjectPropertyEditController(bool staticType) {
            StaticType = staticType;
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new ObjectPropertyEditControl();
            editControl.StaticType = StaticType;
            return editControl;
        }
        
    }
}
