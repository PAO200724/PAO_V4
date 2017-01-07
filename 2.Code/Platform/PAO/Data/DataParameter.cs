using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;
using System.Data;
using PAO.Properties;
using PAO.Data.ValueFetchers;

namespace PAO.Data
{
    /// <summary>
    /// 类:DataParameter
    /// 数据字段
    /// 用于保存数据列或参数的对象
    /// 作者:刘丹(Daniel.liu)
    /// </remarks>
    [Serializable]
    [Icon(typeof(Resources), "field")]
    [DataContract(Namespace = "")]
    [Name("数据字段")]
    [Description("用于保存数据列或参数的对象")]
    public class DataParameter : DataItem
    {
        #region 插件属性
        
        #region 属性:Value
        /// <summary>
        /// 属性:Value
        /// 值
        /// 字段值
        /// </summary>
        [AddonProperty]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DataMember(EmitDefaultValue = false)]
        [Name("值")]
        [Description("字段值")]
        public object Value {
            get;
            set;
        }
        #endregion 属性:Value
        
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
        public IValueFetch ValueFetcher {
            get;
            set;
        }
        #endregion 属性：ValueFetcher

        #endregion

        public DataParameter() {

        }
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public DataParameter(string name) {
            Name = name;
        }

        public DataParameter(string name, object value) {
            Name = name;
            Value = value;
        }
        
        public DataParameter(string name, Type dataType, IValueFetch valueFetcher) {
            Name = name;
            ObjectType = dataType;
            ValueFetcher = valueFetcher;
        }

        public DataParameter(string name, DbType dbType, IValueFetch valueFetcher) {
            Name = name;
            DbType = dbType;
            ValueFetcher = valueFetcher;
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Name", "DbType", "ObjectType", "Value");
        }
    }
}
