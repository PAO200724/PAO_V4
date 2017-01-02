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
using DevExpress.XtraBars;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 通用对象编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class CommonObjectEditControl : BaseObjectEditControl {
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


        private BaseObjectEditControl _EditControl;
        /// <summary>
        /// 编辑控件
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private BaseObjectEditControl EditControl {
            get {
                return _EditControl;
            }
            set {
                if (_EditControl != null) {
                    UnMergeBars();
                    _EditControl.CloseControl();
                    this.Controls.Remove(_EditControl);
                }

                _EditControl = value;
                if (_EditControl != null) {
                    _EditControl.Dock = DockStyle.Fill;
                    _EditControl.DataModifyStateChanged -= EditControl_DataModifyStateChanged;
                    _EditControl.DataModifyStateChanged += EditControl_DataModifyStateChanged;
                    this.Controls.Add(_EditControl);
                    MergeBars();
                }
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
                if (value == null) {
                    EditControl = null;
                } else {
                    var editControl = ConfigPublic.CreateEditControl(value.GetType()) as BaseObjectEditControl;
                    if (editControl == null)
                        editControl = new ObjectPropertyEditController().CreateEditControl(value.GetType()) as BaseObjectEditControl;

                    EditControl = editControl;
                    EditControl.EditValue = value;
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

        public CommonObjectEditControl() {
            InitializeComponent();
        }

        #region StartEditXXX
        public void StartEdit(ObjectEditMode editMode, Type objectType, object componentObject, object key) {
            EditMode = editMode;
            ObjectType = objectType;
            ComponentObject = componentObject;
            Key = key;
            SetControlStatus();
        }

        public void StartEditNull() {
            StartEdit(ObjectEditMode.Object, null, null, null);
            EditValue = null;
        }
        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="objectType">对象类型</param>
        public void StartEditObject(Type objectType) {
            StartEdit(ObjectEditMode.Object, objectType, null, null);
        }
        /// <summary>
        /// 编辑属性
        /// </summary>
        /// <param name="componentObject">组件对象</param>
        /// <param name="propertyName">属性名</param>
        public void StartEditProperty(object componentObject, string propertyName) {
            StartEdit(ObjectEditMode.Property, null, componentObject, propertyName);
        }
        /// <summary>
        /// 编辑列表元素
        /// </summary>
        /// <param name="componentObject">组件对象</param>
        /// <param name="index">索引</param>
        public void StartEditListElement(object componentObject, int index) {
            StartEdit(ObjectEditMode.ListElement, null, componentObject, index);
        }
        /// <summary>
        /// 编辑字典元素
        /// </summary>
        /// <param name="componentObject">组件对象</param>
        /// <param name="key">键</param>
        public void StartEditDictionaryElement(object componentObject, object key) {
            StartEdit(ObjectEditMode.DictionaryElement, null, componentObject, key);
        }
        #endregion

        private void MergeBars() {
            UnMergeBars();
            if (_EditControl is IBarSupport) {
                foreach (var bar in _EditControl.As<IBarSupport>().ExtendBars) {
                    this.BarElement.Merge(bar);
                    bar.Visible = false;
                }
            }
            this.BarElement.Visible = this.BarElement.VisibleLinks.Count > 0;
        }

        private void UnMergeBars() {
            this.BarElement.UnMerge();
            this.BarElement.Visible = false;
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
            this.ButtonProperty.Enabled = editValue.IsNotNull();

            bool canCreate = false;
            if((EditMode == ObjectEditMode.Object && ObjectType != null) || (EditMode == ObjectEditMode.Property)) {
                canCreate = true;
            }

            this.ButtonCreate.Visibility = (canCreate) ? BarItemVisibility.Always : BarItemVisibility.Never;
            this.ButtonDelete.Visibility = (canCreate) ? BarItemVisibility.Always : BarItemVisibility.Never;
            this.ButtonDelete.Enabled = canCreate & editValue.IsNotNull();
            this.ButtonCreate.Enabled = canCreate & editValue.IsNull();
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

            var objectType = propertyValue.GetType();
            BaseObjectEditControl editControl = null;
            // 如果不是PaoObject类型，则显示默认编辑控件
            if (!objectType.IsAddonType()) {
                editControl = ConfigPublic.CreateEditControl(objectType) as BaseObjectEditControl;
            }

            if (editControl == null) {
                editControl = new ObjectLayoutEditController().CreateEditControl(objectType) as BaseObjectEditControl;
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
