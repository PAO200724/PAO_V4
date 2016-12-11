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
using DevExpress.XtraBars.Docking2010;
using System.IO;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraCharts;
using DevExpress.XtraMap;
using DevExpress.XtraScheduler;
using DevExpress.XtraSpreadsheet;
using PAO.UI.WinForm.Controls;

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

        public static DialogReturn ShowDialog(DialogControl childControl) {
            var dialog = new Dialog();
            dialog.OpenControl(childControl);
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
        /// <param name="control">控件</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this DockManager control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayoutToStream(buffer);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this DockManager control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.RestoreLayoutFromStream(buffer);
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this LayoutControl control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayoutToStream(buffer);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this LayoutControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.RestoreLayoutFromStream(buffer);
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this BaseView control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this BaseView control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.RestoreLayoutFromStream(buffer, OptionsLayoutBase.FullLayout);
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this TreeList control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this TreeList control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.RestoreLayoutFromStream(buffer);
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this VGridControl control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this VGridControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.RestoreLayoutFromStream(buffer);
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this PivotGridControl control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this PivotGridControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.RestoreLayoutFromStream(buffer);
        }
        
        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this SchedulerControl control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayoutToStream(buffer);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this SchedulerControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.RestoreLayoutFromStream(buffer);
        }
        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this XtraReport control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveLayout(buffer);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this XtraReport control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.LoadLayout(buffer);
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this ChartControl control) {
            MemoryStream buffer = new MemoryStream();
            control.SaveToStream(buffer);
            return buffer.ToArray();
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this ChartControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            MemoryStream buffer = new MemoryStream(layoutData);
            control.LoadFromStream(buffer);
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
