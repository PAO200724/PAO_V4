using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using PAO.MVC;
using PAO.WinForm.Forms;
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
using PAO.WinForm.Controls;
using System.ComponentModel;
using PAO.WinForm.Editor;
using PAO.WinForm.Config;
using PAO.Event;
using PAO.IO;
using PAO.UI;

namespace PAO.WinForm
{
    /// <summary>
    /// 静态类：WinFormPublic
    /// DevExpress公共类
    /// 作者：PAO
    /// </summary>
    public static class WinFormPublic
    {
        #region Dialog

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

        public static DialogResult DialogReturnToDialogResult(DialogReturn dialogReturn) {
            switch (dialogReturn) {
                case DialogReturn.OK:
                    return DialogResult.OK;
                case DialogReturn.Cancel:
                    return DialogResult.Cancel;
                case DialogReturn.Yes:
                    return DialogResult.Yes;
                case DialogReturn.No:
                    return DialogResult.No;
                default:
                    return DialogResult.None;
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
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayoutToStream(buffer);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this DockManager control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.RestoreLayoutFromStream(buffer);
            }
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this LayoutControl control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayoutToStream(buffer);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this LayoutControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.RestoreLayoutFromStream(buffer);
            }
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this BaseView control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this BaseView control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.RestoreLayoutFromStream(buffer, OptionsLayoutBase.FullLayout);
            }
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this TreeList control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this TreeList control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.RestoreLayoutFromStream(buffer);
            }
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this VGridControl control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this VGridControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.RestoreLayoutFromStream(buffer);
            }
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this PivotGridControl control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this PivotGridControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.RestoreLayoutFromStream(buffer);
            }
        }
        
        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this SchedulerControl control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayoutToStream(buffer);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this SchedulerControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.RestoreLayoutFromStream(buffer);
            }
        }
        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this XtraReport control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveLayout(buffer);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this XtraReport control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.LoadLayout(buffer);
            }
        }

        /// <summary>
        /// 获取布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <returns>布局数据</returns>
        public static byte[] GetLayoutData(this ChartControl control) {
            using (MemoryStream buffer = new MemoryStream()) {
                control.SaveToStream(buffer);
                return buffer.ToArray();
            }
        }

        /// <summary>
        /// 设置布局数据
        /// </summary>
        /// <param name="dockManager">停靠管理器</param>
        /// <param name="layoutData">布局数据</param>
        public static void SetLayoutData(this ChartControl control, byte[] layoutData) {
            if (layoutData.IsNullOrEmpty())
                return;
            using (MemoryStream buffer = new MemoryStream(layoutData)) {
                control.LoadFromStream(buffer);
            }
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

        #region 属性配置
        private static Dictionary<Type, TypeConfigInfo> TypeConfigInfoList = new Dictionary<Type, TypeConfigInfo>();

        /// <summary>
        /// 添加类型配置
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="typeConfigInfo">类型配置信息</param>
        public static void RegisterTypeConfig(Type type, TypeConfigInfo typeConfigInfo) {
            if (type.IsGenericType)
                type = type.GetGenericTypeDefinition();
            if (TypeConfigInfoList.ContainsKey(type)) {
                TypeConfigInfoList[type] = typeConfigInfo;
            }
            else {
                TypeConfigInfoList.Add(type, typeConfigInfo);
            }
        }

        /// <summary>
        /// 获取类型配置信息
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>类型配置信息</returns>
        public static TypeConfigInfo GetTypeConfigInfo(Type type) {
            TypeConfigInfo result = null;
            // 遍历
            type.TraverseParentTypeList((t)=>
            {
                result = TypeConfigInfoList
                    .Where(p=>p.Key == t)
                    .Select(p=>p.Value).FirstOrDefault();
                if (result != null)
                    return false;

                return true;
            });
            return result;
        }

        /// <summary>
        /// 获取属性配置信息
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性配置信息</returns>
        public static PropertyConfigInfo GetPropertyConfigInfo(Type type, string propertyName) {
            PropertyConfigInfo result = null;
            // 遍历
            type.TraverseParentTypeList((t) =>
            {
                var typeConfigInfo = TypeConfigInfoList
                    .Where(p => p.Key == t)
                    .Select(p => p.Value).FirstOrDefault();
                if (typeConfigInfo != null) {
                    // 如果能找到配置属性，则返回
                    var propertyConfigInfo = typeConfigInfo.GetPropertyConfigInfo(propertyName);
                    if (propertyConfigInfo != null) {
                        result = propertyConfigInfo;
                        return false;
                    }
                }

                return true;
            });
            return result;
        }

        /// <summary>
        /// 获取配置后的属性
        /// </summary>
        /// <param name="propertyDesc">属性描述</param>
        /// <returns>如果属性经过定义，返回经过定义的属性，如果属性定义为不再显示，则返回空</returns>
        public static PropertyDescriptor GetConfigedProperty(PropertyDescriptor propertyDesc) {
            var typeConfigInfo = WinFormPublic.GetTypeConfigInfo(propertyDesc.ComponentType);
            var propertyConfigInfo = WinFormPublic.GetPropertyConfigInfo(propertyDesc.ComponentType, propertyDesc.Name);
            if (propertyConfigInfo != null) {
                if (propertyConfigInfo.Browsable) {
                    return new ConfigPropertyDescriptor(propertyDesc, propertyConfigInfo);
                }
            }
            else {
                if (typeConfigInfo == null || !typeConfigInfo.ShowDefinedPropertyOnly) {
                    return propertyDesc;
                }
            }

            return null;
        }
        #endregion

        #region PropertyView
        public static IPropertyView DefaultPropertyView;

        /// <summary>
        /// 在属性视图中显示
        /// </summary>
        /// <param name="selectedObject">对象</param>
        public static void ShowInPropertyView(object selectedObject) {
            if(DefaultPropertyView != null) {
                DefaultPropertyView.SelectedObject = selectedObject;
            }
        }

        #endregion

    }
}
