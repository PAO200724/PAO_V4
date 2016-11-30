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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeSelectControl));
            this.TressListType = new DevExpress.XtraTreeList.TreeList();
            this.ColumnTypeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnTypeDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnNamespace = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.BindingSourceTypes = new System.Windows.Forms.BindingSource();
            this.ImageCollection = new DevExpress.Utils.ImageCollection();
            ((System.ComponentModel.ISupportInitialize)(this.TressListType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // TressListType
            // 
            this.TressListType.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColumnTypeName,
            this.ColumnTypeDisplayName,
            this.ColumnNamespace});
            this.TressListType.DataSource = this.BindingSourceTypes;
            this.TressListType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TressListType.KeyFieldName = "TypeName";
            this.TressListType.Location = new System.Drawing.Point(0, 0);
            this.TressListType.Name = "TressListType";
            this.TressListType.OptionsBehavior.EnableFiltering = true;
            this.TressListType.OptionsBehavior.ReadOnly = true;
            this.TressListType.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TressListType.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TressListType.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.TressListType.OptionsFind.AllowFindPanel = true;
            this.TressListType.OptionsFind.AlwaysVisible = true;
            this.TressListType.OptionsFind.FindNullPrompt = "输入文字查找...";
            this.TressListType.OptionsView.ShowAutoFilterRow = true;
            this.TressListType.OptionsView.ShowIndicator = false;
            this.TressListType.ParentFieldName = "ParentTypeName";
            this.TressListType.SelectImageList = this.ImageCollection;
            this.TressListType.Size = new System.Drawing.Size(837, 622);
            this.TressListType.TabIndex = 2;
            // 
            // ColumnTypeName
            // 
            this.ColumnTypeName.Caption = "类型";
            this.ColumnTypeName.FieldName = "TypeName";
            this.ColumnTypeName.Name = "ColumnTypeName";
            this.ColumnTypeName.Visible = true;
            this.ColumnTypeName.VisibleIndex = 2;
            this.ColumnTypeName.Width = 268;
            // 
            // ColumnTypeDisplayName
            // 
            this.ColumnTypeDisplayName.Caption = "名称";
            this.ColumnTypeDisplayName.FieldName = "DisplayName";
            this.ColumnTypeDisplayName.MinWidth = 33;
            this.ColumnTypeDisplayName.Name = "ColumnTypeDisplayName";
            this.ColumnTypeDisplayName.Visible = true;
            this.ColumnTypeDisplayName.VisibleIndex = 0;
            this.ColumnTypeDisplayName.Width = 378;
            // 
            // ColumnNamespace
            // 
            this.ColumnNamespace.Caption = "名字空间";
            this.ColumnNamespace.FieldName = "Namespace";
            this.ColumnNamespace.Name = "ColumnNamespace";
            this.ColumnNamespace.Visible = true;
            this.ColumnNamespace.VisibleIndex = 1;
            this.ColumnNamespace.Width = 189;
            // 
            // ImageCollection
            // 
            this.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection.ImageStream")));
            this.ImageCollection.Images.SetKeyName(0, "arrow_right.png");
            this.ImageCollection.Images.SetKeyName(1, "link.png");
            this.ImageCollection.InsertGalleryImage("greenwhite_16x16.png", "images/scales/greenwhite_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scales/greenwhite_16x16.png"), 2);
            this.ImageCollection.Images.SetKeyName(2, "greenwhite_16x16.png");
            this.ImageCollection.InsertGalleryImage("lineitem_16x16.png", "images/toolbox%20items/lineitem_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/toolbox%20items/lineitem_16x16.png"), 3);
            this.ImageCollection.Images.SetKeyName(3, "lineitem_16x16.png");
            this.ImageCollection.InsertGalleryImage("redwhite_16x16.png", "images/scales/redwhite_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scales/redwhite_16x16.png"), 4);
            this.ImageCollection.Images.SetKeyName(4, "redwhite_16x16.png");
            // 
            // TypeSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TressListType);
            this.Name = "TypeSelectControl";
            this.Size = new System.Drawing.Size(837, 622);
            ((System.ComponentModel.ISupportInitialize)(this.TressListType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTreeList.TreeList TressListType;
        private DevExpress.Utils.ImageCollection ImageCollection;
        private System.Windows.Forms.BindingSource BindingSourceTypes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnTypeDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnTypeName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnNamespace;
    }
}
