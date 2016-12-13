using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO {
    /// <summary>
    /// 类:Ref
    /// 引用
    /// 通过工厂创建对象的类型
    /// 作者:PAO
    /// </summary>
    [Addon]
    [Name("引用")]
    [Description("通过工厂创建对象的类型")]
    public interface Ref
    {
        /// <summary>
        /// 获取引用的值
        /// </summary>
        object Value {
            get;
        }

        /// <summary>
        /// 重建引用
        /// </summary>
        void BuildRef();
    }

    /// <summary>
    /// 类:Ref
    /// 引用
    /// 通过工厂创建对象的类型
    /// 作者:PAO
    /// </summary>
    [Addon]
    [Name("引用")]
    [Description("通过工厂创建对象的类型")]
    public interface Ref<out T> : Ref
    {
        /// <summary>
        /// 获取引用的值
        /// </summary>
        new T Value {
            get;
        }
    }
}
