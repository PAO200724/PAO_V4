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
using DevExpress.XtraDataLayout;

namespace PAO.Config.Controls.EditControls
{
    /// <summary>
    /// 对象布局式编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class ObjectLayoutEditControl : BaseEditControl
    {
        public ObjectLayoutEditControl() {
            InitializeComponent();
        }

        public override object SelectedObject {
            get {
                return base.SelectedObject; 
            }

            set {
                base.SelectedObject = value;

                if(value == null) {
                    this.BindingSource.DataSource = value;
                } else {
                    this.BindingSource.DataSource = value.GetType();
                    this.BindingSource.Add(value);

                    this.DataLayoutControl.RetrieveFields();
                }
            }
        }
    }
}
