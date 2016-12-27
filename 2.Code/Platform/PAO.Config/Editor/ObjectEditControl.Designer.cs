namespace PAO.Config.Editor
{
    partial class ObjectEditControl
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
            this.PropertyDescriptionControl = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.PropertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertyDescriptionControl
            // 
            this.PropertyDescriptionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyDescriptionControl.Location = new System.Drawing.Point(0, 0);
            this.PropertyDescriptionControl.Name = "PropertyDescriptionControl";
            this.PropertyDescriptionControl.PropertyGrid = this.PropertyGridControl;
            this.PropertyDescriptionControl.Size = new System.Drawing.Size(466, 100);
            this.PropertyDescriptionControl.TabIndex = 0;
            this.PropertyDescriptionControl.TabStop = false;
            // 
            // PropertyGridControl
            // 
            this.PropertyGridControl.AutoGenerateRows = true;
            this.PropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGridControl.Location = new System.Drawing.Point(0, 0);
            this.PropertyGridControl.Name = "PropertyGridControl";
            this.PropertyGridControl.OptionsView.MinRowAutoHeight = 30;
            this.PropertyGridControl.RecordWidth = 120;
            this.PropertyGridControl.RowHeaderWidth = 200;
            this.PropertyGridControl.OptionsView.FixRowHeaderPanelWidth = true;
            this.PropertyGridControl.Size = new System.Drawing.Size(466, 567);
            this.PropertyGridControl.TabIndex = 0;
            this.PropertyGridControl.CustomPropertyDescriptors += new DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventHandler(this.PropertyGridControl_CustomPropertyDescriptors);
            this.PropertyGridControl.CustomRecordCellEdit += new DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventHandler(this.PropertyGridControl_CustomRecordCellEdit);
            this.PropertyGridControl.CustomRecordCellEditForEditing += new DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventHandler(this.PropertyGridControl_CustomRecordCellEditForEditing);
            this.PropertyGridControl.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.PropertyGridControl_CellValueChanged);
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.SplitContainerControl.Horizontal = false;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.Controls.Add(this.PropertyGridControl);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.Controls.Add(this.PropertyDescriptionControl);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(466, 672);
            this.SplitContainerControl.TabIndex = 1;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // ObjectEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerControl);
            this.Name = "ObjectEditControl";
            this.Size = new System.Drawing.Size(466, 672);
            this.Leave += new System.EventHandler(this.ObjectEditControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl PropertyDescriptionControl;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraVerticalGrid.PropertyGridControl PropertyGridControl;
    }
}
