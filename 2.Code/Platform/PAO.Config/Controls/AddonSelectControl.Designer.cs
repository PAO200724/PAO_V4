namespace PAO.Controls
{
    partial class AddonSelectControl
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
            this.GridControlAddonList = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceAddon = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewAddonList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSelf = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAddonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAddon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAddonList)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControlAddonList
            // 
            this.GridControlAddonList.DataSource = this.BindingSourceAddon;
            this.GridControlAddonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlAddonList.Location = new System.Drawing.Point(0, 0);
            this.GridControlAddonList.MainView = this.GridViewAddonList;
            this.GridControlAddonList.Name = "GridControlAddonList";
            this.GridControlAddonList.Size = new System.Drawing.Size(844, 584);
            this.GridControlAddonList.TabIndex = 0;
            this.GridControlAddonList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAddonList});
            // 
            // GridViewAddonList
            // 
            this.GridViewAddonList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnID,
            this.ColumnType,
            this.ColumnSelf});
            this.GridViewAddonList.GridControl = this.GridControlAddonList;
            this.GridViewAddonList.Name = "GridViewAddonList";
            this.GridViewAddonList.OptionsBehavior.AutoPopulateColumns = false;
            this.GridViewAddonList.OptionsBehavior.ReadOnly = true;
            this.GridViewAddonList.OptionsFind.AlwaysVisible = true;
            this.GridViewAddonList.OptionsFind.FindNullPrompt = "输入文字查找...";
            this.GridViewAddonList.OptionsView.ShowAutoFilterRow = true;
            this.GridViewAddonList.OptionsView.ShowGroupPanel = false;
            this.GridViewAddonList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColumnType, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ColumnID
            // 
            this.ColumnID.Caption = "ID";
            this.ColumnID.FieldName = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.ColumnID.Visible = true;
            this.ColumnID.VisibleIndex = 2;
            this.ColumnID.Width = 249;
            // 
            // ColumnType
            // 
            this.ColumnType.Caption = "类型";
            this.ColumnType.FieldName = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Visible = true;
            this.ColumnType.VisibleIndex = 0;
            this.ColumnType.Width = 243;
            // 
            // ColumnSelf
            // 
            this.ColumnSelf.Caption = "对象";
            this.ColumnSelf.FieldName = "Object";
            this.ColumnSelf.Name = "ColumnSelf";
            this.ColumnSelf.Visible = true;
            this.ColumnSelf.VisibleIndex = 1;
            this.ColumnSelf.Width = 334;
            // 
            // AddonSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControlAddonList);
            this.Name = "AddonSelectControl";
            this.Size = new System.Drawing.Size(844, 584);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAddonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAddon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAddonList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControlAddonList;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAddonList;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSelf;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnType;
        private System.Windows.Forms.BindingSource BindingSourceAddon;
    }
}
