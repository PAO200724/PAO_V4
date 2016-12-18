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

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 字典编辑控件
    /// </summary>
    public partial class DictionaryEditControl : BaseEditControl
    {
        public DictionaryEditControl() {
            InitializeComponent();
            this.ColumnObject.ColumnEdit = new ObjectEditor().CreateEditor();
            this.ColumnIndex.ColumnEdit = new RepositoryItemTextEdit();
        }

        /// <summary>
        /// 元素类型
        /// </summary>
        public Type ListType { get; set; }

        private List<ListElement> AddonList;
        private IDictionary SourceList;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object SelectedObject {
            get {
                this.GridViewList.CloseEditor();

                if (SourceList == null)
                    return null;

                SourceList.Clear();
                for (int i = 0; i < AddonList.Count; i++) {
                    SourceList.Add(AddonList[i].Index, AddonList[i].Element);
                }
                return SourceList;
            }

            set {
                SourceList = value as IDictionary;
                if (value == null) {
                    this.BindingSourceList.DataSource = null;
                }
                else if (!(value is IDictionary)) {
                    throw new Exception("列表编辑器只支持插件列表的编辑。");
                }
                else {
                    AddonList = new List<ListElement>();
                    int i = 0;
                    foreach (var key in SourceList.Keys) {
                        AddonList.Add(new ListElement()
                        {
                            Index = key,
                            Element = SourceList[key]
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
            this.GridControlList.RefreshDataSource();
            SetControlStatus();
            ModifyData();
        }

        private void ButtonMoveDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddonList.MoveDown(this.BindingSourceList.Position);
            this.BindingSourceList.Position++;
            this.GridControlList.RefreshDataSource();
            SetControlStatus();
            ModifyData();
        }

        private void ButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            object newObject;
            var inputKeyControl = new InputKeyControl();
            if(WinFormPublic.ShowDialog(inputKeyControl) == DialogReturn.OK) {
                if (ConfigPublic.CreateNewAddonValue(ListType
                    , true
                    , out newObject)) {
                    AddonList.Add(new ListElement() { Index = inputKeyControl.KeyValue, Element = newObject });
                    this.GridControlList.RefreshDataSource();
                    this.BindingSourceList.Position = AddonList.Count - 1;
                    SetControlStatus();
                    ModifyData();
                }
            }
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var position = this.BindingSourceList.Position;
            if ((position >= 0 && position < AddonList.Count)) {
                AddonList.RemoveAt(position);
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

        private void ButtonImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ImportSelectedObject();
        }

        private void DictionaryEditControl_Leave(object sender, EventArgs e) {
            this.GridViewList.CloseEditor();
        }
    }
}
