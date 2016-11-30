using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
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

        public override void OnClosing(DialogResult dialogResult, ref bool cancel) {
            if(dialogResult == DialogResult.OK && KeyValue.IsNullOrEmpty()) {
                UIPublic.ShowWarningDialog("键值不能为空");
                cancel = true;
   
            }
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
