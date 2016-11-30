using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.App
{
    /// <summary>
    /// 类：PathFactory
    /// 路径工厂
    /// 根据路径来查找对象的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("路径工厂")]
    [Description("根据路径来查找对象的工厂")]
    public class PathFactory<T> : Factory<T>
    {
        #region 插件属性

        #region 属性：PropertyPath
        /// <summary>
        /// 属性：PropertyPath
        /// 属性路径
        /// 根据路径在默认应用中查找对象
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("属性路径")]
        [Description("根据路径在默认应用中查找对象")]
        public string PropertyPath {
            get;
            set;
        }
        #endregion 属性：PropertyPath
        #endregion
        public PathFactory() {
        }

        protected override T OnCreateInstance() {
            return (T)AddonPublic.GetPropertyValueByPath(PaoApplication.Default, PropertyPath);
        }
    }
}
