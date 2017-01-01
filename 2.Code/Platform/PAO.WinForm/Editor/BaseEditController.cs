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
        #endregion
        public BaseEditController() {
        }

        protected abstract RepositoryItem OnCreateRepositoryItem(Type objectType);
        
        /// <summary>
        /// 创建RepositoryItem
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>RepositoryItem</returns>
        public virtual RepositoryItem CreateRepositoryItem(Type objectType) {
            var repositoryItem = OnCreateRepositoryItem(objectType);
            return repositoryItem;
        }

        protected abstract Control OnCreateEditControl(Type objectType);

        /// <summary>
        /// 创建编辑控件（可以是BaseEdit或BaseEditControl）
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>编辑控件</returns>
        public virtual Control CreateEditControl(Type objectType) {
            var editControl = OnCreateEditControl(objectType);
            return editControl;
        }
    }
}
