namespace PAO.Config.EditControls
{
    partial class ObjectContainerEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectContainerEditControl));
            this.BarManagerObject = new DevExpress.XtraBars.BarManager(this.components);
            this.BarToolObject = new DevExpress.XtraBars.Bar();
            this.StaticItemObject = new DevExpress.XtraBars.BarStaticItem();
            this.ButtonCreate = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.MenuFormat = new DevExpress.XtraBars.BarSubItem();
            this.ButtonSaveFormat = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonSaveFormatAs = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonRecoverFormat = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonImportFormat = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).BeginInit();
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
            this.StaticItemObject,
            this.ButtonCreate,
            this.ButtonDelete,
            this.MenuFormat,
            this.ButtonSaveFormat,
            this.ButtonSaveFormatAs,
            this.ButtonRecoverFormat,
            this.ButtonImportFormat});
            this.BarManagerObject.MaxItemId = 17;
            // 
            // BarToolObject
            // 
            this.BarToolObject.BarName = "对象工具条";
            this.BarToolObject.DockCol = 0;
            this.BarToolObject.DockRow = 0;
            this.BarToolObject.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarToolObject.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.StaticItemObject, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonCreate),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonDelete),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.MenuFormat, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu)});
            this.BarToolObject.OptionsBar.AllowQuickCustomization = false;
            this.BarToolObject.OptionsBar.DisableClose = true;
            this.BarToolObject.OptionsBar.DisableCustomization = true;
            this.BarToolObject.OptionsBar.DrawDragBorder = false;
            this.BarToolObject.OptionsBar.UseWholeRow = true;
            this.BarToolObject.Text = "对象工具条";
            // 
            // StaticItemObject
            // 
            this.StaticItemObject.Caption = "对象信息";
            this.StaticItemObject.Id = 9;
            this.StaticItemObject.Name = "StaticItemObject";
            this.StaticItemObject.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.Caption = "新建(&N)";
            this.ButtonCreate.Glyph = global::PAO.Config.Properties.Resources.addfile_16x16;
            this.ButtonCreate.Id = 10;
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonCreate_ItemClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Caption = "删除(&D)";
            this.ButtonDelete.Glyph = global::PAO.Config.Properties.Resources.removeitem_16x16;
            this.ButtonDelete.Id = 11;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonDelete_ItemClick);
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
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(674, 32);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 425);
            this.barDockControl2.Size = new System.Drawing.Size(674, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 32);
            this.barDockControl3.Size = new System.Drawing.Size(0, 393);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(674, 32);
            this.barDockControl4.Size = new System.Drawing.Size(0, 393);
            // 
            // MenuFormat
            // 
            this.MenuFormat.Caption = "格式(&F)";
            this.MenuFormat.Glyph = ((System.Drawing.Image)(resources.GetObject("MenuFormat.Glyph")));
            this.MenuFormat.Id = 12;
            this.MenuFormat.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("MenuFormat.LargeGlyph")));
            this.MenuFormat.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonSaveFormat),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonSaveFormatAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRecoverFormat, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonImportFormat)});
            this.MenuFormat.Name = "MenuFormat";
            // 
            // ButtonSaveFormat
            // 
            this.ButtonSaveFormat.Caption = "保存格式(&S)";
            this.ButtonSaveFormat.Id = 13;
            this.ButtonSaveFormat.Name = "ButtonSaveFormat";
            // 
            // ButtonSaveFormatAs
            // 
            this.ButtonSaveFormatAs.Caption = "格式另存为(&S)...";
            this.ButtonSaveFormatAs.Id = 14;
            this.ButtonSaveFormatAs.Name = "ButtonSaveFormatAs";
            // 
            // ButtonRecoverFormat
            // 
            this.ButtonRecoverFormat.Caption = "恢复初始格式(&R)";
            this.ButtonRecoverFormat.Id = 15;
            this.ButtonRecoverFormat.Name = "ButtonRecoverFormat";
            // 
            // ButtonImportFormat
            // 
            this.ButtonImportFormat.Caption = "导入格式(&L)...";
            this.ButtonImportFormat.Id = 16;
            this.ButtonImportFormat.Name = "ButtonImportFormat";
            // 
            // ObjectContainerEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "ObjectContainerEditControl";
            this.Size = new System.Drawing.Size(674, 425);
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManagerObject;
        private DevExpress.XtraBars.Bar BarToolObject;
        private DevExpress.XtraBars.BarStaticItem StaticItemObject;
        private DevExpress.XtraBars.BarButtonItem ButtonCreate;
        private DevExpress.XtraBars.BarButtonItem ButtonDelete;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarSubItem MenuFormat;
        private DevExpress.XtraBars.BarButtonItem ButtonSaveFormat;
        private DevExpress.XtraBars.BarButtonItem ButtonSaveFormatAs;
        private DevExpress.XtraBars.BarButtonItem ButtonRecoverFormat;
        private DevExpress.XtraBars.BarButtonItem ButtonImportFormat;
    }
}
