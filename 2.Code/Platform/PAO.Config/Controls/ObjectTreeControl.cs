using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using PAO.UI.WinForm.Controls;
using System.Collections;

namespace PAO.Config.Controls
{
    /// <summary>
    /// 对象树控件
    /// </summary>
    public partial class ObjectTreeControl : DialogControl
    {
        public ObjectTreeControl() {
            InitializeComponent();
        }

        private object _SelectedObject;
        public object SelectedObject {
            get {
                return _SelectedObject;
            } 
            set {
                if(_SelectedObject != value) {
                    _SelectedObject = value;
                    this.TreeListObject.Nodes.Clear();
                    ConfigPublic.CreateTreeNode(this.TreeListObject.Nodes, _SelectedObject);
                }
            }
        }

    }
}
