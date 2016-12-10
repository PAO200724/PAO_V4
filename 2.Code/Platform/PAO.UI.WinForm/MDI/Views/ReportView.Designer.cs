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
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ButtonProperties = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonExport = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonPrint = new DevExpress.XtraBars.BarButtonItem();
            this.RepositoryItemTextEditCaption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 31);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.Root = this.LayoutControlGroupRoot;
            this.LayoutControl.Size = new System.Drawing.Size(585, 412);
            this.LayoutControl.TabIndex = 0;
            this.LayoutControl.Text = "layoutControl1";
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "Root";
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(585, 412);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
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
            this.barSubItem1});
            this.BarManager.MaxItemId = 8;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.BarTools.OptionsBar.DisableClose = true;
            this.BarTools.Text = "工具条";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(585, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 443);
            this.barDockControlBottom.Size = new System.Drawing.Size(585, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 412);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(585, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 412);
            // 
            // ButtonProperties
            // 
            this.ButtonProperties.Caption = "属性(&P)...";
            this.ButtonProperties.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonProperties.Glyph")));
            this.ButtonProperties.Id = 1;
            this.ButtonProperties.Name = "ButtonProperties";
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
            // RepositoryItemTextEditCaption
            // 
            this.RepositoryItemTextEditCaption.AutoHeight = false;
            this.RepositoryItemTextEditCaption.Name = "RepositoryItemTextEditCaption";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "配置(&C)";
            this.barSubItem1.Id = 7;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonProperties)});
            this.barSubItem1.Name = "barSubItem1";
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
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditCaption)).EndInit();
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
        private DevExpress.XtraBars.BarSubItem barSubItem1;
    }
}
