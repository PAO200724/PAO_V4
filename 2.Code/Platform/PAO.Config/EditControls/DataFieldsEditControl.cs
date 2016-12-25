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
using PAO.Data;
using PAOData = PAO.Data;
using SysData = System.Data;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 对象布局式编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class DataFieldsEditControl : BaseEditControl
    {
        public DataFieldsEditControl() {
            InitializeComponent();
            this.DataLayoutControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// 编辑控件列表
        /// </summary>
        private Dictionary<string, Control> EditControls = new Dictionary<string, Control>();
        /// <summary>
        /// 数据列
        /// </summary>
        private IEnumerable<PAOData.DataField> DataFields;
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DataTable;

        public override bool AutoSize {
            get {
                return base.AutoSize;
            }

            set {
                base.AutoSize = value;
                this.DataLayoutControl.AutoSize = value;
            }
        }

        public override DockStyle Dock {
            get {
                return base.Dock;   
            }

            set {
                base.Dock = value;
                this.DataLayoutControl.Dock = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                // 从SchemaTable中获取值
                this.BindingSource.EndEdit();
                var dataRow = DataTable.Rows[0];
                foreach(var dataColumn in DataFields) {
                    dataColumn.Value = dataRow.Field<object>(dataColumn.Name);
                }
                return DataFields; 
            }

            set {
                var valueString = "[未设置对象]";
                DataFields = value as IEnumerable<PAOData.DataField>;

                if (!DataFields.IsNull()) {
                    valueString = value.ToString();
                    DataTable = DataPublic.GetTableByFields(DataFields);
                } else {
                    DataTable = null;
                }

                Text = String.Format("属性: {0}", valueString);

                this.BindingSource.DataSource = DataTable;
                if (DataFields != null) {
                    this.BindingSource.DataSource = DataTable;
                    this.BindingSource.AddNew();
                }
                RetrieveFields(this.LayoutControlGroupRoot);
            }
        }

        private ObjectLayoutEditorLayoutData _LayoutData;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObjectLayoutEditorLayoutData LayoutData {
            get {
                return _LayoutData;
            }
            set {
                _LayoutData = value;
            }
        }

        public void EndEdit() {
            this.BindingSource.EndEdit();
        }

        protected override bool OnClosing(DialogReturn dialogResult) {
            if (_LayoutData == null)
                _LayoutData = new ObjectLayoutEditorLayoutData();
            _LayoutData.LayoutData = this.DataLayoutControl.GetLayoutData();
            return base.OnClosing(dialogResult);
        }


        /// <summary> 
        /// 根据对象填充属性字段
        /// </summary>
        /// <param name="groupItem">组项目</param>
        /// <param name="objType">对象类型</param>
        private void RetrieveFields(LayoutControlGroup groupItem) {
            groupItem.Items.Clear();
            EditControls.Clear();

            if (DataFields == null)
                return;

            foreach (var dataField in DataFields) {
                Control editControl = null;
                if (_LayoutData != null) {
                    editControl = _LayoutData.CreateEditControl(dataField.Name);
                }

                if (editControl == null) {
                    // 此处第二个参数为true，确保了最少能创建一种编辑器
                    BaseEditor editor = ConfigPublic.GetDefaultEditorByType(dataField.ObjectType);
                    if (editor == null)
                        editor = new TextEditor();
                    editControl = editor.CreateEditControl();
                }
                
                if (editControl.GetType().GetProperty("EditValue") == null)
                    throw new Exception("编辑控件必须实现EditValue属性");

                LayoutControlItem layoutControlItem = null;
                layoutControlItem = groupItem.AddItem();
                layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;

                EditControls.Add(dataField.Name, editControl);

                editControl.Tag = dataField.Name;
                editControl.Name = dataField.Name;
                if (this.BindingSource != null) {
                    editControl.DataBindings.Add(new Binding("EditValue", this.BindingSource, dataField.Name, true));
                }

                layoutControlItem.Control = editControl;
                layoutControlItem.Name = dataField.Name;
                layoutControlItem.Text = dataField.Name;
                layoutControlItem.CustomizationFormText = dataField.Name;

                if (editControl is BaseEditControl) {
                    layoutControlItem.TextVisible = false;
                }
                else {
                    layoutControlItem.TextVisible = true;
                }
            }
            this.DataLayoutControl.Refresh();
            this.DataLayoutControl.SetDefaultLayout();

            /// 读取布局数据
            if (_LayoutData.IsNotNull() && _LayoutData.LayoutData.IsNotNullOrEmpty()) {
                this.DataLayoutControl.SetLayoutData(_LayoutData.LayoutData);
            }
        }
    }
}
