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
using PAO.WinForm.Editor;

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
        
        private object _EditValue;
        /// <summary>
        /// 编辑对象
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object EditValue {
            get {
                return _EditValue;
            }
            set {
                if (value.IsNull())
                    value = null;
                _EditValue = value;
            }
        }

        /// <summary>
        /// 控制器
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BaseEditController Controller { get; set; }
        
        /// <summary>
        /// 导出当前对象
        /// </summary>
        public void ExportSelectedObject() {
            IOPublic.ExportObject(this.EditValue);
        }

        /// <summary>
        /// 可编辑
        /// </summary>
        public virtual bool Editable {
            get {
                return (EditValue != null);
            }
        }
        
        protected override void SetControlStatus() {
        }
    }
}
