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
    /// 类：ReportQueryBehavior
    /// 报表查询行为
    /// 报表查询行为设定
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表查询行为")]
    [Description("报表查询行为设定")]
    public class ReportQueryBehavior : PaoObject
    {
        #region 插件属性

        #region 属性：AutoQueryInterval
        /// <summary>
        /// 属性：AutoQueryInterval
        /// 自动查询时间间隔
        /// 自动查询时间间隔，单位：毫秒，如果数值为负数表示不自动查询
        /// </summary>
        [AddonProperty]
        [DefaultValue(-1)]
        [DataMember(EmitDefaultValue = false)]
        [Name("自动查询时间间隔")]
        [Description("自动查询时间间隔，单位：毫秒，如果数值小于或等于0，表示不自动查询")]
        public int AutoQueryInterval {
            get;
            set;
        }
        #endregion 属性：AutoQueryInterval
        
        #region 属性：QueryCountPerTime
        /// <summary>
        /// 属性：QueryCountPerTime
        /// 每次查询数量
        /// 每次查询的查询数量，如果小于或等于0，表示一次查询到最后一条记录
        /// </summary>
        [AddonProperty]
        [DefaultValue(100)]
        [DataMember(EmitDefaultValue = false)]
        [Name("每次查询数量")]
        [Description("每次查询的查询数量，如果小于或等于0，表示一次查询到最后一条记录")]
        public int QueryCountPerTime {
            get;
            set;
        }
        #endregion 属性：QueryCountPerTime

        #endregion
        public ReportQueryBehavior() {
            AutoQueryInterval = 0;
            QueryCountPerTime = 100;
        }
    }
}
