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

namespace PAO.UI.WinForm.MDI.Inputs
{
    /// <summary>
    /// 参数输入视图
    /// </summary>
    public partial class ParameterInputView : ViewControl, IDockView
    {
        public ParameterInputView() {
            InitializeComponent();
        }
    }
}
