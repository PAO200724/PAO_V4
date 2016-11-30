namespace PAO.Config.Controls
{
    partial class ObjectTreeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectTreeControl));
            this.TreeListObject = new DevExpress.XtraTreeList.TreeList();
            this.ColumnPropertyName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyDescriptor = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnObject = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnElementType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ImageCollectionTree = new DevExpress.Utils.ImageCollection();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeListObject
            // 
            this.TreeListObject.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColumnPropertyName,
            this.ColumnPropertyDescriptor,
            this.ColumnPropertyValue,
            this.ColumnObject,
            this.ColumnElementType});
            this.TreeListObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeListObject.Location = new System.Drawing.Point(0, 0);
            this.TreeListObject.Name = "TreeListObject";
            this.TreeListObject.OptionsBehavior.Editable = false;
            this.TreeListObject.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListObject.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListObject.OptionsView.ShowColumns = false;
            this.TreeListObject.OptionsView.ShowIndicator = false;
            this.TreeListObject.SelectImageList = this.ImageCollectionTree;
            this.TreeListObject.Size = new System.Drawing.Size(418, 571);
            this.TreeListObject.TabIndex = 0;
            // 
            // ColumnPropertyName
            // 
            this.ColumnPropertyName.Caption = "属性";
            this.ColumnPropertyName.FieldName = "PropertyName";
            this.ColumnPropertyName.MinWidth = 33;
            this.ColumnPropertyName.Name = "ColumnPropertyName";
            this.ColumnPropertyName.Visible = true;
            this.ColumnPropertyName.VisibleIndex = 0;
            // 
            // ColumnPropertyDescriptor
            // 
            this.ColumnPropertyDescriptor.Caption = "属性描述";
            this.ColumnPropertyDescriptor.FieldName = "PropertyDescriptor";
            this.ColumnPropertyDescriptor.Name = "ColumnPropertyDescriptor";
            // 
            // ColumnPropertyValue
            // 
            this.ColumnPropertyValue.Caption = "值";
            this.ColumnPropertyValue.FieldName = "Value";
            this.ColumnPropertyValue.Name = "ColumnPropertyValue";
            // 
            // ColumnObject
            // 
            this.ColumnObject.Caption = "对象";
            this.ColumnObject.FieldName = "Object";
            this.ColumnObject.Name = "ColumnObject";
            // 
            // ColumnElementType
            // 
            this.ColumnElementType.Caption = "元素类型";
            this.ColumnElementType.FieldName = "ElementType";
            this.ColumnElementType.Name = "ColumnElementType";
            // 
            // ImageCollectionTree
            // 
            this.ImageCollectionTree.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollectionTree.ImageStream")));
            this.ImageCollectionTree.InsertGalleryImage("forward_16x16.png", "images/navigation/forward_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/forward_16x16.png"), 0);
            this.ImageCollectionTree.Images.SetKeyName(0, "forward_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("product_16x16.png", "images/support/product_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/product_16x16.png"), 1);
            this.ImageCollectionTree.Images.SetKeyName(1, "product_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("group_16x16.png", "images/actions/group_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/group_16x16.png"), 2);
            this.ImageCollectionTree.Images.SetKeyName(2, "group_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("contentarrangeinrows_16x16.png", "images/alignment/contentarrangeinrows_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/alignment/contentarrangeinrows_16x16.png"), 3);
            this.ImageCollectionTree.Images.SetKeyName(3, "contentarrangeinrows_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("freezefirstcolumn_16x16.png", "images/spreadsheet/freezefirstcolumn_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/freezefirstcolumn_16x16.png"), 4);
            this.ImageCollectionTree.Images.SetKeyName(4, "freezefirstcolumn_16x16.png");
            // 
            // ObjectTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreeListObject);
            this.Name = "ObjectTreeControl";
            this.Size = new System.Drawing.Size(418, 571);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList TreeListObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyDescriptor;
        private DevExpress.Utils.ImageCollection ImageCollectionTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyValue;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnElementType;
    }
}
