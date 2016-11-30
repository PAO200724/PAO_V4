using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.Config.Controls
{
    /// <summary>
    /// 插件编辑控件
    /// </summary>
    public partial class ObjectEditControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ObjectEditControl() {
            InitializeComponent();
        }

        public object SelectedObject {
            get {
                return PropertyGridControl.SelectedObject;
            }

            set {
                this.PropertyGridControl.SelectedObject = value;
            }
        }
    }
}
