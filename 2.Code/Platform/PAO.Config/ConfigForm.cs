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

namespace PAO.Config
{
    /// <summary>
    /// 配置工具窗口
    /// 作者：PAO
    /// </summary>
    public partial class ConfigForm : XtraForm
    {
        public ConfigForm() {
            InitializeComponent();
        }

        public void Show(object obj) {
            this.ObjectEditControl.SelectedObject = obj;
            this.ShowDialog();
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
        public static ConfigForm ShowConfigForm(object selectedObject) {

            var configForm = new Config.ConfigForm();
            configForm.Show(selectedObject);
            return configForm;
        }
    }
}
