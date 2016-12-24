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

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 对象容器编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class ObjectContainerEditControl : BaseEditControl
    {
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
                _EditControl = value;
                InitEditControl();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                if (EditControl != null) {
                    EditControl.EditValue = EditControl.EditValue;
                }
                return base.EditValue;
            }

            set {
                if (value.IsNull()) {
                    value = null;
                }
                base.EditValue = value;
                if(EditControl != null) {
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

        public ObjectContainerEditControl() {
            InitializeComponent();
        }

        public void StartEditObject(BaseEditControl editControl) {
            EditMode = ObjectEditMode.Object;
            EditControl = editControl;
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

        public void StartEditDictionary(object componentObject, object key, BaseEditControl editControl) {
            EditMode = ObjectEditMode.DictionaryElement;
            EditControl = editControl;
            ComponentObject = componentObject;
            Key = key;
        }

        private void InitEditControl() {
            if(EditControl != null)
                this.Controls.Remove(EditControl);
            EditControl.Dock = DockStyle.Fill;
            EditControl.DataModifyStateChanged -= EditControl_DataModifyStateChanged;
            EditControl.DataModifyStateChanged += EditControl_DataModifyStateChanged;
            this.Controls.Add(EditControl);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (EditControl is IBarSupport) {
                foreach (var bar in EditControl.As<IBarSupport>().ExtendBars) {
                    this.BarToolObject.Merge(bar);
                    bar.Visible = false;
                }
            }
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
            if (editValue.IsNull()) {
                StaticItemObject.Caption = "[未选择任何对象]";
            }
            else if(editValue is IDictionary || editValue is IList){
                this.StaticItemObject.Caption = editValue.GetType().GetTypeString();
            }
            else {
                StaticItemObject.Caption = editValue.ToString();
            }
            this.ButtonExport.Enabled = editValue.IsNotNull();
            this.ButtonCreate.Enabled = editValue.IsNull();
            this.ButtonDelete.Enabled = editValue.IsNotNull();
            this.ButtonCreate.Visibility = EditMode != ObjectEditMode.Object? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            this.ButtonDelete.Visibility = EditMode != ObjectEditMode.Object ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            base.SetControlStatus();
        }


        private void ButtonExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExportSelectedObject();
        }

        private void ButtonCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (EditMode) {
                case ObjectEditMode.Property:
                    var propertyName = (string)Key;
                    var property = ComponentObject.GetType().GetProperty(propertyName);
                    object newObject = null;
                    var editValue = EditValue;
                    if (ConfigPublic.CreateNewAddonValue(property.PropertyType
                        , false
                        , out newObject)) {
                        EditValue = newObject;
                        SetComponentPropertyValue();
                    }
                    break;
                case ObjectEditMode.ListElement:
                case ObjectEditMode.DictionaryElement:
                    if (ConfigPublic.CreateNewAddonValue(ComponentObject.GetType()
                        , true
                        , out newObject)) {
                        EditValue = newObject;
                        SetComponentPropertyValue();
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
                    break;
                default:
                    break;
            }
        }

        private void ButtonSaveFormat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        private void ButtonSaveFormatAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
        }
    }
}
