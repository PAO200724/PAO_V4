namespace PAO.Config.Controls.EditControls
{
    partial class AddonExtentionEditControl
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
            this.BindingSourceAddonPropertyInfo = new System.Windows.Forms.BindingSource(this.components);
            this.GridControlAddonExtention = new DevExpress.XtraGrid.GridControl();
            this.GridViewAddonExtention = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPropertyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnOrigionValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPropertyValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAddonPropertyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAddonExtention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAddonExtention)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSourceAddonPropertyInfo
            // 
            this.BindingSourceAddonPropertyInfo.DataSource = typeof(PAO.Config.Controls.EditControls.AddonPropertyInfo);
            // 
            // GridControlAddonExtention
            // 
            this.GridControlAddonExtention.DataSource = this.BindingSourceAddonPropertyInfo;
            this.GridControlAddonExtention.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlAddonExtention.Location = new System.Drawing.Point(0, 0);
            this.GridControlAddonExtention.MainView = this.GridViewAddonExtention;
            this.GridControlAddonExtention.Name = "GridControlAddonExtention";
            this.GridControlAddonExtention.Size = new System.Drawing.Size(785, 571);
            this.GridControlAddonExtention.TabIndex = 5;
            this.GridControlAddonExtention.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAddonExtention});
            // 
            // GridViewAddonExtention
            // 
            this.GridViewAddonExtention.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnChecked,
            this.ColumnPropertyName,
            this.ColumnOrigionValue,
            this.ColumnPropertyValue});
            this.GridViewAddonExtention.GridControl = this.GridControlAddonExtention;
            this.GridViewAddonExtention.Name = "GridViewAddonExtention";
            this.GridViewAddonExtention.OptionsView.ShowGroupPanel = false;
            this.GridViewAddonExtention.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.GridViewAddonExtention_RowUpdated);
            // 
            // ColumnChecked
            // 
            this.ColumnChecked.Caption = "选择";
            this.ColumnChecked.FieldName = "Checked";
            this.ColumnChecked.Name = "ColumnChecked";
            this.ColumnChecked.OptionsColumn.FixedWidth = true;
            this.ColumnChecked.OptionsColumn.ShowCaption = false;
            this.ColumnChecked.Visible = true;
            this.ColumnChecked.VisibleIndex = 0;
            this.ColumnChecked.Width = 40;
            // 
            // ColumnPropertyName
            // 
            this.ColumnPropertyName.Caption = "属性名称";
            this.ColumnPropertyName.FieldName = "DisplayName";
            this.ColumnPropertyName.Name = "ColumnPropertyName";
            this.ColumnPropertyName.Visible = true;
            this.ColumnPropertyName.VisibleIndex = 1;
            this.ColumnPropertyName.Width = 147;
            // 
            // ColumnOrigionValue
            // 
            this.ColumnOrigionValue.Caption = "原始值";
            this.ColumnOrigionValue.FieldName = "OriginValue";
            this.ColumnOrigionValue.Name = "ColumnOrigionValue";
            this.ColumnOrigionValue.Visible = true;
            this.ColumnOrigionValue.VisibleIndex = 2;
            this.ColumnOrigionValue.Width = 263;
            // 
            // ColumnPropertyValue
            // 
            this.ColumnPropertyValue.Caption = "属性值";
            this.ColumnPropertyValue.FieldName = "PropertyValue";
            this.ColumnPropertyValue.Name = "ColumnPropertyValue";
            this.ColumnPropertyValue.Visible = true;
            this.ColumnPropertyValue.VisibleIndex = 3;
            this.ColumnPropertyValue.Width = 317;
            // 
            // AddonExtentionEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControlAddonExtention);
            this.Name = "AddonExtentionEditControl";
            this.Size = new System.Drawing.Size(785, 571);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAddonPropertyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAddonExtention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAddonExtention)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource BindingSourceAddonPropertyInfo;
        private DevExpress.XtraGrid.GridControl GridControlAddonExtention;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAddonExtention;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnChecked;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPropertyName;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnOrigionValue;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPropertyValue;
    }
}
