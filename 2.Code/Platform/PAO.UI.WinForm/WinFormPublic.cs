﻿using DevExpress.XtraBars;
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
using DevExpress.XtraBars.Docking2010;
using System.IO;
using DevExpress.XtraBars.Docking;

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

        public static DialogReturn ShowDialog<T>(T childControl) where T : Control, IView{
            var dialog = new Dialog();
            dialog.OpenView(childControl);
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

        #region Layout
        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this DockManager dockManager) {
            MemoryStream buffer = new MemoryStream();
            dockManager.SaveLayoutToStream(buffer);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this DockManager dockManager, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            dockManager.RestoreLayoutFromStream(buffer);
        }
        #endregion

        #region MenuItem
        /// <summary>
        /// 添加菜单到子菜单中（包含下级菜单）
        /// </summary>
        /// <param name="barSubItem">子菜单</param>
        /// <param name="uiItem">菜单项</param>
        /// <param name="container">视图容器</param>
        public static void AddMenuToSubItem(object barSubItem, IUIItem uiItem, IViewContainer container) {
            BarItem barItem = null;
            if(uiItem is FolderItem) {
                var menuItem = uiItem as FolderItem;
                if (menuItem.ChildMenuItems.IsNotNull()) {
                    var newSubItem = new BarSubItem();
                    foreach (var childFunctionItem in menuItem.ChildMenuItems) {
                        AddMenuToSubItem(newSubItem, childFunctionItem, container);
                    }
                    barItem = newSubItem;
                }
            }
            if (barItem == null){
                barItem = new BarButtonItem();
            }

            barItem.Caption = uiItem.Caption;
            barItem.Glyph = uiItem.Icon;
            barItem.LargeGlyph = uiItem.LargeIcon;
            barItem.ItemClick += (sender, e) =>
            {
                try {
                    if(uiItem is BaseController) {
                        var controller = uiItem as BaseController;
                        controller.CreateAndOpenView(container);
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
