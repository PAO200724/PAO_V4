namespace PAO.Config.Editor
{
    partial class ObjectLayoutEditControl
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
            this.DataLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.ButtonCustom = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonRecoverFormat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.TextEditCaption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // DataLayoutControl
            // 
            this.DataLayoutControl.DataSource = this.BindingSource;
            this.DataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataLayoutControl.Location = new System.Drawing.Point(0, 31);
            this.DataLayoutControl.Name = "DataLayoutControl";
            this.DataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(300, 200, 500, 600);
            this.DataLayoutControl.Root = this.LayoutControlGroupRoot;
            this.DataLayoutControl.Size = new System.Drawing.Size(535, 612);
            this.DataLayoutControl.TabIndex = 0;
            this.DataLayoutControl.Text = "布局控件";
            this.DataLayoutControl.ItemSelectionChanged += new System.EventHandler(this.DataLayoutControl_ItemSelectionChanged);
            this.DataLayoutControl.ShowCustomization += new System.EventHandler(this.DataLayoutControl_ShowCustomization);
            this.DataLayoutControl.HideCustomization += new System.EventHandler(this.DataLayoutControl_HideCustomization);
            this.DataLayoutControl.PopupMenuShowing += new DevExpress.XtraLayout.PopupMenuShowingEventHandler(this.DataLayoutControl_PopupMenuShowing);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(PAO.Config.Editor.DataFilterInfo);
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "Root";
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(535, 612);
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
            this.ButtonCustom,
            this.ButtonRecoverFormat});
            this.BarManager.MaxItemId = 7;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TextEditCaption});
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonCustom),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRecoverFormat)});
            this.BarTools.OptionsBar.AllowQuickCustomization = false;
            this.BarTools.OptionsBar.DrawDragBorder = false;
            this.BarTools.OptionsBar.UseWholeRow = true;
            this.BarTools.Text = "工具条";
            // 
            // ButtonCustom
            // 
            this.ButtonCustom.Caption = "自定义(&U)...";
            this.ButtonCustom.Glyph = global::PAO.Config.Properties.Resources.pagesetup_16x16;
            this.ButtonCustom.Id = 2;
            this.ButtonCustom.LargeGlyph = global::PAO.Config.Properties.Resources.pagesetup_32x32;
            this.ButtonCustom.Name = "ButtonCustom";
            this.ButtonCustom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonCustom_ItemClick);
            // 
            // ButtonRecoverFormat
            // 
            this.ButtonRecoverFormat.Caption = "恢复默认格式(&R)";
            this.ButtonRecoverFormat.Glyph = global::PAO.Config.Properties.Resources.reset_16x16;
            this.ButtonRecoverFormat.Id = 3;
            this.ButtonRecoverFormat.LargeGlyph = global::PAO.Config.Properties.Resources.reset_32x32;
            this.ButtonRecoverFormat.Name = "ButtonRecoverFormat";
            this.ButtonRecoverFormat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonRecoverFormat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(535, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 643);
            this.barDockControlBottom.Size = new System.Drawing.Size(535, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 612);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(535, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 612);
            // 
            // TextEditCaption
            // 
            this.TextEditCaption.AutoHeight = false;
            this.TextEditCaption.Name = "TextEditCaption";
            // 
            // ObjectLayoutEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataLayoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ObjectLayoutEditControl";
            this.Size = new System.Drawing.Size(535, 643);
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl DataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarButtonItem ButtonCustom;
        private DevExpress.XtraBars.BarButtonItem ButtonRecoverFormat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TextEditCaption;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
