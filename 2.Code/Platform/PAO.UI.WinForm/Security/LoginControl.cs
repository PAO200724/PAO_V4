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
using PAO.Security;

namespace PAO.UI.WinForm.Security
{
    /// <summary>
    /// 用户登录控件
    /// </summary>
    public partial class LoginControl : DialogControl {
        public LoginControl() {
            InitializeComponent();
        }

        public ISecurity SecurtiyService { get; set; }

        public string User {
            set { this.TextEditUser.Text = value; }
        }
        
        public int MaxUserLength {
            set {
                this.TextEditUser.Properties.MaxLength = value;
            }
        }

        public int MaxPasswordLength {
            set {
                this.TextEditUser.Properties.MaxLength = value;
            }
        }

        public override void OnClosing(DialogResult dialogResult, ref bool cancel) {
            if (dialogResult == DialogResult.OK) {
                try {
                    string hashPassword = null;
                    if (SecurtiyService == null)
                        throw new Exception("安全服务还未初始化");
                    if (TextEditPassword.Text.IsNotNullOrEmpty())
                        hashPassword = SecurityPublic.ComputeHashString(TextEditPassword.Text);
                    var userID = SecurtiyService.Login(TextEditUser.Text, hashPassword);
                    SecurityPublic.ApplicationUser = new UserToken()
                    {
                        UserID = userID,
                    };
                } catch {
                    UIPublic.ShowWarningDialog("登录失败");
                    cancel = true;
                }
            }
            base.OnClosing(dialogResult, ref cancel);
        }

        private void HyperlinkLabelControlRegisterUser_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e) {

        }

        private void HyperlinkLabelControlForgetPassword_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e) {

        }

        public override void SetFormState(Form form) {
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            base.SetFormState(form);
        }
    }
}
