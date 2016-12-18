namespace PAO.Config.DockViews
{
    partial class PropertyView
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
            this.ObjectEditControl = new PAO.Config.EditControls.ObjectEditControl();
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
            this.ObjectEditControl.Size = new System.Drawing.Size(536, 470);
            this.ObjectEditControl.TabIndex = 0;
            // 
            // PropertyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ObjectEditControl);
            this.Name = "PropertyView";
            this.ResumeLayout(false);

        }

        #endregion

        private EditControls.ObjectEditControl ObjectEditControl;
    }
}
