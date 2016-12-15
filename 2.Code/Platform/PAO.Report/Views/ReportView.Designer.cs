namespace PAO.Report.Views
{
    partial class ReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportView));
            this.BindingSourceTable = new System.Windows.Forms.BindingSource(this.components);
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.ButtonQuery = new DevExpress.XtraBars.BarButtonItem();
            this.MenuData = new DevExpress.XtraBars.BarSubItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonPrint = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonRebuildDataFields = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonClearDataFields = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonSetupQueryBehavior = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonClearQueryBehavior = new DevExpress.XtraBars.BarButtonItem();
            this.MenuConfig = new DevExpress.XtraBars.BarSubItem();
            this.ButtonRecoverLayout = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonProperties = new DevExpress.XtraBars.BarButtonItem();
            this.BarExtend = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.DockPanelTables = new DevExpress.XtraBars.Docking.DockPanel();
            this.DockPanelData_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.AccordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.RepositoryItemTextEditCaption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).BeginInit();
            this.DockPanelTables.SuspendLayout();
            this.DockPanelData_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccordionControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSourceTable
            // 
            this.BindingSourceTable.DataSource = typeof(PAO.Report.ReportDataTable);
            // 
            // BarManager
            // 
            this.BarManager.AllowCustomization = false;
            this.BarManager.AllowMoveBarOnToolbar = false;
            this.BarManager.AllowQuickCustomization = false;
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarTools,
            this.BarExtend});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.DockManager = this.DockManager;
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonProperties,
            this.ButtonExport,
            this.ButtonPrint,
            this.MenuConfig,
            this.ButtonRecoverLayout,
            this.ButtonQuery,
            this.MenuData,
            this.ButtonRebuildDataFields,
            this.ButtonClearDataFields,
            this.ButtonSetupQueryBehavior,
            this.ButtonClearQueryBehavior});
            this.BarManager.MaxItemId = 18;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEditCaption});
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonQuery, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.MenuData, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.MenuConfig, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarTools.OptionsBar.AllowQuickCustomization = false;
            this.BarTools.OptionsBar.DisableClose = true;
            this.BarTools.OptionsBar.DrawBorder = false;
            this.BarTools.Text = "工具条";
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Caption = "查询(Q)";
            this.ButtonQuery.Glyph = global::PAO.Report.Properties.Resources.zoom_16x16;
            this.ButtonQuery.Id = 12;
            this.ButtonQuery.LargeGlyph = global::PAO.Report.Properties.Resources.zoom_32x32;
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonQuery_ItemClick);
            // 
            // MenuData
            // 
            this.MenuData.Caption = "数据(&D)";
            this.MenuData.Glyph = global::PAO.Report.Properties.Resources.database_16x16;
            this.MenuData.Id = 13;
            this.MenuData.LargeGlyph = global::PAO.Report.Properties.Resources.database_32x32;
            this.MenuData.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRebuildDataFields, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonClearDataFields),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonSetupQueryBehavior, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonClearQueryBehavior)});
            this.MenuData.Name = "MenuData";
            // 
            // ButtonExport
            // 
            this.ButtonExport.Caption = "导出(&E)";
            this.ButtonExport.Glyph = global::PAO.Report.Properties.Resources.export_16x16;
            this.ButtonExport.Id = 3;
            this.ButtonExport.LargeGlyph = global::PAO.Report.Properties.Resources.export_32x32;
            this.ButtonExport.Name = "ButtonExport";
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.Caption = "打印(&P)";
            this.ButtonPrint.Glyph = global::PAO.Report.Properties.Resources.printer_16x16;
            this.ButtonPrint.Id = 4;
            this.ButtonPrint.LargeGlyph = global::PAO.Report.Properties.Resources.printer_32x32;
            this.ButtonPrint.Name = "ButtonPrint";
            // 
            // ButtonRebuildDataFields
            // 
            this.ButtonRebuildDataFields.Caption = "重建表字段(&R)";
            this.ButtonRebuildDataFields.Id = 14;
            this.ButtonRebuildDataFields.Name = "ButtonRebuildDataFields";
            this.ButtonRebuildDataFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonRebuildDataFields_ItemClick);
            // 
            // ButtonClearDataFields
            // 
            this.ButtonClearDataFields.Caption = "清空并重建表字段(&C)";
            this.ButtonClearDataFields.Id = 15;
            this.ButtonClearDataFields.Name = "ButtonClearDataFields";
            this.ButtonClearDataFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonClearDataFields_ItemClick);
            // 
            // ButtonSetupQueryBehavior
            // 
            this.ButtonSetupQueryBehavior.Caption = "设置查询行为(&S)...";
            this.ButtonSetupQueryBehavior.Id = 16;
            this.ButtonSetupQueryBehavior.Name = "ButtonSetupQueryBehavior";
            this.ButtonSetupQueryBehavior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonSetupQueryBehavior_ItemClick);
            // 
            // ButtonClearQueryBehavior
            // 
            this.ButtonClearQueryBehavior.Caption = "清除查询行为(&L)";
            this.ButtonClearQueryBehavior.Id = 17;
            this.ButtonClearQueryBehavior.Name = "ButtonClearQueryBehavior";
            this.ButtonClearQueryBehavior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonClearQueryBehavior_ItemClick);
            // 
            // MenuConfig
            // 
            this.MenuConfig.Caption = "配置(&C)";
            this.MenuConfig.Glyph = global::PAO.Report.Properties.Resources.edittask_16x16;
            this.MenuConfig.Id = 7;
            this.MenuConfig.LargeGlyph = global::PAO.Report.Properties.Resources.edittask_32x32;
            this.MenuConfig.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRecoverLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonProperties, true)});
            this.MenuConfig.Name = "MenuConfig";
            // 
            // ButtonRecoverLayout
            // 
            this.ButtonRecoverLayout.Caption = "恢复默认布局(R)";
            this.ButtonRecoverLayout.Id = 8;
            this.ButtonRecoverLayout.Name = "ButtonRecoverLayout";
            this.ButtonRecoverLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonRecoverLayout_ItemClick);
            // 
            // ButtonProperties
            // 
            this.ButtonProperties.Caption = "属性(&P)";
            this.ButtonProperties.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonProperties.Glyph")));
            this.ButtonProperties.Id = 1;
            this.ButtonProperties.Name = "ButtonProperties";
            this.ButtonProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonProperties_ItemClick);
            // 
            // BarExtend
            // 
            this.BarExtend.BarName = "扩展工具条";
            this.BarExtend.DockCol = 1;
            this.BarExtend.DockRow = 0;
            this.BarExtend.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarExtend.OptionsBar.AllowQuickCustomization = false;
            this.BarExtend.OptionsBar.DisableClose = true;
            this.BarExtend.OptionsBar.DrawBorder = false;
            this.BarExtend.Text = "扩展工具条";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(880, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 527);
            this.barDockControlBottom.Size = new System.Drawing.Size(880, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(880, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 496);
            // 
            // DockManager
            // 
            this.DockManager.Form = this;
            this.DockManager.MenuManager = this.BarManager;
            this.DockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.DockPanelTables});
            this.DockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // DockPanelTables
            // 
            this.DockPanelTables.Controls.Add(this.DockPanelData_Container);
            this.DockPanelTables.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.DockPanelTables.ID = new System.Guid("44fd46ae-53ca-48e7-a539-953c949c76fb");
            this.DockPanelTables.Location = new System.Drawing.Point(0, 31);
            this.DockPanelTables.Name = "DockPanelTables";
            this.DockPanelTables.Options.AllowDockAsTabbedDocument = false;
            this.DockPanelTables.Options.AllowFloating = false;
            this.DockPanelTables.Options.ShowCloseButton = false;
            this.DockPanelTables.OriginalSize = new System.Drawing.Size(234, 200);
            this.DockPanelTables.Size = new System.Drawing.Size(234, 496);
            this.DockPanelTables.Text = "数据";
            // 
            // DockPanelData_Container
            // 
            this.DockPanelData_Container.Controls.Add(this.AccordionControl);
            this.DockPanelData_Container.Location = new System.Drawing.Point(4, 23);
            this.DockPanelData_Container.Name = "DockPanelData_Container";
            this.DockPanelData_Container.Size = new System.Drawing.Size(226, 469);
            this.DockPanelData_Container.TabIndex = 0;
            // 
            // AccordionControl
            // 
            this.AccordionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccordionControl.Location = new System.Drawing.Point(0, 0);
            this.AccordionControl.Name = "AccordionControl";
            this.AccordionControl.Size = new System.Drawing.Size(226, 469);
            this.AccordionControl.TabIndex = 0;
            this.AccordionControl.Text = "accordionControl1";
            // 
            // RepositoryItemTextEditCaption
            // 
            this.RepositoryItemTextEditCaption.AutoHeight = false;
            this.RepositoryItemTextEditCaption.Name = "RepositoryItemTextEditCaption";
            // 
            // LayoutControl
            // 
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(234, 31);
            this.LayoutControl.MenuManager = this.BarManager;
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(685, 219, 250, 350);
            this.LayoutControl.Root = this.LayoutControlGroupRoot;
            this.LayoutControl.Size = new System.Drawing.Size(646, 496);
            this.LayoutControl.TabIndex = 0;
            this.LayoutControl.Text = "布局控件";
            this.LayoutControl.ItemAdded += new System.EventHandler(this.LayoutControl_ItemAdded);
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "Root";
            this.LayoutControlGroupRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(646, 496);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.DockPanelTables);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(880, 527);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).EndInit();
            this.DockPanelTables.ResumeLayout(false);
            this.DockPanelData_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccordionControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonProperties;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem ButtonPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditCaption;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarSubItem MenuConfig;
        private DevExpress.XtraBars.BarButtonItem ButtonRecoverLayout;
        private DevExpress.XtraBars.Docking.DockManager DockManager;
        private DevExpress.XtraBars.Docking.DockPanel DockPanelTables;
        private DevExpress.XtraBars.Docking.ControlContainer DockPanelData_Container;
        private System.Windows.Forms.BindingSource BindingSourceTable;
        private DevExpress.XtraBars.BarButtonItem ButtonQuery;
        private DevExpress.XtraBars.BarSubItem MenuData;
        private DevExpress.XtraBars.BarButtonItem ButtonRebuildDataFields;
        private DevExpress.XtraBars.BarButtonItem ButtonClearDataFields;
        private DevExpress.XtraBars.Navigation.AccordionControl AccordionControl;
        private DevExpress.XtraBars.BarButtonItem ButtonSetupQueryBehavior;
        private DevExpress.XtraBars.BarButtonItem ButtonClearQueryBehavior;
        private DevExpress.XtraBars.Bar BarExtend;
    }
}
