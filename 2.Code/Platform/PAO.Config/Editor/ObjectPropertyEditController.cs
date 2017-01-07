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
using System.Windows.Forms;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ObjectEditor
    /// 属性式编辑控制器
    /// PropertyGrid样式的编辑控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("属性式编辑控制器")]
    [Description("PropertyGrid样式的编辑控制器")]
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

        #endregion

        public ObjectPropertyEditController() {

        }
        public ObjectPropertyEditController(bool staticType) : base(staticType){
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new ObjectPropertyEditControl();
            return editControl;
        }

        public static new bool TypeFilter(Type type) {
            // 只支持通过代码创建此控制器
            return false;
        }
    }
}
