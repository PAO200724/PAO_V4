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
using PAO.UI;
using PAO.IO;
using PAO.IO.Text;
using System.IO;

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
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object SelectedObject {
            get;
            set;
        }

        /// <summary>
        /// 导出当前对象
        /// </summary>
        public void ExportSelectedObject() {
            string fileName = null;
            if (UIPublic.ShowSaveFileDialog("导出", ref fileName
                , FileExtentions.CONFIG
                , FileExtentions.XML
                , FileExtentions.All) == DialogResult.OK) {
                if (fileName.IsNullOrEmpty())
                    UIPublic.ShowErrorDialog("输入了错误的文件名");
                else {
                    var obj = this.SelectedObject;
                    TextPublic.WriteObjectToFile(fileName, obj);
                }
            }
        }

        /// <summary>
        /// 导入对象
        /// </summary>
        public void ImportSelectedObject() {
            string fileName = null;
            if (UIPublic.ShowOpenFileDialog("导入", ref fileName
                , FileExtentions.CONFIG
                , FileExtentions.XML
                , FileExtentions.All) == DialogResult.OK) {
                if (!File.Exists(fileName))
                    UIPublic.ShowErrorDialog("选择的文件不存在");
                else {
                    var obj = TextPublic.ReadObjectFromFile(fileName);
                    try {
                        this.SelectedObject = obj;
                        ModifyData();
                    }
                    catch (Exception err) {
                        UIPublic.ShowErrorDialog(err.Message);
                    }
                }
            }
        }
    }

}
