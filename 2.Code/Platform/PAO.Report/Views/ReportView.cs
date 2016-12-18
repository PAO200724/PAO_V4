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
using PAO.Config.Controls.EditControls;
using PAO.IO;
using PAO.Config;
using PAO.Config.DockViews;
using PAO.Report.Properties;

namespace PAO.Report.Views
{
    /// <summary>
    /// 报表视图
    /// 作者：PAO
    /// </summary>
    [Icon(typeof(Resources), "report")]
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
            this.BarExtend.Visible = false;
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
        /// 重新查询表，查询前清空数据
        /// </summary>
        /// <param name="reportTable"></param>
        private void RequeryTable(ReportDataTable reportTable) {
            var reportControl = TableControls[reportTable.TableName];
            reportControl.QueryCompleted = false;
            reportControl.RowCount = 0;
            if (DataSource.Tables.Contains(reportTable.TableName)) {
                DataSource.Tables[reportTable.TableName].Clear();
            }
            QueryTable(reportTable);
        }

        /// <summary>
        /// 重置自动查询
        /// </summary>
        /// <param name="reportTable">报表</param>
        private void ResetAutoQuery() {
            var controller = Controller as ReportController;
            foreach (var reportTable in controller.Tables) {
                var queryBehavior = reportTable.QueryBehavior;
                if (queryBehavior == null)
                    queryBehavior = controller.QueryBehavior;

                var tableControl = this.TableControls[reportTable.TableName];
                if (queryBehavior != null) {
                    tableControl.AutoQuery(queryBehavior.AutoQueryInterval);
                } else {
                    tableControl.AutoQuery(-1);
                }
            }
        }

        /// <summary>
        /// 查询表，查询前不清空数据
        /// </summary>
        /// <param name="reportTable"></param>
        private void QueryTable(ReportDataTable reportTable) {
            var controller = Controller as ReportController;
            var tableControl = this.TableControls[reportTable.TableName];
            tableControl.StartQuery();
            if (reportTable.DataFetcher != null) {
                var dataFetcher = reportTable.DataFetcher.Value;
                DataTable queryTable = null;

                int currentCount = 0;
                DataTable currentDataTable = null;

                // 获取当前行
                if (DataSource.Tables.Contains(reportTable.TableName)) {
                    currentDataTable = DataSource.Tables[reportTable.TableName];
                    currentCount = currentDataTable.Rows.Count;
                }
                // 获取查询行为
                ReportQueryBehavior queryBehavior = reportTable.QueryBehavior;
                if (queryBehavior == null) {
                    queryBehavior = controller.QueryBehavior;
                }
                // 获取每次查询的最大量
                int maxCount = 0;
                if (queryBehavior != null)
                    maxCount = queryBehavior.QueryCountPerTime;
                if (maxCount <= 0)
                    maxCount = Int32.MaxValue;

                Action query = () =>
                {
                    queryTable = dataFetcher.FetchData(currentCount, maxCount, tableControl.ParameterValues);
                    queryTable.TableName = reportTable.TableName;
                };

                Action queryComplete = () =>
                {
                    if (queryTable != null) {
                        if (queryTable.Rows.Count < maxCount) {
                            tableControl.QueryCompleted = true;
                        }
                        else {
                            tableControl.QueryCompleted = false;
                        }
                        DataSource.Merge(queryTable);
                        tableControl.RowCount = DataSource.Tables[reportTable.TableName].Rows.Count;
                    }
                    tableControl.EndQuery();
                    SetDataSource();
                };

                if(queryBehavior != null && !queryBehavior.AsyncQuery) {
                    // 同步查询
                    query();

                    queryComplete();
                } else {
                    // 异步查询
                    var backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += (s, e) =>
                    {
                        query();
                    };
                    backgroundWorker.RunWorkerCompleted += (s, e) =>
                    {
                        queryComplete();
                    };
                    backgroundWorker.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// 查询所有表格
        /// </summary>
        private void RequeryAllTable() {
            var controller = Controller as ReportController;
            foreach (var reportTable in controller.Tables) {
                RequeryTable(reportTable);
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
                reportTableControl.Requery += ReportTableControl_Requery;
                reportTableControl.SetupQueryBehavior += ReportTableControl_SetupQueryBehavior;
                reportTableControl.ClearQueryBehavior += ReportTableControl_ClearQueryBehavior;

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
            if(control is IBarSupport) {
                var barSupport = control as IBarSupport;
                control.Enter += (s, e) =>
                {
                    var bars = barSupport.ExtendBars;
                    if(bars.IsNotNullOrEmpty()) {
                        foreach(var bar in bars) {
                            this.BarExtend.Merge(bar);
                            this.BarItemSelectedObject.Caption = view.Caption;
                            this.BarItemSelectedObject.Glyph = view.Icon;
                            this.BarItemSelectedObject.LargeGlyph = view.LargeIcon;
                        }
                    }
                    if(this.BarExtend.ItemLinks.Count > 1) {
                        this.BarExtend.Visible = true;
                    } else {
                        this.BarExtend.Visible = false;
                    }
                };
                control.Leave += (s, e) =>
                {
                    this.BarExtend.UnMerge();
                    this.BarExtend.Visible = false;
                };
            }

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
            foreach(var childControllerRef in controller.Displayers) {
                var childController = childControllerRef.Value;
                childController.CreateAndOpenView(this);
            }

            // 重建参数视图
            RecreateTableView();

            // 准备数据格式
            PrepareDataSchema();

            // 重置自动查询
            ResetAutoQuery();

            // 读取报表和数据的客户端设置
            AddonPublic.LoadAddonExtendProperties(controller);
            this.LayoutControl.SetLayoutData(controller.LayoutData);
            foreach (var reportTable in controller.Tables) {
                AddonPublic.LoadAddonExtendProperties(reportTable);
            }
        }

        protected override void OnClosing() {
            if (ViewList.IsNotNullOrEmpty()) {
                foreach (var view in ViewList) {
                    view.CloseView();
                }
            }
            var controller = Controller as ReportController;
            // 保存报表和数据的客户端设置
            controller.LayoutData = this.LayoutControl.GetLayoutData();
            AddonPublic.SaveAddonExtendProperties(controller, "LayoutData", "QueryBehavior");
            foreach(var reportTable in controller.Tables) {
                AddonPublic.SaveAddonExtendProperties(reportTable, "QueryBehavior");
            }
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
                var controller = Controller as ReportController;
                foreach (var reportTable in controller.Tables) {
                    reportTable.DataColumns = null;
                    RebuildTableColumns();
                }
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

        private void ReportTableControl_Requery(object sender, EventArgs e) {
            var tableControl = sender as ReportTableControl;
            RequeryTable(tableControl.ReportDataTable);
        }

        private void ReportTableControl_SetupQueryBehavior(object sender, EventArgs e) {
            var tableControl = sender as ReportTableControl;
            var objectEditControl = new ObjectEditControl();
            var queryBehavior = IOPublic.ObjectClone(tableControl.ReportDataTable.QueryBehavior);
            if (queryBehavior == null)
                queryBehavior = new ReportQueryBehavior();
            objectEditControl.SelectedObject = queryBehavior;
            if(WinFormPublic.ShowDialog(objectEditControl) == DialogReturn.OK) {
                tableControl.ReportDataTable.QueryBehavior = objectEditControl.SelectedObject as ReportQueryBehavior;
            }
            ResetAutoQuery();
        }


        private void ReportTableControl_ClearQueryBehavior(object sender, EventArgs e) {
            var tableControl = sender as ReportTableControl;
            tableControl.ReportDataTable.QueryBehavior = null;
            ResetAutoQuery();
        }


        private void ButtonQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            RequeryAllTable();
        }

        private void ButtonSetupQueryBehavior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var controller = Controller as ReportController;
            var objectEditControl = new ObjectEditControl();
            var queryBehavior = IOPublic.ObjectClone(controller.QueryBehavior);
            if (queryBehavior == null)
                queryBehavior = new ReportQueryBehavior();
            objectEditControl.SelectedObject = queryBehavior;
            if (WinFormPublic.ShowDialog(objectEditControl) == DialogReturn.OK) {
                controller.QueryBehavior = objectEditControl.SelectedObject as ReportQueryBehavior;
            }
            ResetAutoQuery();
        }

        private void ButtonClearQueryBehavior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var controller = Controller as ReportController;
            controller.QueryBehavior = null;
            ResetAutoQuery();
        }

        private void ButtonProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //ConfigForm.ShowConfigForm(Controller);
            var objectEditControl = new ObjectLayoutEditControl();
            objectEditControl.SelectedObject = Controller;
            WinFormPublic.ShowDialog(objectEditControl);
        }
        #endregion
    }
}
