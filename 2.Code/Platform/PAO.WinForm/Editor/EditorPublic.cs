using PAO.Config;
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
        public const string EditorsStorageName = "Editors";
        /// <summary>
        /// 获取编辑器ID
        /// </summary>
        private static string GetEditorID(Type editorType, Type objectType) {
            return String.Format("{0}_{1}", editorType.FullName, objectType.FullName);
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
        /// 移除默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        public static void RemoveDefaultEditController(Type objectType, Type editorType) {
            string editorID = GetEditorID(editorType, objectType);
            ConfigStoragePublic.RemoveConfig(EditorsStorageName, editorID);
        }

        /// <summary>
        /// 获取默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        /// <returns>默认编辑控制器</returns>
        public static BaseEditController GetDefaultEditController(Type objectType, Type editorType) {
            string editorID = GetEditorID(editorType, objectType);
            return ConfigStoragePublic.GetConfig(EditorsStorageName, editorID) as BaseEditController;
        }

        /// <summary>
        /// 设置默认编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editController">默认编辑控制器</param>
        public static void SetDefaultEditController(Type objectType, BaseEditController editController) {
            string editorID = GetEditorID(editController.GetType(), objectType);
            ConfigStoragePublic.SetConfig(EditorsStorageName, editorID, editController);
        }

        /// <summary>
        /// 获取默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        /// <returns>默认编辑控制器</returns>
        public static BaseEditController GetOrCreateDefaultEditController(Type objectType, Type editorType) {
            var editController = EditorPublic.GetDefaultEditController(objectType, editorType);
            if (editController == null) {
                editController = editorType.CreateInstance() as BaseEditController;
                EditorPublic.SetDefaultEditController(objectType, editController);
            }
            return editController;
        }
    }
}
