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

namespace PAO.Report
{
    /// <summary>
    /// 报表视图
    /// 作者：PAO
    /// </summary>
    public partial class ReportView : ViewControl, IViewContainer
    {
        /// <summary>
        /// 数据格式
        /// </summary>
        private DataSet SchemaDataSet;
        /// <summary>
        /// 数据集
        /// </summary>
        private DataSet DataSet = new DataSet();

        public ReportView() {
            InitializeComponent();
            UIActionDispatcher = new UIActionDispatcher(this);
        }

        private List<IView> ViewList = new List<IView>();

        [Browsable(false)]
        public IEnumerable<IView> Views {
            get {
                return ViewList;
            }
        }

        public void Initialize(DataSet schemaDataSet) {
            SchemaDataSet = schemaDataSet;
        }

        protected override void OnClosing() {
            if(Views.IsNotNullOrEmpty()) {
                foreach(var view in Views) {
                    view.CloseView();
                }
            }
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

        public byte[] LayoutData {
            get {
                return LayoutControl.GetLayoutData();
            }

            set {
                LayoutControl.SetLayoutData(value);
            }
        }

        private void ButtonRecoverLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            LayoutControl.RestoreDefaultLayout();
        }

        private void LayoutControl_ItemAdded(object sender, EventArgs e) {
            if (sender is LayoutControlGroup) {
                var groupItem = sender as LayoutControlGroup;
                groupItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            } else if (sender is TabbedControlGroup) {
                var tabbedControlGroup = sender as TabbedControlGroup;
                tabbedControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            }
        }
    }
}
