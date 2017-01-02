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

namespace PAO.WinForm.Editor
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
    public abstract class BaseEditController : PaoObject
    {
        #region 插件属性

        #region 属性：StaticType
        /// <summary>
        /// 属性：StaticType
        /// 固定类型
        /// 指示此控制器是否对应固定的类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("固定类型")]
        [Description("指示此控制器是否对应固定的类型")]
        public bool StaticType {
            get;
            set;
        }
        #endregion 属性：StaticType

        #endregion
        public BaseEditController() {
            StaticType = true;
        }
        public BaseEditController(bool staticType) {
            StaticType = staticType;
        }
        protected abstract RepositoryItem OnCreateRepositoryItem(Type objectType);
        
        /// <summary>
        /// 创建RepositoryItem
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>RepositoryItem</returns>
        public virtual RepositoryItem CreateRepositoryItem(Type objectType = null) {
            var repositoryItem = OnCreateRepositoryItem(objectType);
            return repositoryItem;
        }

        protected abstract Control OnCreateEditControl(Type objectType);

        /// <summary>
        /// 创建编辑控件（可以是BaseEdit或BaseEditControl）
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>编辑控件</returns>
        public virtual Control CreateEditControl(Type objectType = null) {
            var editControl = OnCreateEditControl(objectType);
            return editControl;
        }

        public static bool TypeFilter(Type type) {
            return true;
        }
    }
}
