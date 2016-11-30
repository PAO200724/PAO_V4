namespace PAO.Config.Controls
{
    partial class AddonConfigControl
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
            this.SplitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.TressListProperty = new DevExpress.XtraTreeList.TreeList();
            this.PropertyConfigControl = new PAO.Config.Controls.PropertyConfigControl();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TressListProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.SplitContainer.Panel1.Controls.Add(this.TressListProperty);
            this.SplitContainer.Panel1.ShowCaption = true;
            this.SplitContainer.Panel1.Text = "属性";
            this.SplitContainer.Panel2.Controls.Add(this.PropertyConfigControl);
            this.SplitContainer.Panel2.Text = "Panel2";
            this.SplitContainer.Size = new System.Drawing.Size(835, 526);
            this.SplitContainer.SplitterPosition = 256;
            this.SplitContainer.TabIndex = 0;
            this.SplitContainer.Text = "分割容器";
            // 
            // TressListProperty
            // 
            this.TressListProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TressListProperty.Location = new System.Drawing.Point(0, 0);
            this.TressListProperty.Name = "TressListProperty";
            this.TressListProperty.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TressListProperty.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TressListProperty.Size = new System.Drawing.Size(252, 503);
            this.TressListProperty.TabIndex = 1;
            // 
            // PropertyConfigControl
            // 
            this.PropertyConfigControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyConfigControl.Location = new System.Drawing.Point(0, 0);
            this.PropertyConfigControl.Name = "PropertyConfigControl";
            this.PropertyConfigControl.Object = null;
            this.PropertyConfigControl.Property = null;
            this.PropertyConfigControl.PropertyValue = null;
            this.PropertyConfigControl.Size = new System.Drawing.Size(574, 526);
            this.PropertyConfigControl.TabIndex = 0;
            // 
            // AddonConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainer);
            this.Name = "AddonConfigControl";
            this.Size = new System.Drawing.Size(835, 526);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TressListProperty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl SplitContainer;
        private DevExpress.XtraTreeList.TreeList TressListProperty;
        private PropertyConfigControl PropertyConfigControl;
    }
}
