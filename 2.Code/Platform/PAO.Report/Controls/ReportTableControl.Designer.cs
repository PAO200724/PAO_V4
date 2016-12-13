namespace PAO.Report.Controls
{
    partial class ReportTableControl
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.BarItemCount = new DevExpress.XtraBars.BarEditItem();
            this.TextEditCount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ButtonMore = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonAll = new DevExpress.XtraBars.BarButtonItem();
            this.BarProgress = new DevExpress.XtraBars.Bar();
            this.BarItemQueryProgress = new DevExpress.XtraBars.BarEditItem();
            this.EditItemProgress = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.AllowCustomization = false;
            this.LayoutControl.AutoSize = true;
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayoutControl.Location = new System.Drawing.Point(0, 60);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(913, -910, 709, 661);
            this.LayoutControl.Root = this.LayoutControlGroupRoot;
            this.LayoutControl.Size = new System.Drawing.Size(290, 6);
            this.LayoutControl.TabIndex = 3;
            this.LayoutControl.Text = "布局控件";
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "Root";
            this.LayoutControlGroupRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(290, 6);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // BarManager
            // 
            this.BarManager.AllowCustomization = false;
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarTools,
            this.BarProgress});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarItemCount,
            this.ButtonMore,
            this.ButtonAll,
            this.BarItemQueryProgress});
            this.BarManager.MaxItemId = 4;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TextEditCount,
            this.EditItemProgress});
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BarItemCount, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonMore),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonAll)});
            this.BarTools.OptionsBar.AllowQuickCustomization = false;
            this.BarTools.OptionsBar.DisableClose = true;
            this.BarTools.OptionsBar.DisableCustomization = true;
            this.BarTools.OptionsBar.DrawDragBorder = false;
            this.BarTools.OptionsBar.UseWholeRow = true;
            this.BarTools.Text = "工具条";
            // 
            // BarItemCount
            // 
            this.BarItemCount.AutoFillWidth = true;
            this.BarItemCount.Caption = "数量：";
            this.BarItemCount.Edit = this.TextEditCount;
            this.BarItemCount.Id = 0;
            this.BarItemCount.Name = "BarItemCount";
            // 
            // TextEditCount
            // 
            this.TextEditCount.AutoHeight = false;
            this.TextEditCount.Name = "TextEditCount";
            this.TextEditCount.ReadOnly = true;
            // 
            // ButtonMore
            // 
            this.ButtonMore.Caption = "更多(&M";
            this.ButtonMore.Glyph = global::PAO.Report.Properties.Resources.doublenext_16x16;
            this.ButtonMore.Id = 1;
            this.ButtonMore.Name = "ButtonMore";
            toolTipTitleItem1.Text = "更多";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "查询更多的数据，耗时较短";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.ButtonMore.SuperTip = superToolTip1;
            this.ButtonMore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonMore_ItemClick);
            // 
            // ButtonAll
            // 
            this.ButtonAll.Caption = "所有(&A)";
            this.ButtonAll.Glyph = global::PAO.Report.Properties.Resources.last_16x16;
            this.ButtonAll.Id = 2;
            this.ButtonAll.Name = "ButtonAll";
            toolTipTitleItem2.Text = "所有";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "查询所有的数据，耗时较长";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.ButtonAll.SuperTip = superToolTip2;
            this.ButtonAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAll_ItemClick);
            // 
            // BarProgress
            // 
            this.BarProgress.BarName = "进度工具条";
            this.BarProgress.DockCol = 0;
            this.BarProgress.DockRow = 1;
            this.BarProgress.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarProgress.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarItemQueryProgress)});
            this.BarProgress.OptionsBar.AllowQuickCustomization = false;
            this.BarProgress.OptionsBar.DisableClose = true;
            this.BarProgress.OptionsBar.DisableCustomization = true;
            this.BarProgress.OptionsBar.DrawDragBorder = false;
            this.BarProgress.OptionsBar.UseWholeRow = true;
            this.BarProgress.Text = "进度工具条";
            this.BarProgress.Visible = false;
            // 
            // BarItemQueryProgress
            // 
            this.BarItemQueryProgress.AutoFillWidth = true;
            this.BarItemQueryProgress.Caption = "进度";
            this.BarItemQueryProgress.Edit = this.EditItemProgress;
            this.BarItemQueryProgress.Id = 3;
            this.BarItemQueryProgress.Name = "BarItemQueryProgress";
            // 
            // EditItemProgress
            // 
            this.EditItemProgress.Name = "EditItemProgress";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(290, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 157);
            this.barDockControlBottom.Size = new System.Drawing.Size(290, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 97);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(290, 60);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 97);
            // 
            // ReportTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReportTableControl";
            this.Size = new System.Drawing.Size(290, 157);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditItemProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem BarItemCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TextEditCount;
        private DevExpress.XtraBars.BarButtonItem ButtonMore;
        private DevExpress.XtraBars.BarButtonItem ButtonAll;
        private DevExpress.XtraBars.BarEditItem BarItemQueryProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar EditItemProgress;
        private DevExpress.XtraBars.Bar BarProgress;
    }
}
