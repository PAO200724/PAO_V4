using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;
using System.Data;
using PAO.Properties;

namespace PAO.Data
{
    /// <summary>
    /// 类:DataField
    /// 数据字段
    /// 用于保存数据列或参数的对象
    /// 作者:刘丹(Daniel.liu)
    /// </remarks>
    [Serializable]
    [Icon(typeof(Resources), "field")]
    [DataContract(Namespace = "")]
    [Name("数据字段")]
    [Description("用于保存数据列或参数的对象")]
    public class DataField : PaoObject
    {
        #region 插件属性
        #region 属性:Name
        /// <summary>
        /// 属性:Name
        /// 名称
        /// 字段名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("名称")]
        [Description("字段名称")]
        public string Name {
            get;
            set;
        }
        #endregion 属性:Name
        
        #region 属性:DbType
        /// <summary>
        /// 属性:DbType
        /// 类型
        /// 数据字段的类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("类型")]
        [Description("数据字段的类型")]
        public DbType DbType {
            get;
            set;
        }
        #endregion 属性:DbType

        #region 属性:Value
        /// <summary>
        /// 属性:Value
        /// 值
        /// 字段值
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("值")]
        [Description("字段值")]
        public object Value {
            get;
            set;
        }
        #endregion 属性:Value

        #region 属性：IsKey
        /// <summary>
        /// 属性：IsKey
        /// 是否主键
        /// 是否主键
        /// </summary>
        [AddonProperty]
        [DefaultValue(false)]
        [DataMember(EmitDefaultValue = false)]
        [Name("是否主键")]
        [Description("是否主键")]
        public bool IsKey {
            get;
            set;
        }
        #endregion 属性：IsKey

        #region 属性：Expression
        /// <summary>
        /// 属性：Expression
        /// 表达式
        /// 计算类的数据列的表达式
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("表达式")]
        [Description("计算类的数据列的表达式")]
        public string Expression {
            get;
            set;
        }
        #endregion 属性：Expression

        #region 属性：ValueFetcher
        /// <summary>
        /// 属性：ValueFetcher
        /// 值获取器
        /// 值获取器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("值获取器")]
        [Description("值获取器")]
        public Ref<IValueFetch> ValueFetcher {
            get;
            set;
        }
        #endregion 属性：ValueFetcher

        #endregion

        public DataField() {

        }

        public Type ObjectType {
            get {
                return DataPublic.GetNativeTypeByDbType(DbType);
            }
            set {
                DbType = DataPublic.GetDbTypeByNativeType(value);
            }
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

        public DataField(string name, Type dataType, string expression = null) {
            Name = name;
            ObjectType = dataType;
            Expression = expression;
        }

        public DataField(string name, DbType dbType, string expression = null) {
            Name = name;
            DbType = dbType;
            Expression = expression;
        }

        public DataField(string name, Type dataType, Ref<IValueFetch> valueFetcher) {
            Name = name;
            ObjectType = dataType;
            ValueFetcher = valueFetcher;
        }

        public DataField(string name, DbType dbType, Ref<IValueFetch> valueFetcher) {
            Name = name;
            DbType = dbType;
            ValueFetcher = valueFetcher;
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Name", "Type", "Value");
        }
    }
}
