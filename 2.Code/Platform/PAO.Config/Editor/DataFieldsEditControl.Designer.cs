namespace PAO.Config.Editor
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
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
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
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(514, 238);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // DataFieldsEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataLayoutControl);
            this.Name = "DataFieldsEditControl";
            this.Size = new System.Drawing.Size(514, 238);
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl DataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private System.Windows.Forms.BindingSource BindingSource;
    }
}
