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
using PAO.UI.WinForm.MDI;
using PAO.UI.MVC;

namespace PAO.Report.Inputs
{
    /// <summary>
    /// 参数输入视图
    /// </summary>
    public partial class ParameterInputView : ViewControl, IView
    {
        public ParameterInputView() {
            InitializeComponent();
        }
    }
}
