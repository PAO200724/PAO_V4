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
using PAO.UI.MVC;

namespace PAO.UI.WinForm.MDI.Views
{
    /// <summary>
    /// 表格控件视图
    /// 作者：PAO
    /// </summary>
    public partial class GridControlView : DialogControl, IDataView
    {
        public GridControlView() {
            InitializeComponent();
        }

        public string DataMember {
            get {
                return this.GridControl.DataMember;
            }

            set {
                this.GridControl.DataMember = value;
            }
        }

        public object DataSource {
            get {
                return this.GridControl.DataSource;
            }

            set {
                this.GridControl.DataSource = value;
            }
        }
    }
}
