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
using PAO.WinForm.Editor;
using PAO.UI;
using System.Collections;

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

        private LayoutControlItem SelectedLayoutItem = null;

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
                if(ObjectType != null) {
                    RetrieveFields(this.LayoutControlGroupRoot, ObjectType);
                }

                Text = String.Format("属性: {0}", valueString);
                base.EditValue = value;

                if(value == null) {
                    this.BindingSource.DataSource = value;
                } else {
                    this.BindingSource.DataSource = value.GetType();
                    this.BindingSource.Add(value);
                    BindEditValue(value);
                }
            }
        }

        protected override void SetControlStatus() {
            this.ButtonRecoverEditor.Enabled = this.DataLayoutControl.CustomizationForm!=null && this.DataLayoutControl.CustomizationForm.Visible && SelectedLayoutItem != null;
            this.ButtonChangeEditor.Enabled = this.DataLayoutControl.CustomizationForm != null && this.DataLayoutControl.CustomizationForm.Visible && SelectedLayoutItem != null;
            base.SetControlStatus();
        }

        protected override void OnClose() {
            var controller = Controller as ObjectLayoutEditController;
            if (controller != null) {
                controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                // 如果设置了ObjectType，则保存默认配置
                if (controller.StaticType && ObjectType != null) {
                    EditorPublic.SetDefaultEditController(ObjectType, controller);
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
                if(editControl is CommonObjectEditControl) {
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
            groupItem.Items.Clear();
            this.DataLayoutControl.CloseControl();
            EditControls.Clear();
            this.DataLayoutControl.Clear(true, true);

            var controller = Controller as ObjectLayoutEditController;
            if (controller != null) {
                this.DataLayoutControl.SetLayoutData(controller.LayoutData);
            }

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

                if(editController == null) {
                    editController = ConfigPublic.GetEditController(propDesc);
                }
                if(editController == null) {
                    var commonEditController = new CommonObjectEditController();
                    commonEditController.StartEditProperty(EditValue, propDesc.Name);
                    editController = commonEditController;
                }

                editControl = editController.CreateEditControl(objType);
                
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
            if(controller != null  && controller.LayoutData.IsNotNullOrEmpty()) {
                this.DataLayoutControl.SetLayoutData(controller.LayoutData);
            }
        }

        private void ButtonCustom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.DataLayoutControl.ShowCustomizationForm();
        }

        private void ButtonRecoverFormat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (UIPublic.ShowYesNoCancelDialog("您是否需要默认格式？") == DialogReturn.Yes) {
                this.DataLayoutControl.RestoreDefaultLayout();
            }
        }

        private void ButtonChangeEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if(SelectedLayoutItem != null) {
                var editControl = SelectedLayoutItem.Control;
                var propDesc = editControl.Tag as PropertyDescriptor;
                if (propDesc == null)
                    return;

                Type editControllerType;
                if (ConfigPublic.SelectEditControllerType(propDesc.PropertyType, out editControllerType) == DialogReturn.OK) {
                    if (editControllerType != null) {
                        var controller = Controller as ObjectLayoutEditController;
                        var editController = editControllerType.CreateInstance() as BaseEditController;
                        if (controller != null) {
                            controller.SetPredfinedEditController(propDesc.Name, editController.GetType());
                        }
                    }
                }
                EditValue = EditValue;
            }
        }

        private void ButtonRecoverEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (SelectedLayoutItem != null) {
                var editControl = SelectedLayoutItem.Control;
                var propDesc = editControl.Tag as PropertyDescriptor;
                if (propDesc == null)
                    return;

                var controller = Controller as ObjectLayoutEditController;
                if (controller != null) {
                    if (UIPublic.ShowYesNoDialog("您确定要恢复默认的编辑器吗？") == DialogReturn.Yes) {
                        controller.RemovePredefinedEditController(propDesc.Name);
                    }
                }
                EditValue = EditValue;
            }
        }

        private void DataLayoutControl_ItemSelectionChanged(object sender, EventArgs e) {
            SelectedLayoutItem = sender as LayoutControlItem;
            SetControlStatus();
        }

        private void DataLayoutControl_ShowCustomization(object sender, EventArgs e) {
            SetControlStatus();
        }

        private void DataLayoutControl_HideCustomization(object sender, EventArgs e) {
            SetControlStatus();
        }
    }
}
