using PAO.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PAO.WinForm.Editor
{
    /// <summary>
    /// 静态类：EditorPublic
    /// 编辑器公共类
    /// 作者：PAO
    /// </summary>
    public static class EditorPublic
    {
        /// <summary>
        /// 根据类型保存的编辑器列表
        /// </summary>
        private static Dictionary<Type, BaseEditController> EditControllerList = new Dictionary<Type, BaseEditController>();

        /// <summary>
        /// 获取某个成员的编辑器类型
        /// </summary>
        /// <param name="member">类型</param>
        /// <returns>编辑器类型</returns>
        public static Type GetEditorType(MemberInfo member) {
            var editorAttr = member.GetAttribute<EditorTypeAttribute>(true);
            if (editorAttr != null && editorAttr.EditorType != null)
                return editorAttr.EditorType;

            return null;
        }

        /// <summary>
        /// 获取某个成员的编辑器类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>编辑器类型</returns>
        public static Type GetEditorType(MemberDescriptor member) {
            var editorAttr = member.Attributes.GetAttribute<EditorTypeAttribute>();
            if (editorAttr != null && editorAttr.EditorType != null)
                return editorAttr.EditorType;

            return null;
        }

        /// <summary>
        /// 获取编辑控制器
        /// </summary>
        /// <param name="propertyDescriptor">属性描述器</param>
        /// <returns></returns>
        public static BaseEditController GetEditController(PropertyDescriptor propertyDescriptor) {
            BaseEditController editController = null;
            var editorType = EditorPublic.GetEditorType(propertyDescriptor);
            if (editorType != null) {
                editController = editorType.CreateInstance() as BaseEditController;
            }

            if(editController == null) {
                editController = GetDefaultEditController(propertyDescriptor.PropertyType);
            }
            return editController;
        }

        /// <summary>
        /// 读取默认编辑控制器列表
        /// </summary>
        /// <param name="path">路径</param>
        public static void LoadDefaultEditControllerList(string path) {
            if(File.Exists(path))
                EditControllerList = IOPublic.ReadObjectFromFile(path) as Dictionary<Type, BaseEditController>;
        }
        
        /// <summary>
        /// 保存默认的编辑控制器列表
        /// </summary>
        /// <param name="path">路径</param>
        public static void SaveDefaultEditControllerList(string path) {
            IOPublic.WriteObjectToFile(path, EditControllerList);
        }

        /// <summary>
        /// 清除默认编辑控制器列表
        /// </summary>
        public static void ClearDefaultEditControllerList() {
            EditControllerList = new Dictionary<Type, BaseEditController>();
        }

        /// <summary>
        /// 移除默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        public static void RemoveDefaultEditController(Type objectType) {
            if (EditControllerList.ContainsKey(objectType))
                EditControllerList.Remove(objectType);
        }

        /// <summary>
        /// 获取默认编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>默认编辑控制器</returns>
        public static BaseEditController GetDefaultEditController(Type objectType) {
            if (EditControllerList.ContainsKey(objectType))
                return EditControllerList[objectType];

            BaseEditController editController = null;
            var editorType = GetEditorType(objectType);
            if (editorType != null) {
                editController = editorType.CreateInstance() as BaseEditController;
                SetDefaultEditController(objectType, editController);
            }

            return null;
        }

        /// <summary>
        /// 设置默认编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editController">默认编辑控制器</param>
        public static void SetDefaultEditController(Type objectType, BaseEditController editController) {
            if (EditControllerList.ContainsKey(objectType))
                EditControllerList[objectType] = editController;
            else
                EditControllerList.Add(objectType, editController);
        }
        
    }
}
