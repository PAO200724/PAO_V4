using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using PAO;
using PAO.WinForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 类：BaseEditor
    /// 编辑器
    /// 编辑器基类
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "edit")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("编辑器")]
    [Description("编辑器基类")]
    public abstract class BaseEditController : PaoObject, IPropertyEditController, ITypeEditController
    {
        #region 插件属性

        #region 属性：ReadOnly
        /// <summary>
        /// 属性：ReadOnly
        /// 只读
        /// 只读
        /// </summary>
        [AddonProperty]
        [DefaultValue(false)]
        [DataMember(EmitDefaultValue = false)]
        [Name("只读")]
        [Description("只读")]
        public bool ReadOnly {
            get;
            set;
        }
        #endregion 属性：ReadOnly
        #endregion
        public BaseEditController() {
            ReadOnly = false;
        }

        [NonSerialized]
        public PropertyDescriptor PropertyDescriptor;

        public abstract RepositoryItem CreateRepositoryItem();

        public abstract Control CreateEditControl();
    }
}
