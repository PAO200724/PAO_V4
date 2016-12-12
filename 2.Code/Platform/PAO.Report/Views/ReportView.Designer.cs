﻿namespace PAO.Report.Views
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportView));
            this.GridControlData = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceTable = new System.Windows.Forms.BindingSource();
            this.GridViewTable = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.GridBindTable = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColumnTableName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColumnTableLoadingProcess = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.EditItemLoadingProcess = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.ColumnTableDataCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.EditItemDataAction = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager();
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.ButtonQuery = new DevExpress.XtraBars.BarButtonItem();
            this.MenuData = new DevExpress.XtraBars.BarSubItem();
            this.ButtonRebuildDataFields = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonClearDataFields = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonPrint = new DevExpress.XtraBars.BarButtonItem();
            this.MenuConfig = new DevExpress.XtraBars.BarSubItem();
            this.ButtonRecoverLayout = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonProperties = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DockManager = new DevExpress.XtraBars.Docking.DockManager();
            this.PanelContainerLeft = new DevExpress.XtraBars.Docking.DockPanel();
            this.DockPanelTables = new DevExpress.XtraBars.Docking.DockPanel();
            this.DockPanelData_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.DockPanelParameters = new DevExpress.XtraBars.Docking.DockPanel();
            this.DockPanelParameter_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.VGridControlParameters = new DevExpress.XtraVerticalGrid.VGridControl();
            this.RepositoryItemTextEditCaption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.EditItemIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemLoadingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemDataAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).BeginInit();
            this.PanelContainerLeft.SuspendLayout();
            this.DockPanelTables.SuspendLayout();
            this.DockPanelData_Container.SuspendLayout();
            this.DockPanelParameters.SuspendLayout();
            this.DockPanelParameter_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VGridControlParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControlData
            // 
            this.GridControlData.DataSource = this.BindingSourceTable;
            this.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlData.Location = new System.Drawing.Point(0, 0);
            this.GridControlData.MainView = this.GridViewTable;
            this.GridControlData.MenuManager = this.BarManager;
            this.GridControlData.Name = "GridControlData";
            this.GridControlData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.EditItemLoadingProcess,
            this.EditItemDataAction,
            this.EditItemIcon});
            this.GridControlData.Size = new System.Drawing.Size(226, 199);
            this.GridControlData.TabIndex = 0;
            this.GridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewTable});
            // 
            // BindingSourceTable
            // 
            this.BindingSourceTable.DataSource = typeof(PAO.Report.ReportDataTable);
            // 
            // GridViewTable
            // 
            this.GridViewTable.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.GridBindTable});
            this.GridViewTable.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.ColumnTableName,
            this.ColumnTableLoadingProcess,
            this.ColumnTableDataCount});
            this.GridViewTable.GridControl = this.GridControlData;
            this.GridViewTable.Name = "GridViewTable";
            this.GridViewTable.OptionsBehavior.ReadOnly = true;
            this.GridViewTable.OptionsDetail.AllowZoomDetail = false;
            this.GridViewTable.OptionsDetail.ShowDetailTabs = false;
            this.GridViewTable.OptionsDetail.SmartDetailExpand = false;
            this.GridViewTable.OptionsDetail.SmartDetailHeight = true;
            this.GridViewTable.OptionsView.ColumnAutoWidth = true;
            this.GridViewTable.OptionsView.ShowBands = false;
            this.GridViewTable.OptionsView.ShowColumnHeaders = false;
            this.GridViewTable.OptionsView.ShowDetailButtons = false;
            this.GridViewTable.OptionsView.ShowGroupPanel = false;
            this.GridViewTable.OptionsView.ShowIndicator = false;
            // 
            // GridBindTable
            // 
            this.GridBindTable.Caption = "表";
            this.GridBindTable.Columns.Add(this.ColumnTableName);
            this.GridBindTable.Columns.Add(this.ColumnTableLoadingProcess);
            this.GridBindTable.Columns.Add(this.ColumnTableDataCount);
            this.GridBindTable.Name = "GridBindTable";
            this.GridBindTable.VisibleIndex = 0;
            this.GridBindTable.Width = 1402;
            // 
            // ColumnTableName
            // 
            this.ColumnTableName.Caption = "表名";
            this.ColumnTableName.FieldName = "TableName";
            this.ColumnTableName.Name = "ColumnTableName";
            this.ColumnTableName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.ColumnTableName.Visible = true;
            this.ColumnTableName.Width = 1402;
            // 
            // ColumnTableLoadingProcess
            // 
            this.ColumnTableLoadingProcess.Caption = "加载进度";
            this.ColumnTableLoadingProcess.ColumnEdit = this.EditItemLoadingProcess;
            this.ColumnTableLoadingProcess.FieldName = "LoadingProcess";
            this.ColumnTableLoadingProcess.Name = "ColumnTableLoadingProcess";
            this.ColumnTableLoadingProcess.RowIndex = 1;
            this.ColumnTableLoadingProcess.Visible = true;
            this.ColumnTableLoadingProcess.Width = 1282;
            // 
            // EditItemLoadingProcess
            // 
            this.EditItemLoadingProcess.Name = "EditItemLoadingProcess";
            this.EditItemLoadingProcess.Stopped = true;
            // 
            // ColumnTableDataCount
            // 
            this.ColumnTableDataCount.Caption = "数据行数";
            this.ColumnTableDataCount.ColumnEdit = this.EditItemDataAction;
            this.ColumnTableDataCount.FieldName = "DataCount";
            this.ColumnTableDataCount.Name = "ColumnTableDataCount";
            this.ColumnTableDataCount.OptionsColumn.FixedWidth = true;
            this.ColumnTableDataCount.RowIndex = 1;
            this.ColumnTableDataCount.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.ColumnTableDataCount.Visible = true;
            this.ColumnTableDataCount.Width = 120;
            // 
            // EditItemDataAction
            // 
            this.EditItemDataAction.AutoHeight = false;
            toolTipTitleItem5.Appearance.Image = global::PAO.Report.Properties.Resources.doublenext_16x16;
            toolTipTitleItem5.Appearance.Options.UseImage = true;
            toolTipTitleItem5.Image = global::PAO.Report.Properties.Resources.doublenext_16x16;
            toolTipTitleItem5.Text = "获取下一批数据";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "继续查询，获取下一批数据，此方法速度较快";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            toolTipTitleItem6.Appearance.Image = global::PAO.Report.Properties.Resources.last_16x16;
            toolTipTitleItem6.Appearance.Options.UseImage = true;
            toolTipTitleItem6.Image = global::PAO.Report.Properties.Resources.last_16x16;
            toolTipTitleItem6.Text = "获取所有数据";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "查询到最后一条数据为止，此方法较慢";
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            this.EditItemDataAction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::PAO.Report.Properties.Resources.next_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, superToolTip5, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::PAO.Report.Properties.Resources.last_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, superToolTip6, true)});
            this.EditItemDataAction.Name = "EditItemDataAction";
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarTools});
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
            this.ButtonClearDataFields});
            this.BarManager.MaxItemId = 16;
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
            this.BarTools.OptionsBar.DisableClose = true;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonClearDataFields)});
            this.MenuData.Name = "MenuData";
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
            this.ButtonProperties.Caption = "属性(&P)...";
            this.ButtonProperties.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonProperties.Glyph")));
            this.ButtonProperties.Id = 1;
            this.ButtonProperties.Name = "ButtonProperties";
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
            this.PanelContainerLeft});
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
            // PanelContainerLeft
            // 
            this.PanelContainerLeft.Controls.Add(this.DockPanelTables);
            this.PanelContainerLeft.Controls.Add(this.DockPanelParameters);
            this.PanelContainerLeft.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.PanelContainerLeft.ID = new System.Guid("1320a631-2bdf-4f76-ae69-31e33bbb9c83");
            this.PanelContainerLeft.Location = new System.Drawing.Point(0, 31);
            this.PanelContainerLeft.Name = "PanelContainerLeft";
            this.PanelContainerLeft.OriginalSize = new System.Drawing.Size(234, 200);
            this.PanelContainerLeft.Size = new System.Drawing.Size(234, 496);
            this.PanelContainerLeft.Text = "panelContainer1";
            // 
            // DockPanelTables
            // 
            this.DockPanelTables.Controls.Add(this.DockPanelData_Container);
            this.DockPanelTables.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.DockPanelTables.ID = new System.Guid("44fd46ae-53ca-48e7-a539-953c949c76fb");
            this.DockPanelTables.Location = new System.Drawing.Point(0, 0);
            this.DockPanelTables.Name = "DockPanelTables";
            this.DockPanelTables.Options.AllowDockAsTabbedDocument = false;
            this.DockPanelTables.Options.AllowFloating = false;
            this.DockPanelTables.Options.ShowCloseButton = false;
            this.DockPanelTables.OriginalSize = new System.Drawing.Size(234, 200);
            this.DockPanelTables.Size = new System.Drawing.Size(234, 226);
            this.DockPanelTables.Text = "数据";
            // 
            // DockPanelData_Container
            // 
            this.DockPanelData_Container.Controls.Add(this.GridControlData);
            this.DockPanelData_Container.Location = new System.Drawing.Point(4, 23);
            this.DockPanelData_Container.Name = "DockPanelData_Container";
            this.DockPanelData_Container.Size = new System.Drawing.Size(226, 199);
            this.DockPanelData_Container.TabIndex = 0;
            // 
            // DockPanelParameters
            // 
            this.DockPanelParameters.Controls.Add(this.DockPanelParameter_Container);
            this.DockPanelParameters.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.DockPanelParameters.ID = new System.Guid("ab3584d5-acc5-4fc2-8785-b22ac016b05d");
            this.DockPanelParameters.Location = new System.Drawing.Point(0, 226);
            this.DockPanelParameters.Name = "DockPanelParameters";
            this.DockPanelParameters.Options.AllowFloating = false;
            this.DockPanelParameters.Options.ShowCloseButton = false;
            this.DockPanelParameters.OriginalSize = new System.Drawing.Size(234, 239);
            this.DockPanelParameters.Size = new System.Drawing.Size(234, 270);
            this.DockPanelParameters.Text = "参数";
            // 
            // DockPanelParameter_Container
            // 
            this.DockPanelParameter_Container.Controls.Add(this.VGridControlParameters);
            this.DockPanelParameter_Container.Location = new System.Drawing.Point(4, 23);
            this.DockPanelParameter_Container.Name = "DockPanelParameter_Container";
            this.DockPanelParameter_Container.Size = new System.Drawing.Size(226, 243);
            this.DockPanelParameter_Container.TabIndex = 0;
            // 
            // VGridControlParameters
            // 
            this.VGridControlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VGridControlParameters.Location = new System.Drawing.Point(0, 0);
            this.VGridControlParameters.Name = "VGridControlParameters";
            this.VGridControlParameters.Size = new System.Drawing.Size(226, 243);
            this.VGridControlParameters.TabIndex = 0;
            // 
            // RepositoryItemTextEditCaption
            // 
            this.RepositoryItemTextEditCaption.AutoHeight = false;
            this.RepositoryItemTextEditCaption.Name = "RepositoryItemTextEditCaption";
            // 
            // EditItemIcon
            // 
            this.EditItemIcon.Name = "EditItemIcon";
            this.EditItemIcon.NullText = " ";
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
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(302, 439);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.PanelContainerLeft);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(880, 527);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemLoadingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemDataAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).EndInit();
            this.PanelContainerLeft.ResumeLayout(false);
            this.DockPanelTables.ResumeLayout(false);
            this.DockPanelData_Container.ResumeLayout(false);
            this.DockPanelParameters.ResumeLayout(false);
            this.DockPanelParameter_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VGridControlParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemIcon)).EndInit();
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
        private DevExpress.XtraGrid.GridControl GridControlData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView GridViewTable;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColumnTableName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColumnTableLoadingProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar EditItemLoadingProcess;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColumnTableDataCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit EditItemDataAction;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit EditItemIcon;
        private System.Windows.Forms.BindingSource BindingSourceTable;
        private DevExpress.XtraBars.Docking.DockPanel PanelContainerLeft;
        private DevExpress.XtraBars.Docking.DockPanel DockPanelParameters;
        private DevExpress.XtraBars.Docking.ControlContainer DockPanelParameter_Container;
        private DevExpress.XtraVerticalGrid.VGridControl VGridControlParameters;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand GridBindTable;
        private DevExpress.XtraBars.BarButtonItem ButtonQuery;
        private DevExpress.XtraBars.BarSubItem MenuData;
        private DevExpress.XtraBars.BarButtonItem ButtonRebuildDataFields;
        private DevExpress.XtraBars.BarButtonItem ButtonClearDataFields;
    }
}
