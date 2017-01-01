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
    public partial class ObjectLayoutEditControl : BaseEditControl
    {
        public ObjectLayoutEditControl() {
            InitializeComponent();
        }

        /// <summary>
        /// 编辑控件列表
        /// </summary>
        private Dictionary<PropertyDescriptor, Control> EditControls = new Dictionary<PropertyDescriptor, Control>();

        private Type _ObjectType;
        /// <summary>
        /// 对象类型
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Type ObjectType {
            get { return _ObjectType; }
            set { _ObjectType = value;
                GetTypeLayoutData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                return base.EditValue; 
            }

            set {
                var valueString = "[未设置对象]";
                if (value.IsNull())
                    value = null;
                else {
                    valueString = value.ToString();
                    if(ObjectType == null) {
                        ObjectType = value.GetType();
                    }
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

        protected override void OnClose() {
            var controller = Controller as ObjectLayoutEditController;
            if (controller.IsTypeEditController) {
                controller = ConfigPublic.CreateEditControllerByType<ObjectLayoutEditController>(ObjectType);
            }

            if (controller != null) {
                controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                ExtendAddonPublic.SetExtendLocalAddon(controller);
            }

            base.OnClose();
        }

        private void GetTypeLayoutData() {
            if (ObjectType.IsNull())
                return;

            string typeID = GetTypeID();

            RetrieveFields(this.LayoutControlGroupRoot, ObjectType);
        }

        private string GetTypeID() {
            return ObjectType.FullName;
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
                if(editControl is ObjectContainerControl) {
                    editControl.As<ObjectContainerControl>().ComponentObject = editValue;
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
            EditControls.Clear();

            var controller = Controller as ObjectLayoutEditController;
            if (controller.IsTypeEditController) {
                controller = ConfigPublic.GetEditControllerByType<ObjectLayoutEditController>(objType);
            }
            if (controller != null) {
                this.DataLayoutControl.SetLayoutData(controller.LayoutData);
            }

            if (objType == null)
                return;

            this.DataLayoutControl.SuspendLayout();
            TabbedControlGroup tabbledGroup = null;
            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(objType)) {
                var configedPropDesc = WinFormPublic.GetConfigedProperty(propDesc);

                if (configedPropDesc == null || !configedPropDesc.IsBrowsable)
                    continue;

                Control editControl = null;
                if(controller != null) {
                   editControl = controller.CreateEditControl(propDesc.PropertyType, propDesc.Name);
                }

                if (editControl == null) {
                    if (AddonPublic.IsAddonDictionaryType(configedPropDesc.PropertyType)) {
                        editControl = new DictionaryEditController().CreateEditControl(propDesc.PropertyType) as BaseEditControl;
                    }
                    else if (AddonPublic.IsAddonListType(configedPropDesc.PropertyType)) {
                        editControl = new ListEditController().CreateEditControl(propDesc.PropertyType) as BaseEditControl;
                    }
                    else {
                        // 此处第二个参数为true，确保了最少能创建一种编辑器
                        BaseEditController editor = ConfigPublic.GetEditor(configedPropDesc, true);
                        editControl = editor.CreateEditControl(propDesc.PropertyType);
                    }
                }
                
                if (editControl.GetType().GetProperty("EditValue") == null)
                    throw new Exception("编辑控件必须实现EditValue属性");

                LayoutControlItem layoutControlItem = null;
                if (editControl is BaseEditControl) {
                    // 在BaseEditControl外套一层ObjectContainerEditControl，用于实现属性的新增删除等
                    var objectContainerEditControl = new ObjectContainerControl();
                    objectContainerEditControl.StartEditProperty(EditValue, propDesc.Name, editControl as BaseEditControl);
                    editControl = objectContainerEditControl;

                    if (tabbledGroup == null) {
                        tabbledGroup = groupItem.AddTabbedGroup();
                    }
                    var layoutGroupItem = tabbledGroup.AddTabPage();
                    layoutGroupItem.Name = "Group_" + configedPropDesc.Name;
                    layoutGroupItem.Text = configedPropDesc.DisplayName;
                    layoutGroupItem.CustomizationFormText = "组_" + configedPropDesc.DisplayName;
                    layoutGroupItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0);

                    layoutControlItem = layoutGroupItem.AddItem();
                    layoutControlItem.TextLocation = DevExpress.Utils.Locations.Top;
                }
                else {
                    layoutControlItem = groupItem.AddItem();
                    layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
                }
                EditControls.Add(propDesc, editControl);
                editControl.Tag = configedPropDesc;
                editControl.Name = configedPropDesc.Name;

                layoutControlItem.Control = editControl;
                layoutControlItem.Name = configedPropDesc.Name;
                layoutControlItem.Text = configedPropDesc.DisplayName;
                layoutControlItem.CustomizationFormText = configedPropDesc.DisplayName;

                if (editControl is BaseEditControl) {
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
    }
}
