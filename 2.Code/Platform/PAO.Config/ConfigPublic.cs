﻿using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using PAO.Config.Controls;
using PAO.Config.EditControls;
using PAO.Config.Editors;
using PAO.Data;
using PAO.UI;
using PAO.WinForm;
using PAO.WinForm.Editors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PAO.DataSetExtendProperty;
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
                        return true;
                    }
                }

                return false;
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
        public static BaseEditor GetEditor(PropertyDescriptor propertyDescriptor) {
            BaseEditor editor = null;

            // 如果属性是定义好了的扩展属性，则直接获取编辑器
            if (propertyDescriptor is ConfigPropertyDescriptor) {
                var configProp = propertyDescriptor as ConfigPropertyDescriptor;
                if (configProp.Editor != null) {
                    editor = IOPublic.ObjectClone(configProp.Editor) as BaseEditor;
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

            if (editor != null) {
                editor.PropertyDescriptor = propertyDescriptor;
            }
            return editor;
        }
        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器</returns>
        public static BaseEditor GetDefaultEditorByType(Type type) {
            BaseEditor editor;
            if (type == typeof(string)) {
                editor = new TextEditor();
            }
            else if (type.IsEnum) {
                editor = new EnumEditor();
            }
            else if (type == typeof(Color)) {
                editor = new ColorPickEditor();
            }
            else if (type == typeof(Font)) {
                editor = new FontEditor();
            }
            else if (type == typeof(DateTime)) {
                editor = new DateEditor();
            }
            else if (type == typeof(bool)) {
                editor = new ToggleSwitchEditor();
            }
            else if (type == typeof(Image)) {
                editor = new ImageEditor();
            }
            else if (type.IsNumberType()) {
                editor = new TextEditor();
            }
            else if (type == typeof(Guid)) {
                editor = new GuidEditor();
            }
            else if (AddonPublic.IsAddon(type)) {
                editor = new ObjectEditor();
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
        public static Type GetEditControlType(Type type) {
            var typeConfigInfo = WinFormPublic.GetTypeConfigInfo(type);
            if (typeConfigInfo != null && typeConfigInfo.EditControlType != null)
                return typeConfigInfo.EditControlType;

            var addonAttr = type.GetAttribute<AddonAttribute>(true);
            if (addonAttr != null && addonAttr.EditorType != null)
                return addonAttr.EditorType;

            return null;
        }
        #endregion

        #region LayoutControl
        /// <summary> 
        /// 根据对象填充属性字段
        /// </summary>
        /// <param name="groupItem">组项目</param>
        /// <param name="obj">对象</param>
        public static void RetrievePropertyFields(this LayoutControlGroup groupItem, object obj) {
            groupItem.Items.Clear();

            if (obj == null)
                return;

            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(obj)) {
                var configedPropDesc = WinFormPublic.GetConfigedProperty(propDesc);

                if (configedPropDesc == null || !configedPropDesc.IsBrowsable)
                    continue;

                Control editControl;
                var propValue = configedPropDesc.GetValue(obj);
                if (AddonPublic.IsAddonDictionaryType(configedPropDesc.PropertyType)) {
                    var dictEditControl = new DictionaryEditControl();
                    dictEditControl.SelectedObject = propValue;
                    editControl = dictEditControl;
                } else if(AddonPublic.IsAddonListType(configedPropDesc.PropertyType)) {
                    var listEditControl = new ListEditControl();
                    listEditControl.SelectedObject = propValue;
                    editControl = listEditControl;
                }
                else {
                    BaseEditor edit = null;
                    edit = ConfigPublic.GetEditor(configedPropDesc);
                    if (edit == null) {
                        edit = new TextEditor();
                    }
                    var repositoryItem = edit.CreateEditor();
                    var editor = repositoryItem.CreateEditor();
                    editor.Properties.Assign(repositoryItem);
                    editor.EditValue = propValue;
                    editControl = editor;
                }
                editControl.Tag = configedPropDesc;
                editControl.Name = configedPropDesc.Name;

                var layoutControlItem = groupItem.AddItem();
                layoutControlItem.Name = configedPropDesc.Name;
                layoutControlItem.Text = configedPropDesc.DisplayName;
                layoutControlItem.CustomizationFormText = configedPropDesc.DisplayName;
                layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
                layoutControlItem.TextVisible = true;
                layoutControlItem.ShowInCustomizationForm = true;
                layoutControlItem.Control = editControl;
            }
        }
        #endregion

    }
}
