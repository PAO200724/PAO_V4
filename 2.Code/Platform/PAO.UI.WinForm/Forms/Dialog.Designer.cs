namespace PAO.UI.WinForm.Forms
{
    partial class Dialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ButtonApply = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.PanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelClient = new System.Windows.Forms.Panel();
            this.PanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonApply
            // 
            this.ButtonApply.Image = global::PAO.UI.WinForm.Properties.Resources.drilldown_16x16;
            this.ButtonApply.Location = new System.Drawing.Point(483, 8);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(80, 35);
            this.ButtonApply.TabIndex = 3;
            this.ButtonApply.Text = "应用(&A)";
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Image = global::PAO.UI.WinForm.Properties.Resources.cancel_16x16;
            this.ButtonCancel.Location = new System.Drawing.Point(397, 8);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(80, 35);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "取消(&C)";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Image = global::PAO.UI.WinForm.Properties.Resources.apply_16x16;
            this.ButtonOK.Location = new System.Drawing.Point(311, 8);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(80, 35);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "确定(&O)";
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.ButtonApply);
            this.PanelButtons.Controls.Add(this.ButtonCancel);
            this.PanelButtons.Controls.Add(this.ButtonOK);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.PanelButtons.Location = new System.Drawing.Point(5, 544);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PanelButtons.Size = new System.Drawing.Size(566, 46);
            this.PanelButtons.TabIndex = 5;
            // 
            // PanelClient
            // 
            this.PanelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelClient.Location = new System.Drawing.Point(5, 5);
            this.PanelClient.Margin = new System.Windows.Forms.Padding(0);
            this.PanelClient.Name = "PanelClient";
            this.PanelClient.Size = new System.Drawing.Size(566, 539);
            this.PanelClient.TabIndex = 6;
            // 
            // Dialog
            // 
            this.AcceptButton = this.ButtonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(576, 595);
            this.Controls.Add(this.PanelClient);
            this.Controls.Add(this.PanelButtons);
            this.DoubleBuffered = true;
            this.Name = "Dialog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            this.PanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton ButtonOK;
        private DevExpress.XtraEditors.SimpleButton ButtonCancel;
        private DevExpress.XtraEditors.SimpleButton ButtonApply;
        private System.Windows.Forms.FlowLayoutPanel PanelButtons;
        private System.Windows.Forms.Panel PanelClient;
    }
}