using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using PAO.Config.Controls;
using PAO.Config.Editors;
using PAO.Config.PaoConfig;
using PAO.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.Config
{
    /// <summary>
    /// 静态类：ConfigPublic
    /// 配置公共类
    /// 作者：PAO
    /// </summary>
    public static class ConfigPublic
    {
        static ConfigPublic() {
            RegisterEditors();
        }

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
                    if (UIPublic.ShowDialog(typeSelectControl) == DialogResult.OK) {
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
                    if (UIPublic.ShowDialog(typeSelectControl) == DialogResult.OK) {
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

        #region 类型的EditorCotrols
        /// <summary>
        /// 编辑器类型映射
        /// </summary>
        public static readonly Dictionary<Type, Type> EditControlTypeMapping = new Dictionary<Type, Type>();

        /// <summary>
        /// 注册编辑器
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <param name="editControlType">编辑器类型</param>
        public static void RegisterEditControlType(Type objType, Type editControlType) {
            if(EditControlTypeMapping.ContainsKey(objType)) {
                EditControlTypeMapping[objType] = editControlType;
            } else {
                EditControlTypeMapping.Add(objType, editControlType);
            }
        }

        /// <summary>
        /// 获取某个类型的编辑器类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器类型</returns>
        public static Type GetTypeEditControlType(Type type) {
            foreach (var kv in EditControlTypeMapping) {
                if (type.IsDerivedFrom(kv.Key)) {
                    return kv.Value;
                }
            }

            var addonAttr = type.GetAttribute<AddonAttribute>(true);
            if (addonAttr != null && addonAttr.EditorType != null)
                return addonAttr.EditorType;

            return null;
        }
        #endregion

        #region 属性的Editors
        /// <summary>
        /// 属性编辑器类型映射
        /// </summary>
        public static readonly Dictionary<PropertyDescriptor, Type> EditorTypeMapping = new Dictionary<PropertyDescriptor, Type>();

        /// <summary>
        /// 注册编辑器
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        public static void RegisterEditorType(Type objType, string propertyName, Type editorType) {
            var properties = TypeDescriptor.GetProperties(objType);
            var propDesc = properties[propertyName];
            if(propDesc != null) {
                if (EditorTypeMapping.ContainsKey(propDesc)) {
                    EditorTypeMapping[propDesc] = editorType;
                }
                else {
                    EditorTypeMapping.Add(propDesc, editorType);
                }
            }
        }
        
        /// <summary>
        /// 获取某个属性的编辑器类型
        /// </summary>
        /// <param name="propertyDescriptor">属性</param>
        /// <returns>编辑器类型</returns>
        public static Type GetPropertyEditorType(PropertyDescriptor propertyDescriptor) {
            if(EditorTypeMapping.ContainsKey(propertyDescriptor)) {
                return EditorTypeMapping[propertyDescriptor];
            }

            var addonAttr = propertyDescriptor.Attributes.GetAttribute<AddonPropertyAttribute>();
            if (addonAttr != null && addonAttr.EditorType != null)
                return addonAttr.EditorType;

            return GetTypeEditControlType(propertyDescriptor.PropertyType);
        }
        
        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="propertyDescriptor">属性</param>
        /// <returns>编辑器</returns>
        public static RepositoryItem CreateDefaultEditor(PropertyDescriptor propertyDescriptor) {
            var editorType = GetPropertyEditorType(propertyDescriptor);
            if(editorType != null) {
                var editor = editorType.CreateInstance() as BaseEditor;
                editor.PropertyDescriptor = propertyDescriptor;
                return editor.CreateEditor();
            }

            return CreateDefaultEditorByPropertyType(propertyDescriptor);
        }

        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器</returns>
        public static RepositoryItem CreateDefaultEditorByPropertyType(PropertyDescriptor propertyDescriptor) {
            BaseEditor editor;
            var type = propertyDescriptor.PropertyType;
            if (type == typeof(string)) {
                editor = new TextEditor();
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
            else if (type == typeof(Color)) {
                editor = new ColorEditor();
            }
            else if (type == typeof(Color)) {
                editor = new ColorEditor();
            }
            else if (type == typeof(Color)) {
                editor = new ColorEditor();
            }
            else {
                editor = new ObjectEditor();
            }
            editor.PropertyDescriptor = propertyDescriptor;
            return editor.CreateEditor();
        }
        #endregion

        #region PAO项目内的Editor注册
        /// <summary>
        /// 注册编辑器
        /// </summary>
        public static void RegisterEditors() {
            ConfigPublic.RegisterEditorType(typeof(PaoObject), "ID", typeof(GuidEditor));
            ConfigPublic.RegisterEditorType(typeof(AddonFactory<>), "AddonID", typeof(AddonIDEditor));
        }
        #endregion
    }
}
