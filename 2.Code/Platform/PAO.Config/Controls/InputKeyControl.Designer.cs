namespace PAO.Config.Controls
{
    partial class InputKeyControl
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
            this.LabelControlInput = new DevExpress.XtraEditors.LabelControl();
            this.TextEditKey = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditKey.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelControlInput
            // 
            this.LabelControlInput.Location = new System.Drawing.Point(3, 3);
            this.LabelControlInput.Name = "LabelControlInput";
            this.LabelControlInput.Size = new System.Drawing.Size(72, 14);
            this.LabelControlInput.TabIndex = 0;
            this.LabelControlInput.Text = "请输入键值：";
            // 
            // TextEditKey
            // 
            this.TextEditKey.Location = new System.Drawing.Point(3, 23);
            this.TextEditKey.Name = "TextEditKey";
            this.TextEditKey.Size = new System.Drawing.Size(325, 20);
            this.TextEditKey.TabIndex = 1;
            // 
            // InputKeyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextEditKey);
            this.Controls.Add(this.LabelControlInput);
            this.Name = "InputKeyControl";
            this.Size = new System.Drawing.Size(331, 46);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditKey.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl LabelControlInput;
        private DevExpress.XtraEditors.TextEdit TextEditKey;
    }
}
