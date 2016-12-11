using PAO.Data;

namespace PAO.Config.Controls.EditControls
{
    partial class DataCommandInfoEditControl
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
            this.BindingSourceDataCommandInfo = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.DataFilterEditControl = new DataFilterEditControl();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SqlTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.LayoutControlGroupSql = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSql = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlGroupDataFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItemDataFilter = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDataCommandInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SqlTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupSql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupDataFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemDataFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSourceDataCommandInfo
            // 
            this.BindingSourceDataCommandInfo.DataSource = typeof(PAO.Data.DataCommandInfo);
            this.BindingSourceDataCommandInfo.CurrentItemChanged += new System.EventHandler(this.BindingSourceDataCommandInfo_CurrentItemChanged);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.DataFilterEditControl);
            this.dataLayoutControl1.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SqlTextEdit);
            this.dataLayoutControl1.DataSource = this.BindingSourceDataCommandInfo;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(873, 282, 689, 620);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(743, 590);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // DataFilterEditControl
            // 
            this.DataFilterEditControl.Location = new System.Drawing.Point(358, 58);
            this.DataFilterEditControl.Name = "DataFilterEditControl";
            this.DataFilterEditControl.ShowApplyButton = false;
            this.DataFilterEditControl.ShowCancelButton = true;
            this.DataFilterEditControl.Size = new System.Drawing.Size(370, 517);
            this.DataFilterEditControl.TabIndex = 6;
            this.DataFilterEditControl.DataModifyStateChanged += new System.EventHandler<PAO.UI.WinForm.DataModifyStateChangedEventArgs>(this.DataFilterEditControl_DataModifyStateChanged);
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceDataCommandInfo, "Name", true));
            this.NameTextEdit.Location = new System.Drawing.Point(39, 12);
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(692, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl1;
            this.NameTextEdit.TabIndex = 4;
            // 
            // SqlTextEdit
            // 
            this.SqlTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceDataCommandInfo, "Sql", true));
            this.SqlTextEdit.EditValue = "";
            this.SqlTextEdit.Location = new System.Drawing.Point(15, 58);
            this.SqlTextEdit.Name = "SqlTextEdit";
            this.SqlTextEdit.Properties.Appearance.Font = new System.Drawing.Font("SimSun-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SqlTextEdit.Properties.Appearance.Options.UseFont = true;
            this.SqlTextEdit.Size = new System.Drawing.Size(328, 517);
            this.SqlTextEdit.StyleController = this.dataLayoutControl1;
            this.SqlTextEdit.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(743, 590);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.splitterItem1,
            this.LayoutControlGroupSql,
            this.LayoutControlGroupDataFilter});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(723, 570);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(723, 24);
            this.ItemForName.Text = "名称";
            this.ItemForName.TextSize = new System.Drawing.Size(24, 14);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(338, 24);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 546);
            // 
            // LayoutControlGroupSql
            // 
            this.LayoutControlGroupSql.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSql});
            this.LayoutControlGroupSql.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlGroupSql.Name = "LayoutControlGroupSql";
            this.LayoutControlGroupSql.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutControlGroupSql.Size = new System.Drawing.Size(338, 546);
            this.LayoutControlGroupSql.Text = "查询语句";
            // 
            // ItemForSql
            // 
            this.ItemForSql.Control = this.SqlTextEdit;
            this.ItemForSql.Location = new System.Drawing.Point(0, 0);
            this.ItemForSql.Name = "ItemForSql";
            this.ItemForSql.Size = new System.Drawing.Size(332, 521);
            this.ItemForSql.Text = "SQL语句";
            this.ItemForSql.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForSql.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForSql.TextVisible = false;
            // 
            // LayoutControlGroupDataFilter
            // 
            this.LayoutControlGroupDataFilter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemDataFilter});
            this.LayoutControlGroupDataFilter.Location = new System.Drawing.Point(343, 24);
            this.LayoutControlGroupDataFilter.Name = "LayoutControlGroupDataFilter";
            this.LayoutControlGroupDataFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutControlGroupDataFilter.Size = new System.Drawing.Size(380, 546);
            this.LayoutControlGroupDataFilter.Text = "数据过滤器";
            // 
            // LayoutControlItemDataFilter
            // 
            this.LayoutControlItemDataFilter.Control = this.DataFilterEditControl;
            this.LayoutControlItemDataFilter.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemDataFilter.Name = "LayoutControlItemDataFilter";
            this.LayoutControlItemDataFilter.Size = new System.Drawing.Size(374, 521);
            this.LayoutControlItemDataFilter.Text = "数据过滤器";
            this.LayoutControlItemDataFilter.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemDataFilter.TextVisible = false;
            // 
            // DataCommandInfoEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "DataCommandInfoEditControl";
            this.Size = new System.Drawing.Size(743, 590);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDataCommandInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SqlTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupSql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupDataFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemDataFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource BindingSourceDataCommandInfo;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DataFilterEditControl DataFilterEditControl;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSql;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupDataFilter;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemDataFilter;
        private DevExpress.XtraEditors.MemoEdit SqlTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupSql;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
    }
}
