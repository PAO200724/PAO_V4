using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Controls;
using PAO.UI;
using PAO.IO;
using System.IO;

namespace PAO.WinForm
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
            IOPublic.ExportObject(this.SelectedObject);
        }

        /// <summary>
        /// 导入对象
        /// </summary>
        public void ImportSelectedObject() {
            IOPublic.ImportObject((obj)=> {
                this.SelectedObject = obj;
                ModifyData();
            });
        }
    }

}
