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

namespace PAO.Config.DockViews
{
    /// <summary>
    /// 属性页视图
    /// 作者：PAO
    /// </summary>
    public partial class PropertyView : ViewControl, IDockView
    {
        /// <summary>
        /// 默认视图
        /// </summary>
        private static PropertyView Default = null;
        public PropertyView() {
            InitializeComponent();
            Default = this;
        }

        /// <summary>
        /// 显示配置窗体
        /// </summary>
        /// <param name="selectedObject">选择对象</param>
        public static void SetSelectedObject(object selectedObject) {
            if(Default != null && !Default.IsDisposed)
                Default.ObjectEditControl.SelectedObject = selectedObject;
        }
    }
}
