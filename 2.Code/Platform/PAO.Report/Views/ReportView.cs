﻿using System;
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
        /// 重建参数视图
        /// </summary>
        private void RecreateTableView() {
            var controller = Controller as ReportController;
            this.ReportTableListControl.ReportDataTables = controller.Tables;
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
            InitValueFetcher();

            // 打开子视图控制器
            this.BindingSourceTable.DataSource = controller.Tables;
            foreach(var childControllerRef in controller.Controllers) {
                var childController = childControllerRef.Value;
                childController.CreateAndOpenView(this);
            }

            // 重建参数视图
            RecreateTableView();

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

        private void ButtonQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var controller = Controller as ReportController;
            foreach (var reportTable in controller.Tables) {

            }
        }
        #endregion
    }
}
