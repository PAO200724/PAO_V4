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

        private Surface _Surface;

        /// <summary>
        /// 外观
        /// </summary>
        public virtual Surface Surface {
            get { return _Surface; }
            set { _Surface = value;
                if(value != null) {
                    BackColor = _Surface.BackColor;
                    ForeColor = _Surface.ForeColor;
                    Font = _Surface.Font;
                }
            }
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <returns>布局数据</returns>
        public virtual byte[] GetLayoutData() {
            return null;
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="layoutData">布局数据</param>
        public virtual void SetLayoutData(byte[] layoutData) {

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
                string ext = Path.GetExtension(fileName);
                OnExport(fileName, ext);
            }
        }

        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="ext">文件扩展名</param>
        protected virtual void OnExport(string fileName, string ext) {

        }
    }
}
