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
        DataSet DataSet = new DataSet();
        /// <summary>
        /// 表定义
        /// </summary>
        List<ReportDataTable> Tables = new List<ReportDataTable>();
        /// <summary>
        /// 视图列表
        /// </summary>
        private List<IView> ViewList = new List<IView>();
        /// <summary>
        /// 视图
        /// </summary>
        [Browsable(false)]
        public IEnumerable<IView> Views {
            get {
                return ViewList;
            }
        }

        public ReportView() {
            InitializeComponent();
            UIActionDispatcher = new UIActionDispatcher(this);
            this.BindingSourceTable.DataSource = Tables;

            Tables.Add(new ReportDataTableInfo()
            {
                TableName = "User",
                Icon = Properties.Resources.chartyaxissettings_32x32
            });

            Tables.Add(new ReportDataTableInfo()
            {
                TableName = "Role",
                Icon = Properties.Resources.chartyaxissettings_32x32
            });
        }
                
        public void OpenView(IView view) {
            // 避免重复添加视图
            if (ViewList.Contains(view)) {
                return;
            }

            ViewList.Add(view);

            if(view is IDataView) {
                var dataView = view as IDataView;
                dataView.SetDataSource(DataSet);
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

        protected override void OnSetController(BaseController value) {
            var controller = value as ReportController;
            if (controller.Controllers.IsNotNullOrEmpty()) {
                foreach (var childController in controller.Controllers) {
                    var view = childController.Value.CreateAndOpenView(this);
                    view.UIActionDispatcher = UIActionDispatcher;
                }
            }
            AddonPublic.ApplyAddonExtendProperties(controller);
            this.LayoutControl.SetLayoutData(controller.LayoutData);
        }

        protected override void OnClosing() {
            if (Views.IsNotNullOrEmpty()) {
                foreach (var view in Views) {
                    view.CloseView();
                }
            }
            var controller = Controller as ReportController;
            controller.LayoutData = this.LayoutControl.GetLayoutData();
            AddonPublic.FetchAddonExtendProperties(controller, "LayoutData");
        }

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

        private void ButtonAddTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            
        }
        #endregion
    }
}
