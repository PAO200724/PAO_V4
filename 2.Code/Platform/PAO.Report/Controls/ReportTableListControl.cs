using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.Report.Controls
{
    /// <summary>
    /// 报表数据表列表控件
    /// 作者：PAO
    /// </summary>
    public partial class ReportTableListControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ReportTableListControl() {
            InitializeComponent();
        }

        private IEnumerable<ReportDataTable> _ReportDataTables;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<ReportDataTable> ReportDataTables {
            get { return _ReportDataTables; }
            set {
                _ReportDataTables = value;
                CreateTableList();
                this.Refresh();
            }
        }

        private void CreateTableList() {
            if (_ReportDataTables == null)
                return;
            foreach (var reportDataTable in _ReportDataTables) {
                var reportTableControl = new ReportTableControl();
                reportTableControl.ReportDataTable = reportDataTable;
                reportTableControl.Dock = DockStyle.Top;
                reportTableControl.Width = this.FlowLayoutPanel.Width;
                this.FlowLayoutPanel.Controls.Add(reportTableControl);
            }
        }
    }
}
