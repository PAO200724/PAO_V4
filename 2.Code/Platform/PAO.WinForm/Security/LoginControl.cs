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
using PAO.Security;
using PAO.Event;
using PAO.UI;

namespace PAO.WinForm.Security
{
    /// <summary>
    /// 用户登录控件
    /// </summary>
    public partial class LoginControl : DialogControl {
        public LoginControl() {
            InitializeComponent();
            Text = "用户登录";
        }

        protected override void OnLoad(EventArgs e) {
            this.TextEditUser.Focus();
            base.OnLoad(e);
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
        
        private void HyperlinkLabelControlRegisterUser_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e) {

        }

        private void HyperlinkLabelControlForgetPassword_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e) {

        }

        public override void SetFormState(Form form) {
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.TopMost = true;
            form.ShowInTaskbar = true;
            form.FormClosing += (sender, e) =>
            {
                if (form.DialogResult == DialogResult.OK) {
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
                    }
                    catch (Exception err) {
                        UIPublic.ShowExceptionDialog(err);
                        e.Cancel = true;
                    }
                }
            };
            base.SetFormState(form);
        }
    }
}
