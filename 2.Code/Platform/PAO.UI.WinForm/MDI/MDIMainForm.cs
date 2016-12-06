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
    public partial class MDIMainForm : DevExpress.XtraEditors.XtraForm, IMainForm, IDocumentContainer, IDockViewContainer, IUIItemContainer
    {
        public const string Message_Status_Ready = "就绪";
        /// <summary>
        /// 默认
        /// </summary>
        public static MDIMainForm Default;

        public MDIMainForm() {
            Default = this;
            InitializeComponent();
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
            AddonPublic.FetchAddonExtendProperties(mdiApplication, "LayoutData");
            base.OnClosing(e);
        }

        protected override void OnLoad(EventArgs e) {
            var mdiApplication = MDIApplication.Default.As<MDIApplication>();
            AddonPublic.ApplyAddonExtendProperties(mdiApplication);
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

        public void OpenDocument(IDocument document) {
            Waiting(() =>
            {
                var docControl = document as Control;
                var tabbedDoc = TabbedView.AddDocument(docControl);
                tabbedDoc.Caption = document.Caption;
                tabbedDoc.Image = document.Icon;
            }, "正在打开文档");
        }

        public void OpenDockView(IDockView dockView) {
            Waiting(() =>
            {
                var dockPanel = this.DockManager.AddPanel(DockingStyle.Right);
                dockPanel.ID = new Guid(dockView.ID);
                dockPanel.Text = dockView.Caption;
                dockPanel.Image = dockView.Icon;
                var view = dockView as Control;
                dockPanel.Controls[0].Controls.Add(view);
                view.Dock = DockStyle.Fill;
            }, "正在打开视图");
        }

        public void OpenUIItem(IUIItem uiItem) {
            WinFormPublic.AddMenuToSubItem(this.MenuFunction, uiItem, this);
        }
    }
}