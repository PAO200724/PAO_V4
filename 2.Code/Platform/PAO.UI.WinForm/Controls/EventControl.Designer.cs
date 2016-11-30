﻿using System;

namespace PAO.UI.WinForm.Controls
{
    partial class EventControl
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
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.ImageControl = new PAO.UI.WinForm.Controls.ImageControl();
            this.TextEditSource = new DevExpress.XtraEditors.TextEdit();
            this.GridControlData = new DevExpress.XtraGrid.GridControl();
            this.GridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumnKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TreeListAssetSnapshot = new DevExpress.XtraTreeList.TreeList();
            this.MemoEditDetail = new DevExpress.XtraEditors.MemoEdit();
            this.TextEditType = new DevExpress.XtraEditors.TextEdit();
            this.TextEditTime = new DevExpress.XtraEditors.TextEdit();
            this.TextEditMessage = new DevExpress.XtraEditors.TextEdit();
            this.RootGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.TabbedControlGroup = new DevExpress.XtraLayout.TabbedControlGroup();
            this.LayoutControlGroupScreenShot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItemPicture = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlGroupCommon = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItemTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItemMessage = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItemType = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlGroupDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItemDetail = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItemSource = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlGroupData = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItemData = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlGroupAssetSnapshot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItemAssetSnapshot = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListAssetSnapshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoEditDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupScreenShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupAssetSnapshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemAssetSnapshot)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ImageControl);
            this.LayoutControl.Controls.Add(this.TextEditSource);
            this.LayoutControl.Controls.Add(this.GridControlData);
            this.LayoutControl.Controls.Add(this.TreeListAssetSnapshot);
            this.LayoutControl.Controls.Add(this.MemoEditDetail);
            this.LayoutControl.Controls.Add(this.TextEditType);
            this.LayoutControl.Controls.Add(this.TextEditTime);
            this.LayoutControl.Controls.Add(this.TextEditMessage);
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(606, 161, 250, 350);
            this.LayoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControl.Root = this.RootGroup;
            this.LayoutControl.Size = new System.Drawing.Size(572, 385);
            this.LayoutControl.TabIndex = 0;
            this.LayoutControl.Text = "LayoutControl";
            // 
            // ImageControl
            // 
            this.ImageControl.Image = null;
            this.ImageControl.Location = new System.Drawing.Point(79, 14);
            this.ImageControl.MaxZoomPercent = 200D;
            this.ImageControl.MinZoomPercent = 50D;
            this.ImageControl.Name = "ImageControl";
            this.ImageControl.ReadOnly = true;
            this.ImageControl.ShowApplyButton = false;
            this.ImageControl.ShowCancelButton = true;
            this.ImageControl.Size = new System.Drawing.Size(479, 357);
            this.ImageControl.TabIndex = 12;
            // 
            // TextEditSource
            // 
            this.TextEditSource.Location = new System.Drawing.Point(118, 14);
            this.TextEditSource.Name = "TextEditSource";
            this.TextEditSource.Properties.ReadOnly = true;
            this.TextEditSource.Size = new System.Drawing.Size(199, 20);
            this.TextEditSource.StyleController = this.LayoutControl;
            this.TextEditSource.TabIndex = 11;
            // 
            // GridControlData
            // 
            this.GridControlData.Location = new System.Drawing.Point(79, 14);
            this.GridControlData.MainView = this.GridViewData;
            this.GridControlData.Name = "GridControlData";
            this.GridControlData.Size = new System.Drawing.Size(479, 357);
            this.GridControlData.TabIndex = 10;
            this.GridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewData});
            // 
            // GridViewData
            // 
            this.GridViewData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumnKey,
            this.GridColumnValue});
            this.GridViewData.GridControl = this.GridControlData;
            this.GridViewData.Name = "GridViewData";
            this.GridViewData.OptionsBehavior.Editable = false;
            this.GridViewData.OptionsView.ShowGroupPanel = false;
            // 
            // GridColumnKey
            // 
            this.GridColumnKey.Caption = "名称";
            this.GridColumnKey.FieldName = "Key";
            this.GridColumnKey.Name = "GridColumnKey";
            this.GridColumnKey.Visible = true;
            this.GridColumnKey.VisibleIndex = 0;
            // 
            // GridColumnValue
            // 
            this.GridColumnValue.Caption = "值";
            this.GridColumnValue.FieldName = "Value";
            this.GridColumnValue.Name = "GridColumnValue";
            this.GridColumnValue.Visible = true;
            this.GridColumnValue.VisibleIndex = 1;
            // 
            // TreeListAssetSnapshot
            // 
            this.TreeListAssetSnapshot.Location = new System.Drawing.Point(79, 14);
            this.TreeListAssetSnapshot.Name = "TreeListAssetSnapshot";
            this.TreeListAssetSnapshot.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListAssetSnapshot.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.TreeListAssetSnapshot.Size = new System.Drawing.Size(479, 357);
            this.TreeListAssetSnapshot.TabIndex = 9;
            // 
            // MemoEditDetail
            // 
            this.MemoEditDetail.Location = new System.Drawing.Point(82, 108);
            this.MemoEditDetail.Name = "MemoEditDetail";
            this.MemoEditDetail.Properties.ReadOnly = true;
            this.MemoEditDetail.Size = new System.Drawing.Size(473, 260);
            this.MemoEditDetail.StyleController = this.LayoutControl;
            this.MemoEditDetail.TabIndex = 7;
            // 
            // TextEditType
            // 
            this.TextEditType.Location = new System.Drawing.Point(118, 38);
            this.TextEditType.Name = "TextEditType";
            this.TextEditType.Properties.ReadOnly = true;
            this.TextEditType.Size = new System.Drawing.Size(440, 20);
            this.TextEditType.StyleController = this.LayoutControl;
            this.TextEditType.TabIndex = 6;
            // 
            // TextEditTime
            // 
            this.TextEditTime.Location = new System.Drawing.Point(360, 14);
            this.TextEditTime.Name = "TextEditTime";
            this.TextEditTime.Properties.ReadOnly = true;
            this.TextEditTime.Size = new System.Drawing.Size(198, 20);
            this.TextEditTime.StyleController = this.LayoutControl;
            this.TextEditTime.TabIndex = 5;
            // 
            // TextEditMessage
            // 
            this.TextEditMessage.Location = new System.Drawing.Point(118, 62);
            this.TextEditMessage.Name = "TextEditMessage";
            this.TextEditMessage.Properties.ReadOnly = true;
            this.TextEditMessage.Size = new System.Drawing.Size(440, 20);
            this.TextEditMessage.StyleController = this.LayoutControl;
            this.TextEditMessage.TabIndex = 4;
            // 
            // RootGroup
            // 
            this.RootGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootGroup.GroupBordersVisible = false;
            this.RootGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.TabbedControlGroup});
            this.RootGroup.Location = new System.Drawing.Point(0, 0);
            this.RootGroup.Name = "Root";
            this.RootGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.RootGroup.Size = new System.Drawing.Size(572, 385);
            this.RootGroup.TextVisible = false;
            // 
            // TabbedControlGroup
            // 
            this.TabbedControlGroup.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.TabbedControlGroup.Location = new System.Drawing.Point(0, 0);
            this.TabbedControlGroup.Name = "TabbedControlGroup";
            this.TabbedControlGroup.SelectedTabPage = this.LayoutControlGroupCommon;
            this.TabbedControlGroup.SelectedTabPageIndex = 0;
            this.TabbedControlGroup.Size = new System.Drawing.Size(572, 385);
            this.TabbedControlGroup.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlGroupCommon,
            this.LayoutControlGroupData,
            this.LayoutControlGroupScreenShot,
            this.LayoutControlGroupAssetSnapshot});
            this.TabbedControlGroup.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // LayoutControlGroupScreenShot
            // 
            this.LayoutControlGroupScreenShot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemPicture});
            this.LayoutControlGroupScreenShot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupScreenShot.Name = "LayoutControlGroupScreenShot";
            this.LayoutControlGroupScreenShot.Size = new System.Drawing.Size(483, 361);
            this.LayoutControlGroupScreenShot.Text = "屏幕截图";
            // 
            // LayoutControlItemPicture
            // 
            this.LayoutControlItemPicture.Control = this.ImageControl;
            this.LayoutControlItemPicture.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemPicture.Name = "LayoutControlItemPicture";
            this.LayoutControlItemPicture.Size = new System.Drawing.Size(483, 361);
            this.LayoutControlItemPicture.Text = "屏幕截图";
            this.LayoutControlItemPicture.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemPicture.TextVisible = false;
            // 
            // LayoutControlGroupCommon
            // 
            this.LayoutControlGroupCommon.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemTime,
            this.LayoutControlItemMessage,
            this.LayoutControlItemType,
            this.LayoutControlGroupDetail,
            this.LayoutControlItemSource});
            this.LayoutControlGroupCommon.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupCommon.Name = "LayoutControlGroupCommon";
            this.LayoutControlGroupCommon.Size = new System.Drawing.Size(483, 361);
            this.LayoutControlGroupCommon.Text = "异常信息";
            // 
            // LayoutControlItemTime
            // 
            this.LayoutControlItemTime.Control = this.TextEditTime;
            this.LayoutControlItemTime.Location = new System.Drawing.Point(242, 0);
            this.LayoutControlItemTime.Name = "LayoutControlItemTime";
            this.LayoutControlItemTime.Size = new System.Drawing.Size(241, 24);
            this.LayoutControlItemTime.Text = "时间：";
            this.LayoutControlItemTime.TextSize = new System.Drawing.Size(36, 14);
            // 
            // LayoutControlItemMessage
            // 
            this.LayoutControlItemMessage.Control = this.TextEditMessage;
            this.LayoutControlItemMessage.Location = new System.Drawing.Point(0, 48);
            this.LayoutControlItemMessage.Name = "LayoutControlItemMessage";
            this.LayoutControlItemMessage.Size = new System.Drawing.Size(483, 24);
            this.LayoutControlItemMessage.Text = "消息：";
            this.LayoutControlItemMessage.TextSize = new System.Drawing.Size(36, 14);
            // 
            // LayoutControlItemType
            // 
            this.LayoutControlItemType.Control = this.TextEditType;
            this.LayoutControlItemType.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlItemType.Name = "LayoutControlItemType";
            this.LayoutControlItemType.Size = new System.Drawing.Size(483, 24);
            this.LayoutControlItemType.Text = "类型：";
            this.LayoutControlItemType.TextSize = new System.Drawing.Size(36, 14);
            // 
            // LayoutControlGroupDetail
            // 
            this.LayoutControlGroupDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemDetail});
            this.LayoutControlGroupDetail.Location = new System.Drawing.Point(0, 72);
            this.LayoutControlGroupDetail.Name = "LayoutControlGroupDetail";
            this.LayoutControlGroupDetail.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutControlGroupDetail.Size = new System.Drawing.Size(483, 289);
            this.LayoutControlGroupDetail.Text = "详细信息";
            // 
            // LayoutControlItemDetail
            // 
            this.LayoutControlItemDetail.Control = this.MemoEditDetail;
            this.LayoutControlItemDetail.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemDetail.Name = "LayoutControlItemDetail";
            this.LayoutControlItemDetail.Size = new System.Drawing.Size(477, 264);
            this.LayoutControlItemDetail.Text = "详细信息";
            this.LayoutControlItemDetail.TextLocation = DevExpress.Utils.Locations.Top;
            this.LayoutControlItemDetail.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemDetail.TextVisible = false;
            // 
            // LayoutControlItemSource
            // 
            this.LayoutControlItemSource.Control = this.TextEditSource;
            this.LayoutControlItemSource.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemSource.Name = "LayoutControlItemSource";
            this.LayoutControlItemSource.Size = new System.Drawing.Size(242, 24);
            this.LayoutControlItemSource.Text = "源：";
            this.LayoutControlItemSource.TextSize = new System.Drawing.Size(36, 14);
            // 
            // LayoutControlGroupData
            // 
            this.LayoutControlGroupData.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemData});
            this.LayoutControlGroupData.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupData.Name = "LayoutControlGroupData";
            this.LayoutControlGroupData.Size = new System.Drawing.Size(483, 361);
            this.LayoutControlGroupData.Text = "消息数据";
            // 
            // LayoutControlItemData
            // 
            this.LayoutControlItemData.Control = this.GridControlData;
            this.LayoutControlItemData.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemData.Name = "LayoutControlItemData";
            this.LayoutControlItemData.Size = new System.Drawing.Size(483, 361);
            this.LayoutControlItemData.Text = "消息数据";
            this.LayoutControlItemData.TextLocation = DevExpress.Utils.Locations.Top;
            this.LayoutControlItemData.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemData.TextVisible = false;
            // 
            // LayoutControlGroupAssetSnapshot
            // 
            this.LayoutControlGroupAssetSnapshot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItemAssetSnapshot});
            this.LayoutControlGroupAssetSnapshot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupAssetSnapshot.Name = "LayoutControlGroupAssetSnapshot";
            this.LayoutControlGroupAssetSnapshot.Size = new System.Drawing.Size(483, 361);
            this.LayoutControlGroupAssetSnapshot.Text = "资产快照";
            // 
            // LayoutControlItemAssetSnapshot
            // 
            this.LayoutControlItemAssetSnapshot.Control = this.TreeListAssetSnapshot;
            this.LayoutControlItemAssetSnapshot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItemAssetSnapshot.Name = "LayoutControlItemAssetSnapshot";
            this.LayoutControlItemAssetSnapshot.Size = new System.Drawing.Size(483, 361);
            this.LayoutControlItemAssetSnapshot.Text = "资产快照";
            this.LayoutControlItemAssetSnapshot.TextLocation = DevExpress.Utils.Locations.Top;
            this.LayoutControlItemAssetSnapshot.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItemAssetSnapshot.TextVisible = false;
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl);
            this.Name = "EventControl";
            this.Size = new System.Drawing.Size(572, 385);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListAssetSnapshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoEditDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupScreenShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupAssetSnapshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItemAssetSnapshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup RootGroup;
        private DevExpress.XtraEditors.TextEdit TextEditMessage;
        private DevExpress.XtraEditors.TextEdit TextEditTime;
        private DevExpress.XtraLayout.TabbedControlGroup TabbedControlGroup;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupCommon;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemTime;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemMessage;
        private DevExpress.XtraEditors.TextEdit TextEditType;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemType;
        private DevExpress.XtraEditors.MemoEdit MemoEditDetail;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemDetail;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupDetail;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupScreenShot;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupAssetSnapshot;
        private DevExpress.XtraTreeList.TreeList TreeListAssetSnapshot;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemAssetSnapshot;
        private DevExpress.XtraGrid.GridControl GridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewData;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupData;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemData;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnKey;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnValue;
        private DevExpress.XtraEditors.TextEdit TextEditSource;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemSource;
        private ImageControl ImageControl;
        private DevExpress.XtraLayout.LayoutControlItem LayoutControlItemPicture;
    }
}