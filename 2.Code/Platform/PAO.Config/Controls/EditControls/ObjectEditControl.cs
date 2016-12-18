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
using PAO.Config.Editors;
using PAO.IO;
using PAO.WinForm.Editors;
using PAO.WinForm.Property;

namespace PAO.Config.Controls.EditControls
{
    /// <summary>
    /// 插件编辑控件
    /// </summary>
    public partial class ObjectEditControl : BaseEditControl
    {
        static ObjectEditControl() {
            ConfigPublic.RegisterEditors();
        }

        public ObjectEditControl() {
            InitializeComponent();
            SetControlStatus();
            SelectedObject = null;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object SelectedObject {
            get {
                this.PropertyGridControl.CloseEditor();
                return base.SelectedObject;
            }

            set {
                base.SelectedObject = value;
                this.PropertyGridControl.SelectedObject = value;
                this.PropertyGridControl.Refresh();
                if(value == null) {
                    StaticItemObject.Caption = "[未选择任何对象]";
                } else {
                    StaticItemObject.Caption = value.ToString();
                }
                SetControlStatus();
            }
        }

        private void SetControlStatus() {
            this.Enabled = SelectedObject != null;
        }

        private void PropertyGridControl_CellValueChanged(object sender
            , DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) {
            ModifyData();
        }

        private void PropertyGridControl_CustomRecordCellEditForEditing(object sender
            , DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e) {
         }

        private void PropertyGridControl_CustomRecordCellEdit(object sender, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e) {
            BaseEditor edit = null;
            var propDesc = PropertyGridControl.GetPropertyDescriptor(e.Row);
            if (propDesc == null)
                return;

            if(propDesc is ConfigPropertyDescriptor) {
                var configProp = propDesc as ConfigPropertyDescriptor;
                if(configProp.Editor != null) {
                    edit = IOPublic.ObjectClone(configProp.Editor) as BaseEditor;
                }
            }

            if(edit == null) {
                edit = ConfigPublic.GetDefaultEditor(propDesc);
            }

            if (edit == null) {
                if(propDesc.PropertyType.IsDerivedFrom(typeof(PaoObject))) {
                    edit = new ObjectEditor();
                }
            }

            if (edit != null) {
                edit.PropertyDescriptor = propDesc;
                e.RepositoryItem = edit.CreateEditor();
            }
        }

        private void ButtonExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExportSelectedObject();
        }

        private void ButtonImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ImportSelectedObject();
        }

        private void ObjectEditControl_Leave(object sender, EventArgs e) {
            this.PropertyGridControl.CloseEditor();
        }

        private void PropertyGridControl_CustomPropertyDescriptors(object sender, DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs e) {
            if (e.Properties.IsNullOrEmpty())
                return;

            var propertyDescriptors = new List<PropertyDescriptor>();


            foreach (PropertyDescriptor propertyDesc in e.Properties) {
                var typeConfigInfo = WinFormPublic.GetTypeConfigInfo(propertyDesc.ComponentType);
                var propertyConfigInfo = WinFormPublic.GetPropertyConfigInfo(propertyDesc.ComponentType, propertyDesc.Name);
                if(propertyConfigInfo != null) {
                    if (propertyConfigInfo.Browsable) {
                        var newProp = new ConfigPropertyDescriptor(propertyDesc, propertyConfigInfo);

                        propertyDescriptors.Add(newProp);
                    }
                }
                else {
                    if(typeConfigInfo == null || !typeConfigInfo.ShowDefinedPropertyOnly) {
                        propertyDescriptors.Add(propertyDesc);
                    }
                }
            }

            e.Properties = new PropertyDescriptorCollection(propertyDescriptors.ToArray());
        }
    }
}
