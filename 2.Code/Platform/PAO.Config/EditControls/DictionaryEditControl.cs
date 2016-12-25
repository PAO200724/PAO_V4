using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using PAO.Config.Editors;
using DevExpress.XtraEditors.Repository;
using PAO.UI;
using PAO.WinForm;
using PAO.Config.Controls;
using DevExpress.XtraBars;
using PAO.WinForm.Editors;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 字典编辑控件
    /// </summary>
    public partial class DictionaryEditControl : BaseEditControl, IBarSupport
    {
        public DictionaryEditControl() {
            InitializeComponent();
            this.ColumnObject.ColumnEdit = new ObjectEditController().CreateRepositoryItem();
            this.ColumnIndex.ColumnEdit = new TextEditController().CreateRepositoryItem();
        }

        private void Element_RowChanged(object sender, DataRowChangeEventArgs e) {
            // 列表发生变化时直接改变EditValue
            var dict = base.EditValue as IDictionary;
            if (dict == null)
                return;

            if (e.Row.RowState == DataRowState.Modified) {
                var elementRow = e.Row as DataSetList.ElementRow;
                if (elementRow.Value == null) {
                    elementRow.Delete();
                }
                else {
                    var originalKey = e.Row["Key", DataRowVersion.Original];
                    if(originalKey == elementRow.Key) {
                        dict[elementRow.Key] = elementRow.Value;
                    } else {
                        dict.Remove(originalKey);
                        dict.Add(elementRow.Key, elementRow.Value);
                    }
                }
            }
            else if (e.Row.RowState == DataRowState.Deleted) {
                var originalKey = (int)e.Row["Key", DataRowVersion.Original];
                dict.Remove(originalKey);
            }
            else if (e.Row.RowState == DataRowState.Added) {
                var elementRow = e.Row as DataSetList.ElementRow;
                dict.Add(elementRow.Key, elementRow.Value);
            }
        }

        /// <summary>
        /// 元素类型
        /// </summary>
        public Type ListType {
            get {
                return this.EditValue.GetType();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                this.GridViewList.CloseEditor();

                return base.EditValue;
            }

            set {
                this.DataSetList.Element.RowChanged -= Element_RowChanged;
                this.DataSetList.Element.RowDeleted -= Element_RowChanged;
                DataSetList.Element.Clear();
                if (value.IsNull()) {
                    base.EditValue = null;
                    this.GridControlList.DataSource = null;
                }
                else if (value is IDictionary) {
                    base.EditValue = value;
                    this.GridControlList.DataSource = this.BindingSourceList;
                    var dict = value as IDictionary;
                    foreach(var key in dict.Keys) {
                        DataSetList.Element.AddElementRow(key, dict[key]);
                    }
                    this.ColumnIndex.OptionsColumn.ReadOnly = false;
                }
                else {
                    throw new Exception("列表编辑器只支持列表的编辑。");
                }
                DataSetList.Element.AcceptChanges();
                this.DataSetList.Element.RowChanged += Element_RowChanged;
                this.DataSetList.Element.RowDeleted += Element_RowChanged;
                SetControlStatus();

            }
        }

        public IEnumerable<Bar> ExtendBars {
            get {
                return new Bar[] { this.BarToolObject };
            }
        }

        protected override void SetControlStatus() {
            var position = this.BindingSourceList.Position;
            this.ButtonDelete.Enabled = (position >= 0 && position < BindingSourceList.Count);
            this.ButtonAdd.Enabled = base.EditValue.IsNotNull();
            base.SetControlStatus();
        }
        
        private void ButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            object newObject;
            var inputKeyControl = new InputKeyControl();
            if(WinFormPublic.ShowDialog(inputKeyControl) == DialogReturn.OK) {
                if (ConfigPublic.CreateNewAddonValue(ListType
                    , true
                    , out newObject)) {
                    DataSetList.Element.AddElementRow(inputKeyControl.KeyValue, newObject);
                    this.GridControlList.RefreshDataSource();
                    this.BindingSourceList.Position = BindingSourceList.Count - 1;
                    SetControlStatus();
                    ModifyData();
                }
            }
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var position = this.BindingSourceList.Position;
            if ((position >= 0 && position < BindingSourceList.Count)) {
                BindingSourceList.RemoveAt(position);
                this.GridControlList.RefreshDataSource();
                SetControlStatus();
                ModifyData();
            }
        }

        private void BindingSourceList_PositionChanged(object sender, EventArgs e) {
            SetControlStatus();
        }

        private void ButtonExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExportSelectedObject();
        }
        
        private void DictionaryEditControl_Leave(object sender, EventArgs e) {
            this.GridViewList.CloseEditor();
        }
    }
}
