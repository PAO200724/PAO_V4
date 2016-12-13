namespace PAO.Report.Controls
{
    partial class ReportTableListControl
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
            this.ScrollableControl = new DevExpress.XtraEditors.XtraScrollableControl();
            this.FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ScrollableControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableControl
            // 
            this.ScrollableControl.Controls.Add(this.FlowLayoutPanel);
            this.ScrollableControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrollableControl.Location = new System.Drawing.Point(0, 0);
            this.ScrollableControl.Name = "ScrollableControl";
            this.ScrollableControl.Size = new System.Drawing.Size(150, 150);
            this.ScrollableControl.TabIndex = 0;
            // 
            // FlowLayoutPanel
            // 
            this.FlowLayoutPanel.AutoSize = true;
            this.FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel.Name = "FlowLayoutPanel";
            this.FlowLayoutPanel.Size = new System.Drawing.Size(150, 0);
            this.FlowLayoutPanel.TabIndex = 0;
            // 
            // ReportTableListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScrollableControl);
            this.Name = "ReportTableListControl";
            this.ScrollableControl.ResumeLayout(false);
            this.ScrollableControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl ScrollableControl;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel;
    }
}
