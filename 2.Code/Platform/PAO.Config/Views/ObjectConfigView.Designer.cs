namespace PAO.Config.Views
{
    partial class ObjectConfigView
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
            this.ObjectTreeEditControl = new PAO.Config.Editor.ObjectTreeEditControl();
            this.SuspendLayout();
            // 
            // ObjectTreeEditControl
            // 
            this.ObjectTreeEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectTreeEditControl.EditMode = true;
            this.ObjectTreeEditControl.Location = new System.Drawing.Point(0, 0);
            this.ObjectTreeEditControl.Name = "ObjectTreeEditControl";
            this.ObjectTreeEditControl.ShowApplyButton = false;
            this.ObjectTreeEditControl.ShowCancelButton = true;
            this.ObjectTreeEditControl.Size = new System.Drawing.Size(417, 448);
            this.ObjectTreeEditControl.TabIndex = 0;
            // 
            // ObjectConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ObjectTreeEditControl);
            this.Name = "ObjectConfigView";
            this.Size = new System.Drawing.Size(417, 448);
            this.ResumeLayout(false);

        }

        #endregion

        private Editor.ObjectTreeEditControl ObjectTreeEditControl;
    }
}
