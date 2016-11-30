namespace PAO.Config.Controls
{
    partial class TypeSelectControl
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
            this.LabelControlTypeName = new DevExpress.XtraEditors.LabelControl();
            this.TressListType = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.TressListType)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelControlTypeName
            // 
            this.LabelControlTypeName.AllowHtmlString = true;
            this.LabelControlTypeName.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControlTypeName.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.LabelControlTypeName.AutoEllipsis = true;
            this.LabelControlTypeName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlTypeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlTypeName.Location = new System.Drawing.Point(0, 0);
            this.LabelControlTypeName.Name = "LabelControlTypeName";
            this.LabelControlTypeName.Padding = new System.Windows.Forms.Padding(3);
            this.LabelControlTypeName.Size = new System.Drawing.Size(837, 35);
            this.LabelControlTypeName.TabIndex = 1;
            this.LabelControlTypeName.Text = "Ref<IDataService>";
            // 
            // TressListType
            // 
            this.TressListType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TressListType.Location = new System.Drawing.Point(0, 35);
            this.TressListType.Name = "TressListType";
            this.TressListType.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TressListType.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TressListType.Size = new System.Drawing.Size(837, 587);
            this.TressListType.TabIndex = 2;
            // 
            // TypeSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TressListType);
            this.Controls.Add(this.LabelControlTypeName);
            this.Name = "TypeSelectControl";
            this.Size = new System.Drawing.Size(837, 622);
            ((System.ComponentModel.ISupportInitialize)(this.TressListType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl LabelControlTypeName;
        private DevExpress.XtraTreeList.TreeList TressListType;
    }
}
