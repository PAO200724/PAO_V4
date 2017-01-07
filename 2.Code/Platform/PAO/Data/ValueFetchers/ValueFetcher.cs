using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;

namespace PAO.Data.ValueFetchers
{
    /// <summary>
    /// 类：ValueFetcher
    /// 值获取器
    /// 所有值获取器的基类
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("值获取器")]
    [Description("所有值获取器的基类")]
    public abstract class ValueFetcher : PaoObject, IValueFetch
    {
        #region 插件属性

        #region 属性：DbType
        /// <summary>
        /// 属性：DbType
        /// 数据类型
        /// 数据类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据类型")]
        [Description("数据类型")]
        public DbType DbType {
            get;
            set;
        }
        #endregion 属性：DbType
        #endregion

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Type ValueType {
            get {
                return DataPublic.GetNativeTypeByDbType(DbType);
            }
        }

        public ValueFetcher() {
            DbType = DbType.String;
        }

        protected object GetDefaultValue() {
            return null;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public abstract object Value {
            get;
        }
    }
}
