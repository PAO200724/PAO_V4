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
using PAO.UI.WinForm.MVC;
using DevExpress.XtraBars.Docking;

namespace PAO.UI.WinForm.MDI
{
    /// <summary>
    /// MDI主窗体
    /// </summary>
    public partial class MDIMainForm : DevExpress.XtraEditors.XtraForm, IMainForm
    {
        public const string Message_Status_Ready = "就绪";
        public static MDIMainForm Default;

        public MDIMainForm() {
            Default = this;
            InitializeComponent();
            SetStatusText(Message_Status_Ready);
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

        public void ShowView(Control view, string caption, Image icon) { 
            Waiting(() =>
            {
                var childForm = new ChildForm();
                childForm.Controls.Add(view);
                view.Dock = DockStyle.Fill;
                childForm.Text = caption;
                childForm.MdiParent = this;
                childForm.Show();
            }, "正在打开视图");
        }

        public void ShowDockPanel(Guid id, Control view, DockingStyle dockingStyle, string caption, Image icon) {
            Waiting(() =>
            {
                var dockPanel = this.DockManager.AddPanel(dockingStyle);
                dockPanel.ID = id;
                dockPanel.Text = caption;
                dockPanel.Image = icon;
                dockPanel.Controls[0].Controls.Add(view);
                view.Dock = DockStyle.Fill;
            }, "正在打开窗口");
        }
        /// <summary>
        /// 增加菜单项
        /// </summary>
        /// <param name="functionItem">功能菜单</param>
        public void AddMenuItem(Controller functionItem) {
            WinFormPublic.AddMenuToSubItem(this.MenuFunction, functionItem, this);
        }

        #region 事件
        private void ButtonExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Close();
        }
        #endregion
    }
}