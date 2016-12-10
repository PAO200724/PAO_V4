using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.MVC;

namespace PAO.UI.WinForm.Controls
{
    public partial class BaseView : DevExpress.XtraEditors.XtraUserControl, IView
    {
        public BaseView() {
            InitializeComponent();
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public Image Icon { get; set; }
        /// <summary>
        /// 大图标
        /// </summary>
        public Image LargeIcon { get; set; }
    }
}
