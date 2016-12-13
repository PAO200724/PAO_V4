using System;
using DevExpress.XtraLayout;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
using PAO.UI.MVC;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using PAO.Data;
using PAO.UI.WinForm;
using PAO.UI;
using DevExpress.XtraVerticalGrid.Rows;
using PAO.Report.ValueFetchers;
using PAO.UI.WinForm.Editors;
using DevExpress.XtraEditors.Repository;
using PAO.Report.Controls;
using DevExpress.XtraBars.Navigation;

namespace PAO.Report.Views
{
    /// <summary>
    /// 报表视图
    /// 作者：PAO
    /// </summary>
    public partial class ReportView : ViewControl, IViewContainer
    {
        /// <summary>
        /// 数据集
        /// </summary>
        internal DataSet DataSource = new DataSet();
        /// <summary>
        /// 视图列表
        /// </summary>
        private List<IView> ViewList = new List<IView>();
        /// <summary>
        /// 表格控件列表
        /// </summary>
        private Dictionary<string, ReportTableControl> TableControls = new Dictionary<string, ReportTableControl>();

        /// <summary>
        /// UI动作分派器
        /// </summary>
        [Browsable(false)]
        public UIActionDispatcher UIActionDispatcher { get; private set; }

        public ReportView() {
            InitializeComponent();
            UIActionDispatcher = new UIActionDispatcher(this);
        }
        
        private void RebuildTableColumns() {

        }

        #region 私有方法
        /// <summary>
        /// 初始化值获取器
        /// </summary>
        private void InitValueFetcher() {
            var controller = Controller as ReportController;
            foreach (var reportTable in controller.Tables) {
                foreach (var parameter in reportTable.QueryParameters) {
                    if (parameter.ValueFetcher != null && parameter.ValueFetcher.Value is IReportElement) {
                        parameter.ValueFetcher.Value.As<IReportElement>().ReportView = this;
                    }
                }
            }
        }

        /// <summary>
        /// 查询表
        /// </summary>
        /// <param name="reportTable"></param>
        private void QueryTable(ReportDataTable reportTable) {
            var tableControl = this.TableControls[reportTable.TableName];
            tableControl.StartQuery();
            if (reportTable.DataFetcher != null) {
                var dataFetcher = reportTable.DataFetcher.Value;
                var backgroundWorker = new BackgroundWorker();
                DataTable dataTable = null;
                int currentCount = 0;
                if (DataSource.Tables.Contains(reportTable.TableName)) {
                    var currentDataTable = DataSource.Tables[reportTable.TableName];
                    currentCount = currentDataTable.Rows.Count;
                }
                backgroundWorker.DoWork += (s, e) =>
                {
                    dataTable = dataFetcher.FetchData(currentCount, 100, null);
                    dataTable.TableName = reportTable.TableName;
                };
                backgroundWorker.RunWorkerCompleted += (s, e) =>
                {
                    if(dataTable != null) {
                        DataSource.Merge(dataTable);
                    }
                    if (DataSource.Tables.Contains(reportTable.TableName)) {
                        tableControl.RowCount = DataSource.Tables[reportTable.TableName].Rows.Count;
                    } else {
                        tableControl.RowCount = 0;
                    }
                    tableControl.EndQuery();
                    SetDataSource();
                };
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 准备数据格式
        /// </summary>
        private void PrepareDataSchema() {
            var controller = Controller as ReportController;
            foreach (var reportTable in controller.Tables) {
                if(reportTable.DataFetcher != null) {
                    // 获取数据格式
                    var dataSchema = reportTable.DataFetcher.Value.GetDataSchema();
                    dataSchema = ReportPublic.RebuildReportTable(reportTable, dataSchema);
                    DataSource.Merge(dataSchema);
                    SetDataSource();
                }
            }
        }

        private void SetDataSource() {
            foreach(var view in ViewList) {
                if(view is IDataView) {
                    view.As<IDataView>().SetDataSource(DataSource);
                }
            }
        }

        /// <summary>
        /// 重建参数视图
        /// </summary>
        private void RecreateTableView() {
            var controller = Controller as ReportController;
            TableControls = new Dictionary<string, Report.Controls.ReportTableControl>();
            foreach (var reportDataTable in controller.Tables) {
                var reportTableControl = new ReportTableControl();
                reportTableControl.ReportDataTable = reportDataTable;
                reportTableControl.Dock = DockStyle.Top;
                reportTableControl.AutoSize = true;
                reportTableControl.RowCount = 0;

                reportTableControl.QueryAll += ReportTableControl_QueryAll;
                reportTableControl.QueryMore += ReportTableControl_QueryMore;
                var elementParameterView = new AccordionControlElement();
                elementParameterView.Name = reportDataTable.ID;
                elementParameterView.Style = ElementStyle.Item;
                elementParameterView.Expanded = true;
                elementParameterView.Text = String.Format("{0}({1})", reportDataTable.Caption, reportDataTable.TableName);
                var container = new AccordionContentContainer();
                container.Controls.Add(reportTableControl);
                container.Height = reportTableControl.Height;
                elementParameterView.ContentContainer = container;

                this.AccordionControl.Elements.Add(elementParameterView);
                this.AccordionControl.Refresh();
                reportTableControl.SizeChanged += (sender, e) => {
                    container.Height = reportTableControl.Height;
                };
                TableControls.Add(reportDataTable.TableName, reportTableControl);
            }
        }
        #endregion

        #region 接口IViewContainer
        public void OpenView(IView view) {
            // 避免重复添加视图
            if (ViewList.Contains(view)) {
                return;
            }

            ViewList.Add(view);
            
            var control = view as Control;
            control.Name = view.ID;

            var groupItem = LayoutControlGroupRoot.AddGroup();
            groupItem.Name = view.ID;
            groupItem.Text = view.Caption;
            groupItem.CaptionImage = view.Icon;
            groupItem.CustomizationFormText = view.Caption;
            groupItem.TextLocation = DevExpress.Utils.Locations.Top;
            groupItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            groupItem.AllowCustomizeChildren = false;

            var layoutControlItem = groupItem.AddItem();
            layoutControlItem.Name = view.ID;
            layoutControlItem.Text = view.Caption;
            layoutControlItem.Image = view.Icon;
            layoutControlItem.CustomizationFormText = view.Caption;
            layoutControlItem.Control = control;
            layoutControlItem.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem.TextVisible = false;
            layoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            layoutControlItem.ShowInCustomizationForm = false;

            LayoutControl.Refresh();
            LayoutControl.SetDefaultLayout();
        }
        #endregion

        #region ViewControl
        protected override void OnSetController(BaseController value) {
            var controller = value as ReportController;
            InitValueFetcher();

            // 打开子视图控制器
            this.BindingSourceTable.DataSource = controller.Tables;
            foreach(var childControllerRef in controller.Controllers) {
                var childController = childControllerRef.Value;
                childController.CreateAndOpenView(this);
            }

            // 重建参数视图
            RecreateTableView();

            // 准备数据格式
            PrepareDataSchema();

            // 读取布局
            AddonPublic.ApplyAddonExtendProperties(controller);
            this.LayoutControl.SetLayoutData(controller.LayoutData);
        }

        protected override void OnClosing() {
            if (ViewList.IsNotNullOrEmpty()) {
                foreach (var view in ViewList) {
                    view.CloseView();
                }
            }
            var controller = Controller as ReportController;
            controller.LayoutData = this.LayoutControl.GetLayoutData();
            AddonPublic.FetchAddonExtendProperties(controller, "LayoutData", "DockPanelLayoutData");
        }
        #endregion

        #region 事件
        private void ButtonRecoverLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            LayoutControl.RestoreDefaultLayout();
        }

        private void LayoutControl_ItemAdded(object sender, EventArgs e) {
            if (sender is LayoutControlGroup) {
                var groupItem = sender as LayoutControlGroup;
                groupItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            }
            else if (sender is TabbedControlGroup) {
                var tabbedControlGroup = sender as TabbedControlGroup;
                tabbedControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            }
        }
        
        private void ButtonClearDataFields_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (UIPublic.ShowYesNoDialog("您确定要清空所有表的列并重建吗？") == DialogReturn.Yes) {

            }
        }

        private void ButtonRebuildDataFields_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            RebuildTableColumns();
        }

        private void ReportTableControl_QueryMore(object sender, EventArgs e) {
            var tableControl = sender as ReportTableControl;
            QueryTable(tableControl.ReportDataTable);
        }

        private void ReportTableControl_QueryAll(object sender, EventArgs e) {
            var tableControl = sender as ReportTableControl;
            QueryTable(tableControl.ReportDataTable);
        }

        private void ButtonQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var controller = Controller as ReportController;
            foreach (var reportTable in controller.Tables) {
                QueryTable(reportTable);
            }
        }
        #endregion
    }
}
