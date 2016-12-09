using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
using PAO.UI.MVC;

namespace PAO.UI.WinForm.Forms
{
    public partial class Dialog : DevExpress.XtraEditors.XtraForm, IViewContainer
    {
        public Dialog() {
            InitializeComponent();
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

        private Control ChildControl;

        public event EventHandler<UIActionEventArgs> UIActing;

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
            if (ChildControl is DialogControl) {
                var dialogControl = ChildControl as DialogControl;
                bool cancel = e.Cancel;
                dialogControl.OnClosing(DialogResult, ref cancel);
                e.Cancel = cancel;
            }
            base.OnClosing(e);
        }

        public void OpenView(IView view) {
            if(view is DialogControl) {
                var dialogControl = view as DialogControl;
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
            } else {
                throw new Exception("Dialog只支持打开DialogControl");
            }
        }

        public void DoUIAction(object sender, string actionName, IEnumerable<object> actionParameters) {
            if (UIActing != null) {
                UIActing(sender, new UIActionEventArgs()
                {
                    ActionName = actionName,
                    ActionParameters = actionParameters
                });
            }
        }
    }
}