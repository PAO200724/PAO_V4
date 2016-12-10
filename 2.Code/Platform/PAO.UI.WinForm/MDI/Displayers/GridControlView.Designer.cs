﻿namespace PAO.UI.WinForm.MDI.Displayers
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
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.AdvBandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.BandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.LayoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.TileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridView)).BeginInit();
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
            // GridControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl);
            this.Name = "GridControlView";
            this.Size = new System.Drawing.Size(517, 491);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvBandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileView)).EndInit();
            this.ResumeLayout(false);

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
    }
}
