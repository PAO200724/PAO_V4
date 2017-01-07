using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Editor;
using DevExpress.XtraEditors.Repository;
using PAO.Data;
using PAO.WinForm;
using DevExpress.XtraLayout;
using PAO.Config;
using PAO.WinForm.Controls;
using PAO.UI;
using PAO.Config.Editor;
using PAO.Report.Controls;
using PAO.MVC;

namespace PAO.Report.Views
{
    /// <summary>
    /// 报表数据表控件
    /// 作者：PAO
    /// </summary>
    public partial class ReportTableView : ViewControl
    {
        public ReportTableView() {
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

        private DataParametersEditControl DataFieldsEditControl;
        
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
                var controller = Controller as ReportTableController;
                if (controller == null)
                    return null;
                return controller.TableName;
            }
        }
        
        protected override void OnClose() {
            var controller = Controller as ReportTableController;
            if(controller != null) {
                controller.QueryParameters = this.DataFieldsEditControl.EditValue as List<DataParameter>;
                ExtendAddonPublic.SetAddonExtendProperties(controller, "QueryBehavior", "ParameterEditController");
            }
            base.OnClose();
        }

        protected override void OnSetController(BaseController value) {
            var controller = value as ReportTableController;
            if (controller == null)
                return;

            if (DataFieldsEditControl != null) {
                DataFieldsEditControl.Parent = null;
                DataFieldsEditControl.CloseControl();
                DataFieldsEditControl.Dispose();
            }

            DataFieldsEditControl = controller.ParameterEditController.CreateEditControl(typeof(DataField)) as DataParametersEditControl;
            DataFieldsEditControl.Dock = DockStyle.Top;
            DataFieldsEditControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DataFieldsEditControl.AutoSize = true;
            DataFieldsEditControl.Parent = this;

            ExtendAddonPublic.GetAddonExtendProperties(controller);

            RecreateParameterInputControls();

            base.OnSetController(value);
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

        public DataParameter[] ParameterValues {
            get {
                var dataFields = DataFieldsEditControl.EditValue as IEnumerable<DataParameter>;
                if (dataFields == null)
                    return null;

                return dataFields.ToArray();
            }
        }

        /// <summary>
        /// 创建参数输入控件
        /// </summary>
        private void RecreateParameterInputControls() {
            var controller = Controller as ReportTableController;
            if (controller != null) {
                this.DataFieldsEditControl.EditValue = controller.GetParameters();
            } else {
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
