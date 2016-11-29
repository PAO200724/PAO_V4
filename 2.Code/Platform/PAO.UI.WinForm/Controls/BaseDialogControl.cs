using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.UI.WinForm.Controls
{
    /// <summary>
    /// 基础对话框控件
    /// </summary>
    public partial class BaseDialogControl : DevExpress.XtraEditors.XtraUserControl, IDialogControl
    {
        public BaseDialogControl() {
            InitializeComponent();
            ShowApplyButton = true;
            ShowCancelButton = true;
        }

        public virtual bool ShowApplyButton { get; set; }

        public virtual bool ShowCancelButton { get; set; }

        public event EventHandler<ApplyButtonStateChangedEventArgs> ApplyButtonStateChanged;

        protected void FileApplyButtonStateChanged(bool enabled) {
            if (ApplyButtonStateChanged != null)
                ApplyButtonStateChanged(this, new ApplyButtonStateChangedEventArgs() { Enabled = enabled});
        }

        public virtual void OnApply() {
            
        }

        public virtual void OnClosing(ref bool cancel) {
        }

        public virtual void SetFormState(Form form) {
        }
    }
}
