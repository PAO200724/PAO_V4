﻿namespace PAO.Report.Displayers
{
    partial class GridControlDataDisplayer
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
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.AdvBandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.GridBandMain = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LayoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.MenuViewType = new DevExpress.XtraBars.BarSubItem();
            this.ButtonViewType = new DevExpress.XtraBars.BarListItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonPrint = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonRecoverLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ButtonProperty = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl.Location = new System.Drawing.Point(0, 31);
            this.GridControl.MainView = this.GridView;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(517, 460);
            this.GridControl.TabIndex = 0;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView,
            this.CardView,
            this.AdvBandedGridView,
            this.LayoutView});
            // 
            // GridView
            // 
            this.GridView.GridControl = this.GridControl;
            this.GridView.Name = "GridView";
            this.GridView.OptionsBehavior.ReadOnly = true;
            this.GridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.GridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.GridView.OptionsView.ColumnAutoWidth = false;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowGroupPanel = false;
            // 
            // CardView
            // 
            this.CardView.FocusedCardTopFieldIndex = 0;
            this.CardView.GridControl = this.GridControl;
            this.CardView.Name = "CardView";
            this.CardView.OptionsBehavior.ReadOnly = true;
            // 
            // AdvBandedGridView
            // 
            this.AdvBandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.GridBandMain});
            this.AdvBandedGridView.GridControl = this.GridControl;
            this.AdvBandedGridView.Name = "AdvBandedGridView";
            this.AdvBandedGridView.OptionsBehavior.ReadOnly = true;
            // 
            // GridBandMain
            // 
            this.GridBandMain.Name = "GridBandMain";
            this.GridBandMain.VisibleIndex = 0;
            // 
            // LayoutView
            // 
            this.LayoutView.GridControl = this.GridControl;
            this.LayoutView.Name = "LayoutView";
            this.LayoutView.OptionsBehavior.ReadOnly = true;
            this.LayoutView.TemplateCard = null;
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarTools});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonExport,
            this.ButtonPrint,
            this.ButtonRecoverLayout,
            this.ButtonViewType,
            this.MenuViewType,
            this.ButtonProperty});
            this.BarManager.MaxItemId = 14;
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuViewType),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRecoverLayout, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonProperty, true)});
            this.BarTools.Text = "工具条";
            this.BarTools.Visible = false;
            // 
            // MenuViewType
            // 
            this.MenuViewType.Caption = "表格类型(&T)";
            this.MenuViewType.Id = 9;
            this.MenuViewType.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonViewType)});
            this.MenuViewType.Name = "MenuViewType";
            // 
            // ButtonViewType
            // 
            this.ButtonViewType.Caption = "表格类型(&T)";
            this.ButtonViewType.Id = 8;
            this.ButtonViewType.Name = "ButtonViewType";
            this.ButtonViewType.ShowChecks = true;
            this.ButtonViewType.Strings.AddRange(new object[] {
            "二维表格视图",
            "复杂表格视图",
            "布局视图",
            "卡片视图"});
            this.ButtonViewType.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.ButtonViewType_ListItemClick);
            // 
            // ButtonExport
            // 
            this.ButtonExport.Caption = "导出(&E)...";
            this.ButtonExport.Glyph = global::PAO.Report.Properties.Resources.export_16x16;
            this.ButtonExport.Id = 1;
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonExport_ItemClick);
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.Caption = "打印(&P)...";
            this.ButtonPrint.Glyph = global::PAO.Report.Properties.Resources.printer_16x16;
            this.ButtonPrint.Id = 2;
            this.ButtonPrint.Name = "ButtonPrint";
            this.ButtonPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonPrint_ItemClick);
            // 
            // ButtonRecoverLayout
            // 
            this.ButtonRecoverLayout.Caption = "恢复默认布局(&R)";
            this.ButtonRecoverLayout.Glyph = global::PAO.Report.Properties.Resources.reset2_16x16;
            this.ButtonRecoverLayout.Id = 3;
            this.ButtonRecoverLayout.LargeGlyph = global::PAO.Report.Properties.Resources.reset2_32x32;
            this.ButtonRecoverLayout.Name = "ButtonRecoverLayout";
            this.ButtonRecoverLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonRecoverLayout_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(517, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 491);
            this.barDockControlBottom.Size = new System.Drawing.Size(517, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 460);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(517, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 460);
            // 
            // ButtonProperty
            // 
            this.ButtonProperty.Caption = "属性(&P)";
            this.ButtonProperty.Glyph = global::PAO.Report.Properties.Resources.properties_16x16;
            this.ButtonProperty.Id = 13;
            this.ButtonProperty.Name = "ButtonProperty";
            this.ButtonProperty.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonProperty_ItemClick);
            // 
            // GridControlDataDisplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GridControlDataDisplayer";
            this.Size = new System.Drawing.Size(517, 491);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView;
        private DevExpress.XtraGrid.Views.Card.CardView CardView;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView AdvBandedGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand GridBandMain;
        private DevExpress.XtraGrid.Views.Layout.LayoutView LayoutView;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem ButtonPrint;
        private DevExpress.XtraBars.BarButtonItem ButtonRecoverLayout;
        private DevExpress.XtraBars.BarListItem ButtonViewType;
        private DevExpress.XtraBars.BarSubItem MenuViewType;
        private DevExpress.XtraBars.BarButtonItem ButtonProperty;
    }
}
