using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO {
    /// <summary>
    /// 类:BaseRef
    /// 引用
    /// 通过工厂创建对象的类型
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("引用")]
    [Description("通过工厂创建对象的类型")]
    public abstract class BaseRef<T> : PaoObject, Ref<T>
    {
        public BaseRef() {

        }

        /// <summary>
        /// 获取引用的值
        /// </summary>
        public abstract T Value {
            get;
        }

        /// <summary>
        /// 重建引用
        /// </summary>
        public virtual void BuildRef() {
        }
    }
}
