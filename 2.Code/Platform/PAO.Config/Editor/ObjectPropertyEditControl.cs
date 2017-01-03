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
using DevExpress.Utils.Menu;

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
        
        private void ButtonCustom_ItemClick(object sender, ItemClickEventArgs e) {
            this.PropertyGridControl.RowsCustomization();
        }
        
        private void ButtonRecoverFormat_ItemClick(object sender, ItemClickEventArgs e) {
            if(DefaultLayoutData.IsNotNullOrEmpty()) {
                if(UIPublic.ShowYesNoDialog("您是否需要默认格式？") == DialogReturn.Yes) {
                    this.PropertyGridControl.SetLayoutData(DefaultLayoutData);
                }
            }
        }
        
        private void PropertyGridControl_PopupMenuShowing(object sender, DevExpress.XtraVerticalGrid.Events.PopupMenuShowingEventArgs e) {
            if (e.Row != null) {
                var controller = Controller as ObjectPropertyEditController;
                if (controller == null)
                    return;
                var propDesc = PropertyGridControl.GetPropertyDescriptor(e.Row);

                if (propDesc != null) {
                    // 修改字段标题
                    var menuChangeCaption = new DXEditMenuItem("标题(&C)"
                        , new TextEditController().CreateRepositoryItem(typeof(string)));
                    menuChangeCaption.Width = 100;
                    menuChangeCaption.EditValue = e.Row.Properties.Caption;
                    menuChangeCaption.BeginGroup = true;
                    menuChangeCaption.EditValueChanged += (s, a) =>
                    {
                        if (menuChangeCaption.EditValue.IsNull())
                            e.Row.Properties.Caption = propDesc.Name;
                        else
                            e.Row.Properties.Caption = (string)menuChangeCaption.EditValue;
                    };
                    e.Menu.Items.Add(menuChangeCaption);

                    // 增加删除行菜单
                    var menuHideRow = new DXMenuItem("隐藏行(&D)"
                        , (s, a) =>
                        {
                            e.Row.Visible = false;
                        });
                    e.Menu.Items.Add(menuHideRow);

                    // 增加更改编辑器菜单
                    var menuChangeEditor = new DXMenuItem("更改编辑器(&E)..."
                        , (s, a) =>
                        {
                            Type editControllerType;
                            if (ConfigPublic.SelectEditControllerType(propDesc.PropertyType, out editControllerType) == DialogReturn.OK) {
                                if (editControllerType != null) {
                                    var editController = editControllerType.CreateInstance() as BaseEditController;
                                    if (controller != null) {
                                        controller.SetPredfinedEditController(propDesc.Name, editController.GetType());
                                    }
                                }
                            }
                        }
                        , Properties.Resources.renamedatasource_16x16);
                    menuChangeEditor.BeginGroup = true;
                    e.Menu.Items.Add(menuChangeEditor);
                    // 增加恢复编辑器菜单
                    var menuRecoverEditor = new DXMenuItem("恢复编辑器(&R)"
                        , (s, a) =>
                        {
                            if (UIPublic.ShowYesNoDialog("您确定要恢复默认的编辑器吗？") == DialogReturn.Yes) {
                                controller.RemovePredefinedEditController(propDesc.Name);
                            }
                        }
                        , Properties.Resources.clearformatting_16x16);
                    e.Menu.Items.Add(menuRecoverEditor);
                }

                // 恢复所有编辑器
                var menuClearEditors = new DXMenuItem("恢复所有编辑器(&C)"
                    , (s, a) =>
                    {
                        if (UIPublic.ShowYesNoDialog("您确定要恢复所有默认的编辑器吗？") == DialogReturn.Yes) {
                            controller.ClearPredefinedEditControllers();
                        }
                    }
                    , Properties.Resources.clear_16x16);
                menuClearEditors.BeginGroup = true;
                e.Menu.Items.Add(menuClearEditors);
            }
        }
    }
}
