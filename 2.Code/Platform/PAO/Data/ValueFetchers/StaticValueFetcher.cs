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
    /// 类：StaticValueFetcher
    /// 静态值获取器
    /// 静态属性值获取器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("静态值获取器")]
    [Description("静态属性值获取器")]
    public class StaticValueFetcher<T> : PaoObject, IValueFetch
    {
        #region 插件属性

        #region 属性：Type
        /// <summary>
        /// 属性：Type
        /// 类型
        /// 静态变量所在的类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("类型")]
        [Description("静态变量所在的类型")]
        public Type Type {
            get;
            set;
        }
        #endregion 属性：Type

        #region 属性：MemberName
        /// <summary>
        /// 属性：MemberName
        /// 成员名称
        /// 静态属性或字段成员名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("成员名称")]
        [Description("静态属性或字段成员名称")]
        public string MemberName {
            get;
            set;
        }
        #endregion 属性：MemberName
        #endregion
        public StaticValueFetcher() {
        }

        public object Value {
            get {
                var propInfo = Type.GetProperty(MemberName, BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty);
                if (propInfo != null)
                    return (T)propInfo.GetValue(null, null);
                var fieldInfo = Type.GetField(MemberName, BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField);
                if (fieldInfo != null)
                    return (T)fieldInfo.GetValue(null);

                return default(T);
            }
        }
    }
}
