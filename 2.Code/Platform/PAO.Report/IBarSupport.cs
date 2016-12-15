using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;

namespace PAO.Report
{
    /// <summary>
    /// 接口：IBarSupport
    /// 工具条接口
    /// 提供工具条的接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("工具条接口")]
    [Description("提供工具条的接口")]
    public interface IBarSupport
    {
        /// <summary>
        /// 扩展工具条
        /// </summary>
        IEnumerable<Bar> ExtendBars { get; }
    }
}
