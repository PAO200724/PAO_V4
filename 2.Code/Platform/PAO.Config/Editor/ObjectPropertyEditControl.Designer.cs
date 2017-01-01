namespace PAO.Config.Editor
{
    partial class ObjectPropertyEditControl
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
            this.PopupMenu = new DevExpress.XtraBars.PopupMenu();
            this.EditCaption = new DevExpress.XtraBars.BarEditItem();
            this.TextEditCaption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ButtonDeleteRow = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonCustom = new DevExpress.XtraBars.BarButtonItem();
            this.BarManager = new DevExpress.XtraBars.BarManager();
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.MenuFormat = new DevExpress.XtraBars.BarSubItem();
            this.ButtonRecoverFormat = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonSaveFormat = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonLoadFormat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // PropertyDescriptionControl
            // 
            this.PropertyDescriptionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyDescriptionControl.Location = new System.Drawing.Point(0, 0);
            this.PropertyDescriptionControl.Name = "PropertyDescriptionControl";
            this.PropertyDescriptionControl.PropertyGrid = this.PropertyGridControl;
            this.PropertyDescriptionControl.Size = new System.Drawing.Size(466, 96);
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
            this.PropertyGridControl.Size = new System.Drawing.Size(466, 540);
            this.PropertyGridControl.TabIndex = 0;
            this.PropertyGridControl.FocusedRowChanged += new DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventHandler(this.PropertyGridControl_FocusedRowChanged);
            this.PropertyGridControl.CustomRecordCellEdit += new DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventHandler(this.PropertyGridControl_CustomRecordCellEdit);
            this.PropertyGridControl.CustomRecordCellEditForEditing += new DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventHandler(this.PropertyGridControl_CustomRecordCellEditForEditing);
            this.PropertyGridControl.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.PropertyGridControl_CellValueChanged);
            this.PropertyGridControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PropertyGridControl_MouseUp);
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.SplitContainerControl.Horizontal = false;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 31);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.Controls.Add(this.PropertyGridControl);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.Controls.Add(this.PropertyDescriptionControl);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(466, 641);
            this.SplitContainerControl.SplitterPosition = 96;
            this.SplitContainerControl.TabIndex = 1;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // PopupMenu
            // 
            this.PopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.EditCaption, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ButtonDeleteRow, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonCustom)});
            this.PopupMenu.Manager = this.BarManager;
            this.PopupMenu.Name = "PopupMenu";
            // 
            // EditCaption
            // 
            this.EditCaption.Caption = "标题(&C)";
            this.EditCaption.Edit = this.TextEditCaption;
            this.EditCaption.EditWidth = 144;
            this.EditCaption.Id = 0;
            this.EditCaption.Name = "EditCaption";
            this.EditCaption.EditValueChanged += new System.EventHandler(this.EditCaption_EditValueChanged);
            // 
            // TextEditCaption
            // 
            this.TextEditCaption.AutoHeight = false;
            this.TextEditCaption.Name = "TextEditCaption";
            // 
            // ButtonDeleteRow
            // 
            this.ButtonDeleteRow.Caption = "删除行(&D)";
            this.ButtonDeleteRow.Glyph = global::PAO.Config.Properties.Resources.remove_16x16;
            this.ButtonDeleteRow.Id = 1;
            this.ButtonDeleteRow.Name = "ButtonDeleteRow";
            this.ButtonDeleteRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonDeleteRow_ItemClick);
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
            this.EditCaption,
            this.ButtonDeleteRow,
            this.ButtonCustom,
            this.ButtonRecoverFormat,
            this.MenuFormat,
            this.ButtonSaveFormat,
            this.ButtonLoadFormat});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonDeleteRow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonCustom),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuFormat),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.EditCaption, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarTools.OptionsBar.AllowQuickCustomization = false;
            this.BarTools.OptionsBar.DrawDragBorder = false;
            this.BarTools.OptionsBar.UseWholeRow = true;
            this.BarTools.Text = "工具条";
            // 
            // MenuFormat
            // 
            this.MenuFormat.Caption = "格式(&F)";
            this.MenuFormat.Id = 4;
            this.MenuFormat.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRecoverFormat),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonSaveFormat, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonLoadFormat)});
            this.MenuFormat.Name = "MenuFormat";
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
            // ButtonSaveFormat
            // 
            this.ButtonSaveFormat.Caption = "保存格式(&S)...";
            this.ButtonSaveFormat.Id = 5;
            this.ButtonSaveFormat.Name = "ButtonSaveFormat";
            this.ButtonSaveFormat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonSaveFormat_ItemClick);
            // 
            // ButtonLoadFormat
            // 
            this.ButtonLoadFormat.Caption = "读取格式(&L)...";
            this.ButtonLoadFormat.Id = 6;
            this.ButtonLoadFormat.Name = "ButtonLoadFormat";
            this.ButtonLoadFormat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonLoadFormat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(466, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 672);
            this.barDockControlBottom.Size = new System.Drawing.Size(466, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 641);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(466, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 641);
            // 
            // ObjectPropertyEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ObjectPropertyEditControl";
            this.Size = new System.Drawing.Size(466, 672);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ObjectPropertyEditControl_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl PropertyDescriptionControl;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraVerticalGrid.PropertyGridControl PropertyGridControl;
        private DevExpress.XtraBars.PopupMenu PopupMenu;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem EditCaption;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TextEditCaption;
        private DevExpress.XtraBars.BarButtonItem ButtonDeleteRow;
        private DevExpress.XtraBars.BarButtonItem ButtonCustom;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarButtonItem ButtonRecoverFormat;
        private DevExpress.XtraBars.BarSubItem MenuFormat;
        private DevExpress.XtraBars.BarButtonItem ButtonSaveFormat;
        private DevExpress.XtraBars.BarButtonItem ButtonLoadFormat;
    }
}
