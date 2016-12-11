namespace PAO.UI.WinForm.MDI.Inputs
{
    partial class ParameterInputView
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
            this.VGridControl = new DevExpress.XtraVerticalGrid.VGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.VGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // VGridControl
            // 
            this.VGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VGridControl.Location = new System.Drawing.Point(0, 0);
            this.VGridControl.Name = "VGridControl";
            this.VGridControl.Size = new System.Drawing.Size(258, 485);
            this.VGridControl.TabIndex = 0;
            // 
            // ParameterInputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VGridControl);
            this.Name = "ParameterInputView";
            this.Size = new System.Drawing.Size(258, 485);
            ((System.ComponentModel.ISupportInitialize)(this.VGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl VGridControl;
    }
}
