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

namespace PAO.Config.Controls.EditControls
{
    /// <summary>
    /// 基础编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class BaseEditControl : DialogControl
    {
        public BaseEditControl() {
            InitializeComponent();
        }

        /// <summary>
        /// 当前选择的对象
        /// </summary>
        public virtual object SelectedObject {
            get;
            set;
        }
    }
}
