﻿namespace PAO.Config.PaoConfig
{
    partial class DataFilterEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFilterEditControl));
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.ButtonAnd = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonOr = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonSql = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.TreeListDataFilter = new DevExpress.XtraTreeList.TreeList();
            this.ColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnArgument = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnFilter = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnDataType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.BindingSourceDataFilter = new System.Windows.Forms.BindingSource(this.components);
            this.ImageCollectionDataFilter = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListDataFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDataFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionDataFilter)).BeginInit();
            this.SuspendLayout();
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
            this.ButtonAnd,
            this.ButtonOr,
            this.ButtonSql,
            this.ButtonDelete});
            this.BarManager.MaxItemId = 4;
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonAnd),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonOr),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonSql, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarTools.Text = "工具条";
            // 
            // ButtonAnd
            // 
            this.ButtonAnd.Caption = "&AND";
            this.ButtonAnd.Id = 0;
            this.ButtonAnd.Name = "ButtonAnd";
            this.ButtonAnd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAnd_ItemClick);
            // 
            // ButtonOr
            // 
            this.ButtonOr.Caption = "&OR";
            this.ButtonOr.Id = 1;
            this.ButtonOr.Name = "ButtonOr";
            this.ButtonOr.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonOr_ItemClick);
            // 
            // ButtonSql
            // 
            this.ButtonSql.Caption = "&SQL";
            this.ButtonSql.Id = 2;
            this.ButtonSql.Name = "ButtonSql";
            this.ButtonSql.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonSql_ItemClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Caption = "删除(&D)";
            this.ButtonDelete.Glyph = global::PAO.Config.Properties.Resources.remove_16x16;
            this.ButtonDelete.Id = 3;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(792, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 518);
            this.barDockControlBottom.Size = new System.Drawing.Size(792, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 487);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(792, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 487);
            // 
            // TreeListDataFilter
            // 
            this.TreeListDataFilter.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColumnName,
            this.ColumnArgument,
            this.ColumnCaption,
            this.ColumnFilter,
            this.ColumnDataType});
            this.TreeListDataFilter.DataSource = this.BindingSourceDataFilter;
            this.TreeListDataFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeListDataFilter.Location = new System.Drawing.Point(0, 31);
            this.TreeListDataFilter.Name = "TreeListDataFilter";
            this.TreeListDataFilter.OptionsBehavior.PopulateServiceColumns = true;
            this.TreeListDataFilter.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListDataFilter.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListDataFilter.Size = new System.Drawing.Size(792, 487);
            this.TreeListDataFilter.TabIndex = 4;
            this.TreeListDataFilter.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.TreeListDataFilter_GetNodeDisplayValue);
            this.TreeListDataFilter.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeListDataFilter_FocusedNodeChanged);
            this.TreeListDataFilter.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.TreeListDataFilter_CellValueChanged);
            this.TreeListDataFilter.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.TreeListDataFilter_ShowingEditor);
            // 
            // ColumnName
            // 
            this.ColumnName.Caption = "名称";
            this.ColumnName.FieldName = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Visible = true;
            this.ColumnName.VisibleIndex = 0;
            this.ColumnName.Width = 147;
            // 
            // ColumnArgument
            // 
            this.ColumnArgument.Caption = "参数";
            this.ColumnArgument.FieldName = "ParameterName";
            this.ColumnArgument.Name = "ColumnArgument";
            this.ColumnArgument.Visible = true;
            this.ColumnArgument.VisibleIndex = 1;
            this.ColumnArgument.Width = 126;
            // 
            // ColumnCaption
            // 
            this.ColumnCaption.Caption = "标题";
            this.ColumnCaption.FieldName = "Caption";
            this.ColumnCaption.Name = "ColumnCaption";
            this.ColumnCaption.Visible = true;
            this.ColumnCaption.VisibleIndex = 3;
            this.ColumnCaption.Width = 141;
            // 
            // ColumnFilter
            // 
            this.ColumnFilter.Caption = "过滤语句";
            this.ColumnFilter.FieldName = "Sql";
            this.ColumnFilter.Name = "ColumnFilter";
            this.ColumnFilter.Visible = true;
            this.ColumnFilter.VisibleIndex = 4;
            this.ColumnFilter.Width = 159;
            // 
            // ColumnDataType
            // 
            this.ColumnDataType.AppearanceCell.Options.UseTextOptions = true;
            this.ColumnDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ColumnDataType.Caption = "数据类型";
            this.ColumnDataType.FieldName = "DataType";
            this.ColumnDataType.Name = "ColumnDataType";
            this.ColumnDataType.Visible = true;
            this.ColumnDataType.VisibleIndex = 2;
            this.ColumnDataType.Width = 112;
            // 
            // BindingSourceDataFilter
            // 
            this.BindingSourceDataFilter.DataSource = typeof(PAO.Config.PaoConfig.DataFilterInfo);
            // 
            // ImageCollectionDataFilter
            // 
            this.ImageCollectionDataFilter.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollectionDataFilter.ImageStream")));
            // 
            // DataFilterEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreeListDataFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DataFilterEditControl";
            this.Size = new System.Drawing.Size(792, 518);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListDataFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDataFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionDataFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTreeList.TreeList TreeListDataFilter;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnArgument;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnFilter;
        private DevExpress.Utils.ImageCollection ImageCollectionDataFilter;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnCaption;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnDataType;
        private DevExpress.XtraBars.BarButtonItem ButtonAnd;
        private DevExpress.XtraBars.BarButtonItem ButtonOr;
        private DevExpress.XtraBars.BarButtonItem ButtonSql;
        private System.Windows.Forms.BindingSource BindingSourceDataFilter;
        private DevExpress.XtraBars.BarButtonItem ButtonDelete;
    }
}
