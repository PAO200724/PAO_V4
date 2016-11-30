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
            this.ImageCollectionTree = new DevExpress.Utils.ImageCollection(this.components);
            this.BarManagerObjectTree = new DevExpress.XtraBars.BarManager(this.components);
            this.BarMainTools = new DevExpress.XtraBars.Bar();
            this.ButtonSave = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonCreate = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonAdd = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonModifyKey = new DevExpress.XtraBars.BarButtonItem();
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
            this.LabelControlValue = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlObjectType = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPropertyType = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPropertyTitle = new DevExpress.XtraEditors.LabelControl();
            this.ObjectEditControl = new PAO.Config.Controls.ObjectEditControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.BarManagerObject = new DevExpress.XtraBars.BarManager(this.components);
            this.BarToolObject = new DevExpress.XtraBars.Bar();
            this.ButtonApply = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonCancel = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObjectTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlMain)).BeginInit();
            this.SplitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlLeft)).BeginInit();
            this.SplitContainerControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).BeginInit();
            this.SuspendLayout();
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
            this.ButtonDelete,
            this.ButtonModifyKey});
            this.BarManagerObjectTree.MaxItemId = 9;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonModifyKey, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarMainTools.OptionsBar.AllowQuickCustomization = false;
            this.BarMainTools.OptionsBar.DisableCustomization = true;
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
            // ButtonModifyKey
            // 
            this.ButtonModifyKey.Caption = "修改键值(&M)";
            this.ButtonModifyKey.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonModifyKey.Glyph")));
            this.ButtonModifyKey.Id = 8;
            this.ButtonModifyKey.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonModifyKey.LargeGlyph")));
            this.ButtonModifyKey.Name = "ButtonModifyKey";
            this.ButtonModifyKey.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonModifyKey_ItemClick);
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
            this.SplitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.SplitContainerControlMain.Location = new System.Drawing.Point(0, 31);
            this.SplitContainerControlMain.Name = "SplitContainerControlMain";
            this.SplitContainerControlMain.Panel1.Controls.Add(this.SplitContainerControlLeft);
            this.SplitContainerControlMain.Panel1.Text = "Panel1";
            this.SplitContainerControlMain.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplitContainerControlMain.Panel2.AppearanceCaption.Options.UseFont = true;
            this.SplitContainerControlMain.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.SplitContainerControlMain.Panel2.Controls.Add(this.ObjectEditControl);
            this.SplitContainerControlMain.Panel2.Controls.Add(this.barDockControl3);
            this.SplitContainerControlMain.Panel2.Controls.Add(this.barDockControl4);
            this.SplitContainerControlMain.Panel2.Controls.Add(this.barDockControl2);
            this.SplitContainerControlMain.Panel2.Controls.Add(this.barDockControl1);
            this.SplitContainerControlMain.Panel2.ShowCaption = true;
            this.SplitContainerControlMain.Size = new System.Drawing.Size(922, 540);
            this.SplitContainerControlMain.SplitterPosition = 358;
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
            this.SplitContainerControlLeft.Panel2.Controls.Add(this.LabelControlValue);
            this.SplitContainerControlLeft.Panel2.Controls.Add(this.LabelControlObjectType);
            this.SplitContainerControlLeft.Panel2.Controls.Add(this.LabelControlPropertyType);
            this.SplitContainerControlLeft.Panel2.Controls.Add(this.LabelControlPropertyTitle);
            this.SplitContainerControlLeft.Panel2.Text = "Panel2";
            this.SplitContainerControlLeft.Size = new System.Drawing.Size(559, 540);
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
            this.TreeListObject.Size = new System.Drawing.Size(559, 412);
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
            // ColumnIndex
            // 
            this.ColumnIndex.Caption = "索引";
            this.ColumnIndex.FieldName = "Index";
            this.ColumnIndex.Name = "ColumnIndex";
            // 
            // LabelControlValue
            // 
            this.LabelControlValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.LabelControlValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControlValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelControlValue.Location = new System.Drawing.Point(0, 76);
            this.LabelControlValue.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlValue.Name = "LabelControlValue";
            this.LabelControlValue.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlValue.Size = new System.Drawing.Size(555, 43);
            this.LabelControlValue.TabIndex = 14;
            this.LabelControlValue.Text = "值";
            // 
            // LabelControlObjectType
            // 
            this.LabelControlObjectType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlObjectType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlObjectType.Location = new System.Drawing.Point(0, 56);
            this.LabelControlObjectType.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlObjectType.Name = "LabelControlObjectType";
            this.LabelControlObjectType.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlObjectType.Size = new System.Drawing.Size(555, 20);
            this.LabelControlObjectType.TabIndex = 13;
            this.LabelControlObjectType.Text = "值类型";
            // 
            // LabelControlPropertyType
            // 
            this.LabelControlPropertyType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.LabelControlPropertyType.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlPropertyType.Location = new System.Drawing.Point(0, 36);
            this.LabelControlPropertyType.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControlPropertyType.Name = "LabelControlPropertyType";
            this.LabelControlPropertyType.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.LabelControlPropertyType.Size = new System.Drawing.Size(555, 20);
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
            this.LabelControlPropertyTitle.Size = new System.Drawing.Size(555, 36);
            this.LabelControlPropertyTitle.TabIndex = 2;
            this.LabelControlPropertyTitle.Text = "属性";
            // 
            // ObjectEditControl
            // 
            this.ObjectEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectEditControl.Location = new System.Drawing.Point(0, 31);
            this.ObjectEditControl.Name = "ObjectEditControl";
            this.ObjectEditControl.SelectedObject = null;
            this.ObjectEditControl.Size = new System.Drawing.Size(354, 469);
            this.ObjectEditControl.TabIndex = 0;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 31);
            this.barDockControl3.Size = new System.Drawing.Size(0, 469);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(354, 31);
            this.barDockControl4.Size = new System.Drawing.Size(0, 469);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 500);
            this.barDockControl2.Size = new System.Drawing.Size(354, 0);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(354, 31);
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
            this.BarManagerObject.Form = this.SplitContainerControlMain.Panel2;
            this.BarManagerObject.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonApply,
            this.ButtonCancel,
            this.ButtonExport,
            this.barButtonItem1});
            this.BarManagerObject.MaxItemId = 4;
            // 
            // BarToolObject
            // 
            this.BarToolObject.BarName = "对象工具条";
            this.BarToolObject.DockCol = 0;
            this.BarToolObject.DockRow = 0;
            this.BarToolObject.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarToolObject.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonApply, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarToolObject.OptionsBar.AllowQuickCustomization = false;
            this.BarToolObject.OptionsBar.DisableCustomization = true;
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
            // ButtonExport
            // 
            this.ButtonExport.Caption = "导出(&E)";
            this.ButtonExport.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonExport.Glyph")));
            this.ButtonExport.Id = 2;
            this.ButtonExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonExport.LargeGlyph")));
            this.ButtonExport.Name = "ButtonExport";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "导入(&I)";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ObjectTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ObjectTreeControl";
            this.Size = new System.Drawing.Size(922, 571);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObjectTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlMain)).EndInit();
            this.SplitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlLeft)).EndInit();
            this.SplitContainerControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem ButtonSave;
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
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraEditors.LabelControl LabelControlValue;
        private DevExpress.XtraEditors.LabelControl LabelControlObjectType;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyType;
        private DevExpress.XtraEditors.LabelControl LabelControlPropertyTitle;
        private DevExpress.XtraBars.BarManager BarManagerObject;
        private DevExpress.XtraBars.Bar BarToolObject;
        private DevExpress.XtraBars.BarButtonItem ButtonApply;
        private DevExpress.XtraBars.BarButtonItem ButtonCancel;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private ObjectEditControl ObjectEditControl;
    }
}
