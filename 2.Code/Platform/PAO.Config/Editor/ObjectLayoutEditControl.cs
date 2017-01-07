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
using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using PAO.Config.Editor;
using PAO.UI;
using System.Collections;
using DevExpress.Utils.Menu;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 对象布局式编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class ObjectLayoutEditControl : BaseObjectEditControl
    {
        public ObjectLayoutEditControl() {
            InitializeComponent();
        }

        /// <summary>
        /// 编辑控件列表
        /// </summary>
        private Dictionary<PropertyDescriptor, Control> EditControls = new Dictionary<PropertyDescriptor, Control>();

        private Type ObjectType = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                return base.EditValue;
            }

            set {
                var valueString = "[未设置对象]";
                Type objectType = null;
                if (value.IsNull())
                    value = null;
                else {
                    valueString = value.ToString();
                    objectType = value.GetType();
                }
                if (ObjectType != objectType) {
                    ObjectType = objectType;
                }
                if (ObjectType != null) {
                    RetrieveFields(this.LayoutControlGroupRoot, ObjectType);
                }

                Text = String.Format("属性: {0}", valueString);
                base.EditValue = value;

                if (value == null) {
                    this.BindingSource.DataSource = value;
                }
                else {
                    this.BindingSource.DataSource = value.GetType();
                    this.BindingSource.Add(value);
                    BindEditValue(value);
                }
            }
        }

        protected override void SetControlStatus() {
            base.SetControlStatus();
        }

        protected override void OnClose() {
            var controller = Controller as ObjectLayoutEditController;
            if (controller != null) {
                controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                // 如果设置了ObjectType，则保存默认配置
                if (controller.StaticType && ObjectType != null) {
                    EditorPublic.SetEditControllerToStorage(ObjectType, controller);
                }

            }

            base.OnClose();
        }

        /// <summary>
        /// 绑定编辑值
        /// </summary>
        /// <param name="editValue"></param>
        private void BindEditValue(object editValue) {
            if (editValue == null)
                return;
            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(ObjectType)) {
                if (!EditControls.ContainsKey(propDesc))
                    continue;

                var editControl = EditControls[propDesc];
                if (editControl is CommonObjectEditControl) {
                    editControl.As<CommonObjectEditControl>().ComponentObject = editValue;
                }
                editControl.DataBindings.Clear();
                if (this.BindingSource != null) {
                    editControl.DataBindings.Add(new Binding("EditValue", this.BindingSource, propDesc.Name, true));
                }
            }
        }

        /// <summary> 
        /// 根据对象填充属性字段
        /// </summary>
        /// <param name="groupItem">组项目</param>
        /// <param name="objType">对象类型</param>
        private void RetrieveFields(LayoutControlGroup groupItem, Type objType) {
            UIPublic.ShowWaitingForm();
            this.DataLayoutControl.CloseControl();
            EditControls.Clear();
            this.DataLayoutControl.Clear(true, true);

            var controller = Controller as ObjectLayoutEditController;

            if (objType == null)
                return;

            this.DataLayoutControl.SuspendLayout();
            TabbedControlGroup tabbledGroup = null;
            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(objType)) {
                if (!propDesc.IsBrowsable)
                    continue;

                BaseEditController editController = null;
                Control editControl = null;

                if (controller != null) {
                    editController = controller.GetPredefinedEditController(propDesc.PropertyType, propDesc.Name);
                }

                if (editController == null) {
                    if (propDesc.PropertyType.IsAddon()) {
                        var commonEditController = new CommonObjectEditController();
                        commonEditController.StartEditProperty(EditValue, propDesc.Name);
                        editController = commonEditController;
                    } else {
                        editController = EditorPublic.GetEditController(propDesc);
                    }
                }

                editControl = editController.CreateEditControl(propDesc.PropertyType);

                if (editControl.GetType().GetProperty("EditValue") == null)
                    throw new Exception("编辑控件必须实现EditValue属性");

                LayoutControlItem layoutControlItem = null;
                if (editControl is BaseObjectEditControl) {
                    if (tabbledGroup == null) {
                        tabbledGroup = groupItem.AddTabbedGroup();
                    }
                    var layoutGroupItem = tabbledGroup.AddTabPage();
                    layoutGroupItem.Name = "Group_" + propDesc.Name;
                    layoutGroupItem.Text = propDesc.DisplayName;
                    layoutGroupItem.CustomizationFormText = "组_" + propDesc.DisplayName;
                    layoutGroupItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0);

                    layoutControlItem = layoutGroupItem.AddItem();
                    layoutControlItem.TextLocation = DevExpress.Utils.Locations.Top;
                }
                else {
                    layoutControlItem = groupItem.AddItem();
                    layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
                }
                EditControls.Add(propDesc, editControl);
                editControl.Tag = propDesc;
                editControl.Name = propDesc.Name;

                layoutControlItem.Control = editControl;
                layoutControlItem.Name = propDesc.Name;
                layoutControlItem.Text = propDesc.DisplayName;
                layoutControlItem.CustomizationFormText = propDesc.DisplayName;

                if (editControl is BaseObjectEditControl) {
                    layoutControlItem.TextVisible = false;
                }
                else {
                    layoutControlItem.TextVisible = true;
                }
            }
            this.DataLayoutControl.ResumeLayout();
            this.DataLayoutControl.SetDefaultLayout();

            // 读取布局数据
            if (controller != null && controller.LayoutData.IsNotNullOrEmpty()) {
                this.DataLayoutControl.SetLayoutData(controller.LayoutData);
            }
            UIPublic.CloseWaitingForm();
        }

        private void ButtonCustom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.DataLayoutControl.ShowCustomizationForm();
        }

        private void ButtonRecoverFormat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (UIPublic.ShowYesNoCancelDialog("您是否需要默认格式？") == DialogReturn.Yes) {
                this.DataLayoutControl.RestoreDefaultLayout();
            }
        }
        
        private void DataLayoutControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e) {
            if (e.HitInfo.Item != null) {
                var controller = Controller as ObjectLayoutEditController;
                if (controller == null)
                    return;
                var layoutItem = e.HitInfo.Item as LayoutControlItem;
                var editControl = layoutItem.Control;
                var propDesc = editControl.Tag as PropertyDescriptor;

                if (propDesc != null) {
                    // 修改字段标题
                    var menuChangeCaption = new DXEditMenuItem("标题(&C)"
                        , new TextEditController().CreateRepositoryItem(typeof(string)));
                    menuChangeCaption.Width = 100;
                    menuChangeCaption.EditValue = layoutItem.Text;
                    menuChangeCaption.BeginGroup = true;
                    menuChangeCaption.EditValueChanged += (s, a) =>
                    {
                        if (menuChangeCaption.EditValue.IsNull())
                            layoutItem.Text = propDesc.Name;
                        else
                            layoutItem.Text = (string)menuChangeCaption.EditValue;
                    };
                    e.Menu.Items.Add(menuChangeCaption);


                    // 增加更改编辑器菜单
                    var menuChangeEditor = new DXMenuItem("更改编辑器(&E)..."
                        , (s, a) =>
                        {
                            Type editControllerType;
                            if (EditorPublic.SelectEditControllerType(propDesc.PropertyType, out editControllerType) == DialogReturn.OK) {
                                if (editControllerType != null) {
                                    var editController = editControllerType.CreateInstance() as BaseEditController;
                                    // 清除前保存配置
                                    controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                                    controller.SetPredfinedEditController(propDesc.Name, editController.GetType());
                                    EditValue = EditValue;
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
                                // 清除前保存配置
                                controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                                controller.RemovePredefinedEditController(propDesc.Name);
                                EditValue = EditValue;
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
                            // 清除前保存配置
                            controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                            controller.ClearPredefinedEditControllers();
                            EditValue = EditValue;
                        }
                    }
                    , Properties.Resources.clear_16x16);
                menuClearEditors.BeginGroup = true;
                e.Menu.Items.Add(menuClearEditors);
            }
        }
    }
}
