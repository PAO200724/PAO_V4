using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report
{
    /// <summary>
    /// 类：ReportDataColumn
    /// 报表的数据列
    /// 报表的数据列定义
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表的数据列")]
    [Description("报表的数据列定义")]
    public class ReportDataColumn : ReportDataField
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
        public ReportDataColumn() {
            IsKey = false;
        }
    }
}
