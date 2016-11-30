namespace PAO.Config.Controls
{
    partial class ObjectEditControl
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
            this.PropertyDescriptionControl = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.PropertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // PropertyDescriptionControl
            // 
            this.PropertyDescriptionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyDescriptionControl.Location = new System.Drawing.Point(0, 0);
            this.PropertyDescriptionControl.Name = "PropertyDescriptionControl";
            this.PropertyDescriptionControl.PropertyGrid = this.PropertyGridControl;
            this.PropertyDescriptionControl.Size = new System.Drawing.Size(603, 100);
            this.PropertyDescriptionControl.TabIndex = 0;
            this.PropertyDescriptionControl.TabStop = false;
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.SplitContainerControl.Horizontal = false;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.Controls.Add(this.PropertyGridControl);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.Controls.Add(this.PropertyDescriptionControl);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(603, 421);
            this.SplitContainerControl.TabIndex = 1;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // PropertyGridControl
            // 
            this.PropertyGridControl.AutoGenerateRows = true;
            this.PropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGridControl.Location = new System.Drawing.Point(0, 0);
            this.PropertyGridControl.Name = "PropertyGridControl";
            this.PropertyGridControl.OptionsView.FixRowHeaderPanelWidth = true;
            this.PropertyGridControl.OptionsView.MinRowAutoHeight = 30;
            this.PropertyGridControl.RecordWidth = 120;
            this.PropertyGridControl.RowHeaderWidth = 80;
            this.PropertyGridControl.Size = new System.Drawing.Size(603, 316);
            this.PropertyGridControl.TabIndex = 0;
            // 
            // ObjectEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerControl);
            this.Name = "ObjectEditControl";
            this.Size = new System.Drawing.Size(603, 421);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl PropertyDescriptionControl;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraVerticalGrid.PropertyGridControl PropertyGridControl;
    }
}
