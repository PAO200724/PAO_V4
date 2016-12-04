namespace PAO.Config.Controls.EditControls
{
    partial class AddonExtentionEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonExtentionEditControl));
            this.BindingSourceAddonPropertyInfo = new System.Windows.Forms.BindingSource(this.components);
            this.BarManagerObject = new DevExpress.XtraBars.BarManager(this.components);
            this.BarToolObject = new DevExpress.XtraBars.Bar();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonImport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.GridControlAddonExtention = new DevExpress.XtraGrid.GridControl();
            this.GridViewAddonExtention = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPropertyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnOrigionValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPropertyValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAddonPropertyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAddonExtention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAddonExtention)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSourceAddonPropertyInfo
            // 
            this.BindingSourceAddonPropertyInfo.DataSource = typeof(PAO.Config.Controls.EditControls.AddonPropertyInfo);
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
            this.ButtonImport});
            this.BarManagerObject.MaxItemId = 4;
            // 
            // BarToolObject
            // 
            this.BarToolObject.BarName = "对象工具条";
            this.BarToolObject.DockCol = 0;
            this.BarToolObject.DockRow = 0;
            this.BarToolObject.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarToolObject.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonImport, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu)});
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
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(785, 31);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 571);
            this.barDockControl2.Size = new System.Drawing.Size(785, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 31);
            this.barDockControl3.Size = new System.Drawing.Size(0, 540);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(785, 31);
            this.barDockControl4.Size = new System.Drawing.Size(0, 540);
            // 
            // GridControlAddonExtention
            // 
            this.GridControlAddonExtention.DataSource = this.BindingSourceAddonPropertyInfo;
            this.GridControlAddonExtention.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlAddonExtention.Location = new System.Drawing.Point(0, 31);
            this.GridControlAddonExtention.MainView = this.GridViewAddonExtention;
            this.GridControlAddonExtention.Name = "GridControlAddonExtention";
            this.GridControlAddonExtention.Size = new System.Drawing.Size(785, 540);
            this.GridControlAddonExtention.TabIndex = 5;
            this.GridControlAddonExtention.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAddonExtention});
            // 
            // GridViewAddonExtention
            // 
            this.GridViewAddonExtention.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnChecked,
            this.ColumnPropertyName,
            this.ColumnOrigionValue,
            this.ColumnPropertyValue});
            this.GridViewAddonExtention.GridControl = this.GridControlAddonExtention;
            this.GridViewAddonExtention.Name = "GridViewAddonExtention";
            this.GridViewAddonExtention.OptionsView.ShowGroupPanel = false;
            this.GridViewAddonExtention.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.GridViewAddonExtention_RowUpdated);
            // 
            // ColumnChecked
            // 
            this.ColumnChecked.Caption = "选择";
            this.ColumnChecked.FieldName = "Checked";
            this.ColumnChecked.Name = "ColumnChecked";
            this.ColumnChecked.OptionsColumn.FixedWidth = true;
            this.ColumnChecked.OptionsColumn.ShowCaption = false;
            this.ColumnChecked.Visible = true;
            this.ColumnChecked.VisibleIndex = 0;
            this.ColumnChecked.Width = 40;
            // 
            // ColumnPropertyName
            // 
            this.ColumnPropertyName.Caption = "属性名称";
            this.ColumnPropertyName.FieldName = "DisplayName";
            this.ColumnPropertyName.Name = "ColumnPropertyName";
            this.ColumnPropertyName.Visible = true;
            this.ColumnPropertyName.VisibleIndex = 1;
            this.ColumnPropertyName.Width = 147;
            // 
            // ColumnOrigionValue
            // 
            this.ColumnOrigionValue.Caption = "原始值";
            this.ColumnOrigionValue.FieldName = "OriginValue";
            this.ColumnOrigionValue.Name = "ColumnOrigionValue";
            this.ColumnOrigionValue.Visible = true;
            this.ColumnOrigionValue.VisibleIndex = 2;
            this.ColumnOrigionValue.Width = 263;
            // 
            // ColumnPropertyValue
            // 
            this.ColumnPropertyValue.Caption = "属性值";
            this.ColumnPropertyValue.FieldName = "PropertyValue";
            this.ColumnPropertyValue.Name = "ColumnPropertyValue";
            this.ColumnPropertyValue.Visible = true;
            this.ColumnPropertyValue.VisibleIndex = 3;
            this.ColumnPropertyValue.Width = 317;
            // 
            // AddonExtentionEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControlAddonExtention);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "AddonExtentionEditControl";
            this.Size = new System.Drawing.Size(785, 571);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAddonPropertyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAddonExtention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAddonExtention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource BindingSourceAddonPropertyInfo;
        private DevExpress.XtraBars.BarManager BarManagerObject;
        private DevExpress.XtraBars.Bar BarToolObject;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem ButtonImport;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraGrid.GridControl GridControlAddonExtention;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAddonExtention;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnChecked;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPropertyName;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnOrigionValue;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPropertyValue;
    }
}
