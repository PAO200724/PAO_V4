using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using PAO.Config.Controls;
using PAO.Config.Editors;
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

        #region Editors
        /// <summary>
        /// 编辑器类型映射
        /// </summary>
        public static readonly Dictionary<Type, Type> EditorTypeMapping = new Dictionary<Type, Type>();

        /// <summary>
        /// 注册编辑器
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        public static void RegisterEditor(Type objType, Type editorType) {
            if(EditorTypeMapping.ContainsKey(objType)) {
                EditorTypeMapping[objType] = editorType;
            } else {
                EditorTypeMapping.Add(objType, editorType);
            }
        }

        /// <summary>
        /// 获取某个类型的编辑器类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器类型</returns>
        public static Type GetTypeEditorType(Type type) {
            foreach (var kv in EditorTypeMapping) {
                if (type.IsDerivedFrom(kv.Key)) {
                    return kv.Value;
                }
            }

            var addonAttr = type.GetAttribute<AddonAttribute>(true);
            if (addonAttr != null && addonAttr.EditorType != null)
                return addonAttr.EditorType;

            return null;
        }

        /// <summary>
        /// 获取某个属性的编辑器类型
        /// </summary>
        /// <param name="propertyDescriptor">属性</param>
        /// <returns>编辑器类型</returns>
        public static Type GetPropertyEditorType(PropertyDescriptor propertyDescriptor) {
            var addonAttr = propertyDescriptor.Attributes.GetAttribute<AddonPropertyAttribute>();
            if (addonAttr != null && addonAttr.EditorType != null)
                return addonAttr.EditorType;

            return GetTypeEditorType(propertyDescriptor.PropertyType);
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
                editor.ObjectType = propertyDescriptor.PropertyType;
                return editor.CreateEditor();
            }

            return CreateDefaultEditor(propertyDescriptor.PropertyType);
        }

        /// <summary>
        /// 创建默认编辑器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器</returns>
        public static RepositoryItem CreateDefaultEditor(Type type) {
            BaseEditor editor;

            if (type == typeof(Color)) {
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
            editor.ObjectType = type;
            return editor.CreateEditor();
        }
        #endregion
    }
}
