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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            this.DockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarMain = new DevExpress.XtraBars.Bar();
            this.MenuSystem = new DevExpress.XtraBars.BarSubItem();
            this.MenuSkin = new DevExpress.XtraBars.SkinBarSubItem();
            this.MenuWindow = new DevExpress.XtraBars.BarSubItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barWorkspaceMenuItem1 = new DevExpress.XtraBars.BarWorkspaceMenuItem();
            this.WorkspaceManager = new DevExpress.Utils.WorkspaceManager();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            this.ButtonExit = new DevExpress.XtraBars.BarButtonItem();
            this.BarStatus = new DevExpress.XtraBars.Bar();
            this.EditItemProgressBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.EditItemWaitingBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.EditItemCalculate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.StaticItemServerTime = new DevExpress.XtraBars.BarStaticItem();
            this.StaticItemStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.TabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.MenuCurrentUser = new DevExpress.XtraBars.BarSubItem();
            this.MenuFunction = new DevExpress.XtraBars.BarSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedMdiManager)).BeginInit();
            this.SuspendLayout();
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
            this.barMdiChildrenListItem1,
            this.barDockingMenuItem1,
            this.MenuWindow,
            this.barWorkspaceMenuItem1,
            this.barToolbarsListItem1,
            this.EditItemCalculate,
            this.EditItemProgressBar,
            this.EditItemWaitingBar,
            this.StaticItemServerTime,
            this.StaticItemStatus,
            this.MenuCurrentUser,
            this.MenuFunction});
            this.BarManager.MainMenu = this.BarMain;
            this.BarManager.MaxItemId = 21;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemCalcEdit1,
            this.repositoryItemProgressBar1,
            this.repositoryItemMarqueeProgressBar1});
            // 
            // BarMain
            // 
            this.BarMain.BarName = "Main menu";
            this.BarMain.DockCol = 0;
            this.BarMain.DockRow = 0;
            this.BarMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuSystem),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuCurrentUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuFunction)});
            this.BarMain.OptionsBar.DisableClose = true;
            this.BarMain.OptionsBar.MultiLine = true;
            this.BarMain.OptionsBar.UseWholeRow = true;
            this.BarMain.Text = "主菜单";
            // 
            // MenuSystem
            // 
            this.MenuSystem.Caption = "系统(&S)";
            this.MenuSystem.Id = 0;
            this.MenuSystem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuSkin),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuWindow),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonExit, true)});
            this.MenuSystem.Name = "MenuSystem";
            // 
            // MenuSkin
            // 
            this.MenuSkin.Caption = "皮肤(&S)";
            this.MenuSkin.Id = 2;
            this.MenuSkin.Name = "MenuSkin";
            // 
            // MenuWindow
            // 
            this.MenuWindow.Caption = "窗口(&W)";
            this.MenuWindow.Id = 5;
            this.MenuWindow.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiChildrenListItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDockingMenuItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barWorkspaceMenuItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barToolbarsListItem1, true)});
            this.MenuWindow.Name = "MenuWindow";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "子窗体(&C)";
            this.barMdiChildrenListItem1.Id = 3;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "视图(&D)";
            this.barDockingMenuItem1.Id = 4;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // barWorkspaceMenuItem1
            // 
            this.barWorkspaceMenuItem1.Caption = "工作空间(&K)";
            this.barWorkspaceMenuItem1.Id = 6;
            this.barWorkspaceMenuItem1.Name = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.WorkspaceManager = this.WorkspaceManager;
            // 
            // WorkspaceManager
            // 
            this.WorkspaceManager.TargetControl = this;
            this.WorkspaceManager.TransitionType = pushTransition1;
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.Caption = "工具条(&T)";
            this.barToolbarsListItem1.Id = 7;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            // 
            // ButtonExit
            // 
            this.ButtonExit.Caption = "退出(&X)";
            this.ButtonExit.Id = 1;
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonExit_ItemClick);
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
            this.EditItemProgressBar.Edit = this.repositoryItemProgressBar1;
            this.EditItemProgressBar.Id = 11;
            this.EditItemProgressBar.Name = "EditItemProgressBar";
            this.EditItemProgressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // EditItemWaitingBar
            // 
            this.EditItemWaitingBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.EditItemWaitingBar.Caption = "等待条";
            this.EditItemWaitingBar.Edit = this.repositoryItemMarqueeProgressBar1;
            this.EditItemWaitingBar.Id = 12;
            this.EditItemWaitingBar.Name = "EditItemWaitingBar";
            this.EditItemWaitingBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // EditItemCalculate
            // 
            this.EditItemCalculate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.EditItemCalculate.Caption = "计算器";
            this.EditItemCalculate.Edit = this.repositoryItemCalcEdit1;
            this.EditItemCalculate.EditWidth = 88;
            this.EditItemCalculate.Id = 10;
            this.EditItemCalculate.Name = "EditItemCalculate";
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
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
            this.barDockControlTop.Size = new System.Drawing.Size(894, 26);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 574);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(894, 26);
            this.barDockControl1.Size = new System.Drawing.Size(0, 574);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(894, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 574);
            // 
            // TabbedMdiManager
            // 
            this.TabbedMdiManager.MdiParent = this;
            // 
            // MenuCurrentUser
            // 
            this.MenuCurrentUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.MenuCurrentUser.Caption = "当前用户";
            this.MenuCurrentUser.Id = 18;
            this.MenuCurrentUser.Name = "MenuCurrentUser";
            // 
            // MenuFunction
            // 
            this.MenuFunction.Caption = "扩展功能(&E)";
            this.MenuFunction.Id = 20;
            this.MenuFunction.Name = "MenuFunction";
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedMdiManager)).EndInit();
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
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager TabbedMdiManager;
        private DevExpress.XtraBars.BarSubItem MenuSystem;
        private DevExpress.XtraBars.SkinBarSubItem MenuSkin;
        private DevExpress.XtraBars.BarSubItem MenuWindow;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarWorkspaceMenuItem barWorkspaceMenuItem1;
        private DevExpress.Utils.WorkspaceManager WorkspaceManager;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraBars.BarButtonItem ButtonExit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem EditItemProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarEditItem EditItemWaitingBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraBars.BarEditItem EditItemCalculate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraBars.BarStaticItem StaticItemServerTime;
        private DevExpress.XtraBars.BarStaticItem StaticItemStatus;
        private DevExpress.XtraBars.BarSubItem MenuCurrentUser;
        private DevExpress.XtraBars.BarSubItem MenuFunction;
    }
}