using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm;

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
            var propDesc = PropertyGridControl.GetPropertyDescriptor(e.Row);
            e.RepositoryItem = ConfigPublic.CreateDefaultEditor(propDesc);
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
    }
}
