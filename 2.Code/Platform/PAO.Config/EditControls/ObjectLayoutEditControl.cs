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
using PAO.WinForm.Editors;
using PAO.UI;
using System.Collections;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 对象布局式编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class ObjectLayoutEditControl : BaseEditControl, ILayoutDataSupport
    {
        public ObjectLayoutEditControl() {
            InitializeComponent();
        }

        private Dictionary<PropertyDescriptor, Control> EditControls = new Dictionary<PropertyDescriptor, Control>();

        public override object EditValue {
            get {
                return base.EditValue; 
            }

            set {
                var valueString = "[未设置对象]";
                if (value.IsNull())
                    value = null;
                else if (value is IEnumerable)
                    valueString = value.GetType().GetTypeString();
                else
                    valueString = value.ToString();

                Text = String.Format("属性: {0}", valueString);
                base.EditValue = value;

                if(value == null) {
                    this.BindingSource.DataSource = value;
                } else {
                    this.BindingSource.DataSource = value.GetType();
                    this.BindingSource.Add(value);
                }
            }
        }

        private Type _ObjectType;
        /// <summary>
        /// 对象类型
        /// </summary>
        public Type ObjectType {
            get { return _ObjectType; }
            set { _ObjectType = value; }
        }

        private ObjectLayoutEditorLayoutData _LayoutData;
        /// <summary>
        /// 布局数据
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object LayoutData {
            get {
                // 获取布局数据
                if (_LayoutData == null) {
                    _LayoutData = new ObjectLayoutEditorLayoutData();
                    _LayoutData.LayoutData = this.DataLayoutControl.GetLayoutData();
                }
                return _LayoutData;
            }

            set {
                _LayoutData = value as ObjectLayoutEditorLayoutData;
                if(_LayoutData == null) {
                    _LayoutData = new ObjectLayoutEditorLayoutData();
                }

                RetrieveFields(this.LayoutControlGroupRoot, ObjectType);
            }
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

                var editControl = EditControls[propDesc] as ObjectContainerEditControl;
                if(editControl != null) {
                    editControl.ComponentObject = editValue;
                }
            }
        }

        /// <summary>
        /// 根据对象填充属性字段
        /// </summary>
        public void RetrieveFields() {
            RetrieveFields(this.LayoutControlGroupRoot, ObjectType);
        }

        /// <summary> 
        /// 根据对象填充属性字段
        /// </summary>
        /// <param name="groupItem">组项目</param>
        /// <param name="objType">对象类型</param>
        private void RetrieveFields(LayoutControlGroup groupItem, Type objType) {
            groupItem.Items.Clear();
            EditControls.Clear();

            if (objType == null)
                return;

            TabbedControlGroup tabbledGroup = null;
            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(objType)) {
                var configedPropDesc = WinFormPublic.GetConfigedProperty(propDesc);

                if (configedPropDesc == null || !configedPropDesc.IsBrowsable)
                    continue;

                Control editControl = null;
                if (_LayoutData != null) {
                    editControl = _LayoutData.CreateEditControl(propDesc.Name);
                }

                if (editControl == null) {
                    if (AddonPublic.IsAddonDictionaryType(configedPropDesc.PropertyType)) {
                        editControl = new DictionaryEditControl();
                    }
                    else if (AddonPublic.IsAddonListType(configedPropDesc.PropertyType)) {
                        editControl = new ListEditControl();
                    }
                    else {
                        // 此处第二个参数为true，确保了最少能创建一种编辑器
                        BaseEditor editor = ConfigPublic.GetEditor(configedPropDesc, true);
                        editControl = editor.CreateEditControl();
                    }
                }
                
                if (editControl.GetType().GetProperty("EditValue") == null)
                    throw new Exception("编辑控件必须实现EditValue属性");

                LayoutControlItem layoutControlItem = null;
                if (editControl is BaseEditControl) {
                    // 在BaseEditControl外套一层ObjectContainerEditControl，用于实现属性的新增删除等
                    var objectContainerEditControl = new ObjectContainerEditControl();
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
                editControl.DataBindings.Add(new Binding("EditValue", this.BindingSource, propDesc.Name, true));
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
        }
    }
}
