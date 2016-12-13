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
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraScheduler;
using PAO.App;
using PAO.UI.WinForm.Security;
using PAO.Security;
using DevExpress.XtraSplashScreen;
using PAO.Trans;
using PAO.IO;
using PAO.IO.Text;

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

        [Browsable(false)]
        public UIActionDispatcher UIActionDispatcher {
            get; private set;
        }

        public MDIMainForm() {
            Default = this;
            this.DialogResult = DialogResult.Cancel;
            InitializeComponent();

            UIActionDispatcher = new UIActionDispatcher(this);
            SetStatusText(Message_Status_Ready);
        }

        private MDIApplication _MDIApplication;
        public void Initialize(MDIApplication application) {
            _MDIApplication = application;

            Text = _MDIApplication.Caption;


            // 添加菜单项
            if (_MDIApplication.MenuItems.IsNotNullOrEmpty()) {
                foreach (var menuItem in _MDIApplication.MenuItems) {
                    _MDIApplication.MainForm.AddMenuItem(menuItem.Value);
                }
            }

            if (_MDIApplication.Controllers.IsNotNullOrEmpty()) {
                foreach (var controllerRef in _MDIApplication.Controllers) {
                    var controller = controllerRef.Value;
                    TransactionPublic.Run(String.Format("打开控制器:{0}", controller), () =>
                    {
                        controller.CreateAndOpenView(this);
                    });
                }
            }

            // 显示当前用户
            var securityService = _MDIApplication.SecurityService.Value;
            var userInfo = securityService.GetUserInfo();
            MenuCurrentUser.Caption = userInfo.UserName;

            if (MenuFunction.ItemLinks.Count <= 0)
                MenuFunction.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
                MenuFunction.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            AddonPublic.LoadAddonExtendProperties(_MDIApplication);

            // 加载布局数据
            this.DockManager.SetLayoutData(_MDIApplication.LayoutData);
        }

        #region 事件
        private void ButtonExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Close();
        }
        #endregion

        protected override void OnClosing(CancelEventArgs e) {
            this.DialogResult = DialogResult.OK;

            if(DockViews.IsNotNullOrEmpty()) {
                foreach(var dockView in DockViews) {
                    dockView.CloseView();
                }
            }

            foreach(Document doc in this.TabbedView.Documents) {
                var view = doc.Control as IView;
                if (view != null) {
                    view.CloseView();
                }
            }

            _MDIApplication.LayoutData = this.DockManager.GetLayoutData();
            _MDIApplication.SkinName = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            AddonPublic.SaveAddonExtendProperties(_MDIApplication, "LayoutData", "SkinName");
            base.OnClosing(e);
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

        List<IDockView> DockViews = new List<IDockView>();
        public void OpenView(IView view) {
            Waiting(() =>
            {
                if(view is IDockView) {
                    var dockPanel = this.DockManager.AddPanel(DockingStyle.Right);
                    dockPanel.ID = new Guid(view.ID);
                    dockPanel.Text = view.Caption;
                    dockPanel.Image = view.Icon;
                    dockPanel.Options.AllowFloating = false;
                    var headerButton = new CustomHeaderButton("...", ButtonStyle.PushButton);
                    dockPanel.Options.ShowCloseButton = false;
                    dockPanel.Options.AllowDockAsTabbedDocument = false;
                    dockPanel.Options.AllowFloating = false;
                    dockPanel.CustomHeaderButtons.Add(headerButton);
                    dockPanel.CustomButtonClick += (sender, e) =>
                    {

                    };
                    var control = view as Control;
                    dockPanel.Controls[0].Controls.Add(control);
                    control.Dock = DockStyle.Fill;

                    var dockView = view as IDockView;
                    if(!DockViews.Contains(dockView))
                        DockViews.Add(dockView);
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
        
        private void ButtonRecoverLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var panelList = this.DockManager.Panels.ToList();
            foreach (var dockPanel in panelList) {
                dockPanel.Controls[0].Controls.Clear();
                this.DockManager.RemovePanel(dockPanel);
            }

            foreach(var view in DockViews) {
                OpenView(view);
            }
        }

        private void TabbedView_DocumentClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e) {
            var view = e.Document.Control as IView;
            if(view != null) {
                view.CloseView();
            }
        }

        private void TimerDateTime_Tick(object sender, EventArgs e) {
            try {
                if (_MDIApplication.DateTimeService != null) {
                    var dateTimeService = _MDIApplication.DateTimeService.Value;
                    string dateTimeString = dateTimeService.GetCurrentDateTime().ToString("服务器时间：yyyy-MM-dd HH:mm:ss");
                    this.StaticItemServerTime.Caption = dateTimeString;
                }
            } catch {
                this.StaticItemServerTime.Caption = "服务器连接失败";
            }
        }

        private void ButtonLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.Hide();
            if (_MDIApplication.Login()) {
                this.Show();
            }
            else { 
                this.Close();
            }
        }

        private void ButtonSaveConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            string fileName = AppPublic.GetAbsolutePath(AppPublic.DefaultConfigFileName);
            if(UIPublic.ShowSaveFileDialog("保存配置", ref fileName, 
                FileExtentions.CONFIG,
                FileExtentions.XML,
                FileExtentions.All) == DialogReturn.OK) {
                TextPublic.WriteObjectToFile(fileName, PaoApplication.Default);
            }
        }
    }
}