namespace PAO.Config
{
    partial class ConfigForm
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
            this.ObjectEditControl = new PAO.Config.Controls.EditControls.ObjectEditControl();
            this.SuspendLayout();
            // 
            // ObjectEditControl
            // 
            this.ObjectEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectEditControl.Enabled = false;
            this.ObjectEditControl.Location = new System.Drawing.Point(0, 0);
            this.ObjectEditControl.Name = "ObjectEditControl";
            this.ObjectEditControl.ShowApplyButton = false;
            this.ObjectEditControl.ShowCancelButton = true;
            this.ObjectEditControl.Size = new System.Drawing.Size(326, 587);
            this.ObjectEditControl.TabIndex = 0;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 587);
            this.Controls.Add(this.ObjectEditControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.Text = "配置";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.EditControls.ObjectEditControl ObjectEditControl;
    }
}
