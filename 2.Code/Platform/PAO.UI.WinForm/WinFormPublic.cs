using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using PAO.UI.MVC;
using PAO.UI.WinForm.Forms;
using PAO.UI.WinForm.MDI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 静态类：WinFormPublic
    /// DevExpress公共类
    /// 作者：PAO
    /// </summary>
    public static class WinFormPublic
    {
        #region Public

        public static DialogReturn DialogResultToDialogReturn(DialogResult result) {
            switch (result) {
                case DialogResult.OK:
                    return DialogReturn.OK;
                case DialogResult.Cancel:
                    return DialogReturn.Cancel;
                case DialogResult.Yes:
                    return DialogReturn.Yes;
                case DialogResult.No:
                    return DialogReturn.No;
                default:
                    return DialogReturn.None;
            }
        }

        public static DialogReturn ShowDialog(Control childControl) {
            var dialog = new Dialog();
            dialog.ChildControl = childControl;
            return DialogResultToDialogReturn(dialog.ShowDialog());
        }


        /// <summary>
        /// 截屏
        /// </summary>
        /// <returns>屏幕截屏</returns>
        public static Image ScreenShot(Screen screen) {
            Bitmap bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bitmap)) {
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bitmap.Size);
            }

            return bitmap;
        }
        #endregion

        #region ButtonEditor
        /// <summary>
        /// 添加清除按钮
        /// </summary>
        /// <param name="buttonEdit">按钮编辑器</param>
        public static void AddClearButton(this RepositoryItemButtonEdit buttonEdit) {
            buttonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
        }

        private static void ButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
            if(e.Button.Kind == ButtonPredefines.Delete) {
                var buttonEdit = sender as ButtonEdit;
                buttonEdit.EditValue = null;
            }
        }
        #endregion

        #region MenuItem
        /// <summary>
        /// 添加菜单到子菜单中（包含下级菜单）
        /// </summary>
        /// <param name="barSubItem">子菜单</param>
        /// <param name="menuItem">菜单项</param>
        /// <param name="mainForm">主窗体</param>
        public static void AddMenuToSubItem(object barSubItem, IUIItem uiItem, IMainForm mainFom) {
            BarItem barItem = null;
            if(uiItem is IMenuItem) {
                var menuItem = uiItem as IMenuItem;
                if (menuItem.ChildMenuItems.IsNotNull()) {
                    var newSubItem = new BarSubItem();
                    foreach (var childFunctionItem in menuItem.ChildMenuItems) {
                        AddMenuToSubItem(newSubItem, childFunctionItem, mainFom);
                    }
                    barItem = newSubItem;
                }
                else {
                    barItem = new BarButtonItem();
                }
            }

            barItem.Caption = uiItem.Caption;
            barItem.Glyph = uiItem.Icon;
            barItem.LargeGlyph = uiItem.LargeIcon;
            barItem.ItemClick += (sender, e) =>
            {
                try {
                    if(uiItem is ICommand) {
                        var command = uiItem as ICommand;
                        command.DoCommand();
                    }
                } catch (Exception err) {
                    UIPublic.ShowErrorDialog(err.FormatException());
                }
            };

            if (barSubItem is BarSubItem) {
                var barItemLink = barSubItem.As<BarSubItem>().AddItem(barItem);
                barItemLink.RecentIndex = 1;
            }
            else if(barSubItem is Bar) {
                var barItemLink = barSubItem.As<Bar>().AddItem(barItem);
            }
            else {
                throw new Exception("此对象不支持添加子菜单");
            }
        }
        #endregion
    }
}
