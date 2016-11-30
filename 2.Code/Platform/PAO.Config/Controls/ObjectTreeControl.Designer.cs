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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectTreeControl));
            this.TreeListObject = new DevExpress.XtraTreeList.TreeList();
            this.ColumnPropertyName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyValueString = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyTypeString = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyDescriptor = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnObject = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyElementType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ImageCollectionTree = new DevExpress.Utils.ImageCollection(this.components);
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.LabelControlPropertyTitle = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPropertyType = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlObjectType = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlValue = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeListObject
            // 
            this.TreeListObject.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColumnPropertyName,
            this.ColumnPropertyValueString,
            this.ColumnPropertyTypeString,
            this.ColumnPropertyDescriptor,
            this.ColumnPropertyValue,
            this.ColumnObject,
            this.ColumnPropertyElementType});
            this.TreeListObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeListObject.Location = new System.Drawing.Point(0, 0);
            this.TreeListObject.Name = "TreeListObject";
            this.TreeListObject.OptionsBehavior.EnableFiltering = true;
            this.TreeListObject.OptionsBehavior.ReadOnly = true;
            this.TreeListObject.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListObject.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListObject.OptionsCustomization.AllowBandMoving = false;
            this.TreeListObject.OptionsCustomization.AllowBandResizing = false;
            this.TreeListObject.OptionsCustomization.AllowColumnMoving = false;
            this.TreeListObject.OptionsCustomization.AllowQuickHideColumns = false;
            this.TreeListObject.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.TreeListObject.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.TreeListObject.OptionsFind.AllowFindPanel = true;
            this.TreeListObject.OptionsFind.AlwaysVisible = true;
            this.TreeListObject.OptionsFind.FindNullPrompt = "输入文字查找...";
            this.TreeListObject.OptionsView.ShowAutoFilterRow = true;
            this.TreeListObject.OptionsView.ShowIndicator = false;
            this.TreeListObject.SelectImageList = this.ImageCollectionTree;
            this.TreeListObject.Size = new System.Drawing.Size(418, 425);
            this.TreeListObject.TabIndex = 0;
            this.TreeListObject.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeListObject_FocusedNodeChanged);
            // 
            // ColumnPropertyName
            // 
            this.ColumnPropertyName.Caption = "属性";
            this.ColumnPropertyName.FieldName = "PropertyName";
            this.ColumnPropertyName.MinWidth = 33;
            this.ColumnPropertyName.Name = "ColumnPropertyName";
            this.ColumnPropertyName.Visible = true;
            this.ColumnPropertyName.VisibleIndex = 0;
            this.ColumnPropertyName.Width = 193;
            // 
            // ColumnPropertyValueString
            // 
            this.ColumnPropertyValueString.Caption = "值";
            this.ColumnPropertyValueString.FieldName = "ObjectString";
            this.ColumnPropertyValueString.Name = "ColumnPropertyValueString";
            this.ColumnPropertyValueString.Visible = true;
            this.ColumnPropertyValueString.VisibleIndex = 2;
            this.ColumnPropertyValueString.Width = 114;
            // 
            // ColumnPropertyTypeString
            // 
            this.ColumnPropertyTypeString.Caption = "值类型";
            this.ColumnPropertyTypeString.FieldName = "TypeName";
            this.ColumnPropertyTypeString.Name = "ColumnPropertyTypeString";
            this.ColumnPropertyTypeString.Visible = true;
            this.ColumnPropertyTypeString.VisibleIndex = 1;
            this.ColumnPropertyTypeString.Width = 109;
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
            // ColumnPropertyElementType
            // 
            this.ColumnPropertyElementType.Caption = "元素类型";
            this.ColumnPropertyElementType.FieldName = "ElementType";
            this.ColumnPropertyElementType.Name = "ColumnPropertyElementType";
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
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.TreeListObject);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.LabelControlValue);
            this.SplitContainer.Panel2.Controls.Add(this.LabelControlObjectType);
            this.SplitContainer.Panel2.Controls.Add(this.LabelControlPropertyType);
            this.SplitContainer.Panel2.Controls.Add(this.LabelControlPropertyTitle);
            this.SplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.SplitContainer.Size = new System.Drawing.Size(418, 571);
            this.SplitContainer.SplitterDistance = 425;
            this.SplitContainer.TabIndex = 1;
            // 
            // LabelControlPropertyTitle
            // 
            this.LabelControlPropertyTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControlPropertyTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlPropertyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlPropertyTitle.Location = new System.Drawing.Point(5, 5);
            this.LabelControlPropertyTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyTitle.Name = "LabelControlPropertyTitle";
            this.LabelControlPropertyTitle.Padding = new System.Windows.Forms.Padding(5);
            this.LabelControlPropertyTitle.Size = new System.Drawing.Size(408, 36);
            this.LabelControlPropertyTitle.TabIndex = 0;
            this.LabelControlPropertyTitle.Text = "属性";
            // 
            // LabelControlPropertyType
            // 
            this.LabelControlPropertyType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlPropertyType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlPropertyType.Location = new System.Drawing.Point(5, 41);
            this.LabelControlPropertyType.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyType.Name = "LabelControlPropertyType";
            this.LabelControlPropertyType.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlPropertyType.Size = new System.Drawing.Size(408, 20);
            this.LabelControlPropertyType.TabIndex = 6;
            this.LabelControlPropertyType.Text = "属性类型";
            // 
            // LabelControlObjectType
            // 
            this.LabelControlObjectType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlObjectType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlObjectType.Location = new System.Drawing.Point(5, 61);
            this.LabelControlObjectType.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlObjectType.Name = "LabelControlObjectType";
            this.LabelControlObjectType.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlObjectType.Size = new System.Drawing.Size(408, 20);
            this.LabelControlObjectType.TabIndex = 7;
            this.LabelControlObjectType.Text = "值类型";
            // 
            // LabelControlValue
            // 
            this.LabelControlValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.LabelControlValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControlValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelControlValue.Location = new System.Drawing.Point(5, 81);
            this.LabelControlValue.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlValue.Name = "LabelControlValue";
            this.LabelControlValue.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlValue.Size = new System.Drawing.Size(408, 56);
            this.LabelControlValue.TabIndex = 8;
            this.LabelControlValue.Text = "值";
            // 
            // ObjectTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainer);
            this.Name = "ObjectTreeControl";
            this.Size = new System.Drawing.Size(418, 571);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).EndInit();
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList TreeListObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyDescriptor;
        private DevExpress.Utils.ImageCollection ImageCollectionTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyValue;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyElementType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyValueString;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyTypeString;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyTitle;
        private DevExpress.XtraEditors.LabelControl LabelControlValue;
        private DevExpress.XtraEditors.LabelControl LabelControlObjectType;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyType;
    }
}
