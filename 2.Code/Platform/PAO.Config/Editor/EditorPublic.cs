using DevExpress.XtraEditors.Repository;
using PAO.Config;
using PAO.Config.Controls;
using PAO.IO;
using PAO.UI;
using PAO.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 静态类：EditorPublic
    /// 编辑器公共类
    /// 作者：PAO
    /// </summary>
    public static class EditorPublic
    {
        #region 查找允许的编辑器类型
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

        #region ObjectLayoutEditControl
        /// <summary>
        /// 显示对象布局控件
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DialogReturn ShowObjectLayoutEditControl(object obj) {
            var objectType = obj.GetType();
            var editController = GetOrCreateEditControllerFromStorage<ObjectLayoutEditController>(objectType);
            var dataFieldEditControl = editController.CreateEditControl(objectType) as ObjectLayoutEditControl;
            dataFieldEditControl.EditValue = obj;
            var result = WinFormPublic.ShowDialog(dataFieldEditControl);
            if (result == DialogReturn.OK) {
            }

            return result;
        }
        #endregion

        #region 客户端存储
        public const string EditorsStorageName = "Editors";
        /// <summary>
        /// 获取编辑器ID
        /// </summary>
        private static string GetEditorID(Type editorType, Type objectType) {
            return String.Format("{0}_{1}", editorType.FullName, objectType.FullName);
        }

        /// <summary>
        /// 从客户端存储中默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        public static void RemoveEditControllerFromStorage(Type objectType, Type editorType) {
            string editorID = GetEditorID(editorType, objectType);
            ConfigStoragePublic.RemoveConfig(EditorsStorageName, editorID);
        }

        /// <summary>
        /// 从客户端存储中获取默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        /// <returns>默认编辑控制器</returns>
        public static BaseEditController GetEditControllerFromStorage(Type objectType, Type editorType) {
            string editorID = GetEditorID(editorType, objectType);
            return ConfigStoragePublic.GetConfig(EditorsStorageName, editorID) as BaseEditController;
        }

        /// <summary>
        /// 设置默认编辑控制器到客户端存储
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editController">默认编辑控制器</param>
        public static void SetEditControllerToStorage(Type objectType, BaseEditController editController) {
            string editorID = GetEditorID(editController.GetType(), objectType);
            ConfigStoragePublic.SetConfig(EditorsStorageName, editorID, editController);
        }

        /// <summary>
        /// 获取默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        /// <returns>默认编辑控制器</returns>
        public static BaseEditController GetOrCreateEditControllerFromStorage(Type objectType, Type editorType) {
            var editController = EditorPublic.GetEditControllerFromStorage(objectType, editorType);
            if (editController == null) {
                editController = editorType.CreateInstance() as BaseEditController;
                EditorPublic.SetEditControllerToStorage(objectType, editController);
            }
            return editController;
        }


        /// <summary>
        /// 获取默认的编辑控制器
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="editorType">编辑器类型</param>
        /// <returns>默认编辑控制器</returns>
        public static T GetOrCreateEditControllerFromStorage<T>(Type objectType) where T : BaseEditController {
            return (T)GetOrCreateEditControllerFromStorage(objectType, typeof(T));
        }
        #endregion

        #region 通过反射(EditorTypeAttribute)获取编辑器类型
        /// <summary>
        /// 获取某个成员的编辑器类型
        /// </summary>
        /// <param name="member">类型</param>
        /// <returns>编辑器类型</returns>
        public static Type GetEditorTypeByReflection(MemberInfo member) {
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
        public static Type GetEditorTypeByReflection(MemberDescriptor member) {
            var editorAttr = member.Attributes.GetAttribute<EditorTypeAttribute>();
            if (editorAttr != null && editorAttr.EditorType != null)
                return editorAttr.EditorType;

            return null;
        }
        #endregion

        #region 默认的编辑器类型

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

        #endregion

        #region 创建编辑器控件
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

        #region 获取或创建编辑器
        /// 通用获取或创建编辑器步骤：（BaseObjectEditController中）
        /// 1. 从BaseObjectEditController中的PredefinedEditors属性中获取编辑控制器；
        /// 2. 通过类或属性的EditorTypeAttribute获取编辑控制器类型；
        /// 3. 根据类型获取默认的编辑控制器；
        /// 4. 从客户端存储中获取编辑控制器的配置；
        /// 5. 创建编辑器；
        /// 
        /// 指定数据类型获取编辑器的步骤：
        /// 1. 通过类或属性的EditorTypeAttribute获取编辑控制器类型；
        /// 2. 根据类型获取默认的编辑控制器；
        /// 3. 从客户端存储中获取编辑控制器的配置；
        /// 4. 创建编辑器；
        /// 
        /// 指定编辑器类型创建编辑器的步骤：
        /// 1. 从客户端存储中获取编辑控制器的配置；
        /// 3. 创建编辑器；

        public static BaseEditController GetEditController(Type objectType) {
            BaseEditController editController = null;
            var editorType = EditorPublic.GetEditorTypeByReflection(objectType);
            if (editorType == null) {
                editorType = GetDefaultEditorType(objectType);
            }

            if (editorType == null)
                return null;

            editController = EditorPublic.GetEditControllerFromStorage(objectType, editorType);
            if (editController == null) {
                editController = editorType.CreateInstance() as BaseEditController;
                EditorPublic.SetEditControllerToStorage(objectType, editController);
            }
            return editController;
        }


        public static BaseEditController GetEditController(PropertyDescriptor propertyDescriptor) {
            BaseEditController editController = null;
            var editorType = EditorPublic.GetEditorTypeByReflection(propertyDescriptor);

            if (editorType == null) {
                editController = GetEditController(propertyDescriptor.PropertyType);
            }
            else {
                editController = editorType.CreateInstance() as BaseEditController;
                EditorPublic.SetEditControllerToStorage(propertyDescriptor.PropertyType, editController);
            }

            return editController;
        }

        #endregion
    }
}
