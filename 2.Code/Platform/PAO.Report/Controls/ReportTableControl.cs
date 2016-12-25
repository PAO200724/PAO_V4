using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Editors;
using DevExpress.XtraEditors.Repository;
using PAO.Data;
using PAO.WinForm;
using DevExpress.XtraLayout;
using PAO.Config;
using PAO.WinForm.Controls;
using PAO.UI;

namespace PAO.Report.Controls
{
    /// <summary>
    /// 报表数据表控件
    /// 作者：PAO
    /// </summary>
    public partial class ReportTableControl : ViewControl
    {
        public ReportTableControl() {
            InitializeComponent();
            QueryCompleted = false;
        }

        /// <summary>
        /// 查询更多事件
        /// </summary>
        public event EventHandler QueryMore;
        /// <summary>
        /// 查询所有事件
        /// </summary>
        public event EventHandler QueryAll;
        /// <summary>
        /// 重新查询事件
        /// </summary>
        public event EventHandler Requery;
        /// <summary>
        /// 重新查询事件
        /// </summary>
        public event EventHandler SetupQueryBehavior;
        /// <summary>
        /// 重新查询事件
        /// </summary>
        public event EventHandler ClearQueryBehavior;
        
        private ReportDataTable _ReportDataTable;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReportDataTable ReportDataTable {
            get {
                return _ReportDataTable;
            }
            set {
                _ReportDataTable = value;
                if (_ReportDataTable == null)
                    return;

                ExtendAddonPublic.GetAddonExtendProperties(_ReportDataTable);

                RecreateParameterInputControls();
            }
        }

        private bool _QueryCompleted;
        /// <summary>
        /// 查询完成
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool QueryCompleted { get {
                return _QueryCompleted;
            }
            set {
                _QueryCompleted = value;
                this.ButtonAll.Enabled = !_QueryCompleted;
                this.ButtonMore.Enabled = !_QueryCompleted;
            }
        }

        public string TableName {
            get {
                if (_ReportDataTable == null)
                    return null;
                return _ReportDataTable.TableName;
            }
        }

        protected override bool OnClosing(DialogReturn dialogResult) {
            if (this.DataFieldsEditControl != null) {
                if (this.DataFieldsEditControl.Close(dialogResult))
                    return true;

                _ReportDataTable.ParameterInputLayoutData = this.DataFieldsEditControl.LayoutData;
            }
            ExtendAddonPublic.SetAddonExtendProperties(_ReportDataTable, "QueryBehavior", "ParameterInputLayoutData");
            return base.OnClosing(dialogResult);
        }

        public void StartQuery() {
            this.BarProgress.Visible = true;
            this.EditItemProgress.Stopped = false;
            this.Refresh();
        }

        public void EndQuery() {
            this.BarProgress.Visible = false;
            this.EditItemProgress.Stopped = true;
            this.Refresh();
        }

        public void AutoQuery(int timeBreak) {
            if(timeBreak <= 0) {
                this.TimerAutoQuery.Enabled = false;
            } else {
                this.TimerAutoQuery.Enabled = true;
                this.TimerAutoQuery.Interval = timeBreak;
            }
        }

        public int RowCount {
            get {
                if (this.BarItemCount.EditValue == null)
                    return 0;
                return (int)this.BarItemCount.EditValue;
            }

            set {
                this.BarItemCount.EditValue = value;
            }
        }

        public DataField[] ParameterValues {
            get {
                var dataFields = DataFieldsEditControl.EditValue as IEnumerable<DataField>;
                if (dataFields == null)
                    return null;

                return dataFields.ToArray();
            }
        }

        /// <summary>
        /// 创建参数输入控件
        /// </summary>
        private void RecreateParameterInputControls() {
            if(ReportDataTable != null) {
                this.DataFieldsEditControl.LayoutData = ReportDataTable.ParameterInputLayoutData;
                this.DataFieldsEditControl.EditValue = ReportDataTable.GetParameters();
            } else {
                this.DataFieldsEditControl.LayoutData = null;
                this.DataFieldsEditControl.EditValue = null;
            }
            this.Refresh();
        }

        private void ButtonMore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (QueryMore != null)
                QueryMore(this, new EventArgs());
        }

        private void ButtonAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (QueryAll != null)
                QueryAll(this, new EventArgs());
        }

        private void ButtonRequery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (Requery != null)
                Requery(this, new EventArgs());
        }

        private void TimerAutoQuery_Tick(object sender, EventArgs e) {
            if (Requery != null)
                Requery(this, new EventArgs());
        }

        private void ButtonQueryBehavior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (SetupQueryBehavior != null)
                SetupQueryBehavior(this, new EventArgs());
        }
        
        private void ButtonClearQueryBehavior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (ClearQueryBehavior != null)
                ClearQueryBehavior(this, new EventArgs());
        }
    }
}
