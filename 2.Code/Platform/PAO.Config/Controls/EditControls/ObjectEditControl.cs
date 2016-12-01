using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.Config.Controls.EditControls
{
    /// <summary>
    /// 插件编辑控件
    /// </summary>
    public partial class ObjectEditControl : BaseEditControl
    {
        public ObjectEditControl() {
            InitializeComponent();
            SetControlStatus();
        }

        public override object SelectedObject {
            get {
                return base.SelectedObject;
            }

            set {
                base.SelectedObject = value;
                this.PropertyGridControl.SelectedObject = value;
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
    }
}
