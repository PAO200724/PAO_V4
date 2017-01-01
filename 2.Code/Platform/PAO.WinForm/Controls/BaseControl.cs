using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.MVC;
using PAO.UI;

namespace PAO.WinForm.Controls
{
    /// <summary>
    /// 基础控件
    /// 作者：PAO
    /// </summary>
    public partial class BaseControl : DevExpress.XtraEditors.XtraUserControl, IClosable
    {
        public BaseControl() {
            InitializeComponent();
        }

        public event EventHandler Closing;

        protected virtual void OnClose() {
            return;
        }

        public void Close() {
            // 关闭子控制
            if(Controls.IsNotNullOrEmpty()) {
                foreach(Control childControl in Controls) {
                    childControl.CloseControl();
                }
            }

            if (Closing != null) {
                Closing(this, new EventArgs());
            }

            OnClose();
        }
    }
}
