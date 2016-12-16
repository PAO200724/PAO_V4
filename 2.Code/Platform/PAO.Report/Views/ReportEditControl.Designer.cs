namespace PAO.Report.Views
{
    partial class ReportEditControl
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
            this.DockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.DockPanelProperties = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ObjectEditControl = new PAO.Config.Controls.EditControls.ObjectEditControl();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).BeginInit();
            this.DockPanelProperties.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            this.SuspendLayout();
            // 
            // DockManager
            // 
            this.DockManager.Form = this;
            this.DockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.DockPanelProperties});
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
            // DockPanelProperties
            // 
            this.DockPanelProperties.Controls.Add(this.dockPanel1_Container);
            this.DockPanelProperties.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.DockPanelProperties.ID = new System.Guid("98390e32-1dd3-47c2-92e8-0dad1900985a");
            this.DockPanelProperties.Location = new System.Drawing.Point(575, 0);
            this.DockPanelProperties.Name = "DockPanelProperties";
            this.DockPanelProperties.Options.AllowDockAsTabbedDocument = false;
            this.DockPanelProperties.Options.AllowFloating = false;
            this.DockPanelProperties.Options.ShowCloseButton = false;
            this.DockPanelProperties.OriginalSize = new System.Drawing.Size(200, 200);
            this.DockPanelProperties.Size = new System.Drawing.Size(200, 473);
            this.DockPanelProperties.Text = "属性";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ObjectEditControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 446);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ObjectEditControl
            // 
            this.ObjectEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectEditControl.Enabled = false;
            this.ObjectEditControl.Location = new System.Drawing.Point(0, 0);
            this.ObjectEditControl.Name = "ObjectEditControl";
            this.ObjectEditControl.ShowApplyButton = false;
            this.ObjectEditControl.ShowCancelButton = true;
            this.ObjectEditControl.Size = new System.Drawing.Size(192, 446);
            this.ObjectEditControl.TabIndex = 1;
            // 
            // LayoutControl
            // 
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.Root = this.LayoutControlGroupRoot;
            this.LayoutControl.Size = new System.Drawing.Size(575, 473);
            this.LayoutControl.TabIndex = 1;
            this.LayoutControl.Text = "布局控件";
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "LayoutControlGroupRoot";
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(575, 473);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // ReportEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.DockPanelProperties);
            this.Name = "ReportEditControl";
            this.Size = new System.Drawing.Size(775, 473);
            ((System.ComponentModel.ISupportInitialize)(this.DockManager)).EndInit();
            this.DockPanelProperties.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager DockManager;
        private DevExpress.XtraBars.Docking.DockPanel DockPanelProperties;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private Config.Controls.EditControls.ObjectEditControl ObjectEditControl;
        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
    }
}
