using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.Config.Editor;
using DevExpress.XtraEditors.Repository;
using PAO.Data;
using PAO.WinForm;
using DevExpress.XtraLayout;
using PAO.Config;
using PAO.WinForm.Controls;
using PAO.UI;
using PAO.Report.Controls;
using PAO.MVC;
using PAO.IO;

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
        /// 数据表
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DataTable;

        internal List<ReportTableView> ChildTableViews;

        private BackgroundWorker QueryWorker;
        /// <summary>
        /// 数据发生了变更
        /// </summary>
        public event EventHandler<DataFetchedEventArgs> DataFetched;
        /// <summary>
        /// 数据发生了变更
        /// </summary>
        public event EventHandler DataRequery;

        private DataParametersEditControl DataFieldsEditControl;
        
        private bool _QueryCompleted;
        /// <summary>
        /// 上级查询行为
        /// </summary>
        private ReportQueryBehavior ParentQueryBehavior;

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
                ExtendAddonPublic.SetAddonExtendProperties(controller, "QueryBehavior", "ParameterEditController", "QueryParameters", "DataColumns");
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

        public void ResetAutoQueryTimer(int timeBreak) {
            if(timeBreak <= 0) {
                this.TimerAutoQuery.Enabled = false;
            } else {
                this.TimerAutoQuery.Enabled = true;
                this.TimerAutoQuery.Interval = timeBreak;
            }
        }

        /// <summary>
        /// 重新查询表，查询前清空数据
        /// </summary>
        /// <param name="queryAll">是否查询所有数据</param>
        public void RequeryTable(bool queryAll) {
            var controller = Controller as ReportTableController;
            QueryCompleted = false;
            RowCount = 0;
            DataTable = new DataTable(controller.TableName);

            if (DataRequery != null)
                DataRequery(this, new EventArgs());
            QueryTable(DataTable, queryAll);
        }

        /// <summary>
        /// 查询表，查询前不清空数据
        /// </summary>
        /// <param name="dataTable">数据表，用于保存结果</param>
        /// <param name="queryAll">是否查询所有数据</param>
        public void QueryTable(DataTable dataTable, bool queryAll) {
            var controller = Controller as ReportTableController;
            StartQuery();
            if (controller.DataFetcher != null) {
                var dataFetcher = controller.DataFetcher.Value;
                DataTable queryTable = null;

                int currentCount = 0;

                // 获取当前行号
                currentCount = DataTable.Rows.Count;

                // 获取查询行为
                ReportQueryBehavior queryBehavior = controller.QueryBehavior;
                if (queryBehavior == null) {
                    queryBehavior = controller.QueryBehavior;
                }
                // 获取每次查询的最大量
                int maxCount = 0;
                if(!queryAll && queryBehavior != null) {
                    maxCount = queryBehavior.QueryCountPerTime;
                }
                if (maxCount <= 0) {
                    maxCount = Int32.MaxValue;
                }

                var paramValues = ParameterValues;
                Action query = () =>
                {
                    queryTable = dataFetcher.FetchData(currentCount, maxCount, paramValues);
                    queryTable.TableName = controller.TableName;
                };

                Action queryComplete = () =>
                {
                    // 如果当前DataTable已经变化，说明在上一次查询完成前开始了下一轮查询，则不再继续查询
                    if (dataTable != DataTable)
                        return;

                    if (queryTable != null) {
                        if (queryTable.Rows.Count < maxCount) {
                            QueryCompleted = true;
                        }
                        else {
                            QueryCompleted = false;
                        }
                        DataTable.Merge(queryTable);

                        RowCount = DataTable.Rows.Count;

                        if (DataFetched != null) {
                            DataFetched(this, new DataFetchedEventArgs(queryTable));
                        }
                    }
                    EndQuery();
                };

                // 异步查询(避免同步查询导致的死机问题)
                QueryWorker = new BackgroundWorker();
                QueryWorker.DoWork += (s, e) =>
                {
                    query();
                };
                QueryWorker.RunWorkerCompleted += (s, e) =>
                {
                    // 如果背景线程已经取消，则不再执行后续工作
                    if (QueryWorker.CancellationPending)
                        return;

                    queryComplete();
                };
                QueryWorker.RunWorkerAsync(DataTable);
            }
        }

        public void CancelQuery() {
            if(QueryWorker != null) {
                QueryWorker.CancelAsync();
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

        private void ButtonAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            RequeryTable(true);
        }

        private void ButtonMore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            RequeryTable(false);
        }
        
        private void ButtonRequery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            RequeryTable(false);
        }

        private void TimerAutoQuery_Tick(object sender, EventArgs e) {
        }

        private void ButtonQueryBehavior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var controller = Controller as ReportTableController;
            if (EditorPublic.ShowEditPropertyDialog(controller, "QueryBehavior") == DialogReturn.OK) {
                ResetAutoQuery();
            }
        }
        
        private void ButtonClearQueryBehavior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var controller = Controller as ReportTableController;
            controller.QueryBehavior = null;
            ResetAutoQuery();
        }

        /// <summary>
        /// 重置自动查询
        /// </summary>
        /// <param name="parentQueryBehavior">上级查询行为</param>
        public void ResetAutoQuery(ReportQueryBehavior parentQueryBehavior = null) {
            var controller = Controller as ReportTableController;
            if(parentQueryBehavior != null) {
                ParentQueryBehavior = parentQueryBehavior;
            }
            var queryBehavior = controller.QueryBehavior;
            if(queryBehavior == null) {
                queryBehavior = ParentQueryBehavior;
            }
            if (queryBehavior != null) {
                ResetAutoQueryTimer(queryBehavior.AutoQueryInterval);
            }
            else {
                ResetAutoQueryTimer(-1);
            }
        }

    }
}
