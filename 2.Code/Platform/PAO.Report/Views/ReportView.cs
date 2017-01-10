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
using PAO.WinForm.Controls;
using PAO.MVC;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using PAO.Data;
using PAO.WinForm;
using PAO.UI;
using DevExpress.XtraVerticalGrid.Rows;
using PAO.Config.Editor;
using DevExpress.XtraEditors.Repository;
using PAO.Report.Controls;
using DevExpress.XtraBars.Navigation;
using PAO.IO;
using PAO.Config;
using PAO.Config.DockViews;
using PAO.Report.Properties;
using System.Collections.Concurrent;

namespace PAO.Report.Views
{
    /// <summary>
    /// 报表视图
    /// 作者：PAO
    /// </summary>
    [Icon(typeof(Resources), "report")]
    public partial class ReportView : ViewControl, IViewContainer, IView
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
        private Dictionary<string, ReportTableView> TableControls = new Dictionary<string, ReportTableView>();

        /// <summary>
        /// 背景工作
        /// </summary>
        private List<BackgroundWorker> BackgroundWorkers = new List<BackgroundWorker>();
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
        /// 查询所有表格
        /// </summary>
        private void RequeryAllTable() {
            foreach (var tableControl in TableControls.Values) {
                tableControl.RequeryTable(false);
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
                    var dataSchema = reportTable.GetSchemaTable();
                    DataSource.Merge(dataSchema, true, MissingSchemaAction.AddWithKey);
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
            TableControls = new Dictionary<string, ReportTableView>();
            this.AccordionControl.Elements.Clear();
            RecreateTableView(this.AccordionControl.Elements, null, controller.Tables);
            this.AccordionControl.Refresh();
        }


        /// <summary>
        /// 重建参数视图
        /// </summary>
        private void RecreateTableView(AccordionControlElementCollection elements
            , ReportTableView parentTableView
            , IEnumerable<ReportTableController> tables) {
            if(parentTableView != null) {
                parentTableView.ChildTableViews = new List<Views.ReportTableView>();
            }
            foreach (var reportDataTable in tables) {
                ExtendAddonPublic.GetAddonExtendProperties(reportDataTable);

                var elementTableView = new AccordionControlElement();
                elementTableView.Name = reportDataTable.ID;
                elementTableView.Style = ElementStyle.Group;
                elementTableView.Expanded = true;
                elementTableView.Text = String.Format("{0}({1})", reportDataTable.Caption, reportDataTable.TableName);
                elements.Add(elementTableView);
                

                var reportTableView = reportDataTable.CreateView() as ReportTableView;
                reportTableView.Dock = DockStyle.Top;
                reportTableView.AutoSize = true;
                reportTableView.RowCount = 0;
                reportTableView.BorderStyle = BorderStyle.FixedSingle;
                reportTableView.DataFetched += ReportTableView_DataFetched;
                reportTableView.DataRequery += ReportTableView_DataRequery;

                var elementParameterView = new AccordionControlElement();
                elementParameterView.Name = reportDataTable.ID;
                elementParameterView.Style = ElementStyle.Item;
                elementParameterView.Expanded = true;
                elementParameterView.Text = "查询";
                var container = new AccordionContentContainer();
                container.Controls.Add(reportTableView);
                container.Height = reportTableView.Height;
                elementParameterView.ContentContainer = container;
                reportTableView.SizeChanged += (sender, e) => {
                    container.Height = reportTableView.Height;
                };
                TableControls.Add(reportDataTable.TableName, reportTableView);
                elementTableView.Elements.Add(elementParameterView);
                if(parentTableView != null) {
                    parentTableView.ChildTableViews.Add(reportTableView);
                }

                if (reportDataTable.ChildTables.IsNotNullOrEmpty()) {
                    RecreateTableView(elementTableView.Elements, reportTableView, reportDataTable.ChildTables);
                }
            }
        }

        /// <summary>
        /// 重置自动查询
        /// </summary>
        private void ResetAutoQuery() {
            var controller = Controller as ReportController;
            foreach (var tableControl in TableControls.Values) {
                tableControl.ResetAutoQuery(controller.QueryBehavior);
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
                    if(this.BarExtend.VisibleLinks.Count > 1) {
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

            // 打开子视图控制器
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
            ExtendAddonPublic.GetAddonExtendProperties(controller);
            this.LayoutControl.SetLayoutData(controller.LayoutData);
        }

        protected override void OnClose() {
            // 杀掉背景线程
            while (BackgroundWorkers.Count > 0) {
                var backgroundWorker = BackgroundWorkers[0];
                BackgroundWorkers.RemoveAt(0);
                backgroundWorker.CancelAsync();
            }
            var controller = Controller as ReportController;
            // 保存报表和数据的客户端设置
            controller.LayoutData = this.LayoutControl.GetLayoutData();
            ExtendAddonPublic.SetAddonExtendProperties(controller, "LayoutData", "QueryBehavior");
            base.OnClose();
        }
        #endregion

        #region 事件
        

        private void ReportTableView_DataFetched(object sender, DataFetchedEventArgs e) {
            SetDataSource();
        }

        private void ReportTableView_DataRequery(object sender, EventArgs e) {
            var tableView = sender as ReportTableView;
            var dataTable = tableView.DataTable;
            if (DataSource.Tables.Contains(dataTable.TableName)) {
                DataSource.Tables.Remove(dataTable.TableName);
            }
            DataSource.Tables.Add(dataTable);
        }

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
                
        private void ButtonQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            RequeryAllTable();
        }
        
        private void ButtonProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var objectEditControl = new ObjectLayoutEditController().CreateEditControl(Controller.GetType()) as BaseObjectEditControl;
            objectEditControl.EditValue = Controller;
            WinFormPublic.ShowDialog(objectEditControl);
        }

        private void ButtonSetupQueryBehavior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var controller = Controller as ReportController;
            if (EditorPublic.ShowEditPropertyDialog(controller, "QueryBehavior") == DialogReturn.OK) {
                ResetAutoQuery();
            }
        }
        #endregion
    }
}
