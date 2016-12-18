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

        private Func<object> _ObjectCreateMethod;
        /// <summary>
        /// 对象创建方法
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<object> ObjectCreateMethod {
            get { return _ObjectCreateMethod; }
            set {
                _ObjectCreateMethod = value;
                SetControlStatus();
            }
        }

        private object _SelectedObject;
        /// <summary>
        /// 当前选择的对象
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object SelectedObject {
            get {
                return _SelectedObject;
            }
            set {
                _SelectedObject = value;
                SetControlStatus();
            }
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

        /// <summary>
        /// 可编辑
        /// </summary>
        public virtual bool Editable {
            get {
                return Newable || (SelectedObject != null);
            }
        }

        /// <summary>
        /// 可新建
        /// </summary>
        public virtual bool Newable {
            get {
                return ObjectCreateMethod != null;
            }
        }

        protected override void SetControlStatus() {
            this.Enabled = Editable;
        }

        /// <summary>
        /// 新建
        /// </summary>
        public virtual void CreateNew() {
            Newable.CheckTrue("只有设置了ObjectCreateMethod属性的编辑器控件才能新建对象");
            if(UIPublic.ShowYesNoDialog("您确定要删除当前对象并创建新的对象吗？") == DialogReturn.Yes) {
                this.SelectedObject = ObjectCreateMethod();
            }
        }
    }
}
