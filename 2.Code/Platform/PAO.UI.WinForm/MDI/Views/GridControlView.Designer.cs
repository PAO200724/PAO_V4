namespace PAO.UI.WinForm.MDI.Views
{
    partial class GridControlView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridControlView));
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ButtonProperties = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonAutoFilter = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonPrint = new DevExpress.XtraBars.BarButtonItem();
            this.EditItemCaption = new DevExpress.XtraBars.BarEditItem();
            this.RepositoryItemTextEditCaption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.CardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.AdvBandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.BandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LayoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.TileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.PopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl.Location = new System.Drawing.Point(0, 0);
            this.GridControl.MainView = this.GridView;
            this.GridControl.MenuManager = this.BarManager;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(517, 491);
            this.GridControl.TabIndex = 0;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView,
            this.CardView,
            this.AdvBandedGridView,
            this.BandedGridView,
            this.LayoutView,
            this.TileView});
            // 
            // GridView
            // 
            this.GridView.GridControl = this.GridControl;
            this.GridView.Name = "GridView";
            // 
            // BarManager
            // 
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonProperties,
            this.ButtonAutoFilter,
            this.ButtonExport,
            this.ButtonPrint,
            this.EditItemCaption});
            this.BarManager.MaxItemId = 6;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEditCaption});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(517, 0);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 491);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(517, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 491);
            // 
            // ButtonProperties
            // 
            this.ButtonProperties.Caption = "属性(&P)...";
            this.ButtonProperties.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonProperties.Glyph")));
            this.ButtonProperties.Id = 1;
            this.ButtonProperties.Name = "ButtonProperties";
            // 
            // ButtonAutoFilter
            // 
            this.ButtonAutoFilter.Caption = "自动过滤框(&A)";
            this.ButtonAutoFilter.Id = 2;
            this.ButtonAutoFilter.Name = "ButtonAutoFilter";
            // 
            // ButtonExport
            // 
            this.ButtonExport.Caption = "导出(&E)...";
            this.ButtonExport.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonExport.Glyph")));
            this.ButtonExport.Id = 3;
            this.ButtonExport.Name = "ButtonExport";
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.Caption = "打印(&P)...";
            this.ButtonPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonPrint.Glyph")));
            this.ButtonPrint.Id = 4;
            this.ButtonPrint.Name = "ButtonPrint";
            // 
            // EditItemCaption
            // 
            this.EditItemCaption.Caption = "标题(&C)";
            this.EditItemCaption.Edit = this.RepositoryItemTextEditCaption;
            this.EditItemCaption.EditWidth = 192;
            this.EditItemCaption.Id = 5;
            this.EditItemCaption.Name = "EditItemCaption";
            // 
            // RepositoryItemTextEditCaption
            // 
            this.RepositoryItemTextEditCaption.AutoHeight = false;
            this.RepositoryItemTextEditCaption.Name = "RepositoryItemTextEditCaption";
            // 
            // CardView
            // 
            this.CardView.FocusedCardTopFieldIndex = 0;
            this.CardView.GridControl = this.GridControl;
            this.CardView.Name = "CardView";
            // 
            // AdvBandedGridView
            // 
            this.AdvBandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.AdvBandedGridView.GridControl = this.GridControl;
            this.AdvBandedGridView.Name = "AdvBandedGridView";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            // 
            // BandedGridView
            // 
            this.BandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.BandedGridView.GridControl = this.GridControl;
            this.BandedGridView.Name = "BandedGridView";
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            // 
            // LayoutView
            // 
            this.LayoutView.GridControl = this.GridControl;
            this.LayoutView.Name = "LayoutView";
            this.LayoutView.TemplateCard = null;
            // 
            // TileView
            // 
            this.TileView.GridControl = this.GridControl;
            this.TileView.Name = "TileView";
            // 
            // PopupMenu
            // 
            this.PopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonAutoFilter, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.EditItemCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonProperties, true)});
            this.PopupMenu.Manager = this.BarManager;
            this.PopupMenu.Name = "PopupMenu";
            // 
            // GridControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GridControlView";
            this.Size = new System.Drawing.Size(517, 491);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView;
        private DevExpress.XtraGrid.Views.Card.CardView CardView;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView AdvBandedGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView BandedGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Layout.LayoutView LayoutView;
        private DevExpress.XtraGrid.Views.Tile.TileView TileView;
        private DevExpress.XtraBars.PopupMenu PopupMenu;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonProperties;
        private DevExpress.XtraBars.BarButtonItem ButtonAutoFilter;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem ButtonPrint;
        private DevExpress.XtraBars.BarEditItem EditItemCaption;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditCaption;
    }
}
