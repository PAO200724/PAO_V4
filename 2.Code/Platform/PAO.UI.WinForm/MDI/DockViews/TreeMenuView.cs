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
    public partial class TreeMenuView : ViewControl, IDockView, IMenuContainer
    {
        public TreeMenuView() {
            InitializeComponent();
        }

        /// <summary>
        /// 类型图标索引
        /// </summary>
        private Dictionary<string, int> TypeIconIndexList = new Dictionary<string, int>();
        /// <summary>
        /// 对象类型
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>图片索引</returns>
        private int GetImageIndex(Image icon) {
            if (icon == null)
                return -1;
            ImageCollection.Images.Add(icon.Clone() as Image);
            return ImageCollection.Images.Count - 1;
        }

        protected override void OnSetController(BaseController value) {
            var controller = value as TreeMenuController;
            if (controller.MenuItems.IsNotNullOrEmpty()) {
                foreach (var menuItem in controller.MenuItems) {
                    AddMenuItem(menuItem.Value);
                }
            }
        }

        private void AddNode(TreeListNodes nodes, IUIItem uiItem) {
            var node = nodes.Add(new object[]
            {
                uiItem.Caption,
                uiItem
            });
            node.ImageIndex = GetImageIndex(uiItem.Icon);
            node.SelectImageIndex = node.ImageIndex;
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
