using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraBars.Docking;
using PAO.UI.MVC;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;

namespace PAO.UI.WinForm.MDI
{
    /// <summary>
    /// MDI主窗体
    /// </summary>
    public partial class MDIMainForm : DevExpress.XtraEditors.XtraForm, IMainForm
    {
        public const string Message_Status_Ready = "就绪";
        /// <summary>
        /// 默认
        /// </summary>
        public static MDIMainForm Default;

        private UIActionDispatcher _UIActionDispatcher;
        public UIActionDispatcher UIActionDispatcher {
            get {
                return _UIActionDispatcher;
            }
        }

        public MDIMainForm() {
            Default = this;
            InitializeComponent();
            _UIActionDispatcher = new UIActionDispatcher(this);
            SetStatusText(Message_Status_Ready);
        }

        #region 事件
        private void ButtonExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Close();
        }
        #endregion

        protected override void OnClosing(CancelEventArgs e) {
            var mdiApplication = MDIApplication.Default.As<MDIApplication>();
            mdiApplication.LayoutData = this.DockManager.GetLayoutData();
            mdiApplication.SkinName = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            AddonPublic.FetchAddonExtendProperties(mdiApplication, "LayoutData", "SkinName");
            base.OnClosing(e);
        }

        protected override void OnLoad(EventArgs e) {
            var mdiApplication = MDIApplication.Default.As<MDIApplication>();
            // 显示当前用户
            var securityService = mdiApplication.SecurityService.Value;
            var userInfo = securityService.GetUserInfo();
            MenuCurrentUser.Caption = userInfo.UserName;

            AddonPublic.ApplyAddonExtendProperties(mdiApplication);

            // 加载布局数据
            this.DockManager.SetLayoutData(mdiApplication.LayoutData);

            if (MenuFunction.ItemLinks.Count <= 0)
                MenuFunction.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
                MenuFunction.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            base.OnLoad(e);
        }

        public void SetStatusText(string status) {
            this.StaticItemStatus.Caption = status;
        }

        public void Waiting(Action action, string message = "程序运行中...") {
            SetStatusText(message);
            UIPublic.ShowWaitingForm();
            this.EditItemWaitingBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.Refresh();
            action();
            this.EditItemWaitingBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            SetStatusText(Message_Status_Ready);
            UIPublic.CloseWaitingForm();
        }

        public void OpenView(IView view) {
            Waiting(() =>
            {
                if(view is IDockView) {
                    var dockPanel = this.DockManager.AddPanel(DockingStyle.Right);
                    dockPanel.ID = new Guid(view.ID);
                    dockPanel.Text = view.Caption;
                    dockPanel.Image = view.Icon;
                    var control = view as Control;
                    dockPanel.Controls[0].Controls.Add(control);
                    control.Dock = DockStyle.Fill;
                } else {
                    var docControl = view as Control;
                    var tabbedDoc = TabbedView.AddDocument(docControl);
                    tabbedDoc.Caption = view.Caption;
                    tabbedDoc.Image = view.Icon;
                }
            }, "正在打开文档");
        }

        public void AddMenuItem(IUIItem menuItem) {
            WinFormPublic.AddMenuToSubItem(this.MenuFunction, menuItem, this);
        }
    }
}