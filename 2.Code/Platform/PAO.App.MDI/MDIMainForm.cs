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
using PAO.MVC;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraScheduler;
using PAO.App;
using PAO.WinForm.Security;
using PAO.Security;
using DevExpress.XtraSplashScreen;
using PAO.Trans;
using PAO.IO;
using PAO.Event;
using PAO.WinForm;
using PAO.UI;

namespace PAO.App.MDI
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

        /// <summary>
        /// 服务器和客户端时间差
        /// </summary>
        private TimeSpan ServerTimeSpan;
        /// <summary>
        /// 最后一次获取服务器的时间的时间
        /// </summary>
        private DateTime LastServerTime = DateTime.MinValue;
        /// <summary>
        /// 最后一次时间服务异常
        /// </summary>
        private Exception LastServerTimeException = null;
        /// <summary>
        /// 默认布局数据
        /// </summary>
        private byte[] DefaultLayoutData;

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

            DefaultLayoutData = this.DockManager.GetLayoutData();
            AddonPublic.LoadAddonExtendProperties(_MDIApplication);

            // 加载布局数据
            this.DockManager.SetLayoutData(_MDIApplication.LayoutData);
        }

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
                    dockPanel.Options.ShowCloseButton = false;
                    dockPanel.Options.AllowDockAsTabbedDocument = false;
                    dockPanel.ClosingPanel += (sender, e) =>
                    {
                        if (DialogResult != DialogResult.OK)
                            e.Cancel = true;
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

        #region 事件
        private void ButtonExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Close();
        }

        private void ButtonRecoverLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (UIPublic.ShowYesNoDialog("您确定要清除当前的布局并恢复默认布局吗？") == DialogReturn.Yes) {
                this.DockManager.SetLayoutData(DefaultLayoutData);
            }
        }

        private void TabbedView_DocumentClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e) {
            var view = e.Document.Control as IView;
            if (view != null) {
                view.CloseView();
            }
        }

        private void TimerDateTime_Tick(object sender, EventArgs e) {
            var timeSyncInterval = Math.Max(_MDIApplication.TimeSyncInterval, 1);
            if ((DateTime.Now - LastServerTime).TotalMinutes >= timeSyncInterval) {
                LastServerTime = DateTime.Now;
                try {
                    if (_MDIApplication.DateTimeService != null) {
                        var dateTimeService = _MDIApplication.DateTimeService.Value;
                        var serverTime = dateTimeService.GetCurrentDateTime();
                        ServerTimeSpan = serverTime - DateTime.Now;
                    }
                    LastServerTimeException = null;
                }
                catch (Exception err) {
                    LastServerTimeException = err;
                    EventPublic.Error(LastServerTimeException.FormatException());
                }
            }

            if (LastServerTimeException == null) {
                var calcServerTime = DateTime.Now + ServerTimeSpan;
                string dateTimeString = calcServerTime.ToString("服务器时间：yyyy-MM-dd HH:mm:ss");
                this.StaticItemServerTime.Caption = dateTimeString;
            }
            else {
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
            if (UIPublic.ShowSaveFileDialog("保存配置", ref fileName,
                FileExtentions.CONFIG,
                FileExtentions.XML,
                FileExtentions.All) == DialogReturn.OK) {
                IOPublic.WriteObjectToFile(fileName, PaoApplication.Default);
            }
        }

        private void DocumentManager_DocumentActivate(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e) {
            WinFormPublic.ShowInPropertyView(null);
        }
        #endregion

    }
}