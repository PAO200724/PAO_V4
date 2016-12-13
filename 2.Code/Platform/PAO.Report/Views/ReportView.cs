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
        /// 数据集
        /// </summary>
        internal DataSet DataSchema = new DataSet();
        /// <summary>
        /// 视图列表
        /// </summary>
        private List<IView> ViewList = new List<IView>();

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
            var controller = Controller as ReportController;
            if(controller.Tables.IsNotNullOrEmpty()) {
                foreach(var reportTable in controller.Tables) {
                    // 从DataFetcher获取格式
                    if(reportTable.DataFetcher != null) {
                        var dataFetcher = reportTable.DataFetcher.Value;
                        var tableSchema = dataFetcher.GetDataSchema();

                        // 重建ReportTable中的数据列
                        var reportColumns = ReportPublic.GetReportDataColumns(tableSchema);
                        if(reportTable.DataColumns == null) {
                            reportTable.DataColumns = new List<ReportDataColumn>();
                        }
                        ReportPublic.RebuildReportColumn(reportTable.DataColumns, reportColumns);

                        tableSchema.TableName = reportTable.TableName;

                        DataSchema.Merge(DataSchema);
                        DataSource.Merge(tableSchema);
                    }
                }
            }
        }

        #region 接口IViewContainer
        public void OpenView(IView view) {
            // 避免重复添加视图
            if (ViewList.Contains(view)) {
                return;
            }

            ViewList.Add(view);

            if(view is IDataView) {
                var dataView = view as IDataView;
                dataView.SetDataSource(DataSource);
            }

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
            foreach(var childControllerRef in controller.Controllers) {
                var childController = childControllerRef.Value;
                childController.CreateAndOpenView(this);
            }
            this.BindingSourceTable.DataSource = controller.Tables;

            AddonPublic.ApplyAddonExtendProperties(controller);
            this.LayoutControl.SetLayoutData(controller.LayoutData);
            this.DockManager.SetLayoutData(controller.DockPanelLayoutData);
        }

        protected override void OnClosing() {
            if (ViewList.IsNotNullOrEmpty()) {
                foreach (var view in ViewList) {
                    view.CloseView();
                }
            }
            var controller = Controller as ReportController;
            controller.LayoutData = this.LayoutControl.GetLayoutData();
            controller.DockPanelLayoutData = this.DockManager.GetLayoutData();
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

        private void ButtonQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }
        #endregion
    }
}
