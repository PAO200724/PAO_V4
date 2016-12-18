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
using PAO.Config.Editors;
using PAO.UI;
using PAO.IO;
using System.IO;
using PAO.WinForm;
using DevExpress.XtraBars;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 列表编辑控件
    /// </summary>
    public partial class ListEditControl : TypeEditControl
    {
        public ListEditControl() {
            InitializeComponent();
            this.ColumnObject.ColumnEdit = new ObjectEditor().CreateEditor();
        }

        /// <summary>
        /// 元素类型
        /// </summary>
        public Type ListType {
            get {
                return this.SelectedObject.GetType();
            }
        }

        private List<ListElement> AddonList;
        private IList SourceList;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object SelectedObject {
            get {
                this.GridViewList.CloseEditor();

                if (SourceList == null)
                    return null;

                SourceList.Clear();
                for(int i=0;i< AddonList.Count;i++) {
                    SourceList.Add(AddonList[i].Element);
                }
                return SourceList;
            }

            set {
                SourceList = value as IList;
                if (value == null) {
                    this.BindingSourceList.DataSource = null;
                    this.StaticItemObject.Caption = "[未选择任何对象]";
                }
                else if (!(value is IList)) {
                    throw new Exception("列表编辑器只支持插件列表的编辑。");
                }
                else {
                    this.StaticItemObject.Caption = value.GetType().GetTypeString();
                    AddonList = new List<ListElement>();
                    int i = 0;
                    foreach (var addon in SourceList) {
                        AddonList.Add(new ListElement()
                        {
                            Index = i,
                            Element = addon
                        });
                        i++;
                    }
                    this.BindingSourceList.DataSource = AddonList;
                }
                SetControlStatus();
            }
        }

        protected override void SetControlStatus() {
            var position = this.BindingSourceList.Position;
            this.ButtonMoveUp.Enabled = AddonList.IsNotNullOrEmpty() && AddonList.CanMoveUp(position);
            this.ButtonMoveDown.Enabled = AddonList.IsNotNullOrEmpty() && AddonList.CanMoveDown(position);
            this.ButtonDelete.Enabled = (position >= 0 && position < AddonList.Count);
            this.ButtonExport.Enabled = (AddonList.IsNotNullOrEmpty());
            this.ButtonNew.Visibility = Newable ? BarItemVisibility.Always : BarItemVisibility.Never;
            base.SetControlStatus();
        }

        private void DeleteElement(int position) {
            AddonList.RemoveAt(position);
            ResetIndex();
            this.GridControlList.RefreshDataSource();
            SetControlStatus();
            ModifyData();
        }

        private void ResetIndex() {
            if(AddonList.IsNotNullOrEmpty()) {
                for(int i=0;i<AddonList.Count;i++) {
                    AddonList[i].Index = i;
                }
            }
        }

        private void GridViewList_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e) {
            var position = e.RowHandle;
            var newValue = this.GridViewList.GetRowCellValue(e.RowHandle, ColumnObject);

            if (position >= 0 && SourceList.IsNotNullOrEmpty()) {
                if(newValue == null) {
                    DeleteElement(position);
                } else {
                    if(position >= SourceList.Count) {
                        SourceList.Add(newValue);
                    }
                    else {
                        SourceList[position] = newValue;
                    }
                    SetControlStatus();
                    ModifyData();
                }
            }
        }

        private void ButtonMoveUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddonList.MoveUp(this.BindingSourceList.Position);
            this.BindingSourceList.Position--;
            ResetIndex();
            this.GridControlList.RefreshDataSource();
            SetControlStatus();
            ModifyData();
        }

        private void ButtonMoveDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddonList.MoveDown(this.BindingSourceList.Position);
            this.BindingSourceList.Position++;
            ResetIndex();
            this.GridControlList.RefreshDataSource();
            SetControlStatus();
            ModifyData();
        }

        private void ButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            object newObject;
            if (ConfigPublic.CreateNewAddonValue(ListType
                , true
                , out newObject)) {
                AddonList.Add(new ListElement() { Element = newObject });
                ResetIndex();
                this.GridControlList.RefreshDataSource();
                this.BindingSourceList.Position = AddonList.Count - 1;
                SetControlStatus();
                ModifyData();
            }
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var position = this.BindingSourceList.Position;
            if ((position >= 0 && position < AddonList.Count)) {
                DeleteElement(position);
            }
        }


        private void BindingSourceList_PositionChanged(object sender, EventArgs e) {
            SetControlStatus();
        }

        private void ButtonExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExportSelectedObject();
        }
        
        private void ButtonImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ImportSelectedObject();
        }

        private void ListEditControl_Leave(object sender, EventArgs e) {
            this.GridViewList.CloseEditor();
        }

        private void ButtonNew_ItemClick(object sender, ItemClickEventArgs e) {
            CreateNew();
        }
    }
}
