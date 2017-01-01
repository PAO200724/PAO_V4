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
using System.Collections;
using PAO.UI;
using PAO.IO;
using PAO.WinForm.Editor;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 对象容器编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class ObjectContainerControl : BaseEditControl {
        /// <summary>
        /// 组件对象，在属性、列表元素和字典元素编辑模式下分别代表组件对象、列表和字典
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObjectEditMode EditMode { get; private set; }

        /// <summary>
        /// 组件对象，在属性、列表元素和字典元素编辑模式下分别代表组件对象、列表和字典
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object ComponentObject { get; set; }

        /// <summary>
        /// 键，在属性、列表元素和字典元素编辑模式下分别代表属性名称、索引和键
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Key { get; set; }


        /// <summary>
        /// 对象类型
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Type ObjectType { get; set; }


        private BaseEditControl _EditControl;
        /// <summary>
        /// 编辑控件
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseEditControl EditControl {
            get {
                return _EditControl;
            }
            private set {
                if (_EditControl != null) {
                    UnMergeBars();
                    _EditControl.CloseControl();
                    this.Controls.Remove(_EditControl);
                }

                _EditControl = value;
                _EditControl.Dock = DockStyle.Fill;
                _EditControl.DataModifyStateChanged -= EditControl_DataModifyStateChanged;
                _EditControl.DataModifyStateChanged += EditControl_DataModifyStateChanged;
                this.Controls.Add(_EditControl);
                MergeBars();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                if (_EditControl != null) {
                    _EditControl.EditValue = _EditControl.EditValue;
                }
                return base.EditValue;
            }

            set {
                if (value.IsNull()) {
                    value = null;
                }
                base.EditValue = value;
                if (_EditControl != null) {
                    _EditControl.EditValue = value;
                }
                SetControlStatus();
            }
        }

        private void SetComponentPropertyValue() {
            switch (EditMode) {
                case ObjectEditMode.Property:
                    var propertyName = (string)Key;
                    ComponentObject.SetPropertyValueByPath(propertyName, EditValue);
                    break;
                case ObjectEditMode.ListElement:
                    var index = (int)Key;
                    ComponentObject.SetPropertyValueByPath(index.ToString(), EditValue);
                    break;
                case ObjectEditMode.DictionaryElement:
                    ComponentObject.SetPropertyValueByPath(Key.ToString(), EditValue);
                    break;
                default:
                    break;
            }
        }

        public ObjectContainerControl() {
            InitializeComponent();
        }

        #region StartEditXXX
        public void StartEditNull() {
            EditMode = ObjectEditMode.Object;
            EditControl = null;
            ObjectType = null;
        }

        public void StartEditObject(Type objectType, BaseEditControl editControl) {
            EditMode = ObjectEditMode.Object;
            EditControl = editControl;
            ObjectType = objectType;
        }

        public void StartEditProperty(object componentObject, string propertyName, BaseEditControl editControl) {
            EditMode = ObjectEditMode.Property;
            EditControl = editControl;
            ComponentObject = componentObject;
            Key = propertyName;
        }

        public void StartEditListEelement(object componentObject, int index, BaseEditControl editControl) {
            EditMode = ObjectEditMode.ListElement;
            EditControl = editControl;
            ComponentObject = componentObject;
            Key = index;
        }

        public void StartEditDictionaryElement(object componentObject, object key, BaseEditControl editControl) {
            EditMode = ObjectEditMode.DictionaryElement;
            EditControl = editControl;
            ComponentObject = componentObject;
            Key = key;
        }
        #endregion

        private void MergeBars() {
            this.BarToolObject.UnMerge();
            if (_EditControl is IBarSupport) {
                foreach (var bar in _EditControl.As<IBarSupport>().ExtendBars) {
                    this.BarToolObject.Merge(bar);
                    bar.Visible = false;
                }
            }
        }

        private void UnMergeBars() {
            this.BarToolObject.UnMerge();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            MergeBars();
        }
        
        private void EditControl_DataModifyStateChanged(object sender, DataModifyStateChangedEventArgs e) {
            if (e.DataModified) {
                ModifyData();
            }
            else {
                Apply();
            }
        }

        protected override void SetControlStatus() {
            object editValue = base.EditValue;
            this.ButtonExport.Enabled = editValue.IsNotNull();
            this.ButtonCreate.Enabled = editValue.IsNull();
            this.ButtonDelete.Enabled = editValue.IsNotNull();
            this.W.Enabled = editValue.IsNotNull();
            this.ButtonCreate.Visibility = (EditMode == ObjectEditMode.Object && ObjectType == null)? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            this.ButtonDelete.Visibility = (EditMode == ObjectEditMode.Object && ObjectType == null) ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            base.SetControlStatus();
        }


        private void ButtonExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExportSelectedObject();
        }

        private void ButtonCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            object newObject = null;
            var editValue = EditValue;
            switch (EditMode) {
                case ObjectEditMode.Property:
                    var propertyName = (string)Key;
                    var property = ComponentObject.GetType().GetProperty(propertyName);
                    if (ConfigPublic.CreateNewAddonValue(property.PropertyType
                        , false
                        , out newObject)) {
                        EditValue = newObject;
                        SetComponentPropertyValue();
                        ModifyData();
                    }
                    break;
                case ObjectEditMode.ListElement:
                case ObjectEditMode.DictionaryElement:
                    if (ConfigPublic.CreateNewAddonValue(ComponentObject.GetType()
                        , true
                        , out newObject)) {
                        EditValue = newObject;
                        SetComponentPropertyValue();
                        ModifyData();
                    }
                    break;
                case ObjectEditMode.Object:
                    var objectType = ObjectType;
                    if (objectType == null)
                        objectType = typeof(PaoObject);
                    if (ConfigPublic.CreateNewAddonValue(objectType
                        , false
                        , out newObject)) {
                        EditValue = newObject;
                        SetComponentPropertyValue();
                        ModifyData();
                    }
                    break;
                default:
                    break;
            }
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (EditMode) {
                case ObjectEditMode.Property:
                case ObjectEditMode.ListElement:
                case ObjectEditMode.DictionaryElement:
                    EditValue = null;
                    SetComponentPropertyValue();
                    ModifyData();
                    break;
                default:
                    break;
            }
        }

        private void ButtonSaveFormat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        private void ButtonSaveFormatAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
        }

        private void ButtonProperty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.ShowWaitingForm();
            var propertyValue = EditValue;

            Type editControlType = ConfigPublic.GetEditControllerType(propertyValue.GetType());
            BaseEditControl editControl = null;
            var objectType = propertyValue.GetType();
            if (editControlType != null) {
                var editController = editControlType.CreateInstance() as BaseEditController;
                editControl = editController.CreateEditControl(objectType) as BaseEditControl;
            }
            if (editControl == null) {
                if (objectType.IsAddonDictionaryType()) {
                    editControl = new DictionaryEditController().CreateEditControl(objectType) as BaseEditControl;
                }
                else if (objectType.IsAddonListType()) {
                    editControl = new ListEditController().CreateEditControl(objectType) as BaseEditControl;
                }
            }
            if (editControl == null) {
                editControl = ObjectLayoutEditController.CreateTypeEditControl();
            }

            editControl.EditValue = IOPublic.ObjectClone(propertyValue);
            UIPublic.CloseWaitingForm();
            if (WinFormPublic.ShowDialog(editControl) == DialogReturn.OK) {
                EditValue = editControl.EditValue;
            }
            SetControlStatus();
        }
    }
}
