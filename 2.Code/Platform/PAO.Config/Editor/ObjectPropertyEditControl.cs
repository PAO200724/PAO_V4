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
            if (controller != null) {
                controller.LayoutData = this.PropertyGridControl.GetLayoutData();
                // 如果设置了ObjectType，则保存默认配置
                if(controller.StaticType && EditValue!=null) {
                    EditorPublic.SetDefaultEditController(EditValue.GetType(), controller);
                }
            }
            base.OnClose();
        }

        protected override void SetControlStatus() {
            base.SetControlStatus();
            this.EditCaption.Enabled = this.PropertyGridControl.FocusedRow != null;
            this.ButtonDeleteRow.Enabled = this.PropertyGridControl.FocusedRow != null;
            if (this.PropertyGridControl.FocusedRow != null) {
                EditCaption.EditValue = this.PropertyGridControl.FocusedRow.Properties.Caption;

                var propDesc = PropertyGridControl.GetPropertyDescriptor(PropertyGridControl.FocusedRow);
                this.ButtonEditor.Enabled = propDesc != null;
                this.ButtonRecoverEditor.Enabled = propDesc != null;
            }
            else {
                this.ButtonEditor.Enabled = false;
            }
        }

        private void PropertyGridControl_CellValueChanged(object sender
            , DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) {
            ModifyData();
        }

        private void PropertyGridControl_CustomRecordCellEditForEditing(object sender
            , DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e) {
        }

        private void PropertyGridControl_CustomRecordCellEdit(object sender, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e) {
            RepositoryItem repositoryItem = null;
            var propDesc = PropertyGridControl.GetPropertyDescriptor(e.Row);
            if (propDesc == null)
                return;
            var controller = Controller as ObjectPropertyEditController;
            if(controller != null) {
                var editController = controller.GetPredefinedEditController(propDesc.PropertyType, propDesc.Name);
                if(editController != null)
                    repositoryItem = editController.CreateRepositoryItem(propDesc.PropertyType);
            }

            if (repositoryItem == null) {
                if (propDesc.PropertyType.IsAddon()) {
                    // 如果是插件，统一使用CommonObjectEditControl，这样可以新增空对象
                    var editController = new CommonObjectEditController();
                    editController.StartEditProperty(EditValue, propDesc.Name);
                    repositoryItem = editController.CreateRepositoryItem(propDesc.PropertyType);
                }
                else {
                    repositoryItem = ConfigPublic.CreateRepositoryItem(propDesc);
                }
            }

            if (repositoryItem != null) {
                e.RepositoryItem = repositoryItem;
            }
        }

        private void ObjectPropertyEditControl_Validating(object sender, CancelEventArgs e) {
            this.PropertyGridControl.CloseEditor();
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
                if(UIPublic.ShowYesNoDialog("您是否需要默认格式？") == DialogReturn.Yes) {
                    this.PropertyGridControl.SetLayoutData(DefaultLayoutData);
                }
            }
        }
        
        private void ButtonEditor_ItemClick(object sender, ItemClickEventArgs e) {
            if (this.PropertyGridControl.FocusedRow != null) {
                var propDesc = PropertyGridControl.GetPropertyDescriptor(PropertyGridControl.FocusedRow);
                if (propDesc == null)
                    return;

                Type editControllerType;
                if(ConfigPublic.SelectEditControllerType(propDesc.PropertyType, out editControllerType) == DialogReturn.OK) {
                    if(editControllerType != null) {
                        var controller = Controller as ObjectPropertyEditController;
                        var editController = editControllerType.CreateInstance() as BaseEditController;
                        if(controller != null) {
                            controller.SetPredfinedEditController(propDesc.Name, editController.GetType());
                        }
                    }
                }
            }
        }

        private void ButtonRecoverEditor_ItemClick(object sender, ItemClickEventArgs e) {
            if (this.PropertyGridControl.FocusedRow != null) {
                var propDesc = PropertyGridControl.GetPropertyDescriptor(PropertyGridControl.FocusedRow);
                if (propDesc == null)
                    return;
                var controller = Controller as ObjectPropertyEditController;
                if (controller != null) {
                    if(UIPublic.ShowYesNoDialog("您确定要恢复默认的编辑器吗？") == DialogReturn.Yes) {
                        controller.RemovePredefinedEditController(propDesc.Name);
                    }
                }
            }
        }
    }
}
