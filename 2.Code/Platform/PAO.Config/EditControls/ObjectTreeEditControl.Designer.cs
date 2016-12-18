namespace PAO.Config.EditControls
{
    partial class ObjectTreeEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectTreeEditControl));
            this.ImageCollectionTree = new DevExpress.Utils.ImageCollection();
            this.BarManagerObjectTree = new DevExpress.XtraBars.BarManager();
            this.BarMainTools = new DevExpress.XtraBars.Bar();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonImport = new DevExpress.XtraBars.BarButtonItem();
            this.MenuItemExtend = new DevExpress.XtraBars.BarSubItem();
            this.ButtonImportExtend = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExportExtend = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonCreate = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonAdd = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonModifyKey = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonProperty = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.SplitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.SplitContainerControlLeft = new DevExpress.XtraEditors.SplitContainerControl();
            this.TreeListObject = new DevExpress.XtraTreeList.TreeList();
            this.ColumnPropertyName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyValueString = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyTypeString = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyDescriptor = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnObject = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnPropertyElementType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.LabelControlPropertyDescription = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPropertyType = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPropertyTitle = new DevExpress.XtraEditors.LabelControl();
            this.SplitContainerControlProperty = new DevExpress.XtraEditors.SplitContainerControl();
            this.TabControlObject = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageObject = new DevExpress.XtraTab.XtraTabPage();
            this.ObjectEditControl = new PAO.Config.EditControls.ObjectEditControl();
            this.TabPageList = new DevExpress.XtraTab.XtraTabPage();
            this.ListEditControl = new PAO.Config.EditControls.ListEditControl();
            this.TabPageDictionary = new DevExpress.XtraTab.XtraTabPage();
            this.DictionaryEditControl = new PAO.Config.EditControls.DictionaryEditControl();
            this.AddonExtentionEditControl = new PAO.Config.EditControls.AddonExtentionEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObjectTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlMain)).BeginInit();
            this.SplitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlLeft)).BeginInit();
            this.SplitContainerControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlProperty)).BeginInit();
            this.SplitContainerControlProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlObject)).BeginInit();
            this.TabControlObject.SuspendLayout();
            this.TabPageObject.SuspendLayout();
            this.TabPageList.SuspendLayout();
            this.TabPageDictionary.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageCollectionTree
            // 
            this.ImageCollectionTree.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollectionTree.ImageStream")));
            this.ImageCollectionTree.Images.SetKeyName(0, "arrow_right.png");
            this.ImageCollectionTree.InsertGalleryImage("listnumbers_16x16.png", "images/format/listnumbers_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/format/listnumbers_16x16.png"), 1);
            this.ImageCollectionTree.Images.SetKeyName(1, "listnumbers_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("listbullets_16x16.png", "images/format/listbullets_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/format/listbullets_16x16.png"), 2);
            this.ImageCollectionTree.Images.SetKeyName(2, "listbullets_16x16.png");
            this.ImageCollectionTree.InsertGalleryImage("deletelist_16x16.png", "images/actions/deletelist_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/deletelist_16x16.png"), 3);
            this.ImageCollectionTree.Images.SetKeyName(3, "deletelist_16x16.png");
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
            this.ButtonExport,
            this.ButtonAdd,
            this.ButtonCreate,
            this.ButtonDelete,
            this.ButtonModifyKey,
            this.ButtonImport,
            this.ButtonProperty,
            this.ButtonImportExtend,
            this.ButtonExportExtend,
            this.MenuItemExtend});
            this.BarManagerObjectTree.MaxItemId = 14;
            // 
            // BarMainTools
            // 
            this.BarMainTools.BarName = "主工具条";
            this.BarMainTools.DockCol = 0;
            this.BarMainTools.DockRow = 0;
            this.BarMainTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarMainTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonImport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuItemExtend, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonCreate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonModifyKey, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonProperty, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarMainTools.OptionsBar.AllowQuickCustomization = false;
            this.BarMainTools.OptionsBar.DisableCustomization = true;
            this.BarMainTools.Text = "主工具条";
            // 
            // ButtonExport
            // 
            this.ButtonExport.Caption = "导出(&E)";
            this.ButtonExport.Glyph = global::PAO.Config.Properties.Resources.saveto_16x16;
            this.ButtonExport.Hint = "保存整个对象";
            this.ButtonExport.Id = 1;
            this.ButtonExport.LargeGlyph = global::PAO.Config.Properties.Resources.saveto_32x32;
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonExport_ItemClick);
            // 
            // ButtonImport
            // 
            this.ButtonImport.Caption = "导入(&I)";
            this.ButtonImport.Glyph = global::PAO.Config.Properties.Resources.loadfrom_16x16;
            this.ButtonImport.Id = 9;
            this.ButtonImport.LargeGlyph = global::PAO.Config.Properties.Resources.loadfrom_32x32;
            this.ButtonImport.Name = "ButtonImport";
            this.ButtonImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonImport_ItemClick);
            // 
            // MenuItemExtend
            // 
            this.MenuItemExtend.Caption = "扩展配置(&T)";
            this.MenuItemExtend.Id = 13;
            this.MenuItemExtend.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonImportExtend),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonExportExtend)});
            this.MenuItemExtend.Name = "MenuItemExtend";
            // 
            // ButtonImportExtend
            // 
            this.ButtonImportExtend.Caption = "导入扩展配置";
            this.ButtonImportExtend.Id = 11;
            this.ButtonImportExtend.Name = "ButtonImportExtend";
            this.ButtonImportExtend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonImportExtend_ItemClick);
            // 
            // ButtonExportExtend
            // 
            this.ButtonExportExtend.Caption = "导出扩展配置";
            this.ButtonExportExtend.Id = 12;
            this.ButtonExportExtend.Name = "ButtonExportExtend";
            this.ButtonExportExtend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonExportExtend_ItemClick);
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
            // ButtonModifyKey
            // 
            this.ButtonModifyKey.Caption = "修改键值(&M)";
            this.ButtonModifyKey.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonModifyKey.Glyph")));
            this.ButtonModifyKey.Id = 8;
            this.ButtonModifyKey.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonModifyKey.LargeGlyph")));
            this.ButtonModifyKey.Name = "ButtonModifyKey";
            this.ButtonModifyKey.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonModifyKey_ItemClick);
            // 
            // ButtonProperty
            // 
            this.ButtonProperty.Caption = "属性(&P)";
            this.ButtonProperty.Glyph = global::PAO.Config.Properties.Resources.properties_16x16;
            this.ButtonProperty.Id = 10;
            this.ButtonProperty.LargeGlyph = global::PAO.Config.Properties.Resources.properties_32x32;
            this.ButtonProperty.Name = "ButtonProperty";
            this.ButtonProperty.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonProperty_ItemClick);
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
            // SplitContainerControlMain
            // 
            this.SplitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.SplitContainerControlMain.Location = new System.Drawing.Point(0, 31);
            this.SplitContainerControlMain.Name = "SplitContainerControlMain";
            this.SplitContainerControlMain.Panel1.Controls.Add(this.SplitContainerControlLeft);
            this.SplitContainerControlMain.Panel1.Text = "Panel1";
            this.SplitContainerControlMain.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplitContainerControlMain.Panel2.AppearanceCaption.Options.UseFont = true;
            this.SplitContainerControlMain.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.SplitContainerControlMain.Panel2.Controls.Add(this.SplitContainerControlProperty);
            this.SplitContainerControlMain.Panel2.ShowCaption = true;
            this.SplitContainerControlMain.Size = new System.Drawing.Size(922, 540);
            this.SplitContainerControlMain.SplitterPosition = 504;
            this.SplitContainerControlMain.TabIndex = 7;
            this.SplitContainerControlMain.Text = "splitContainerControl1";
            // 
            // SplitContainerControlLeft
            // 
            this.SplitContainerControlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControlLeft.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.SplitContainerControlLeft.Horizontal = false;
            this.SplitContainerControlLeft.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControlLeft.Name = "SplitContainerControlLeft";
            this.SplitContainerControlLeft.Panel1.Controls.Add(this.TreeListObject);
            this.SplitContainerControlLeft.Panel1.Text = "Panel1";
            this.SplitContainerControlLeft.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.SplitContainerControlLeft.Panel2.Controls.Add(this.LabelControlPropertyDescription);
            this.SplitContainerControlLeft.Panel2.Controls.Add(this.LabelControlPropertyType);
            this.SplitContainerControlLeft.Panel2.Controls.Add(this.LabelControlPropertyTitle);
            this.SplitContainerControlLeft.Panel2.Text = "Panel2";
            this.SplitContainerControlLeft.Size = new System.Drawing.Size(504, 540);
            this.SplitContainerControlLeft.SplitterPosition = 123;
            this.SplitContainerControlLeft.TabIndex = 0;
            this.SplitContainerControlLeft.Text = "splitContainerControl2";
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
            this.ColumnPropertyElementType,
            this.ColumnIndex});
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
            this.TreeListObject.Size = new System.Drawing.Size(504, 412);
            this.TreeListObject.TabIndex = 1;
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
            this.ColumnPropertyName.Width = 202;
            // 
            // ColumnPropertyValueString
            // 
            this.ColumnPropertyValueString.Caption = "值";
            this.ColumnPropertyValueString.FieldName = "ObjectString";
            this.ColumnPropertyValueString.Name = "ColumnPropertyValueString";
            this.ColumnPropertyValueString.Visible = true;
            this.ColumnPropertyValueString.VisibleIndex = 2;
            this.ColumnPropertyValueString.Width = 204;
            // 
            // ColumnPropertyTypeString
            // 
            this.ColumnPropertyTypeString.Caption = "值类型";
            this.ColumnPropertyTypeString.FieldName = "TypeName";
            this.ColumnPropertyTypeString.Name = "ColumnPropertyTypeString";
            this.ColumnPropertyTypeString.OptionsColumn.FixedWidth = true;
            this.ColumnPropertyTypeString.Visible = true;
            this.ColumnPropertyTypeString.VisibleIndex = 1;
            this.ColumnPropertyTypeString.Width = 151;
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
            // ColumnIndex
            // 
            this.ColumnIndex.Caption = "索引";
            this.ColumnIndex.FieldName = "Index";
            this.ColumnIndex.Name = "ColumnIndex";
            // 
            // LabelControlPropertyDescription
            // 
            this.LabelControlPropertyDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.LabelControlPropertyDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControlPropertyDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelControlPropertyDescription.Location = new System.Drawing.Point(0, 56);
            this.LabelControlPropertyDescription.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyDescription.Name = "LabelControlPropertyDescription";
            this.LabelControlPropertyDescription.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlPropertyDescription.Size = new System.Drawing.Size(500, 63);
            this.LabelControlPropertyDescription.TabIndex = 14;
            this.LabelControlPropertyDescription.Text = "属性描述";
            // 
            // LabelControlPropertyType
            // 
            this.LabelControlPropertyType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlPropertyType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlPropertyType.Location = new System.Drawing.Point(0, 36);
            this.LabelControlPropertyType.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyType.Name = "LabelControlPropertyType";
            this.LabelControlPropertyType.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlPropertyType.Size = new System.Drawing.Size(500, 20);
            this.LabelControlPropertyType.TabIndex = 8;
            this.LabelControlPropertyType.Text = "属性类型";
            // 
            // LabelControlPropertyTitle
            // 
            this.LabelControlPropertyTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControlPropertyTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlPropertyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlPropertyTitle.Location = new System.Drawing.Point(0, 0);
            this.LabelControlPropertyTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyTitle.Name = "LabelControlPropertyTitle";
            this.LabelControlPropertyTitle.Padding = new System.Windows.Forms.Padding(5);
            this.LabelControlPropertyTitle.Size = new System.Drawing.Size(500, 36);
            this.LabelControlPropertyTitle.TabIndex = 2;
            this.LabelControlPropertyTitle.Text = "属性";
            // 
            // SplitContainerControlProperty
            // 
            this.SplitContainerControlProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControlProperty.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.SplitContainerControlProperty.Horizontal = false;
            this.SplitContainerControlProperty.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControlProperty.Name = "SplitContainerControlProperty";
            this.SplitContainerControlProperty.Panel1.Controls.Add(this.TabControlObject);
            this.SplitContainerControlProperty.Panel1.Text = "Panel1";
            this.SplitContainerControlProperty.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.SplitContainerControlProperty.Panel2.Controls.Add(this.AddonExtentionEditControl);
            this.SplitContainerControlProperty.Panel2.ShowCaption = true;
            this.SplitContainerControlProperty.Panel2.Text = "扩展属性";
            this.SplitContainerControlProperty.Size = new System.Drawing.Size(409, 500);
            this.SplitContainerControlProperty.SplitterPosition = 288;
            this.SplitContainerControlProperty.TabIndex = 2;
            this.SplitContainerControlProperty.Text = "splitContainerControl1";
            // 
            // TabControlObject
            // 
            this.TabControlObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlObject.Location = new System.Drawing.Point(0, 0);
            this.TabControlObject.Name = "TabControlObject";
            this.TabControlObject.SelectedTabPage = this.TabPageObject;
            this.TabControlObject.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.TabControlObject.Size = new System.Drawing.Size(409, 288);
            this.TabControlObject.TabIndex = 1;
            this.TabControlObject.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageObject,
            this.TabPageList,
            this.TabPageDictionary});
            // 
            // TabPageObject
            // 
            this.TabPageObject.Controls.Add(this.ObjectEditControl);
            this.TabPageObject.Name = "TabPageObject";
            this.TabPageObject.Size = new System.Drawing.Size(403, 282);
            this.TabPageObject.Text = "插件";
            // 
            // ObjectEditControl
            // 
            this.ObjectEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectEditControl.Enabled = false;
            this.ObjectEditControl.Location = new System.Drawing.Point(0, 0);
            this.ObjectEditControl.Name = "ObjectEditControl";
            this.ObjectEditControl.ShowApplyButton = true;
            this.ObjectEditControl.ShowCancelButton = true;
            this.ObjectEditControl.Size = new System.Drawing.Size(403, 282);
            this.ObjectEditControl.TabIndex = 1;
            this.ObjectEditControl.DataModifyStateChanged += new System.EventHandler<PAO.WinForm.DataModifyStateChangedEventArgs>(this.ObjectEditControl_DataModifyStateChanged);
            // 
            // TabPageList
            // 
            this.TabPageList.Controls.Add(this.ListEditControl);
            this.TabPageList.Name = "TabPageList";
            this.TabPageList.Size = new System.Drawing.Size(403, 282);
            this.TabPageList.Text = "列表";
            // 
            // ListEditControl
            // 
            this.ListEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListEditControl.ListType = null;
            this.ListEditControl.Location = new System.Drawing.Point(0, 0);
            this.ListEditControl.Name = "ListEditControl";
            this.ListEditControl.ShowApplyButton = true;
            this.ListEditControl.ShowCancelButton = true;
            this.ListEditControl.Size = new System.Drawing.Size(403, 282);
            this.ListEditControl.TabIndex = 0;
            this.ListEditControl.DataModifyStateChanged += new System.EventHandler<PAO.WinForm.DataModifyStateChangedEventArgs>(this.ListEditControl_DataModifyStateChanged);
            // 
            // TabPageDictionary
            // 
            this.TabPageDictionary.Controls.Add(this.DictionaryEditControl);
            this.TabPageDictionary.Name = "TabPageDictionary";
            this.TabPageDictionary.Size = new System.Drawing.Size(403, 282);
            this.TabPageDictionary.Text = "字典";
            // 
            // DictionaryEditControl
            // 
            this.DictionaryEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DictionaryEditControl.ListType = null;
            this.DictionaryEditControl.Location = new System.Drawing.Point(0, 0);
            this.DictionaryEditControl.Name = "DictionaryEditControl";
            this.DictionaryEditControl.ShowApplyButton = true;
            this.DictionaryEditControl.ShowCancelButton = true;
            this.DictionaryEditControl.Size = new System.Drawing.Size(403, 282);
            this.DictionaryEditControl.TabIndex = 0;
            this.DictionaryEditControl.DataModifyStateChanged += new System.EventHandler<PAO.WinForm.DataModifyStateChangedEventArgs>(this.DictionaryEditControl_DataModifyStateChanged);
            // 
            // AddonExtentionEditControl
            // 
            this.AddonExtentionEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonExtentionEditControl.Location = new System.Drawing.Point(0, 0);
            this.AddonExtentionEditControl.Name = "AddonExtentionEditControl";
            this.AddonExtentionEditControl.OriginAddon = null;
            this.AddonExtentionEditControl.ShowApplyButton = false;
            this.AddonExtentionEditControl.ShowCancelButton = true;
            this.AddonExtentionEditControl.Size = new System.Drawing.Size(405, 184);
            this.AddonExtentionEditControl.TabIndex = 0;
            this.AddonExtentionEditControl.DataModifyStateChanged += new System.EventHandler<PAO.WinForm.DataModifyStateChangedEventArgs>(this.AddonExtentionEditControl_DataModifyStateChanged);
            // 
            // ObjectTreeEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ObjectTreeEditControl";
            this.Size = new System.Drawing.Size(922, 571);
            this.Enter += new System.EventHandler(this.ObjectTreeEditControl_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObjectTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlMain)).EndInit();
            this.SplitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlLeft)).EndInit();
            this.SplitContainerControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlProperty)).EndInit();
            this.SplitContainerControlProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabControlObject)).EndInit();
            this.TabControlObject.ResumeLayout(false);
            this.TabPageObject.ResumeLayout(false);
            this.TabPageList.ResumeLayout(false);
            this.TabPageDictionary.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.Utils.ImageCollection ImageCollectionTree;
        private DevExpress.XtraBars.BarManager BarManagerObjectTree;
        private DevExpress.XtraBars.Bar BarMainTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem ButtonAdd;
        private DevExpress.XtraBars.BarButtonItem ButtonCreate;
        private DevExpress.XtraBars.BarButtonItem ButtonDelete;
        private DevExpress.XtraBars.BarButtonItem ButtonModifyKey;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControlMain;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControlLeft;
        private DevExpress.XtraTreeList.TreeList TreeListObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyValueString;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyTypeString;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyDescriptor;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyValue;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnPropertyElementType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnIndex;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyDescription;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyType;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyTitle;
        private DevExpress.XtraTab.XtraTabControl TabControlObject;
        private DevExpress.XtraTab.XtraTabPage TabPageObject;
        private DevExpress.XtraTab.XtraTabPage TabPageList;
        private DevExpress.XtraTab.XtraTabPage TabPageDictionary;
        private ListEditControl ListEditControl;
        private DictionaryEditControl DictionaryEditControl;
        private DevExpress.XtraBars.BarButtonItem ButtonImport;
        private DevExpress.XtraBars.BarButtonItem ButtonProperty;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControlProperty;
        private ObjectEditControl ObjectEditControl;
        private AddonExtentionEditControl AddonExtentionEditControl;
        private DevExpress.XtraBars.BarSubItem MenuItemExtend;
        private DevExpress.XtraBars.BarButtonItem ButtonImportExtend;
        private DevExpress.XtraBars.BarButtonItem ButtonExportExtend;
    }
}
