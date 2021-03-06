﻿namespace PAO.Config.Editor
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
            this.BarManagerObject = new DevExpress.XtraBars.BarManager(this.components);
            this.BarToolObject = new DevExpress.XtraBars.Bar();
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
            this.DataSetList = new PAO.Config.Editor.DataSetList();
            this.GridViewList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnObject = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetList)).BeginInit();
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
            this.ButtonAdd,
            this.ButtonDelete,
            this.ButtonMoveUp,
            this.ButtonMoveDown});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonMoveUp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonMoveDown)});
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
            this.ButtonAdd.LargeGlyph = global::PAO.Config.Properties.Resources.add_32x32;
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
            this.barDockControl1.Size = new System.Drawing.Size(623, 28);
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
            this.barDockControl3.Location = new System.Drawing.Point(0, 28);
            this.barDockControl3.Size = new System.Drawing.Size(0, 479);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(623, 28);
            this.barDockControl4.Size = new System.Drawing.Size(0, 479);
            // 
            // GridControlList
            // 
            this.GridControlList.DataSource = this.BindingSourceList;
            this.GridControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlList.Location = new System.Drawing.Point(0, 28);
            this.GridControlList.MainView = this.GridViewList;
            this.GridControlList.MenuManager = this.BarManagerObject;
            this.GridControlList.Name = "GridControlList";
            this.GridControlList.Size = new System.Drawing.Size(623, 479);
            this.GridControlList.TabIndex = 4;
            this.GridControlList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewList});
            // 
            // BindingSourceList
            // 
            this.BindingSourceList.DataMember = "Element";
            this.BindingSourceList.DataSource = this.DataSetList;
            this.BindingSourceList.Sort = "Key";
            this.BindingSourceList.PositionChanged += new System.EventHandler(this.BindingSourceList_PositionChanged);
            // 
            // DataSetList
            // 
            this.DataSetList.DataSetName = "DataSetList";
            this.DataSetList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.Caption = "索引号";
            this.ColumnIndex.FieldName = "Key";
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
            this.ColumnObject.FieldName = "Value";
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
            ((System.ComponentModel.ISupportInitialize)(this.DataSetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManagerObject;
        private DevExpress.XtraBars.Bar BarToolObject;
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
        private DataSetList DataSetList;
    }
}
