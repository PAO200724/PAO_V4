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
using PAO.Data;
using System.IO;
using PAO.UI.WinForm;
using PAO.UI;

namespace PAO.Report.Displayers
{
    /// <summary>
    /// 数据显示器基类
    /// </summary>
    public partial class BaseDataDisplayer : ViewControl
    {
        public BaseDataDisplayer() {
            InitializeComponent();
        }

        /// <summary>
        /// 数据控件
        /// </summary>
        protected virtual Control DataControl {
            get {
                return null;
            }
        }
        
        /// <summary>
        /// 导出文件的扩展名
        /// </summary>
        protected virtual string[] ExportFileFilters { get {
                return null;
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export() {
            if (ExportFileFilters == null)
                throw new Exception("未定义可导出的扩展名");
            string fileName = "";
            if(UIPublic.ShowSaveFileDialog("导出", ref fileName, ExportFileFilters) == DialogReturn.OK) {
                OnExport(fileName);
            }
        }

        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="fileName">文件名</param>
        protected virtual void OnExport(string fileName) {

        }
    }
}
