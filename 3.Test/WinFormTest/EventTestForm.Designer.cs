namespace WinFormTest
{
    partial class EventTestForm
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
            this.EventControl = new PAO.UI.WinForm.EventControl();
            this.SuspendLayout();
            // 
            // EventControl
            // 
            this.EventControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventControl.Location = new System.Drawing.Point(0, 0);
            this.EventControl.Name = "EventControl";
            this.EventControl.Size = new System.Drawing.Size(667, 494);
            this.EventControl.TabIndex = 0;
            // 
            // EventTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 494);
            this.Controls.Add(this.EventControl);
            this.Name = "EventTestForm";
            this.Text = "EventTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private PAO.UI.WinForm.EventControl EventControl;
    }
}