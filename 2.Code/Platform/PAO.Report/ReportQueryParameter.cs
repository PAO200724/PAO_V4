using PAO;
using PAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report
{
    /// <summary>
    /// 类：ReportQueryParameter
    /// 报表查询参数
    /// 报表查询参数
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表查询参数")]
    [Description("报表查询参数")]
    public class ReportQueryParameter : ReportDataField
    {
        #region 插件属性

        #region 属性：UserInput
        /// <summary>
        /// 属性：UserInput
        /// 用户输入
        /// 是否由用户输入
        /// </summary>
        [AddonProperty]
        [DefaultValue(true)]
        [DataMember(EmitDefaultValue = false)]
        [Name("用户输入")]
        [Description("是否由用户输入")]
        public bool UserInput {
            get;
            set;
        }
        #endregion 属性：UserInput

        #region 属性：ValueFetcher
        /// <summary>
        /// 属性：ValueFetcher
        /// 值获取器
        /// 默认值获取器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("值获取器")]
        [Description("默认值获取器")]
        public Ref<IValueFetch> ValueFetcher {
            get;
            set;
        }
        #endregion 属性：ValueFetcher

        #endregion
        public ReportQueryParameter() {
            UserInput = true;
        }
    }
}
