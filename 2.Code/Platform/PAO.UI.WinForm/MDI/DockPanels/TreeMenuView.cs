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
using DevExpress.XtraTreeList.Nodes;
using PAO.UI.MVC;

namespace PAO.UI.WinForm.MDI.DockPanels
{
    /// <summary>
    /// 菜单视图
    /// </summary>
    public partial class TreeMenuView : DialogControl, IDockView, IUIItemContainer
    {
        public TreeMenuView() {
            InitializeComponent();
        }

        IMainForm MainForm;
        public void Initialize(IMainForm mainForm, IEnumerable<IUIItem> menuItems) {
            MainForm = mainForm;
            if (menuItems != null) {
                foreach(var controller in menuItems) {
                    AddNode(this.TreeListMenu.Nodes, controller);
                }
            }
        }

        private void AddNode(TreeListNodes nodes, IUIItem controller) {
            var node = nodes.Add(new object[]
            {
                controller.Caption,
                controller
            });
            if(controller is IMenuItem) {
                var menuItem = controller as IMenuItem;
                var childMenuItems = menuItem.ChildMenuItems;
                if (childMenuItems.IsNotNullOrEmpty()) {
                    foreach (var childController in childMenuItems) {
                        AddNode(node.Nodes, childController);
                    }
                }
            }
        }

        private void TreeListMenu_DoubleClick(object sender, EventArgs e) {
            MainForm.Waiting(() =>
            {
                var focusedNode = this.TreeListMenu.FocusedNode;
                if (focusedNode != null) {
                    var command = focusedNode.GetValue(ColumnMenu) as ICommand;
                    if (command != null) {
                        command.DoCommand();
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

        public void OpenUIItem(IUIItem functionItem) {
            MainForm = MVCPublic.MainForm;
            AddNode(this.TreeListMenu.Nodes, functionItem);
        }
    }
}
