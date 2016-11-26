using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO {
    /// <summary>
    /// 类:Factory
    /// 工厂类
    /// 用工厂方式创建引用的类
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("工厂类")]
    [Description("用工厂方式创建引用的类")]
    public abstract class Factory<T> : Ref<T> {
        #region 插件属性
        #region 属性:BufferInstance
        /// <summary>
        /// 属性:BufferInstance
        /// 缓存实例
        /// 如果缓存了实例，则除非BuildRef，否则不重新创建实例，默认为true
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("缓存实例")]
        [Description("如果缓存了实例，则除非BuildRef，否则不重新创建实例，默认为true")]
        public bool BufferInstance {
            get;
            set;
        }
        #endregion 属性:BufferInstance
        #endregion
        /// <summary>
        /// 对象实例
        /// </summary>
        [NonSerialized]
        private T Instance;
        /// <summary>
        /// 对象是否创建
        /// </summary>
        [NonSerialized]
        private bool Builden;

        /// <summary>
        /// 对象实例是否创建
        /// </summary>
        public bool IsBuilden {
            get {
                return Builden;
            }
        }

        public Factory() {
            BufferInstance = true;
        }

        protected override void OnCreate() {
            Builden = false;
            base.OnCreate();
        }

        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null/*,"属性名称"*/);
        }

        public override T Value {
            get {
                // 如果从未创建过实例或者不缓存实例，则创建实例，否则直接范围实例
                if (!Builden || !BufferInstance) {
                    BuildRef();
                }
                return Instance;
            }
        }

        public override void BuildRef() {
            Builden = true;
            Instance = OnCreateInstance();
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <returns>对象实例</returns>
        protected abstract T OnCreateInstance();
    }
}
