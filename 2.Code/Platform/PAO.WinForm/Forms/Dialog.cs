using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Controls;
using PAO.MVC;

namespace PAO.WinForm.Forms
{
    /// <summary>
    /// 对话框
    /// 作者：PAO
    /// </summary>
    public partial class Dialog : DevExpress.XtraEditors.XtraForm
    {
        public Dialog() {
            InitializeComponent();
            _UIActionDispatcher = new UIActionDispatcher(this);
        }

        public bool ShowCancelButton {
            get {
                return ButtonCancel.Visible;
            }

            set {
                ButtonCancel.Visible = value;
            }
        }

        public bool ShowApplyButton {
            get {
                return ButtonApply.Visible;
            }

            set {
                ButtonApply.Visible = value;
            }
        }

        private UIActionDispatcher _UIActionDispatcher;
        public UIActionDispatcher UIActionDispatcher {
            get {
                return _UIActionDispatcher;
            }
        }

        private Control ChildControl;

        private void DialogControl_DataModifyStateChanged(object sender, DataModifyStateChangedEventArgs e) {
            ButtonApply.Enabled = e.DataModified;
        }
        
        private void ButtonApply_Click(object sender, EventArgs e) {
            if (ChildControl is DialogControl) {
                var dialogControl = ChildControl as DialogControl;
                dialogControl.Apply();
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            var dialogControl = ChildControl as DialogControl;
            try {
                dialogControl.CloseControl();
            }
            catch (Exception err) {
                e.Cancel = true;
                throw err;
            }
            base.OnClosing(e);
        }

        public void OpenControl(DialogControl dialogControl) {
            ShowCancelButton = dialogControl.ShowCancelButton;
            ShowApplyButton = dialogControl.ShowApplyButton;
            dialogControl.DataModifyStateChanged += DialogControl_DataModifyStateChanged;
            dialogControl.SetFormState(this);

            PanelClient.SuspendLayout();
            PanelClient.Controls.Clear();
            ChildControl = dialogControl;
            if (ChildControl != null) {
                this.Width += ChildControl.Width - PanelClient.ClientRectangle.Width;
                this.Height += ChildControl.Height - PanelClient.ClientRectangle.Height;
                PanelClient.Controls.Add(dialogControl);
                Text = ChildControl.Text;
                ChildControl.Dock = DockStyle.Fill;
            }
            PanelClient.ResumeLayout();
        }
        
    }
}