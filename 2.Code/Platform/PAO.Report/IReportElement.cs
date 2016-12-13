using PAO.Report.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Report
{
    /// <summary>
    /// 接口：IReportElement
    /// 报表元素
    /// 报表元素
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("报表元素")]
    [Description("报表元素")]
    public interface IReportElement
    {
        ReportView ReportView { get; set; }
    }
}
