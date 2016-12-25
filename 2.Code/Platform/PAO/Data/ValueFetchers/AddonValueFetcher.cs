using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Data.ValueFetchers
{
    /// <summary>
    /// 类：AddonValueFetcher
    /// 插件值获取器
    /// 获取插件的值的获取器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("插件值获取器")]
    [Description("获取插件的值的获取器")]
    public class AddonValueFetcher<T> : PaoObject, IValueFetch
    {
        #region 插件属性

        #region 属性：AddonID
        /// <summary>
        /// 属性：AddonID
        /// 插件ID
        /// 插件ID
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("插件ID")]
        [Description("插件ID")]
        public string AddonID {
            get;
            set;
        }
        #endregion 属性：AddonID

        #region 属性：MemberName
        /// <summary>
        /// 属性：MemberName
        /// 成员名称
        /// 插件属性或字段名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("成员名称")]
        [Description("插件属性或字段名称")]
        public string MemberName {
            get;
            set;
        }
        #endregion 属性：MemberName
        #endregion
        public AddonValueFetcher() {
        }

        public object Value {
            get {
                // 获取插件
                var addon = AddonPublic.GetRuntimeAddonByID(AddonID);
                if (addon == null)
                    return default(T);

                // 获取插件的值
                Type addonType = addon.GetType();
                var propInfo = addonType.GetProperty(MemberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
                if (propInfo != null)
                    return (T)propInfo.GetValue(addon, null);
                var fieldInfo = addonType.GetField(MemberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField);
                if (fieldInfo != null)
                    return (T)fieldInfo.GetValue(addon);

                return default(T);
            }
        }
        
    }
}
