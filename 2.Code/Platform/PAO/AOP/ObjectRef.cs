﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO {
    /// <summary>
    /// 类：ObjectRef
    /// 对象连接
    /// 直接链接到对象的Ref类
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("对象连接")]
    [Description("直接链接到对象的Ref类")]
    public class ObjectRef<T> : Ref<T> {
        #region 插件属性
        /// <summary>
        /// 属性：Reference
        /// 引用
        /// 对象的直接引用，如果设置了此值，则直接将此值作为追踪值
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("对象的直接引用")]
        [Description("对象的直接引用")]
        public T Reference {
            get;
            set;
        }
        #endregion
        public ObjectRef() {
        }

        public ObjectRef(T reference) {
            Reference = reference;
        }
        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null/*,"属性名称"*/);
        }

        /// <summary>
        /// 获取引用的值
        /// </summary>
        public override T Value {
            get {
                return Reference;
            }
        }
    }
}
