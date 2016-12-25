namespace PAO.Config.EditControls
{
    partial class DataFieldsEditControl
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
            this.PopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ButtonChangeEditor = new DevExpress.XtraBars.BarButtonItem();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // DataLayoutControl
            // 
            this.DataLayoutControl.DataSource = this.BindingSource;
            this.DataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.DataLayoutControl.Name = "DataLayoutControl";
            this.DataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(300, 200, 500, 600);
            this.DataLayoutControl.Root = this.LayoutControlGroupRoot;
            this.DataLayoutControl.Size = new System.Drawing.Size(514, 238);
            this.DataLayoutControl.TabIndex = 0;
            this.DataLayoutControl.Text = "布局控件";
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(PAO.Config.EditControls.DataFilterInfo);
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "Root";
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(514, 238);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // PopupMenu
            // 
            this.PopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonChangeEditor)});
            this.PopupMenu.Manager = this.BarManager;
            this.PopupMenu.Name = "PopupMenu";
            // 
            // ButtonChangeEditor
            // 
            this.ButtonChangeEditor.Caption = "更换编辑器(&E)...";
            this.ButtonChangeEditor.Id = 0;
            this.ButtonChangeEditor.Name = "ButtonChangeEditor";
            // 
            // BarManager
            // 
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonChangeEditor});
            this.BarManager.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(514, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 238);
            this.barDockControlBottom.Size = new System.Drawing.Size(514, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 238);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(514, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 238);
            // 
            // DataFieldsEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataLayoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DataFieldsEditControl";
            this.Size = new System.Drawing.Size(514, 238);
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl DataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraBars.PopupMenu PopupMenu;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonChangeEditor;
    }
}
