namespace PAO.UI.WinForm.MDI.Views
{
    partial class ReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportView));
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.ButtonQueryNow = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonPrint = new DevExpress.XtraBars.BarButtonItem();
            this.MenuConfig = new DevExpress.XtraBars.BarSubItem();
            this.ButtonRecoverLayout = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonProperties = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.RepositoryItemTextEditCaption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.MenuData = new DevExpress.XtraBars.BarSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 31);
            this.LayoutControl.MenuManager = this.BarManager;
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(685, 219, 250, 350);
            this.LayoutControl.Root = this.LayoutControlGroupRoot;
            this.LayoutControl.Size = new System.Drawing.Size(536, 439);
            this.LayoutControl.TabIndex = 0;
            this.LayoutControl.Text = "布局控件";
            this.LayoutControl.ItemAdded += new System.EventHandler(this.LayoutControl_ItemAdded);
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
            this.ButtonProperties,
            this.ButtonExport,
            this.ButtonPrint,
            this.MenuConfig,
            this.ButtonRecoverLayout,
            this.ButtonQueryNow,
            this.MenuData});
            this.BarManager.MaxItemId = 11;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEditCaption});
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonQueryNow, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuData),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuConfig)});
            this.BarTools.OptionsBar.DisableClose = true;
            this.BarTools.Text = "工具条";
            // 
            // ButtonQueryNow
            // 
            this.ButtonQueryNow.Caption = "查询(&Q)";
            this.ButtonQueryNow.Glyph = global::PAO.UI.WinForm.Properties.Resources.zoom_16x16;
            this.ButtonQueryNow.Id = 9;
            this.ButtonQueryNow.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.zoom_32x32;
            this.ButtonQueryNow.Name = "ButtonQueryNow";
            // 
            // ButtonExport
            // 
            this.ButtonExport.Caption = "导出(&E)";
            this.ButtonExport.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonExport.Glyph")));
            this.ButtonExport.Id = 3;
            this.ButtonExport.Name = "ButtonExport";
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.Caption = "打印(&P)";
            this.ButtonPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonPrint.Glyph")));
            this.ButtonPrint.Id = 4;
            this.ButtonPrint.Name = "ButtonPrint";
            // 
            // MenuConfig
            // 
            this.MenuConfig.Caption = "配置(&C)";
            this.MenuConfig.Id = 7;
            this.MenuConfig.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRecoverLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonProperties, true)});
            this.MenuConfig.Name = "MenuConfig";
            // 
            // ButtonRecoverLayout
            // 
            this.ButtonRecoverLayout.Caption = "恢复默认布局(R)";
            this.ButtonRecoverLayout.Id = 8;
            this.ButtonRecoverLayout.Name = "ButtonRecoverLayout";
            this.ButtonRecoverLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonRecoverLayout_ItemClick);
            // 
            // ButtonProperties
            // 
            this.ButtonProperties.Caption = "属性(&P)...";
            this.ButtonProperties.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonProperties.Glyph")));
            this.ButtonProperties.Id = 1;
            this.ButtonProperties.Name = "ButtonProperties";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(536, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 470);
            this.barDockControlBottom.Size = new System.Drawing.Size(536, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 439);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(536, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 439);
            // 
            // RepositoryItemTextEditCaption
            // 
            this.RepositoryItemTextEditCaption.AutoHeight = false;
            this.RepositoryItemTextEditCaption.Name = "RepositoryItemTextEditCaption";
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "Root";
            this.LayoutControlGroupRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(536, 439);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // MenuData
            // 
            this.MenuData.Caption = "数据(&D)";
            this.MenuData.Id = 10;
            this.MenuData.Name = "MenuData";
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReportView";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonProperties;
        private DevExpress.XtraBars.BarButtonItem ButtonExport;
        private DevExpress.XtraBars.BarButtonItem ButtonPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditCaption;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarSubItem MenuConfig;
        private DevExpress.XtraBars.BarButtonItem ButtonRecoverLayout;
        private DevExpress.XtraBars.BarButtonItem ButtonQueryNow;
        private DevExpress.XtraBars.BarSubItem MenuData;
    }
}
