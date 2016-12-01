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
                if (value is DialogControl) {
                    var dialogControl = value as DialogControl;
                    ShowCancelButton = dialogControl.ShowCancelButton;
                    ShowApplyButton = dialogControl.ShowApplyButton;
                    dialogControl.DataModifyStateChanged += DialogControl_DataModifyStateChanged;
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

        private void DialogControl_DataModifyStateChanged(object sender, DataModifyStateChangedEventArgs e) {
            ButtonApply.Enabled = e.DataModified;
        }
        
        private void ButtonApply_Click(object sender, EventArgs e) {
            if (_ChildControl is DialogControl) {
                var dialogControl = _ChildControl as DialogControl;
                dialogControl.Apply();
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (_ChildControl is DialogControl) {
                var dialogControl = _ChildControl as DialogControl;
                bool cancel = e.Cancel;
                dialogControl.OnClosing(DialogResult, ref cancel);
                e.Cancel = cancel;
            }
            base.OnClosing(e);
        }
    }
}