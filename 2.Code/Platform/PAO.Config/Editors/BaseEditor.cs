using DevExpress.XtraEditors.Repository;
using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：BaseEditor
    /// 编辑器
    /// 编辑器基类
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("编辑器")]
    [Description("编辑器基类")]
    public abstract class BaseEditor : PaoObject
    {
        #region 插件属性
        #endregion
        public BaseEditor() {
        }

        [NonSerialized]
        internal Type ObjectType;

        public abstract RepositoryItem CreateEditor();
    }
}
