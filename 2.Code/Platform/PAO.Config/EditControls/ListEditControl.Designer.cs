namespace PAO.Config.EditControls
{
    partial class ListEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListEditControl));
            this.BarManagerObject = new DevExpress.XtraBars.BarManager(this.components);
            this.BarToolObject = new DevExpress.XtraBars.Bar();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonImport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonAdd = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonMoveUp = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonMoveDown = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.GridControlList = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceList = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnObject = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewList)).BeginInit();
            this.SuspendLayout();
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
            this.BarManagerObject.Form = this;
            this.BarManagerObject.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonExport,
            this.ButtonImport,
            this.ButtonAdd,
            this.ButtonDelete,
            this.ButtonMoveUp,
            this.ButtonMoveDown});
            this.BarManagerObject.MaxItemId = 8;
            // 
            // BarToolObject
            // 
            this.BarToolObject.BarName = "对象工具条";
            this.BarToolObject.DockCol = 0;
            this.BarToolObject.DockRow = 0;
            this.BarToolObject.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarToolObject.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonImport, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonMoveUp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonMoveDown)});
            this.BarToolObject.OptionsBar.AllowQuickCustomization = false;
            this.BarToolObject.OptionsBar.DisableCustomization = true;
            this.BarToolObject.Text = "对象工具条";
            // 
            // ButtonExport
            // 
            this.ButtonExport.Caption = "导出(&E)";
            this.ButtonExport.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonExport.Glyph")));
            this.ButtonExport.Id = 2;
            this.ButtonExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonExport.LargeGlyph")));
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonExport_ItemClick);
            // 
            // ButtonImport
            // 
            this.ButtonImport.Caption = "导入(&I)";
            this.ButtonImport.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonImport.Glyph")));
            this.ButtonImport.Id = 3;
            this.ButtonImport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ButtonImport.LargeGlyph")));
            this.ButtonImport.Name = "ButtonImport";
            this.ButtonImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonImport_ItemClick);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Caption = "新增(&A)";
            this.ButtonAdd.Glyph = global::PAO.Config.Properties.Resources.addfile_16x16;
            this.ButtonAdd.Id = 4;
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAdd_ItemClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Caption = "删除(&D)";
            this.ButtonDelete.Glyph = global::PAO.Config.Properties.Resources.removeitem_16x16;
            this.ButtonDelete.Id = 5;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonDelete_ItemClick);
            // 
            // ButtonMoveUp
            // 
            this.ButtonMoveUp.Caption = "上移(&U)";
            this.ButtonMoveUp.Glyph = global::PAO.Config.Properties.Resources.moveup_16x16;
            this.ButtonMoveUp.Id = 6;
            this.ButtonMoveUp.LargeGlyph = global::PAO.Config.Properties.Resources.moveup_32x32;
            this.ButtonMoveUp.Name = "ButtonMoveUp";
            this.ButtonMoveUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonMoveUp_ItemClick);
            // 
            // ButtonMoveDown
            // 
            this.ButtonMoveDown.Caption = "下移(&D)";
            this.ButtonMoveDown.Glyph = global::PAO.Config.Properties.Resources.movedown_16x16;
            this.ButtonMoveDown.Id = 7;
            this.ButtonMoveDown.LargeGlyph = global::PAO.Config.Properties.Resources.movedown_32x32;
            this.ButtonMoveDown.Name = "ButtonMoveDown";
            this.ButtonMoveDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonMoveDown_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(623, 31);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 507);
            this.barDockControl2.Size = new System.Drawing.Size(623, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 31);
            this.barDockControl3.Size = new System.Drawing.Size(0, 476);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(623, 31);
            this.barDockControl4.Size = new System.Drawing.Size(0, 476);
            // 
            // GridControlList
            // 
            this.GridControlList.DataSource = this.BindingSourceList;
            this.GridControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlList.Location = new System.Drawing.Point(0, 31);
            this.GridControlList.MainView = this.GridViewList;
            this.GridControlList.MenuManager = this.BarManagerObject;
            this.GridControlList.Name = "GridControlList";
            this.GridControlList.Size = new System.Drawing.Size(623, 476);
            this.GridControlList.TabIndex = 4;
            this.GridControlList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewList});
            // 
            // BindingSourceList
            // 
            this.BindingSourceList.DataSource = typeof(PAO.Config.ListElement);
            this.BindingSourceList.PositionChanged += new System.EventHandler(this.BindingSourceList_PositionChanged);
            // 
            // GridViewList
            // 
            this.GridViewList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnIndex,
            this.ColumnObject});
            this.GridViewList.GridControl = this.GridControlList;
            this.GridViewList.Name = "GridViewList";
            this.GridViewList.OptionsBehavior.ReadOnly = true;
            this.GridViewList.OptionsCustomization.AllowSort = false;
            this.GridViewList.OptionsView.ShowGroupPanel = false;
            this.GridViewList.RowHeight = 30;
            this.GridViewList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColumnIndex, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.GridViewList.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.GridViewList_RowUpdated);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.Caption = "索引号";
            this.ColumnIndex.FieldName = "Index";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ColumnIndex.OptionsColumn.FixedWidth = true;
            this.ColumnIndex.Visible = true;
            this.ColumnIndex.VisibleIndex = 0;
            this.ColumnIndex.Width = 76;
            // 
            // ColumnObject
            // 
            this.ColumnObject.Caption = "对象";
            this.ColumnObject.FieldName = "Element";
            this.ColumnObject.Name = "ColumnObject";
            this.ColumnObject.Visible = true;
            this.ColumnObject.VisibleIndex = 1;
            // 
            // ListEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControlList);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "ListEditControl";
            this.Size = new System.Drawing.Size(623, 507);
            this.Leave += new System.EventHandler(this.ListEditControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManagerObject;
        private DevExpress.XtraBars.Bar BarToolObject;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem ButtonImport;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraGrid.GridControl GridControlList;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewList;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnIndex;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnObject;
        private System.Windows.Forms.BindingSource BindingSourceList;
        private DevExpress.XtraBars.BarButtonItem ButtonAdd;
        private DevExpress.XtraBars.BarButtonItem ButtonDelete;
        private DevExpress.XtraBars.BarButtonItem ButtonMoveUp;
        private DevExpress.XtraBars.BarButtonItem ButtonMoveDown;
    }
}
