using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report.Views
{
    /// <summary>
    /// 类：ChildReportTableController
    /// 子报表数据表控制器
    /// 子报表数据表控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("子报表数据表控制器")]
    [Description("子报表数据表控制器")]
    public class ChildReportTableController : ReportTableController
    {
        #region 插件属性

        #region 属性：ParameterMapping
        /// <summary>
        /// 属性：ParameterMapping
        /// 参数映射
        /// 参数映射
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("参数映射")]
        [Description("参数映射")]
        public Dictionary<string, string> ParameterMapping {
            get;
            set;
        }
        #endregion 属性：ParameterMapping
        #endregion
        public ChildReportTableController() {
        }
    }
}
