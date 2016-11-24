using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO {
    /// <summary>
    /// 类：Ref
    /// 引用
    /// 通过工厂创建对象的类型
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("引用")]
    [Description("通过工厂创建对象的类型")]
    public abstract class Ref<T> : PaoObject{
        public Ref() {

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

        public static implicit operator T(Ref<T> obj) {
            return obj.Value;
        }

        public static implicit operator Ref<T>(T obj) {
            return new ObjectRef<T>(obj);
        }
    }
}
