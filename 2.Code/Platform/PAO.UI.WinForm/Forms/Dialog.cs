using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.UI.WinForm.Forms
{
    public partial class Dialog : DevExpress.XtraEditors.XtraForm
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

        private Control _ChildControl;
        public Control ChildControl {
            get {
                return _ChildControl;
            }

            set {
                _ChildControl = value;
                if (value is IDialogControl) {
                    var dialogControl = value as IDialogControl;
                    ShowCancelButton = dialogControl.ShowCancelButton;
                    ShowApplyButton = dialogControl.ShowApplyButton;
                    dialogControl.ApplyButtonStateChanged += DialogControl_ApplyButtonStateChanged;
                    dialogControl.SetFormState(this);
                }

                PanelClient.SuspendLayout();
                PanelClient.Controls.Clear();
                if (_ChildControl != null) {
                    this.Width += _ChildControl.Width - PanelClient.ClientRectangle.Width;
                    this.Height += _ChildControl.Height - PanelClient.ClientRectangle.Height;
                    PanelClient.Controls.Add(value);
                    Text = _ChildControl.Text;
                    _ChildControl.Dock = DockStyle.Fill;
                }
                PanelClient.ResumeLayout();
            }
        }

        private void DialogControl_ApplyButtonStateChanged(object sender, ApplyButtonStateChangedEventArgs e) {
            ButtonApply.Enabled = e.Enabled;
        }

        private void ButtonApply_Click(object sender, EventArgs e) {
            if (_ChildControl is IDialogControl) {
                var dialogControl = _ChildControl as IDialogControl;
                dialogControl.OnApply();
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (_ChildControl is IDialogControl) {
                var dialogControl = _ChildControl as IDialogControl;
                bool cancel = e.Cancel;
                dialogControl.OnClosing(ref cancel);
                e.Cancel = cancel;
            }
            base.OnClosing(e);
        }
    }
}