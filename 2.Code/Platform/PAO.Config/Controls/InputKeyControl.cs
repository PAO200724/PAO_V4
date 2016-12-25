using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Controls;
using PAO.UI;

namespace PAO.Config.Controls
{
    /// <summary>
    /// 输入键的控件
    /// </summary>
    public partial class InputKeyControl : DialogControl
    {
        public InputKeyControl() {
            InitializeComponent();
            ShowCancelButton = true;
            ShowApplyButton = false;
            Text = "键值输入";
        }

        public override void SetFormState(Form form) {
            form.WindowState = FormWindowState.Normal;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected override bool OnClosing(DialogReturn dialogResult) {
            if (dialogResult == DialogReturn.OK && KeyValue.IsNullOrEmpty()) {
                UIPublic.ShowWarningDialog("键值不能为空");
                return true;
            }
            return false;
        }

        public string KeyValue {
            get {
                return TextEditKey.Text;
            }

            set {
                TextEditKey.Text = value;
            }
        }
    }
}
