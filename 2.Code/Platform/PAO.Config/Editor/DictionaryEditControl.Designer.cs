namespace PAO.Config.Editor
{
    partial class DictionaryEditControl
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
            this.ColumnObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridViewList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridControlList = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceList = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetList = new PAO.Config.Editor.DataSetList();
            this.BarManagerObject = new DevExpress.XtraBars.BarManager(this.components);
            this.BarToolObject = new DevExpress.XtraBars.Bar();
            this.ButtonAdd = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).BeginInit();
            this.SuspendLayout();
            // 
            // ColumnObject
            // 
            this.ColumnObject.Caption = "对象";
            this.ColumnObject.FieldName = "Value";
            this.ColumnObject.Name = "ColumnObject";
            this.ColumnObject.OptionsColumn.ReadOnly = true;
            this.ColumnObject.Visible = true;
            this.ColumnObject.VisibleIndex = 1;
            // 
            // GridViewList
            // 
            this.GridViewList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnIndex,
            this.ColumnObject});
            this.GridViewList.GridControl = this.GridControlList;
            this.GridViewList.Name = "GridViewList";
            this.GridViewList.OptionsCustomization.AllowSort = false;
            this.GridViewList.OptionsView.ShowGroupPanel = false;
            this.GridViewList.RowHeight = 30;
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.Caption = "键";
            this.ColumnIndex.FieldName = "Key";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ColumnIndex.OptionsColumn.FixedWidth = true;
            this.ColumnIndex.Visible = true;
            this.ColumnIndex.VisibleIndex = 0;
            this.ColumnIndex.Width = 76;
            // 
            // GridControlList
            // 
            this.GridControlList.DataSource = this.BindingSourceList;
            this.GridControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlList.Location = new System.Drawing.Point(0, 28);
            this.GridControlList.MainView = this.GridViewList;
            this.GridControlList.MenuManager = this.BarManagerObject;
            this.GridControlList.Name = "GridControlList";
            this.GridControlList.Size = new System.Drawing.Size(570, 401);
            this.GridControlList.TabIndex = 5;
            this.GridControlList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewList});
            // 
            // BindingSourceList
            // 
            this.BindingSourceList.DataMember = "Element";
            this.BindingSourceList.DataSource = this.DataSetList;
            this.BindingSourceList.Sort = "";
            // 
            // DataSetList
            // 
            this.DataSetList.DataSetName = "DataSetList";
            this.DataSetList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.ButtonAdd,
            this.ButtonDelete});
            this.BarManagerObject.MaxItemId = 10;
            // 
            // BarToolObject
            // 
            this.BarToolObject.BarName = "扩展工具条";
            this.BarToolObject.DockCol = 0;
            this.BarToolObject.DockRow = 0;
            this.BarToolObject.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarToolObject.HideWhenMerging = DevExpress.Utils.DefaultBoolean.True;
            this.BarToolObject.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu)});
            this.BarToolObject.OptionsBar.AllowQuickCustomization = false;
            this.BarToolObject.OptionsBar.DisableClose = true;
            this.BarToolObject.OptionsBar.DisableCustomization = true;
            this.BarToolObject.OptionsBar.DrawDragBorder = false;
            this.BarToolObject.OptionsBar.UseWholeRow = true;
            this.BarToolObject.Text = "对象工具条";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Caption = "新增(&A)";
            this.ButtonAdd.Glyph = global::PAO.Config.Properties.Resources.add_16x16;
            this.ButtonAdd.Id = 4;
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAdd_ItemClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Caption = "删除(&D)";
            this.ButtonDelete.Glyph = global::PAO.Config.Properties.Resources.remove_16x16;
            this.ButtonDelete.Id = 5;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonDelete_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(570, 28);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 429);
            this.barDockControl2.Size = new System.Drawing.Size(570, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 28);
            this.barDockControl3.Size = new System.Drawing.Size(0, 401);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(570, 28);
            this.barDockControl4.Size = new System.Drawing.Size(0, 401);
            // 
            // DictionaryEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControlList);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "DictionaryEditControl";
            this.Leave += new System.EventHandler(this.DictionaryEditControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn ColumnObject;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewList;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnIndex;
        private DevExpress.XtraGrid.GridControl GridControlList;
        private System.Windows.Forms.BindingSource BindingSourceList;
        private DevExpress.XtraBars.BarManager BarManagerObject;
        private DevExpress.XtraBars.Bar BarToolObject;
        private DevExpress.XtraBars.BarButtonItem ButtonAdd;
        private DevExpress.XtraBars.BarButtonItem ButtonDelete;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DataSetList DataSetList;
    }
}
