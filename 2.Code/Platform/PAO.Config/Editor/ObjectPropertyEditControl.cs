using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm;
using PAO.Config.Editor;
using PAO.IO;
using PAO.WinForm.Editor;
using PAO.WinForm.Config;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using PAO.UI;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 插件编辑控件
    /// </summary>
    public partial class ObjectPropertyEditControl : BaseObjectEditControl, IBarSupport
    {
        private byte[] DefaultLayoutData = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                this.PropertyGridControl.CloseEditor();
                return base.EditValue;
            }

            set {
                base.EditValue = value;

                this.PropertyGridControl.SelectedObject = value;
                var controller = Controller as ObjectPropertyEditController;
                if (controller.IsTypeEditController && value != null) {
                    controller = ConfigPublic.GetEditControllerByType<ObjectPropertyEditController>(value.GetType());
                }

                DefaultLayoutData = this.PropertyGridControl.GetLayoutData();
                if (controller != null) {
                    this.PropertyGridControl.SetLayoutData(controller.LayoutData);
                }
                SetControlStatus();
            }
        }

        public IEnumerable<Bar> ExtendBars {
            get {
                return new Bar[] { this.BarTools };
            }
        }

        public ObjectPropertyEditControl() {
            InitializeComponent();
            SetControlStatus();
        }

        protected override void OnClose() {
            var editValue = EditValue;
            var controller = Controller as ObjectPropertyEditController;
            if (controller.IsTypeEditController && editValue != null) {
                controller = ConfigPublic.CreateEditControllerByType<ObjectPropertyEditController>(editValue.GetType());
            }

            if (controller != null) {
                controller.LayoutData = this.PropertyGridControl.GetLayoutData();
                ExtendAddonPublic.SetExtendLocalAddon(controller);
            }
            base.OnClose();
        }

        protected override void SetControlStatus() {
            base.SetControlStatus();
            this.EditCaption.Enabled = this.PropertyGridControl.FocusedRow != null;
            this.ButtonDeleteRow.Enabled = this.PropertyGridControl.FocusedRow != null;
            if (this.PropertyGridControl.FocusedRow != null) {
                EditCaption.EditValue = this.PropertyGridControl.FocusedRow.Properties.Caption;
            }
        }

        private void PropertyGridControl_CellValueChanged(object sender
            , DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) {
            ModifyData();
        }

        private void PropertyGridControl_CustomRecordCellEditForEditing(object sender
            , DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e) {
        }

        Dictionary<PropertyDescriptor, RepositoryItem> EditList = new Dictionary<PropertyDescriptor, RepositoryItem>();
        private void PropertyGridControl_CustomRecordCellEdit(object sender, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e) {
            BaseEditController edit = null;
            var propDesc = PropertyGridControl.GetPropertyDescriptor(e.Row);
            if (propDesc == null)
                return;

            if(EditList.ContainsKey(propDesc)) {
                e.RepositoryItem = EditList[propDesc];
                return;
            }

            if(propDesc is ConfigPropertyDescriptor) {
                var configProp = propDesc as ConfigPropertyDescriptor;
                if(configProp.Editor != null) {
                    edit = IOPublic.ObjectClone(configProp.Editor) as BaseEditController;
                }
            }

            if(edit == null) {
                edit = ConfigPublic.GetEditor(propDesc);
            }

            if (edit == null) {
                if(propDesc.PropertyType.IsDerivedFrom(typeof(PaoObject))) {
                    edit = ObjectPropertyEditController.DefaultTypeEditController;
                }
            }

            if (edit != null) {
                e.RepositoryItem = edit.CreateRepositoryItem(propDesc.PropertyType);
            }

            EditList.Add(propDesc, e.RepositoryItem);
        }
        
        private void ObjectEditControl_Leave(object sender, EventArgs e) {
            this.PropertyGridControl.CloseEditor();
        }

        private void PropertyGridControl_CustomPropertyDescriptors(object sender, DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs e) {
            if (e.Properties.IsNullOrEmpty())
                return;

            var propertyDescriptors = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor propertyDesc in e.Properties) {
                var configedProperty = WinFormPublic.GetConfigedProperty(propertyDesc);
                if(configedProperty != null) {
                    propertyDescriptors.Add(configedProperty);
                }
            }

            e.Properties = new PropertyDescriptorCollection(propertyDescriptors.ToArray());
        }

        private void PropertyGridControl_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var pt = new Point(e.X, e.Y);
                var HitInfo = this.PropertyGridControl.CalcHitInfo(pt);
                if(HitInfo.HitInfoType == DevExpress.XtraVerticalGrid.HitInfoTypeEnum.HeaderCell) {
                    this.PropertyGridControl.FocusedRow = HitInfo.Row;
                    // 显示菜单
                    PopupMenu.ShowPopup(this.PropertyGridControl.PointToScreen(pt));
                }
            }
        }

        private void EditCaption_EditValueChanged(object sender, EventArgs e) {
            if(this.PropertyGridControl.FocusedRow != null) {
                this.PropertyGridControl.FocusedRow.Properties.Caption = EditCaption.EditValue as string;
            }
        }
                        
        private void ButtonCustom_ItemClick(object sender, ItemClickEventArgs e) {
            this.PropertyGridControl.RowsCustomization();
        }

        private void ButtonDeleteRow_ItemClick(object sender, ItemClickEventArgs e) {
            if (this.PropertyGridControl.FocusedRow != null) {
                this.PropertyGridControl.FocusedRow.Visible = false;
                SetControlStatus();
            }
        }

        private void PropertyGridControl_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e) {
            SetControlStatus();
        }

        private void ButtonRecoverFormat_ItemClick(object sender, ItemClickEventArgs e) {
            if(DefaultLayoutData.IsNotNullOrEmpty()) {
                if(UIPublic.ShowYesNoCancelDialog("您是否需要默认格式？") == DialogReturn.Yes) {
                    this.PropertyGridControl.SetLayoutData(DefaultLayoutData);
                }
            }
        }
    }
}
