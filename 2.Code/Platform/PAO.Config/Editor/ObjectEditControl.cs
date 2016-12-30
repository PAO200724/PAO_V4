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

namespace PAO.Config.Editor
{
    /// <summary>
    /// 插件编辑控件
    /// </summary>
    public partial class ObjectEditControl : BaseEditControl
    {
        VGridHitInfo HitInfo;

        internal ObjectEditControl() {
            InitializeComponent();
            EditValue = null;
            SetControlStatus();
        }
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

                SetControlStatus();
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
                    edit = new ObjectEditController();
                }
            }

            if (edit != null) {
                edit.PropertyDescriptor = propDesc;
                e.RepositoryItem = edit.CreateRepositoryItem();
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
            HitInfo = null;
            if (e.Button == MouseButtons.Right) {
                var pt = new Point(e.X, e.Y);
                HitInfo = this.PropertyGridControl.CalcHitInfo(pt);
                if(HitInfo.HitInfoType == DevExpress.XtraVerticalGrid.HitInfoTypeEnum.HeaderCell) {
                    // 显示菜单
                    PopupMenu.ShowPopup(this.PropertyGridControl.PointToScreen(pt));
                }
            }
        }

        private void EditCaption_EditValueChanged(object sender, EventArgs e) {
            if(HitInfo != null) {
                HitInfo.Row.Properties.Caption = EditCaption.EditValue as string;
            }
        }

        private void PopupMenu_BeforePopup(object sender, CancelEventArgs e) {
            if (HitInfo != null) {
                EditCaption.EditValue = HitInfo.Row.Properties.Caption;
            }
        }
    }
}
