namespace PAO.Config.Editor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectTreeEditControl));
            this.ImageCollectionTree = new DevExpress.Utils.ImageCollection(this.components);
            this.BarManagerObjectTree = new DevExpress.XtraBars.BarManager(this.components);
            this.BarMainTools = new DevExpress.XtraBars.Bar();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.MenuItemExtend = new DevExpress.XtraBars.BarSubItem();
            this.ButtonImportExtend = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExportExtend = new DevExpress.XtraBars.BarButtonItem();
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
            this.ObjectContainerEditControl = new PAO.Config.Editor.ObjectContainerControl();
            this.AddonExtentionEditControl = new PAO.Config.Editor.AddonExtentionEditControl();
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageProperty = new DevExpress.XtraTab.XtraTabPage();
            this.TabPageExtendProperty = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObjectTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlMain)).BeginInit();
            this.SplitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControlLeft)).BeginInit();
            this.SplitContainerControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.TabControl.SuspendLayout();
            this.TabPageProperty.SuspendLayout();
            this.TabPageExtendProperty.SuspendLayout();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuItemExtend, true)});
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(922, 28);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 543);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(922, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 543);
            // 
            // SplitContainerControlMain
            // 
            this.SplitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.SplitContainerControlMain.Location = new System.Drawing.Point(0, 28);
            this.SplitContainerControlMain.Name = "SplitContainerControlMain";
            this.SplitContainerControlMain.Panel1.Controls.Add(this.SplitContainerControlLeft);
            this.SplitContainerControlMain.Panel1.Text = "Panel1";
            this.SplitContainerControlMain.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplitContainerControlMain.Panel2.AppearanceCaption.Options.UseFont = true;
            this.SplitContainerControlMain.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.SplitContainerControlMain.Panel2.Controls.Add(this.TabControl);
            this.SplitContainerControlMain.Panel2.ShowCaption = true;
            this.SplitContainerControlMain.Size = new System.Drawing.Size(922, 543);
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
            this.SplitContainerControlLeft.Size = new System.Drawing.Size(504, 543);
            this.SplitContainerControlLeft.SplitterPosition = 93;
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
            this.TreeListObject.Size = new System.Drawing.Size(504, 444);
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
            this.LabelControlPropertyDescription.Size = new System.Drawing.Size(500, 33);
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
            // ObjectContainerEditControl
            // 
            this.ObjectContainerEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectContainerEditControl.Location = new System.Drawing.Point(0, 0);
            this.ObjectContainerEditControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ObjectContainerEditControl.Name = "ObjectContainerEditControl";
            this.ObjectContainerEditControl.ShowApplyButton = false;
            this.ObjectContainerEditControl.ShowCancelButton = true;
            this.ObjectContainerEditControl.Size = new System.Drawing.Size(402, 476);
            this.ObjectContainerEditControl.TabIndex = 0;
            this.ObjectContainerEditControl.DataModifyStateChanged += new System.EventHandler<PAO.WinForm.DataModifyStateChangedEventArgs>(this.ObjectContainerEditControl_DataModifyStateChanged);
            // 
            // AddonExtentionEditControl
            // 
            this.AddonExtentionEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonExtentionEditControl.Location = new System.Drawing.Point(0, 0);
            this.AddonExtentionEditControl.Name = "AddonExtentionEditControl";
            this.AddonExtentionEditControl.OriginAddon = null;
            this.AddonExtentionEditControl.ShowApplyButton = false;
            this.AddonExtentionEditControl.ShowCancelButton = true;
            this.AddonExtentionEditControl.Size = new System.Drawing.Size(402, 476);
            this.AddonExtentionEditControl.TabIndex = 0;
            this.AddonExtentionEditControl.DataModifyStateChanged += new System.EventHandler<PAO.WinForm.DataModifyStateChangedEventArgs>(this.AddonExtentionEditControl_DataModifyStateChanged);
            // 
            // TabControl
            // 
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedTabPage = this.TabPageProperty;
            this.TabControl.Size = new System.Drawing.Size(408, 503);
            this.TabControl.TabIndex = 3;
            this.TabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageProperty,
            this.TabPageExtendProperty});
            // 
            // TabPageProperty
            // 
            this.TabPageProperty.Controls.Add(this.ObjectContainerEditControl);
            this.TabPageProperty.Name = "TabPageProperty";
            this.TabPageProperty.Size = new System.Drawing.Size(402, 476);
            this.TabPageProperty.Text = "属性";
            // 
            // TabPageExtendProperty
            // 
            this.TabPageExtendProperty.Controls.Add(this.AddonExtentionEditControl);
            this.TabPageExtendProperty.Name = "TabPageExtendProperty";
            this.TabPageExtendProperty.Size = new System.Drawing.Size(402, 476);
            this.TabPageExtendProperty.Text = "扩展属性";
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
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.TabPageProperty.ResumeLayout(false);
            this.TabPageExtendProperty.ResumeLayout(false);
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
        private AddonExtentionEditControl AddonExtentionEditControl;
        private DevExpress.XtraBars.BarSubItem MenuItemExtend;
        private DevExpress.XtraBars.BarButtonItem ButtonImportExtend;
        private DevExpress.XtraBars.BarButtonItem ButtonExportExtend;
        private ObjectContainerControl ObjectContainerEditControl;
        private DevExpress.XtraTab.XtraTabControl TabControl;
        private DevExpress.XtraTab.XtraTabPage TabPageProperty;
        private DevExpress.XtraTab.XtraTabPage TabPageExtendProperty;
    }
}
