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
    public class DataField : DataItem
    {
        #region 插件属性
        
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

        #endregion

        public DataField() {

        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public DataField(string name) {
            Name = name;
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
        
        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Name", "DbType", "ObjectType");
        }
    }
}
