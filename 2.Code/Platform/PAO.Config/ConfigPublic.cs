using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using PAO.Config.Controls;
using PAO.Config.Editor;
using PAO.Data;
using PAO.UI;
using PAO.WinForm;
using PAO.WinForm.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraLayout;
using PAO.IO;
using System.Reflection;

namespace PAO.Config
{
    /// <summary>
    /// 静态类：ConfigPublic
    /// 配置公共类
    /// 作者：PAO
    /// </summary>
    public static class ConfigPublic
    {
        #region 插件列表
        /// <summary>
        /// 编辑时根对象
        /// </summary>
        public static object RootEditingObject;

        /// <summary>
        /// 根据插件ID查找编辑中的插件
        /// </summary>
        /// <param name="addonID">插件ID</param>
        /// <returns></returns>
        public static PaoObject GetEditiongAddonByID(string addonID) {
            if (RootEditingObject == null)
                return null;
            PaoObject addonEditing = null;
            AddonPublic.TraverseAddon((addon) =>
            {
                if (addon is PaoObject) {
                    var paoObj = addon as PaoObject;
                    if (paoObj.ID == addonID) {
                        addonEditing = paoObj;
                        return false;
                    }
                }

                return true;
            }, RootEditingObject);

            return addonEditing;
        }
        #endregion

        #region NewAddonValue
        /// <summary>
        /// 创建新的属性值
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="createElement">创建元素对象</param>
        /// <param name="propDesc">属性描述</param>
        /// <return>属性值</return>
        public static bool CreateNewAddonValue(Type objectType, bool createElement, out object newObject) {
            if (objectType.IsAddonDictionaryType() || objectType.IsAddonListType()) {
                if (createElement) {
                    var listElementType = ReflectionPublic.GetCollectionElementType(objectType);
                    if (listElementType == null) {
                        newObject = null;
                        return false;
                    }

                    return CreateNewAddonValue(listElementType, false, out newObject);
                }
                else {
                    // 创建新的对象
                    newObject = objectType.CreateInstance();
                    return true;
                }
            }
            else {
                var typeSelectControl = new TypeSelectControl();
                if (objectType.IsGenericType && objectType.IsDerivedFrom(typeof(Ref<>))) {
                    var refType = objectType.GetGenericArguments()[0];
                    typeSelectControl.Initialize(p =>
                    {
                        return (p.IsDerivedFrom(refType) || p.IsDerivedFrom(typeof(Factory<>))) && p.IsClass && !p.IsAbstract;
                    });
                    if (WinFormPublic.ShowDialog(typeSelectControl) == DialogReturn.OK) {
                        var selectedAddonType = typeSelectControl.SelectedType;
                        if (selectedAddonType != null) {
                            if (selectedAddonType.IsDerivedFrom(typeof(Ref<>))) {
                                // 创建新的工厂
                                var objectRefType = selectedAddonType.MakeGenericType(refType);
                                newObject = objectRefType.CreateInstance();
                                return true;
                            }
                            else {
                                // 创建新的对象
                                var newInstance = selectedAddonType.CreateInstance();
                                var objectRefType = typeof(ObjectRef<>).MakeGenericType(refType);
                                newObject = objectRefType.CreateInstance(newInstance);
                                return true;
                            }
                        }
                    }
                }
                else {
                    typeSelectControl.Initialize(p =>
                    {
                        return p.IsDerivedFrom(objectType) && p.IsClass && !p.IsAbstract;
                    });
                    if (WinFormPublic.ShowDialog(typeSelectControl) == DialogReturn.OK) {
                        var selectedAddonType = typeSelectControl.SelectedType;
                        if (selectedAddonType != null) {
                            // 创建新的对象
                            newObject = selectedAddonType.CreateInstance();
                            return true;
                        }
                    }
                }
            }
            newObject = null;
            return false;
        }
        #endregion

        #region Editors
        #region RepositoryItem & EditControl
        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器</returns>
        private static BaseEditController GetDefaultEditorByType(Type type) {
            BaseEditController editor;
            if (type == typeof(string)) {
                editor = new TextEditController();
            }
            else if (type.IsEnum) {
                editor = new EnumEditController();
            }
            else if (type == typeof(Color)) {
                editor = new ColorPickEditController();
            }
            else if (type == typeof(Font)) {
                editor = new FontEditor();
            }
            else if (type == typeof(DateTime)) {
                editor = new DateEditController();
            }
            else if (type == typeof(bool)) {
                editor = new CheckEditController();
            }
            else if (type == typeof(Image)) {
                editor = new ImageEditController();
            }
            else if (type.IsNumberType()) {
                editor = new TextEditController();
            }
            else if (type == typeof(Guid)) {
                editor = new GuidEditController();
            }
            else if (AddonPublic.IsAddonDictionaryType(type)) {
                editor = new DictionaryEditController();
            }
            else if (AddonPublic.IsAddonListType(type)) {
                editor = new ListEditController();
            }
            else if (AddonPublic.IsAddon(type)) {
                editor = new ObjectPropertyEditController();
            }
            else {
                return null;
            }
            return editor;
        }

        private static BaseEditController GetEditController(Type objectType) {
            BaseEditController editController = EditorPublic.GetDefaultEditController(objectType);
            if (editController == null) {
                editController = GetDefaultEditorByType(objectType);
                EditorPublic.SetDefaultEditController(objectType, editController);
            }
            return editController;
        }

        private static BaseEditController GetEditController(PropertyDescriptor propertyDescriptor) {
            BaseEditController editController = EditorPublic.GetEditController(propertyDescriptor);
            if(editController == null) {
                editController = GetDefaultEditorByType(propertyDescriptor.PropertyType);
                EditorPublic.SetDefaultEditController(propertyDescriptor.PropertyType, editController);
            }

            return editController;
        }

        /// <summary>
        /// 根据类型保存的编辑器列表
        /// </summary>
        private static Dictionary<Type, Control> EditControlListByType = new Dictionary<Type, Control>();

        /// <summary>
        /// 创建编辑控件
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>编辑控件</returns>
        public static Control CreateEditControl(Type objectType) {
            if (EditControlListByType.ContainsKey(objectType))
                return EditControlListByType[objectType];

            var editController = GetEditController(objectType);
            if (editController != null) {
                var editControl = editController.CreateEditControl(objectType);
                EditControlListByType.Add(objectType, editControl);
                return editControl;
            }
            return null;
        }
        
        /// <summary>
        /// 创建RepositoryItem
        /// </summary>
        /// <param name="propertyDescriptor">属性描述器</param>
        /// <returns>RepositoryItem</returns>
        public static RepositoryItem CreateRepositoryItem(PropertyDescriptor propertyDescriptor) {
            var editController = GetEditController(propertyDescriptor);
            if (editController != null) {
                var repositoryItem = editController.CreateRepositoryItem(propertyDescriptor.PropertyType);
                return repositoryItem;
            }
            return null;
        }
        #endregion RepositoryItem & EditControl

        /// <summary>
        /// 获取对象编辑器ID
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        /// <returns>对象编辑器ID</returns>
        private static string GetTypeEditControlID(Type editorType, Type objectType) {
            return String.Format("EditController_{0}_{1}", editorType, objectType);
        }


        /// <summary>
        /// 根据类型获取编辑器控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <typeparam name="T">编辑器类型类型</typeparam>
        /// <returns>编辑器控制器</returns>
        private static T GetEditControllerByType<T>(Type objectType) where T : BaseEditController {
            var id = GetTypeEditControlID(typeof(T), objectType);

            var editController = (T)ExtendAddonPublic.GetExtendLocalAddon(id);
            return editController;
        }

        /// <summary>
        /// 编辑器控制器
        /// </summary>
        /// <typeparam name="T">编辑器类型类型</typeparam>
        /// <param name="objectType">对象类型</param>
        /// <returns>新的编辑器控制器</returns>
        private static T CreateEditControllerByType<T>(Type objectType) where T : BaseEditController, new() {
            var id = GetTypeEditControlID(typeof(T), objectType);
            var editController = new T();
            editController.ID = id;
            return editController;
        }
        #endregion
    }
}
