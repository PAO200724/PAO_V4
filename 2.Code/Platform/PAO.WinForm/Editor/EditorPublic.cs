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
        private static Dictionary<string, BaseEditController> EditControllerList = new Dictionary<string, BaseEditController>();

        /// <summary>
        /// 获取编辑器ID
        /// </summary>
        private static string GetEditorID(Type editorType, Type objectType) {
            return String.Format("{0}.{1}", editorType.FullName, objectType.FullName);
        }

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
        /// 读取默认编辑控制器列表
        /// </summary>
        /// <param name="path">路径</param>
        public static void LoadDefaultEditControllerList(string path) {
            if(File.Exists(path))
                EditControllerList = IOPublic.ReadObjectFromFile(path) as Dictionary<string, BaseEditController>;
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
            EditControllerList = new Dictionary<string, BaseEditController>();
        }

        /// <summary>
        /// 移除默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        public static void RemoveDefaultEditController(Type objectType, Type editorType) {
            string editorID = GetEditorID(editorType, objectType);
            if (EditControllerList.ContainsKey(editorID))
                EditControllerList.Remove(editorID);
        }

        /// <summary>
        /// 获取默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        /// <returns>默认编辑控制器</returns>
        public static BaseEditController GetDefaultEditController(Type objectType, Type editorType) {
            string editorID = GetEditorID(editorType, objectType);
            if (EditControllerList.ContainsKey(editorID))
                return EditControllerList[editorID];

            return null;
        }

        /// <summary>
        /// 设置默认编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editController">默认编辑控制器</param>
        public static void SetDefaultEditController(Type objectType, BaseEditController editController) {
            string editorID = GetEditorID(editController.GetType(), objectType);
            if (EditControllerList == null)
                EditControllerList = new Dictionary<string, BaseEditController>();
            if (EditControllerList.ContainsKey(editorID))
                EditControllerList[editorID] = editController;
            else
                EditControllerList.Add(editorID, editController);
        }
        
    }
}
