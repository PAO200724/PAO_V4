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
    /// 类:DataItem
    /// 数据字段
    /// 用于保存数据列或参数的对象
    /// 作者:刘丹(Daniel.liu)
    /// </remarks>
    [Serializable]
    [Icon(typeof(Resources), "field")]
    [DataContract(Namespace = "")]
    [Name("数据字段")]
    [Description("用于保存数据列或参数的对象")]
    public class DataItem : PaoObject
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
        

        #endregion

        public DataItem() {

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        public DataItem(string name) {
            Name = name;
        }
        
        public DataItem(string name, Type dataType) {
            Name = name;
            ObjectType = dataType;
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Name", "DbType");
        }
    }
}
