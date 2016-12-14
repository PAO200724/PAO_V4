using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.Config
{
    /// <summary>
    /// 配置工具窗口
    /// 作者：PAO
    /// </summary>
    public partial class ConfigForm : XtraForm
    {
        private static ConfigForm Default;

        public ConfigForm() {
            InitializeComponent();
        }

        public void Show(object obj) {
            this.ObjectEditControl.SelectedObject = obj;
            this.Show();
        }

        public object SelectedObject {
            get {
                return this.ObjectEditControl.SelectedObject;
            }

            set {
                this.ObjectEditControl.SelectedObject = value;
            }
        }

        /// <summary>
        /// 显示配置窗体
        /// </summary>
        /// <param name="selectedObject">选择对象</param>
        public static void ShowConfigForm(object selectedObject) {
            if (Default == null || Default.IsDisposed)
                Default = new Config.ConfigForm();
            Default.Show(selectedObject);
        }

        /// <summary>
        /// 隐藏配置窗体
        /// </summary>
        public static void HideConfigForm() {
            Default.Hide();
        }
    }
}
