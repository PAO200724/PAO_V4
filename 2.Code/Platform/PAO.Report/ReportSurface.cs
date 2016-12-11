using PAO;
using PAO.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report
{
    /// <summary>
    /// 类：ReportSurface
    /// 报表外观
    /// 报表外观
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表外观")]
    [Description("报表外观")]
    public class ReportSurface : Surface
    {
        #region 插件属性

        #region 属性：TitleFont
        /// <summary>
        /// 属性：TitleFont
        /// 标题字体
        /// 标题字体
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("标题字体")]
        [Description("标题字体")]
        public Font TitleFont {
            get;
            set;
        }
        #endregion 属性：TitleFont

        #endregion
        public ReportSurface() {
        }
    }
}
