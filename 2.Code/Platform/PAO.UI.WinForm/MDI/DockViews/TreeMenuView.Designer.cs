namespace PAO.UI.WinForm.MDI.DockViews
{
    partial class TreeMenuView
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
            this.TreeListMenu = new DevExpress.XtraTreeList.TreeList();
            this.ColumnCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColumnMenu = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.ButtonExpandAll = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeListMenu
            // 
            this.TreeListMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColumnCaption,
            this.ColumnMenu});
            this.TreeListMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeListMenu.Location = new System.Drawing.Point(0, 29);
            this.TreeListMenu.Name = "TreeListMenu";
            this.TreeListMenu.OptionsBehavior.Editable = false;
            this.TreeListMenu.OptionsBehavior.EnableFiltering = true;
            this.TreeListMenu.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListMenu.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListMenu.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.TreeListMenu.OptionsFind.FindNullPrompt = "搜索...";
            this.TreeListMenu.OptionsView.ShowAutoFilterRow = true;
            this.TreeListMenu.OptionsView.ShowColumns = false;
            this.TreeListMenu.OptionsView.ShowIndicator = false;
            this.TreeListMenu.Size = new System.Drawing.Size(314, 483);
            this.TreeListMenu.TabIndex = 0;
            this.TreeListMenu.DoubleClick += new System.EventHandler(this.TreeListMenu_DoubleClick);
            // 
            // ColumnCaption
            // 
            this.ColumnCaption.Caption = "标题";
            this.ColumnCaption.FieldName = "Caption";
            this.ColumnCaption.Name = "ColumnCaption";
            this.ColumnCaption.Visible = true;
            this.ColumnCaption.VisibleIndex = 0;
            // 
            // ColumnMenu
            // 
            this.ColumnMenu.Caption = "菜单";
            this.ColumnMenu.FieldName = "Menu";
            this.ColumnMenu.Name = "ColumnMenu";
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
            this.ButtonExpandAll});
            this.BarManager.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(314, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 512);
            this.barDockControlBottom.Size = new System.Drawing.Size(314, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 483);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(314, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 483);
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonExpandAll)});
            this.BarTools.Text = "工具条";
            // 
            // ButtonExpandAll
            // 
            this.ButtonExpandAll.Caption = "全部展开(&E)";
            this.ButtonExpandAll.Id = 0;
            this.ButtonExpandAll.Name = "ButtonExpandAll";
            this.ButtonExpandAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonExpandAll_ItemClick);
            // 
            // TreeMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreeListMenu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TreeMenuView";
            this.Size = new System.Drawing.Size(314, 512);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList TreeListMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnCaption;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColumnMenu;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarButtonItem ButtonExpandAll;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
