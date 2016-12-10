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
using System.Threading.Tasks;

namespace PAO.UI.WinForm.MDI.DockViews
{
    /// <summary>
    /// 菜单视图
    /// </summary>
    public partial class TreeMenuView : DialogControl, IDockView, IMenuContainer
    {
        public TreeMenuView() {
            InitializeComponent();
        }
        
        private void AddNode(TreeListNodes nodes, IUIItem uiItem) {
            var node = nodes.Add(new object[]
            {
                uiItem.Caption,
                uiItem
            });
            if (uiItem is FolderItem) {
                var menuItem = uiItem as FolderItem;
                var childMenuItems = menuItem.ChildMenuItems;
                if (childMenuItems.IsNotNullOrEmpty()) {
                    foreach (var childController in childMenuItems) {
                        AddNode(node.Nodes, childController);
                    }
                }
            }
        }

        private void TreeListMenu_DoubleClick(object sender, EventArgs e) {
            MVCPublic.MainForm.Waiting(() =>
            {
                var focusedNode = this.TreeListMenu.FocusedNode;
                if (focusedNode != null) {
                    var controller = focusedNode.GetValue(ColumnMenu) as BaseController;
                    if (controller != null) {
                        controller.CreateAndOpenView(MVCPublic.MainForm);
                    }
                }
            }, "打开菜单");
        }

        private void ButtonExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusedNode = this.TreeListMenu.FocusedNode;
            if (focusedNode != null) {
                focusedNode.ExpandAll();
            } else {
                this.TreeListMenu.ExpandAll();
            }
        }
                
        public void AddMenuItem(IUIItem menuItem) {
            AddNode(this.TreeListMenu.Nodes, menuItem);
        }
    }
}
