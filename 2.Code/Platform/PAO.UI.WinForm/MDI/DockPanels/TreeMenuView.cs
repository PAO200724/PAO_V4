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

namespace PAO.UI.WinForm.MDI.DockPanels
{
    /// <summary>
    /// 菜单视图
    /// </summary>
    public partial class TreeMenuView : DialogControl, IDockView, IUIContainer
    {
        public TreeMenuView() {
            InitializeComponent();
        }
        
        public event EventHandler<UIActionEventArgs> UIActing;

        private void AddNode(TreeListNodes nodes, IUIItem uiItem) {
            var node = nodes.Add(new object[]
            {
                uiItem.Caption,
                uiItem
            });
            uiItem.UIContainer = UIContainer;
            if (uiItem is IMenuItem) {
                var menuItem = uiItem as IMenuItem;
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
                    var command = focusedNode.GetValue(ColumnMenu) as ICommand;
                    if (command != null) {
                        command.DoCommand();
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
        
        public void DoUIAction(object sender, string actionName, IEnumerable<object> actionParameters) {
            if(UIActing != null) {
                UIActing(sender, new UIActionEventArgs()
                {
                    ActionName = actionName,
                    ActionParameters = actionParameters
                });
            }
        }

        public void OpenUIItem(IUIItem uiItem) {
            AddNode(this.TreeListMenu.Nodes, uiItem);
        }
    }
}
