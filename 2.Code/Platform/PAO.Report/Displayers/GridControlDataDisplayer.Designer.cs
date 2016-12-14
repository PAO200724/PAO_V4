namespace PAO.Report.Displayers
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
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.GridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.CardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.AdvBandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.GridBandMain = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LayoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.TileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl.Location = new System.Drawing.Point(0, 0);
            this.GridControl.MainView = this.GridView;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(517, 491);
            this.GridControl.TabIndex = 0;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView,
            this.BandedGridView,
            this.CardView,
            this.AdvBandedGridView,
            this.LayoutView,
            this.TileView});
            // 
            // GridView
            // 
            this.GridView.GridControl = this.GridControl;
            this.GridView.Name = "GridView";
            this.GridView.OptionsBehavior.ReadOnly = true;
            this.GridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.GridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowGroupPanel = false;
            this.GridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
            // 
            // BandedGridView
            // 
            this.BandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.GridBand});
            this.BandedGridView.GridControl = this.GridControl;
            this.BandedGridView.Name = "BandedGridView";
            // 
            // GridBand
            // 
            this.GridBand.Name = "GridBand";
            this.GridBand.VisibleIndex = 0;
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
            this.GridBandMain});
            this.AdvBandedGridView.GridControl = this.GridControl;
            this.AdvBandedGridView.Name = "AdvBandedGridView";
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
            this.LayoutView.TemplateCard = null;
            // 
            // TileView
            // 
            this.TileView.GridControl = this.GridControl;
            this.TileView.Name = "TileView";
            // 
            // GridControlDataDisplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl);
            this.Name = "GridControlDataDisplayer";
            this.Size = new System.Drawing.Size(517, 491);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView;
        private DevExpress.XtraGrid.Views.Card.CardView CardView;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView AdvBandedGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand GridBandMain;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView BandedGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand GridBand;
        private DevExpress.XtraGrid.Views.Layout.LayoutView LayoutView;
        private DevExpress.XtraGrid.Views.Tile.TileView TileView;
    }
}
