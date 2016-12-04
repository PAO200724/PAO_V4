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
using PAO.UI.WinForm.MVC;
using DevExpress.XtraTreeList.Nodes;

namespace PAO.UI.WinForm.MDI.DockPanels
{
    /// <summary>
    /// 菜单视图
    /// </summary>
    public partial class TreeMenuView : DialogControl
    {
        public TreeMenuView() {
            InitializeComponent();
        }

        IMainForm MainForm;
        public void Initialize(IMainForm mainForm, IEnumerable<Controller> menuItems) {
            MainForm = mainForm;
            if (menuItems != null) {
                foreach(var controller in menuItems) {
                    AddNode(this.TreeListMenu.Nodes, controller);
                }
            }
        }

        private void AddNode(TreeListNodes nodes, Controller controller) {
            var node = nodes.Add(new object[]
            {
                controller.Caption,
                controller
            });
            if(controller.ChildFunctionItems.IsNotNullOrEmpty()) {
                foreach(var childController in controller.ChildFunctionItems) {
                    AddNode(node.Nodes, childController.Value);
                }
            }
        }

        private void TreeListMenu_DoubleClick(object sender, EventArgs e) {
            MainForm.Waiting(() =>
            {
                var focusedNode = this.TreeListMenu.FocusedNode;
                if (focusedNode != null) {
                    var controller = focusedNode.GetValue(ColumnMenu) as Controller;
                    if (controller != null) {
                        controller.DoCommand(MainForm);
                    }
                }
            }, "打开视图");
        }

        private void ButtonExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusedNode = this.TreeListMenu.FocusedNode;
            if (focusedNode != null) {
                focusedNode.ExpandAll();
            } else {
                this.TreeListMenu.ExpandAll();
            }
        }
    }
}
