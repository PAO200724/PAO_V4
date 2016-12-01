using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
using System.Collections;
using PAO.Config.Editors;

namespace PAO.Config.Controls.EditControls
{
    /// <summary>
    /// 列表编辑控件
    /// </summary>
    public partial class ListEditControl : BaseEditControl
    {
        public ListEditControl() {
            InitializeComponent();
            this.ColumnObject.ColumnEdit = new ObjectEditor().CreateEditor();
        }

        /// <summary>
        /// 元素类型
        /// </summary>
        public Type ListType { get; set; }

        private List<ListElement> AddonList;
        private IList SourceList;
        public override object SelectedObject {
            get {
                if (SourceList == null)
                    return null;

                SourceList.Clear();
                for(int i=0;i< AddonList.Count;i++) {
                    SourceList.Add(AddonList[i].Element);
                }
                return SourceList;
            }

            set {
                if (value == null) {
                    this.BindingSourceList.DataSource = null;
                }
                else if (!(value is IList)) {
                    throw new Exception("列表编辑器只支持插件列表的编辑。");
                }
                else {
                    SourceList = value as IList;
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

        private void SetControlStatus() {
            var position = this.BindingSourceList.Position;
            this.Enabled = SourceList != null;
            this.ButtonMoveUp.Enabled = AddonList.IsNotNullOrEmpty() && AddonList.CanMoveUp(position);
            this.ButtonMoveDown.Enabled = AddonList.IsNotNullOrEmpty() && AddonList.CanMoveDown(position);
            this.ButtonDelete.Enabled = (position >= 0 && position < AddonList.Count);
        }

        private void ResetIndex() {
            if(AddonList.IsNotNullOrEmpty()) {
                for(int i=0;i<AddonList.Count;i++) {
                    AddonList[i].Index = i;
                }
            }
        }

        private void GridViewList_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e) {
            if (this.BindingSourceList.Position >= 0 && SourceList.IsNotNullOrEmpty()) {
                var listElement = this.BindingSourceList.Current as ListElement;
                SourceList[this.BindingSourceList.Position] = listElement.Element;
                SetControlStatus();
                ModifyData();
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
                AddonList.RemoveAt(position);
                ResetIndex();
                this.GridControlList.RefreshDataSource();
                SetControlStatus();
                ModifyData();
            }
        }

        private void BindingSourceList_PositionChanged(object sender, EventArgs e) {
            SetControlStatus();
        }
    }
}
