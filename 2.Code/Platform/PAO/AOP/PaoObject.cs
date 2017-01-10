using PAO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace PAO {
    /// <summary>
    /// 类:PaoObject
    /// 基础对象
    /// 插件类，所有实体对象的基类
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [Icon(typeof(Resources), "addon")]
    [Addon]
    [DataContract(Namespace = "")]
    [Name("基础对象")]
    [Description("插件类，所有实体对象的基类")]
    public class PaoObject {
        #region 插件属性
        #region 属性:ID
        /// <summary>
        /// 属性:ID
        /// ID
        /// 唯一编号
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("ID")]
        [Description("唯一编号")]
        [EditorType("PAO.Config.Editor.GuidEditController")]
        public virtual string ID {
            get;
            set;
        }
        #endregion 属性:ID
        #endregion 插件属性
        public PaoObject() {
            ID = Guid.NewGuid().ToString();
            OnCreate();
        }

        public string ToShortString() {
            return base.ToString();
        }

        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null, "ID");
        }
        #region 初始化
        /// <summary>
        /// 此方法在构造函数和反序列化时被调用
        /// 构造方法在反序列化时是不会被调用的，切记！
        /// </summary>
        protected virtual void OnCreate() {
        }
        #endregion

        #region Serialize
        [OnDeserializing]
        private void _OnDeserializing(StreamingContext context) {
            OnDeserializing(context);
        }

        [OnDeserialized]
        private void _OnDeserialized(StreamingContext context) {
            OnDeserialized(context);
            OnCreate();
        }

        [OnSerializing]
        private void _OnSerializing(StreamingContext context) {
            OnSerializing(context);
        }

        [OnSerialized]
        private void _OnSerialized(StreamingContext context) {
            OnSerialized(context);
        }

        protected virtual void OnDeserializing(StreamingContext context) {
        }

        protected virtual void OnDeserialized(StreamingContext context) {
        }

        protected virtual void OnSerializing(StreamingContext context) {
        }

        protected virtual void OnSerialized(StreamingContext context) {
        }
        #endregion

        #region Object
        [Browsable(false)]
        public object Self {
            get { return this; }
        }

        [Browsable(false)]
        public virtual object Key {
            get {
                return this;
            }
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns>返回Key的哈希值</returns>
        public override int GetHashCode() {
            if (Key == null || (Key is PaoObject && (PaoObject)Key == this))
                return base.GetHashCode();
            return Key.GetHashCode();
        }

        public override bool Equals(Object obj) {
            PaoObject personObj = obj as PaoObject;
            if (personObj == null)
                return false;
            else if (Key != this)
                return Key.Equals(personObj.Key);
            else
                return base.Equals(obj);
        }

        #endregion
    }
}
