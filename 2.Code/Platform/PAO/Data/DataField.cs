using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace PAO.Data
{
    /// <summary>
    /// 类:DataField
    /// 数据字段
    /// 用于保存数据列或参数的对象
    /// 作者:刘丹(Daniel.liu)
    /// </remarks>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("数据字段")]
    [Description("用于保存数据列或参数的对象")]
    public class DataField
    {
        #region 插件属性
        #region 属性:Type
        /// <summary>
        /// 属性:Type
        /// 类型
        /// 数据字段的类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("类型")]
        [Description("数据字段的类型")]
        public DbType Type {
            get;
            set;
        }
        #endregion 属性:Type

        #region 属性:Name
        /// <summary>
        /// 属性:Name
        /// 名称
        /// 字段名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("名称")]
        [Description("字段名称")]
        public string Name {
            get;
            set;
        }
        #endregion 属性:Name

        #region 属性:Caption
        /// <summary>
        /// 属性:Caption
        /// 标题
        /// 字段标题
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("标题")]
        [Description("字段标题")]
        public string Caption {
            get;
            set;
        }
        #endregion 属性:Caption

        #region 属性:Value
        /// <summary>
        /// 属性:Value
        /// 值
        /// 字段值
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("值")]
        [Description("字段值")]
        public object Value {
            get;
            set;
        }
        #endregion 属性:Value
        #endregion

        public DataField() {

        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public DataField(string name) {
            Name = name;
        }

        public DataField(string name, object value) {
            Name = name;
            Value = value;
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Name", "Type", "Value");
        }
    }
}
