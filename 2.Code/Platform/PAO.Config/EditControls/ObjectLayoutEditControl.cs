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

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 对象布局式编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class ObjectLayoutEditControl : TypeEditControl
    {
        public ObjectLayoutEditControl() {
            InitializeComponent();
        }

        public override object SelectedObject {
            get {
                return base.SelectedObject; 
            }

            set {
                base.SelectedObject = value;

                if(value == null) {
                    this.BindingSource.DataSource = value;
                } else {
                    this.BindingSource.DataSource = value.GetType();
                    this.BindingSource.Add(value);

                    RetrievePropertyFields(this.LayoutControlGroupRoot, value);
                }
            }
        }

        /// <summary> 
        /// 根据对象填充属性字段
        /// </summary>
        /// <param name="groupItem">组项目</param>
        /// <param name="obj">对象</param>
        public void RetrievePropertyFields(LayoutControlGroup groupItem, object obj) {
            groupItem.Items.Clear();

            if (obj == null)
                return;

            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(obj)) {
                var configedPropDesc = WinFormPublic.GetConfigedProperty(propDesc);

                if (configedPropDesc == null || !configedPropDesc.IsBrowsable)
                    continue;

                Control editControl;
                if (AddonPublic.IsAddonDictionaryType(configedPropDesc.PropertyType)) {
                    var dictEditControl = new DictionaryEditControl();
                    dictEditControl.PropertyType = propDesc.PropertyType;
                    dictEditControl.DataBindings.Add(new Binding("SelectedObject", this.BindingSource, propDesc.Name, true));
                    editControl = dictEditControl;
                }
                else if (AddonPublic.IsAddonListType(configedPropDesc.PropertyType)) {
                    var listEditControl = new ListEditControl();
                    listEditControl.PropertyType = propDesc.PropertyType;
                    listEditControl.DataBindings.Add(new Binding("SelectedObject", this.BindingSource, propDesc.Name, true));
                    editControl = listEditControl;
                }
                else {
                    BaseEditor edit = null;
                    edit = ConfigPublic.GetEditor(configedPropDesc);
                    if (edit == null) {
                        edit = new TextEditor();
                    }
                    var repositoryItem = edit.CreateEditor();
                    var editor = repositoryItem.CreateEditor();
                    editor.Properties.Assign(repositoryItem);
                    editor.DataBindings.Add(new Binding("EditValue", this.BindingSource, propDesc.Name, true));
                    editControl = editor;
                }
                editControl.Tag = configedPropDesc;
                editControl.Name = configedPropDesc.Name;

                var layoutControlItem = groupItem.AddItem();
                layoutControlItem.Name = configedPropDesc.Name;
                layoutControlItem.Text = configedPropDesc.DisplayName;
                layoutControlItem.CustomizationFormText = configedPropDesc.DisplayName;
                layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
                layoutControlItem.TextVisible = true;
                layoutControlItem.ShowInCustomizationForm = true;
                layoutControlItem.Control = editControl;
            }
        }
    }
}
