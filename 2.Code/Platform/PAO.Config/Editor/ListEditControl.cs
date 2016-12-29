using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Controls;
using System.Collections;
using PAO.Config.Editor;
using PAO.UI;
using PAO.IO;
using System.IO;
using PAO.WinForm;
using DevExpress.XtraBars;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 集合编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class ListEditControl : BaseEditControl, IBarSupport
    {
        internal ListEditControl() {
            InitializeComponent();
            this.ColumnObject.ColumnEdit = new ObjectEditController().CreateRepositoryItem();
        }
        
        private void Element_RowChanged(object sender, DataRowChangeEventArgs e) {
            // 列表发生变化时直接改变EditValue
            var list = base.EditValue as IList;
            if (list == null)
                return;

            if (e.Row.RowState == DataRowState.Modified) {
                var elementRow = e.Row as DataSetList.ElementRow;
                if (elementRow.Value == null) {
                    elementRow.Delete();
                }
                else {
                    list[(int)elementRow.Key] = elementRow.Value;
                }
            }
            else if (e.Row.RowState == DataRowState.Deleted) {
                var index = (int)e.Row["Key", DataRowVersion.Original];
                list.RemoveAt(index);
            }
            else if (e.Row.RowState == DataRowState.Added) {
                var elementRow = e.Row as DataSetList.ElementRow;
                list.Add(elementRow.Value);
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
                else if (value is IList) {
                    base.EditValue = value;
                    this.GridControlList.DataSource = this.BindingSourceList;
                    var list = value as IList;
                    for (int i = 0; i < list.Count; i++) {
                        DataSetList.Element.AddElementRow(i, list[i]);
                    }
                    this.ColumnIndex.OptionsColumn.ReadOnly = true;
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
            this.ButtonMoveUp.Enabled = BindingSourceList.CanMoveUp(position);
            this.ButtonMoveDown.Enabled = BindingSourceList.CanMoveDown(position);
            this.ButtonDelete.Enabled = (position >= 0 && position < BindingSourceList.Count);
            this.ButtonAdd.Enabled = base.EditValue.IsNotNull();
            base.SetControlStatus();
        }

        private void ButtonMoveUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.DataSetList.Element.RowChanged -= Element_RowChanged;
            this.DataSetList.Element.RowDeleted -= Element_RowChanged;

            var list = base.EditValue as IList;
            var position = this.BindingSourceList.Position;

            var currentRow = DataSetList.Element.FindByKey(position);
            var prevRow = DataSetList.Element.FindByKey(position - 1);
            // 两行交换位置
            currentRow.Key = -1;
            prevRow.Key = position;
            currentRow.Key = position - 1;

            list.MoveUp(position);

            this.GridControlList.RefreshDataSource();

            this.BindingSourceList.Position = position - 1;
            SetControlStatus();
            ModifyData();

            this.DataSetList.Element.RowChanged += Element_RowChanged;
            this.DataSetList.Element.RowDeleted += Element_RowChanged;
        }

        private void ButtonMoveDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.DataSetList.Element.RowChanged -= Element_RowChanged;
            this.DataSetList.Element.RowDeleted -= Element_RowChanged;

            var list = base.EditValue as IList;
            var position = this.BindingSourceList.Position;

            var currentRow = DataSetList.Element.FindByKey(position);
            var nextRow = DataSetList.Element.FindByKey(position + 1);
            // 两行交换位置
            currentRow.Key = -1;
            nextRow.Key = position;
            currentRow.Key = position + 1;

            list.MoveDown(position);

            this.GridControlList.RefreshDataSource();

            this.BindingSourceList.Position = position + 1;
            SetControlStatus();
            ModifyData();

            this.DataSetList.Element.RowChanged += Element_RowChanged;
            this.DataSetList.Element.RowDeleted += Element_RowChanged;
        }

        private void ButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            object newObject;
            if (ConfigPublic.CreateNewAddonValue(ListType
                , true
                , out newObject)) {
                DataSetList.Element.AddElementRow(DataSetList.Element.Count, newObject);
                this.GridControlList.RefreshDataSource();
                this.BindingSourceList.Position = BindingSourceList.Count - 1;
                SetControlStatus();
                ModifyData();
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
                
        private void ListEditControl_Leave(object sender, EventArgs e) {
            this.GridViewList.CloseEditor();
        }
        
    }
}
