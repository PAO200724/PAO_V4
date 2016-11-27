using System;

namespace PAO.UI.WinForm
{
    partial class ExceptionControl
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
            this.components = new System.ComponentModel.Container();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.RootGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.BindingSourceException = new System.Windows.Forms.BindingSource(this.components);
            this.TextEditMessage = new DevExpress.XtraEditors.TextEdit();
            this.LayoutControlItemMessage = new DevExpress.XtraLayout.LayoutControlItem();
            this.TextEditTime = new DevExpress.XtraEditors.TextEdit();
            this.LayoutControlItemTime = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceException)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemTime)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.TextEditTime);
            this.LayoutControl.Controls.Add(this.TextEditMessage);
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.Root = this.RootGroup;
            this.LayoutControl.Size = new System.Drawing.Size(928, 807);
            this.LayoutControl.TabIndex = 0;
            this.LayoutControl.Text = "LayoutControl";
            // 
            // RootGroup
            // 
            this.RootGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootGroup.GroupBordersVisible = false;
            this.RootGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemMessage,
            this.LayoutControlItemTime});
            this.RootGroup.Location = new System.Drawing.Point(0, 0);
            this.RootGroup.Name = "RootGroup";
            this.RootGroup.Size = new System.Drawing.Size(928, 807);
            this.RootGroup.TextVisible = false;
            // 
            // BindingSourceException
            // 
            this.BindingSourceException.DataSource = typeof(System.Exception);
            // 
            // TextEditMessage
            // 
            this.TextEditMessage.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceException, "Message", true));
            this.TextEditMessage.Location = new System.Drawing.Point(51, 36);
            this.TextEditMessage.Name = "TextEditMessage";
            this.TextEditMessage.Size = new System.Drawing.Size(865, 20);
            this.TextEditMessage.StyleController = this.LayoutControl;
            this.TextEditMessage.TabIndex = 4;
            // 
            // LayoutControlItemMessage
            // 
            this.LayoutControlItemMessage.Control = this.TextEditMessage;
            this.LayoutControlItemMessage.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlItemMessage.Name = "LayoutControlItemMessage";
            this.LayoutControlItemMessage.Size = new System.Drawing.Size(908, 763);
            this.LayoutControlItemMessage.Text = "消息：";
            this.LayoutControlItemMessage.TextSize = new System.Drawing.Size(36, 14);
            // 
            // TextEditTime
            // 
            this.TextEditTime.Location = new System.Drawing.Point(51, 12);
            this.TextEditTime.Name = "TextEditTime";
            this.TextEditTime.Size = new System.Drawing.Size(865, 20);
            this.TextEditTime.StyleController = this.LayoutControl;
            this.TextEditTime.TabIndex = 5;
            // 
            // LayoutControlItemTime
            // 
            this.LayoutControlItemTime.Control = this.TextEditTime;
            this.LayoutControlItemTime.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemTime.Name = "LayoutControlItemTime";
            this.LayoutControlItemTime.Size = new System.Drawing.Size(908, 24);
            this.LayoutControlItemTime.Text = "时间：";
            this.LayoutControlItemTime.TextSize = new System.Drawing.Size(36, 14);
            // 
            // ExceptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl);
            this.Name = "ExceptionControl";
            this.Size = new System.Drawing.Size(928, 807);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceException)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup RootGroup;
        private System.Windows.Forms.BindingSource BindingSourceException;
        private DevExpress.XtraEditors.TextEdit TextEditMessage;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemMessage;
        private DevExpress.XtraEditors.TextEdit TextEditTime;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemTime;
    }
}
