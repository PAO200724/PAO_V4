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

        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器</returns>
        private static Type GetDefaultEditorType(Type type) {
            Type editorType;
            if (type == typeof(string)) {
                editorType = typeof(TextEditController);
            }
            else if (type.IsEnum) {
                editorType = typeof(EnumEditController);
            }
            else if (type == typeof(Color)) {
                editorType = typeof(ColorPickEditController);
            }
            else if (type == typeof(Font)) {
                editorType = typeof(FontEditController);
            }
            else if (type == typeof(DateTime)) {
                editorType = typeof(DateEditController);
            }
            else if (type == typeof(bool)) {
                editorType = typeof(CheckEditController);
            }
            else if (type == typeof(Image)) {
                editorType = typeof(ImageEditController);
            }
            else if (type.IsNumberType()) {
                editorType = typeof(TextEditController);
            }
            else if (type == typeof(Guid)) {
                editorType = typeof(GuidEditController);
            }
            else if (AddonPublic.IsAddonDictionaryType(type)) {
                editorType = typeof(DictionaryEditController);
            }
            else if (AddonPublic.IsAddonListType(type)) {
                editorType = typeof(ListEditController);
            }
            else if (AddonPublic.IsAddon(type)) {
                editorType = typeof(ObjectPropertyEditController);
            }
            else {
                return null;
            }
            return editorType;
        }
        
        public static BaseEditController GetEditController(Type objectType) {
            BaseEditController editController = null;
            var editorType = EditorPublic.GetEditorType(objectType);
            if (editorType == null) {
                editorType = GetDefaultEditorType(objectType);
            }

            if (editorType == null)
                return null;

            editController = EditorPublic.GetDefaultEditController(objectType, editorType);
            if (editController == null) {
                editController = editorType.CreateInstance() as BaseEditController;
                EditorPublic.SetDefaultEditController(objectType, editController);
            }
            return editController;
        }


        public static BaseEditController GetEditController(PropertyDescriptor propertyDescriptor) {
            BaseEditController editController = null;
            var editorType = EditorPublic.GetEditorType(propertyDescriptor);

            if (editorType == null) {
                editController = GetEditController(propertyDescriptor.PropertyType);
            }
            else {
                editController = editorType.CreateInstance() as BaseEditController;
                EditorPublic.SetDefaultEditController(propertyDescriptor.PropertyType, editController);
            }

            return editController;
        }
        /// <summary>
        /// 创建编辑控件
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>编辑控件</returns>
        public static Control CreateEditControl(Type objectType) {
            var editController = GetEditController(objectType);
            if (editController != null) {
                var editControl = editController.CreateEditControl(objectType);
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

        #endregion

        #region 查找编辑器类型(EditorTypeFinder)
        /// <summary>
        /// 根据对象类型查找编辑器类型
        /// </summary>
        /// <param name="type">待检测的类型</param>
        /// <param name="objectType">对象类型</param>
        /// <returns>编辑器类型</returns>
        public static bool IsEditControllerTypeOfType(Type type, Type objectType) {
            if (!type.IsDerivedFrom(typeof(BaseEditController)) || type.IsAbstract)
                return false;

            var typeFilterMethod = type.GetMethod("TypeFilter", BindingFlags.Static | BindingFlags.Public);
            if (typeFilterMethod == null)
                return true;

            return (bool)typeFilterMethod.Invoke(null, new object[] { objectType });
        }
        /// <summary>
        /// 根据对象类型查找编辑器类型
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>编辑器类型</returns>
        public static IEnumerable<Type> FindEditorTypesByObjectType(Type objectType) {
            return AddonPublic.AddonTypeList.Where(p =>
            {
                return IsEditControllerTypeOfType(p, objectType);
            });
        }

        /// <summary>
        /// 选择编辑器类型
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>编辑器类型</returns>
        public static DialogReturn SelectEditControllerType(Type objectType, out Type editControllerType) {
            var typeSelectControl = new TypeSelectControl();
            typeSelectControl.Initialize(p => {
                return IsEditControllerTypeOfType(p, objectType);
            });

            editControllerType = null;
            var result = WinFormPublic.ShowDialog(typeSelectControl);
            if (result == DialogReturn.OK) {
                editControllerType = typeSelectControl.SelectedType;
            }
            return result;
        }
        #endregion
    }
}
