namespace PAO.WinForm.Security
{
    partial class LoginControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginControl));
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.HyperlinkLabelControlRegisterUser = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.HyperlinkLabelControlForgetPassword = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.CheckEditRememberPassword = new DevExpress.XtraEditors.CheckEdit();
            this.TextEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.TextEditUser = new DevExpress.XtraEditors.TextEdit();
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItemUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItemPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItemRememberPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItemRegisterUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItemForgetPassword = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRememberPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemRememberPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemRegisterUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemForgetPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.HyperlinkLabelControlRegisterUser);
            this.LayoutControl.Controls.Add(this.HyperlinkLabelControlForgetPassword);
            this.LayoutControl.Controls.Add(this.CheckEditRememberPassword);
            this.LayoutControl.Controls.Add(this.TextEditPassword);
            this.LayoutControl.Controls.Add(this.TextEditUser);
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.Root = this.LayoutControlGroupRoot;
            this.LayoutControl.Size = new System.Drawing.Size(297, 91);
            this.LayoutControl.TabIndex = 0;
            this.LayoutControl.Text = "布局控件";
            // 
            // HyperlinkLabelControlRegisterUser
            // 
            this.HyperlinkLabelControlRegisterUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HyperlinkLabelControlRegisterUser.Location = new System.Drawing.Point(257, 60);
            this.HyperlinkLabelControlRegisterUser.Name = "HyperlinkLabelControlRegisterUser";
            this.HyperlinkLabelControlRegisterUser.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.HyperlinkLabelControlRegisterUser.Size = new System.Drawing.Size(28, 14);
            this.HyperlinkLabelControlRegisterUser.StyleController = this.LayoutControl;
            this.HyperlinkLabelControlRegisterUser.TabIndex = 8;
            this.HyperlinkLabelControlRegisterUser.Text = "注册";
            this.HyperlinkLabelControlRegisterUser.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.HyperlinkLabelControlRegisterUser_HyperlinkClick);
            // 
            // HyperlinkLabelControlForgetPassword
            // 
            this.HyperlinkLabelControlForgetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HyperlinkLabelControlForgetPassword.Location = new System.Drawing.Point(205, 60);
            this.HyperlinkLabelControlForgetPassword.Name = "HyperlinkLabelControlForgetPassword";
            this.HyperlinkLabelControlForgetPassword.Size = new System.Drawing.Size(48, 14);
            this.HyperlinkLabelControlForgetPassword.StyleController = this.LayoutControl;
            this.HyperlinkLabelControlForgetPassword.TabIndex = 7;
            this.HyperlinkLabelControlForgetPassword.Text = "忘记密码";
            this.HyperlinkLabelControlForgetPassword.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.HyperlinkLabelControlForgetPassword_HyperlinkClick);
            // 
            // CheckEditRememberPassword
            // 
            this.CheckEditRememberPassword.Location = new System.Drawing.Point(12, 60);
            this.CheckEditRememberPassword.Name = "CheckEditRememberPassword";
            this.CheckEditRememberPassword.Properties.Caption = "记住密码";
            this.CheckEditRememberPassword.Size = new System.Drawing.Size(189, 19);
            this.CheckEditRememberPassword.StyleController = this.LayoutControl;
            this.CheckEditRememberPassword.TabIndex = 6;
            // 
            // TextEditPassword
            // 
            this.TextEditPassword.Location = new System.Drawing.Point(51, 36);
            this.TextEditPassword.Name = "TextEditPassword";
            this.TextEditPassword.Properties.PasswordChar = '*';
            this.TextEditPassword.Size = new System.Drawing.Size(234, 20);
            this.TextEditPassword.StyleController = this.LayoutControl;
            this.TextEditPassword.TabIndex = 5;
            // 
            // TextEditUser
            // 
            this.TextEditUser.Location = new System.Drawing.Point(51, 12);
            this.TextEditUser.Name = "TextEditUser";
            this.TextEditUser.Properties.NullValuePrompt = "输入用户名/邮箱地址/手机号登录";
            this.TextEditUser.Properties.NullValuePromptShowForEmptyValue = true;
            this.TextEditUser.Size = new System.Drawing.Size(234, 20);
            this.TextEditUser.StyleController = this.LayoutControl;
            this.TextEditUser.TabIndex = 4;
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.CustomizationFormText = "根";
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemUser,
            this.LayoutControlItemPassword,
            this.LayoutControlItemRememberPassword,
            this.LayoutControlItemRegisterUser,
            this.LayoutControlItemForgetPassword});
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "LayoutControlGroupRoot";
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(297, 91);
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // LayoutControlItemUser
            // 
            this.LayoutControlItemUser.Control = this.TextEditUser;
            this.LayoutControlItemUser.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemUser.Name = "LayoutControlItemUser";
            this.LayoutControlItemUser.Size = new System.Drawing.Size(277, 24);
            this.LayoutControlItemUser.Text = "用户：";
            this.LayoutControlItemUser.TextSize = new System.Drawing.Size(36, 14);
            // 
            // LayoutControlItemPassword
            // 
            this.LayoutControlItemPassword.Control = this.TextEditPassword;
            this.LayoutControlItemPassword.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlItemPassword.Name = "LayoutControlItemPassword";
            this.LayoutControlItemPassword.Size = new System.Drawing.Size(277, 24);
            this.LayoutControlItemPassword.Text = "密码：";
            this.LayoutControlItemPassword.TextSize = new System.Drawing.Size(36, 14);
            // 
            // LayoutControlItemRememberPassword
            // 
            this.LayoutControlItemRememberPassword.Control = this.CheckEditRememberPassword;
            this.LayoutControlItemRememberPassword.Location = new System.Drawing.Point(0, 48);
            this.LayoutControlItemRememberPassword.Name = "LayoutControlItemRememberPassword";
            this.LayoutControlItemRememberPassword.Size = new System.Drawing.Size(193, 23);
            this.LayoutControlItemRememberPassword.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemRememberPassword.TextVisible = false;
            // 
            // LayoutControlItemRegisterUser
            // 
            this.LayoutControlItemRegisterUser.Control = this.HyperlinkLabelControlRegisterUser;
            this.LayoutControlItemRegisterUser.Location = new System.Drawing.Point(245, 48);
            this.LayoutControlItemRegisterUser.Name = "LayoutControlItemRegisterUser";
            this.LayoutControlItemRegisterUser.Size = new System.Drawing.Size(32, 23);
            this.LayoutControlItemRegisterUser.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemRegisterUser.TextVisible = false;
            // 
            // LayoutControlItemForgetPassword
            // 
            this.LayoutControlItemForgetPassword.Control = this.HyperlinkLabelControlForgetPassword;
            this.LayoutControlItemForgetPassword.Location = new System.Drawing.Point(193, 48);
            this.LayoutControlItemForgetPassword.Name = "LayoutControlItemForgetPassword";
            this.LayoutControlItemForgetPassword.Size = new System.Drawing.Size(52, 23);
            this.LayoutControlItemForgetPassword.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemForgetPassword.TextVisible = false;
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(297, 91);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRememberPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemRememberPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemRegisterUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemForgetPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private DevExpress.XtraEditors.HyperlinkLabelControl HyperlinkLabelControlRegisterUser;
        private DevExpress.XtraEditors.HyperlinkLabelControl HyperlinkLabelControlForgetPassword;
        private DevExpress.XtraEditors.CheckEdit CheckEditRememberPassword;
        private DevExpress.XtraEditors.TextEdit TextEditPassword;
        private DevExpress.XtraEditors.TextEdit TextEditUser;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemUser;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemPassword;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemRememberPassword;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemForgetPassword;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemRegisterUser;
    }
}
