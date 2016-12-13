namespace PAO.UI.WinForm.MDI
{
    partial class MDIMainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraSplashScreen.SplashScreenManager SplashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::PAO.UI.WinForm.Forms.PaoSplashScreen), true, true);
            this.DockManager = new DevExpress.XtraBars.Docking.DockManager();
            this.BarManager = new DevExpress.XtraBars.BarManager();
            this.BarMain = new DevExpress.XtraBars.Bar();
            this.MenuSystem = new DevExpress.XtraBars.BarSubItem();
            this.MenuSkin = new DevExpress.XtraBars.SkinBarSubItem();
            this.MenuWindow = new DevExpress.XtraBars.BarSubItem();
            this.ButtonRecoverLayout = new DevExpress.XtraBars.BarButtonItem();
            this.BarDockingMenuItem = new DevExpress.XtraBars.BarDockingMenuItem();
            this.MenuToolBar = new DevExpress.XtraBars.BarSubItem();
            this.BarToolbarsListItem = new DevExpress.XtraBars.BarToolbarsListItem();
            this.ButtonExit = new DevExpress.XtraBars.BarButtonItem();
            this.MenuCurrentUser = new DevExpress.XtraBars.BarSubItem();
            this.ButtonLogout = new DevExpress.XtraBars.BarButtonItem();
            this.MenuFunction = new DevExpress.XtraBars.BarSubItem();
            this.BarStatus = new DevExpress.XtraBars.Bar();
            this.EditItemProgressBar = new DevExpress.XtraBars.BarEditItem();
            this.RepositoryItemProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.EditItemWaitingBar = new DevExpress.XtraBars.BarEditItem();
            this.RepositoryItemMarqueeProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.EditItemCalculate = new DevExpress.XtraBars.BarEditItem();
            this.RepositoryItemCalcEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.StaticItemServerTime = new DevExpress.XtraBars.BarStaticItem();
            this.StaticItemStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DocumentManager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.TabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
            this.TimerDateTime = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemMarqueeProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCalcEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedView)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashScreenManager
            // 
            SplashScreenManager.ClosingDelay = 500;
            // 
            // DockManager
            // 
            this.DockManager.Form = this;
            this.DockManager.MenuManager = this.BarManager;
            this.DockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarMain,
            this.BarStatus});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControl1);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MenuSystem,
            this.ButtonExit,
            this.MenuSkin,
            this.BarDockingMenuItem,
            this.MenuWindow,
            this.BarToolbarsListItem,
            this.EditItemCalculate,
            this.EditItemProgressBar,
            this.EditItemWaitingBar,
            this.StaticItemServerTime,
            this.StaticItemStatus,
            this.MenuCurrentUser,
            this.MenuFunction,
            this.MenuToolBar,
            this.ButtonRecoverLayout,
            this.ButtonLogout});
            this.BarManager.MainMenu = this.BarMain;
            this.BarManager.MaxItemId = 24;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemCalcEdit,
            this.RepositoryItemProgressBar,
            this.RepositoryItemMarqueeProgressBar});
            // 
            // BarMain
            // 
            this.BarMain.BarName = "Main menu";
            this.BarMain.DockCol = 0;
            this.BarMain.DockRow = 0;
            this.BarMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.MenuSystem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.MenuCurrentUser, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.MenuFunction, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarMain.OptionsBar.DisableClose = true;
            this.BarMain.OptionsBar.MultiLine = true;
            this.BarMain.OptionsBar.UseWholeRow = true;
            this.BarMain.Text = "主菜单";
            // 
            // MenuSystem
            // 
            this.MenuSystem.Caption = "系统(&S)";
            this.MenuSystem.Glyph = global::PAO.UI.WinForm.Properties.Resources.operatingsystem_16x16;
            this.MenuSystem.Id = 0;
            this.MenuSystem.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.operatingsystem_32x32;
            this.MenuSystem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuSkin),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuWindow),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuToolBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonExit, true)});
            this.MenuSystem.Name = "MenuSystem";
            // 
            // MenuSkin
            // 
            this.MenuSkin.Caption = "皮肤(&S)";
            this.MenuSkin.Glyph = global::PAO.UI.WinForm.Properties.Resources.colors_16x16;
            this.MenuSkin.Id = 2;
            this.MenuSkin.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.colors_32x32;
            this.MenuSkin.Name = "MenuSkin";
            // 
            // MenuWindow
            // 
            this.MenuWindow.Caption = "窗口(&W)";
            this.MenuWindow.Glyph = global::PAO.UI.WinForm.Properties.Resources.windows_16x16;
            this.MenuWindow.Id = 5;
            this.MenuWindow.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.windows_32x32;
            this.MenuWindow.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRecoverLayout, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarDockingMenuItem, true)});
            this.MenuWindow.Name = "MenuWindow";
            // 
            // ButtonRecoverLayout
            // 
            this.ButtonRecoverLayout.Caption = "恢复布局(&R)";
            this.ButtonRecoverLayout.Glyph = global::PAO.UI.WinForm.Properties.Resources.reset_16x16;
            this.ButtonRecoverLayout.Id = 22;
            this.ButtonRecoverLayout.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.reset_32x32;
            this.ButtonRecoverLayout.Name = "ButtonRecoverLayout";
            this.ButtonRecoverLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonRecoverLayout_ItemClick);
            // 
            // BarDockingMenuItem
            // 
            this.BarDockingMenuItem.Caption = "视图(&D)";
            this.BarDockingMenuItem.Id = 4;
            this.BarDockingMenuItem.Name = "BarDockingMenuItem";
            // 
            // MenuToolBar
            // 
            this.MenuToolBar.Caption = "工具条(&T)";
            this.MenuToolBar.Glyph = global::PAO.UI.WinForm.Properties.Resources.ide_16x16;
            this.MenuToolBar.Id = 21;
            this.MenuToolBar.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.ide_32x32;
            this.MenuToolBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarToolbarsListItem)});
            this.MenuToolBar.Name = "MenuToolBar";
            // 
            // BarToolbarsListItem
            // 
            this.BarToolbarsListItem.Caption = "工具条(&T)";
            this.BarToolbarsListItem.Id = 7;
            this.BarToolbarsListItem.Name = "BarToolbarsListItem";
            // 
            // ButtonExit
            // 
            this.ButtonExit.Caption = "退出(&X)";
            this.ButtonExit.Glyph = global::PAO.UI.WinForm.Properties.Resources.close_16x16;
            this.ButtonExit.Id = 1;
            this.ButtonExit.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.close_32x32;
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonExit_ItemClick);
            // 
            // MenuCurrentUser
            // 
            this.MenuCurrentUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.MenuCurrentUser.Caption = "当前用户";
            this.MenuCurrentUser.Glyph = global::PAO.UI.WinForm.Properties.Resources.customer_16x16;
            this.MenuCurrentUser.Id = 18;
            this.MenuCurrentUser.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.customer_32x32;
            this.MenuCurrentUser.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonLogout)});
            this.MenuCurrentUser.Name = "MenuCurrentUser";
            // 
            // ButtonLogout
            // 
            this.ButtonLogout.Caption = "注销(&L)";
            this.ButtonLogout.Glyph = global::PAO.UI.WinForm.Properties.Resources.undo_16x16;
            this.ButtonLogout.Id = 23;
            this.ButtonLogout.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.undo_32x32;
            this.ButtonLogout.Name = "ButtonLogout";
            this.ButtonLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonLogout_ItemClick);
            // 
            // MenuFunction
            // 
            this.MenuFunction.Caption = "扩展功能(&E)";
            this.MenuFunction.Glyph = global::PAO.UI.WinForm.Properties.Resources.morefunctions_16x16;
            this.MenuFunction.Id = 20;
            this.MenuFunction.LargeGlyph = global::PAO.UI.WinForm.Properties.Resources.morefunctions_32x32;
            this.MenuFunction.Name = "MenuFunction";
            // 
            // BarStatus
            // 
            this.BarStatus.BarName = "Status bar";
            this.BarStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.BarStatus.DockCol = 0;
            this.BarStatus.DockRow = 0;
            this.BarStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.BarStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.EditItemProgressBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.EditItemWaitingBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.EditItemCalculate),
            new DevExpress.XtraBars.LinkPersistInfo(this.StaticItemServerTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.StaticItemStatus)});
            this.BarStatus.OptionsBar.AllowQuickCustomization = false;
            this.BarStatus.OptionsBar.DrawDragBorder = false;
            this.BarStatus.OptionsBar.UseWholeRow = true;
            this.BarStatus.Text = "状态条";
            // 
            // EditItemProgressBar
            // 
            this.EditItemProgressBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.EditItemProgressBar.Caption = "进度条";
            this.EditItemProgressBar.Edit = this.RepositoryItemProgressBar;
            this.EditItemProgressBar.Id = 11;
            this.EditItemProgressBar.Name = "EditItemProgressBar";
            this.EditItemProgressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // RepositoryItemProgressBar
            // 
            this.RepositoryItemProgressBar.Name = "RepositoryItemProgressBar";
            // 
            // EditItemWaitingBar
            // 
            this.EditItemWaitingBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.EditItemWaitingBar.Caption = "等待条";
            this.EditItemWaitingBar.Edit = this.RepositoryItemMarqueeProgressBar;
            this.EditItemWaitingBar.Id = 12;
            this.EditItemWaitingBar.Name = "EditItemWaitingBar";
            this.EditItemWaitingBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // RepositoryItemMarqueeProgressBar
            // 
            this.RepositoryItemMarqueeProgressBar.Name = "RepositoryItemMarqueeProgressBar";
            // 
            // EditItemCalculate
            // 
            this.EditItemCalculate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.EditItemCalculate.Caption = "计算器";
            this.EditItemCalculate.Edit = this.RepositoryItemCalcEdit;
            this.EditItemCalculate.EditWidth = 121;
            this.EditItemCalculate.Id = 10;
            this.EditItemCalculate.Name = "EditItemCalculate";
            // 
            // RepositoryItemCalcEdit
            // 
            this.RepositoryItemCalcEdit.Appearance.Options.UseTextOptions = true;
            this.RepositoryItemCalcEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.RepositoryItemCalcEdit.AutoHeight = false;
            this.RepositoryItemCalcEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemCalcEdit.Name = "RepositoryItemCalcEdit";
            // 
            // StaticItemServerTime
            // 
            this.StaticItemServerTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.StaticItemServerTime.Caption = "服务器时间";
            this.StaticItemServerTime.Id = 13;
            this.StaticItemServerTime.Name = "StaticItemServerTime";
            this.StaticItemServerTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // StaticItemStatus
            // 
            this.StaticItemStatus.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.StaticItemStatus.Id = 14;
            this.StaticItemStatus.Name = "StaticItemStatus";
            this.StaticItemStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(894, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 600);
            this.barDockControlBottom.Size = new System.Drawing.Size(894, 31);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 576);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(894, 24);
            this.barDockControl1.Size = new System.Drawing.Size(0, 576);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(894, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 576);
            // 
            // DocumentManager
            // 
            this.DocumentManager.MdiParent = this;
            this.DocumentManager.MenuManager = this.BarManager;
            this.DocumentManager.View = this.TabbedView;
            this.DocumentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.TabbedView});
            // 
            // TabbedView
            // 
            this.TabbedView.DocumentClosing += new DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventHandler(this.TabbedView_DocumentClosing);
            // 
            // TimerDateTime
            // 
            this.TimerDateTime.Enabled = true;
            this.TimerDateTime.Interval = 1000;
            this.TimerDateTime.Tick += new System.EventHandler(this.TimerDateTime_Tick);
            // 
            // MDIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 631);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "MDIMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDIMainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemMarqueeProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCalcEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager DockManager;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarMain;
        private DevExpress.XtraBars.Bar BarStatus;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarSubItem MenuSystem;
        private DevExpress.XtraBars.SkinBarSubItem MenuSkin;
        private DevExpress.XtraBars.BarSubItem MenuWindow;
        private DevExpress.XtraBars.BarDockingMenuItem BarDockingMenuItem;
        private DevExpress.XtraBars.BarToolbarsListItem BarToolbarsListItem;
        private DevExpress.XtraBars.BarButtonItem ButtonExit;
        private DevExpress.XtraBars.BarEditItem EditItemProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar RepositoryItemProgressBar;
        private DevExpress.XtraBars.BarEditItem EditItemWaitingBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar RepositoryItemMarqueeProgressBar;
        private DevExpress.XtraBars.BarEditItem EditItemCalculate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit RepositoryItemCalcEdit;
        private DevExpress.XtraBars.BarStaticItem StaticItemServerTime;
        private DevExpress.XtraBars.BarStaticItem StaticItemStatus;
        private DevExpress.XtraBars.BarSubItem MenuCurrentUser;
        private DevExpress.XtraBars.BarSubItem MenuFunction;
        private DevExpress.XtraBars.Docking2010.DocumentManager DocumentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView TabbedView;
        private DevExpress.XtraBars.BarSubItem MenuToolBar;
        private DevExpress.XtraBars.BarButtonItem ButtonRecoverLayout;
        private System.Windows.Forms.Timer TimerDateTime;
        private DevExpress.XtraBars.BarButtonItem ButtonLogout;
    }
}