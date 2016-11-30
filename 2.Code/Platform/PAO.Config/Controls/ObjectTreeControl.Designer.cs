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
            this.ColumnPropertyValueString = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyTypeString = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyDescriptor = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnObject = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyElementType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ImageCollectionTree = new DevExpress.Utils.ImageCollection();
            this.SplitContainerPropertyTree = new System.Windows.Forms.SplitContainer();
            this.GroupControlProperty = new DevExpress.XtraEditors.GroupControl();
            this.LabelControlValue = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlObjectType = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPropertyType = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPropertyTitle = new DevExpress.XtraEditors.LabelControl();
            this.SplitContainerClient = new System.Windows.Forms.SplitContainer();
            this.GroupControlObject = new DevExpress.XtraEditors.GroupControl();
            this.PanelControlObject = new DevExpress.XtraEditors.PanelControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.BarManagerObjectTree = new DevExpress.XtraBars.BarManager();
            this.BarMainTools = new DevExpress.XtraBars.Bar();
            this.ButtonSave = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonCreate = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonAdd = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BarToolObject = new DevExpress.XtraBars.Bar();
            this.ButtonApply = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonCancel = new DevExpress.XtraBars.BarButtonItem();
            this.BarManagerObject = new DevExpress.XtraBars.BarManager();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerPropertyTree)).BeginInit();
            this.SplitContainerPropertyTree.Panel1.SuspendLayout();
            this.SplitContainerPropertyTree.Panel2.SuspendLayout();
            this.SplitContainerPropertyTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlProperty)).BeginInit();
            this.GroupControlProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerClient)).BeginInit();
            this.SplitContainerClient.Panel1.SuspendLayout();
            this.SplitContainerClient.Panel2.SuspendLayout();
            this.SplitContainerClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlObject)).BeginInit();
            this.GroupControlObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObjectTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).BeginInit();
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
            this.TreeListObject.Size = new System.Drawing.Size(535, 413);
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
            this.ImageCollectionTree.Images.SetKeyName(0, "arrow_right.png");
            this.ImageCollectionTree.InsertGalleryImage("product_16x16.png", "images/support/product_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/product_16x16.png"), 1);
            this.ImageCollectionTree.Images.SetKeyName(1, "product_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("group_16x16.png", "images/actions/group_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/group_16x16.png"), 2);
            this.ImageCollectionTree.Images.SetKeyName(2, "group_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("contentarrangeinrows_16x16.png", "images/alignment/contentarrangeinrows_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/alignment/contentarrangeinrows_16x16.png"), 3);
            this.ImageCollectionTree.Images.SetKeyName(3, "contentarrangeinrows_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("freezefirstcolumn_16x16.png", "images/spreadsheet/freezefirstcolumn_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/freezefirstcolumn_16x16.png"), 4);
            this.ImageCollectionTree.Images.SetKeyName(4, "freezefirstcolumn_16x16.png");
            // 
            // SplitContainerPropertyTree
            // 
            this.SplitContainerPropertyTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerPropertyTree.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainerPropertyTree.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerPropertyTree.Name = "SplitContainerPropertyTree";
            this.SplitContainerPropertyTree.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerPropertyTree.Panel1
            // 
            this.SplitContainerPropertyTree.Panel1.Controls.Add(this.TreeListObject);
            // 
            // SplitContainerPropertyTree.Panel2
            // 
            this.SplitContainerPropertyTree.Panel2.Controls.Add(this.GroupControlProperty);
            this.SplitContainerPropertyTree.Panel2MinSize = 50;
            this.SplitContainerPropertyTree.Size = new System.Drawing.Size(535, 540);
            this.SplitContainerPropertyTree.SplitterDistance = 413;
            this.SplitContainerPropertyTree.TabIndex = 1;
            // 
            // GroupControlProperty
            // 
            this.GroupControlProperty.Controls.Add(this.LabelControlValue);
            this.GroupControlProperty.Controls.Add(this.LabelControlObjectType);
            this.GroupControlProperty.Controls.Add(this.LabelControlPropertyType);
            this.GroupControlProperty.Controls.Add(this.LabelControlPropertyTitle);
            this.GroupControlProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControlProperty.Location = new System.Drawing.Point(0, 0);
            this.GroupControlProperty.Margin = new System.Windows.Forms.Padding(0);
            this.GroupControlProperty.Name = "GroupControlProperty";
            this.GroupControlProperty.ShowCaption = false;
            this.GroupControlProperty.Size = new System.Drawing.Size(535, 123);
            this.GroupControlProperty.TabIndex = 0;
            this.GroupControlProperty.Text = "属性";
            // 
            // LabelControlValue
            // 
            this.LabelControlValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.LabelControlValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControlValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelControlValue.Location = new System.Drawing.Point(2, 78);
            this.LabelControlValue.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlValue.Name = "LabelControlValue";
            this.LabelControlValue.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlValue.Size = new System.Drawing.Size(531, 43);
            this.LabelControlValue.TabIndex = 9;
            this.LabelControlValue.Text = "值";
            // 
            // LabelControlObjectType
            // 
            this.LabelControlObjectType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlObjectType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlObjectType.Location = new System.Drawing.Point(2, 58);
            this.LabelControlObjectType.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlObjectType.Name = "LabelControlObjectType";
            this.LabelControlObjectType.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlObjectType.Size = new System.Drawing.Size(531, 20);
            this.LabelControlObjectType.TabIndex = 8;
            this.LabelControlObjectType.Text = "值类型";
            // 
            // LabelControlPropertyType
            // 
            this.LabelControlPropertyType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlPropertyType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlPropertyType.Location = new System.Drawing.Point(2, 38);
            this.LabelControlPropertyType.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyType.Name = "LabelControlPropertyType";
            this.LabelControlPropertyType.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlPropertyType.Size = new System.Drawing.Size(531, 20);
            this.LabelControlPropertyType.TabIndex = 7;
            this.LabelControlPropertyType.Text = "属性类型";
            // 
            // LabelControlPropertyTitle
            // 
            this.LabelControlPropertyTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControlPropertyTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlPropertyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlPropertyTitle.Location = new System.Drawing.Point(2, 2);
            this.LabelControlPropertyTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyTitle.Name = "LabelControlPropertyTitle";
            this.LabelControlPropertyTitle.Padding = new System.Windows.Forms.Padding(5);
            this.LabelControlPropertyTitle.Size = new System.Drawing.Size(531, 36);
            this.LabelControlPropertyTitle.TabIndex = 1;
            this.LabelControlPropertyTitle.Text = "属性";
            // 
            // SplitContainerClient
            // 
            this.SplitContainerClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerClient.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainerClient.Location = new System.Drawing.Point(0, 31);
            this.SplitContainerClient.Name = "SplitContainerClient";
            // 
            // SplitContainerClient.Panel1
            // 
            this.SplitContainerClient.Panel1.Controls.Add(this.SplitContainerPropertyTree);
            // 
            // SplitContainerClient.Panel2
            // 
            this.SplitContainerClient.Panel2.Controls.Add(this.GroupControlObject);
            this.SplitContainerClient.Size = new System.Drawing.Size(922, 540);
            this.SplitContainerClient.SplitterDistance = 535;
            this.SplitContainerClient.TabIndex = 2;
            // 
            // GroupControlObject
            // 
            this.GroupControlObject.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupControlObject.AppearanceCaption.Options.UseFont = true;
            this.GroupControlObject.Controls.Add(this.PanelControlObject);
            this.GroupControlObject.Controls.Add(this.barDockControl3);
            this.GroupControlObject.Controls.Add(this.barDockControl4);
            this.GroupControlObject.Controls.Add(this.barDockControl2);
            this.GroupControlObject.Controls.Add(this.barDockControl1);
            this.GroupControlObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControlObject.Location = new System.Drawing.Point(0, 0);
            this.GroupControlObject.Name = "GroupControlObject";
            this.GroupControlObject.Size = new System.Drawing.Size(383, 540);
            this.GroupControlObject.TabIndex = 0;
            this.GroupControlObject.Text = "属性";
            // 
            // PanelControlObject
            // 
            this.PanelControlObject.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PanelControlObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlObject.Location = new System.Drawing.Point(2, 65);
            this.PanelControlObject.Name = "PanelControlObject";
            this.PanelControlObject.Size = new System.Drawing.Size(379, 473);
            this.PanelControlObject.TabIndex = 4;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(2, 65);
            this.barDockControl3.Size = new System.Drawing.Size(0, 473);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(381, 65);
            this.barDockControl4.Size = new System.Drawing.Size(0, 473);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(2, 538);
            this.barDockControl2.Size = new System.Drawing.Size(379, 0);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(2, 34);
            this.barDockControl1.Size = new System.Drawing.Size(379, 31);
            // 
            // BarManagerObjectTree
            // 
            this.BarManagerObjectTree.AllowMoveBarOnToolbar = false;
            this.BarManagerObjectTree.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarMainTools});
            this.BarManagerObjectTree.DockControls.Add(this.barDockControlTop);
            this.BarManagerObjectTree.DockControls.Add(this.barDockControlBottom);
            this.BarManagerObjectTree.DockControls.Add(this.barDockControlLeft);
            this.BarManagerObjectTree.DockControls.Add(this.barDockControlRight);
            this.BarManagerObjectTree.Form = this;
            this.BarManagerObjectTree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonSave,
            this.ButtonAdd,
            this.ButtonCreate,
            this.ButtonDelete});
            this.BarManagerObjectTree.MaxItemId = 8;
            // 
            // BarMainTools
            // 
            this.BarMainTools.BarName = "主工具条";
            this.BarMainTools.DockCol = 0;
            this.BarMainTools.DockRow = 0;
            this.BarMainTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarMainTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonCreate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarMainTools.Text = "主工具条";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Caption = "保存(&S)";
            this.ButtonSave.Glyph = global::PAO.Config.Properties.Resources.save_16x16;
            this.ButtonSave.Hint = "保存整个对象";
            this.ButtonSave.Id = 1;
            this.ButtonSave.LargeGlyph = global::PAO.Config.Properties.Resources.save_32x32;
            this.ButtonSave.Name = "ButtonSave";
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.Caption = "创建(&C)";
            this.ButtonCreate.Glyph = global::PAO.Config.Properties.Resources.new_16x16;
            this.ButtonCreate.Hint = "创建新对象";
            this.ButtonCreate.Id = 5;
            this.ButtonCreate.LargeGlyph = global::PAO.Config.Properties.Resources.new_32x32;
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonCreate_ItemClick);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Caption = "添加项(&A)";
            this.ButtonAdd.Glyph = global::PAO.Config.Properties.Resources.insert_16x16;
            this.ButtonAdd.Hint = "添加列表元素";
            this.ButtonAdd.Id = 4;
            this.ButtonAdd.LargeGlyph = global::PAO.Config.Properties.Resources.insert_32x32;
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAdd_ItemClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Caption = "删除(&D)";
            this.ButtonDelete.Glyph = global::PAO.Config.Properties.Resources.remove_16x16;
            this.ButtonDelete.Hint = "清除对象或删除列表对象";
            this.ButtonDelete.Id = 7;
            this.ButtonDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonDelete.LargeGlyph")));
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(922, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 571);
            this.barDockControlBottom.Size = new System.Drawing.Size(922, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 540);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(922, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 540);
            // 
            // BarToolObject
            // 
            this.BarToolObject.BarName = "对象工具条";
            this.BarToolObject.DockCol = 0;
            this.BarToolObject.DockRow = 0;
            this.BarToolObject.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarToolObject.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonApply, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarToolObject.Text = "对象工具条";
            // 
            // ButtonApply
            // 
            this.ButtonApply.Caption = "应用(&A)";
            this.ButtonApply.Glyph = global::PAO.Config.Properties.Resources.apply_16x16;
            this.ButtonApply.Id = 0;
            this.ButtonApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonApply.LargeGlyph")));
            this.ButtonApply.Name = "ButtonApply";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Caption = "取消(&C)";
            this.ButtonCancel.Glyph = global::PAO.Config.Properties.Resources.cancel_16x16;
            this.ButtonCancel.Id = 1;
            this.ButtonCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonCancel.LargeGlyph")));
            this.ButtonCancel.Name = "ButtonCancel";
            // 
            // BarManagerObject
            // 
            this.BarManagerObject.AllowMoveBarOnToolbar = false;
            this.BarManagerObject.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarToolObject});
            this.BarManagerObject.DockControls.Add(this.barDockControl1);
            this.BarManagerObject.DockControls.Add(this.barDockControl2);
            this.BarManagerObject.DockControls.Add(this.barDockControl3);
            this.BarManagerObject.DockControls.Add(this.barDockControl4);
            this.BarManagerObject.Form = this.GroupControlObject;
            this.BarManagerObject.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonApply,
            this.ButtonCancel});
            this.BarManagerObject.MaxItemId = 2;
            // 
            // ObjectTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerClient);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ObjectTreeControl";
            this.Size = new System.Drawing.Size(922, 571);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).EndInit();
            this.SplitContainerPropertyTree.Panel1.ResumeLayout(false);
            this.SplitContainerPropertyTree.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerPropertyTree)).EndInit();
            this.SplitContainerPropertyTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlProperty)).EndInit();
            this.GroupControlProperty.ResumeLayout(false);
            this.SplitContainerClient.Panel1.ResumeLayout(false);
            this.SplitContainerClient.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerClient)).EndInit();
            this.SplitContainerClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlObject)).EndInit();
            this.GroupControlObject.ResumeLayout(false);
            this.GroupControlObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObjectTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.SplitContainer SplitContainerPropertyTree;
        private System.Windows.Forms.SplitContainer SplitContainerClient;
        private DevExpress.XtraEditors.GroupControl GroupControlObject;
        private DevExpress.XtraEditors.GroupControl GroupControlProperty;
        private DevExpress.XtraEditors.LabelControl LabelControlValue;
        private DevExpress.XtraEditors.LabelControl LabelControlObjectType;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyType;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyTitle;
        private DevExpress.XtraBars.BarManager BarManagerObjectTree;
        private DevExpress.XtraBars.Bar BarMainTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonSave;
        private DevExpress.XtraBars.BarButtonItem ButtonAdd;
        private DevExpress.XtraBars.BarButtonItem ButtonCreate;
        private DevExpress.XtraBars.BarButtonItem ButtonDelete;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.Bar BarToolObject;
        private DevExpress.XtraBars.BarManager BarManagerObject;
        private DevExpress.XtraBars.BarButtonItem ButtonApply;
        private DevExpress.XtraBars.BarButtonItem ButtonCancel;
        private DevExpress.XtraEditors.PanelControl PanelControlObject;
    }
}
