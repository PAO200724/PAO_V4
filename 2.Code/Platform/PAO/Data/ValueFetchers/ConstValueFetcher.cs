using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO.IO;

namespace PAO.Data.ValueFetchers
{
    /// <summary>
    /// 类：ConstValueFetcher
    /// 常量值获取器
    /// 值为常量的获取器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("常量值获取器")]
    [Description("值为常量的获取器")]
    public class ConstValueFetcher : ValueFetcher
    {
        #region 插件属性
        #region 属性：ConstValue
        /// <summary>
        /// 属性：ConstValue
        /// 常量
        /// 常量
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("常量")]
        [Description("常量")]
        public string ConstValue {
            get;
            set;
        }
        #endregion 属性：ConstValue
        #endregion
        public ConstValueFetcher() {
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object Value {
            get {
                if (ConstValue.IsNullOrEmpty())
                    return GetDefaultValue();

                if (ValueType == typeof(object)) {
                    return IOPublic.Deserialize<string>(ConstValue);
                }
                else {
                    return Convert.ChangeType(ConstValue, ValueType);
                }
            }
        }
    }
}
