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
using PAO.WinForm.Config;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraLayout;
using PAO.IO;

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

        #region 属性的Editors
        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="propertyDescriptor">属性</param>
        /// <returns>编辑器</returns>
        public static BaseEditController GetEditor(PropertyDescriptor propertyDescriptor, bool textEditorForNull = false) {
            BaseEditController editor = null;

            // 如果属性是定义好了的扩展属性，则直接获取编辑器
            if (propertyDescriptor is ConfigPropertyDescriptor) {
                var configProp = propertyDescriptor as ConfigPropertyDescriptor;
                if (configProp.Editor != null) {
                    editor = IOPublic.ObjectClone(configProp.Editor) as BaseEditController;
                }
            }

            // 从扩展的配置中获取编辑器
            if (editor == null) {
                var propConfigInfo = WinFormPublic.GetPropertyConfigInfo(propertyDescriptor.ComponentType, propertyDescriptor.Name);
                if (propConfigInfo != null) {
                    editor = propConfigInfo.Editor;
                }
            }

            // 根据属性类型获取编辑器
            if (editor == null) {
                editor = GetDefaultEditorByType(propertyDescriptor.PropertyType);
            }

            if (textEditorForNull && editor == null) {
                editor = new TextEditController();
            }
            return editor;
        }
        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器</returns>
        public static BaseEditController GetDefaultEditorByType(Type type) {
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
            else if (AddonPublic.IsAddon(type)) {
                editor = new ObjectEditController();
            }
            else {
                return null;
            }
            return editor;
        }

        #endregion

        #region 类型的EditorCotrols
        /// <summary>
        /// 获取某个类型的编辑器类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器类型</returns>
        public static Type GetEditControllerType(Type type) {
            var typeConfigInfo = WinFormPublic.GetTypeConfigInfo(type);
            if (typeConfigInfo != null && typeConfigInfo.EditControlType != null)
                return typeConfigInfo.EditControlType;

            var addonAttr = type.GetAttribute<AddonAttribute>(true);
            if (addonAttr != null && addonAttr.EditorType != null)
                return addonAttr.EditorType;

            return null;
        }

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
        public static T GetEditControllerByType<T>(Type objectType) where T : BaseEditController {
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
        public static T CreateEditControllerByType<T>(Type objectType) where T : BaseEditController, new() {
            var id = GetTypeEditControlID(typeof(T), objectType);
            var editController = new T();
            editController.ID = id;
            return editController;
        }
        #endregion
    }
}
