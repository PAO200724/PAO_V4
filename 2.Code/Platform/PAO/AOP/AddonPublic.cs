using PAO.App;
using PAO.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace PAO {
    /// <summary>
    /// 静态类:AddonPublic
    /// 插件公共类
    /// 作者:PAO
    /// </summary>
    public static class AddonPublic {
        #region 插件类型判断
        /// <summary>
        /// 判断是否为插件类型
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <returns>如果类型用AddonAttribute修饰，返回true，否则返回false</returns>
        public static bool IsAddonType(this Type objType) {
            if (objType.HasAttribute<AddonAttribute>(true))
                return true;

            return false;
        }

        /// <summary>
        /// 判断是否为插件枚举类型
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <returns>如果是插件枚举或者插件数组，返回true，否则返回false</returns>
        public static bool IsAddonListType(this Type objType) {
            if(objType.IsGenericType 
                && objType.IsDerivedFrom(typeof(IList<>)) 
                && objType.GetGenericArguments()[0].IsAddon()) {
                return true;
            }

            if (objType.IsArray
                && objType.GetElementType().IsAddon()) {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 判断是否为插件字典类型
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <returns>如果是插件字典，返回true，否则返回false</returns>
        public static bool IsAddonDictionaryType(this Type objType) {
            if (objType.IsGenericType
                && objType.IsDerivedFrom(typeof(IDictionary<,>))
                && objType.GetGenericArguments()[0] == typeof(string)
                && objType.GetGenericArguments()[1].IsAddon()) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 判断是否为插件类型
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <returns>如果是插件类、插件列表类或插件字典类，返回true，否则返回false</returns>
        public static bool IsAddon(this Type objType) {
            if (IsAddonType(objType) || IsAddonListType(objType) || IsAddonDictionaryType(objType)) {
                return true;
            }
            return false;
        }
        #endregion

        #region 插件类型列表
        /// <summary>
        /// 插件对象类型列表
        /// </summary>
        public static List<Type> AddonTypeList = new List<Type>();

        public static void RebuildAddonTypeList() {
            AddonTypeList = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                foreach (var type in assembly.GetTypes()) {
                    if (type.HasAttribute<AddonAttribute>(true)) {
                        AddonTypeList.Add(type);
                        EventPublic.Information("插件加载：{0}", type);
                    }
                }
            }
        }
        #endregion

        #region 插件类型检索
        const string AssemblyPattern = "PAO.*.dll";

        /// <summary>
        /// 程序集过滤器
        /// </summary>
        public static Func<Assembly, bool> AssemblyFilter = (p) =>
        {
            return p.FullName.StartsWith("PAO");
        };

        /// <summary>
        /// 添加文件的元件集到插件类型列表
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="includeSubDir">是否包含子目录，默认为True</param>
        public static Assembly AddFile(string file) {
            // 此处不能使用LoadFrom，因为KF.Base冲突
            EventPublic.Information("开始加载插件文件:{0}", file);
            try {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(file);
                var assembly = AppDomain.CurrentDomain.Load(assemblyName);
                EventPublic.Information("插件文件加载完毕:{0}", file);
                return assembly;
            } catch (Exception err) {
                // 加载文件时记录异常，不报错
                EventPublic.Exception(err);
                return null;
            }
        }

        /// <summary>
        /// 添加目录中的元件集到插件类型列表
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="includeSubDir">是否包含子目录，默认为True</param>
        public static void AddDirectory(string dir, bool includeSubDir = true) {
            EventPublic.Information("开始加载插件目录:{0}", dir);
            var files = Directory.GetFiles(dir, AssemblyPattern, includeSubDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (var file in files) {
                AddFile(file);
            }
            EventPublic.Information("插件目录加载完毕:{0}", dir);
        }


        /// <summary>
        /// 遍历插件，检索插件以及子插件，并将这些插件放入addonList
        /// </summary>
        /// <param name="addonList">插件列表</param>
        /// <param name="rootObj">根插件</param>
        public static void TraverseAddon(Dictionary<string, PaoObject> addonList, PaoObject rootObj) {
            if (rootObj == null)
                return;

            // 如果已经存在此插件，则直接返回
            if (addonList.ContainsKey(rootObj.ID))
                return;

            addonList.Add(rootObj.ID, rootObj);

            var properties = TypeDescriptor.GetProperties(rootObj
                , new Attribute[] { new DisplayNameAttribute(), new DescriptionAttribute(), new DataMemberAttribute() });
            foreach (PropertyDescriptor property in properties) {
                // 获取属性值，然后根据属性值的状况查找子插件
                object propertyValue = null;
                try {
                    propertyValue = property.GetValue(rootObj);
                }
                catch (Exception err) {
                    EventPublic.Exception(err);
                }

                if (propertyValue == null)
                    continue;

                var propertyType = propertyValue.GetType();
                // 跳过值类型和字符串
                if (propertyType.IsValueType || propertyType == typeof(string)) {
                    continue;
                }

                if (propertyValue is PaoObject) {
                    // 插件属性
                    TraverseAddon(addonList, propertyValue as PaoObject);
                }
                else if (propertyValue is IDictionary) {
                    // 处理字典
                    var dict = propertyValue as IDictionary;
                    foreach (object key in dict.Keys) {
                        object element = dict[key];
                        if (element == null) {
                            continue;
                        }

                        if (element is PaoObject) {
                            TraverseAddon(addonList, element as PaoObject);
                        }
                    }
                }
                else if (propertyValue is IEnumerable) {
                    // 跳过基础类型数组，避免过长的循环
                    var elementType = propertyType.GetElementType();
                    if (propertyType.IsArray && (elementType.IsValueType || elementType == typeof(string)))
                        continue;

                    // 处理列表
                    foreach (object element in propertyValue as IEnumerable) {
                        if (element == null) {
                            continue;
                        }

                        if (element is PaoObject) {
                            TraverseAddon(addonList, element as PaoObject);
                        }
                    }
                }
            }
        }
        #endregion

        #region 插件属性路径
        /// <summary>
        /// 用键值对的方式来设置属性
        /// </summary>
        /// <param name="originalObject">对象</param>
        /// <param name="path">属性名称</param>
        /// <returns>值</returns>
        public static object GetPropertyValueByPath(this object originalObject, string path) {
            originalObject.CheckNotNull("原始对象不能为空");
            Debug.Assert(!path.IsNullOrEmpty());

            // 通过"."来分割属性
            string[] properties = path.Split(new char[] { '.' }, 2);

            Type type = originalObject.GetType();
            string propertyName = properties[0];

            object propertyValue = null;

            if (originalObject is IDictionary) {
                propertyValue = ((IDictionary)originalObject)[propertyName];
            }
            else if (originalObject is IList
              && type.IsGenericType && type.GetGenericArguments()[0].IsDerivedFrom(typeof(PaoObject))) {
                // 资产列表
                foreach (PaoObject asset in originalObject as IEnumerable) {
                    if (asset != null && asset.ID == propertyName) {
                        propertyValue = asset;
                        break;
                    }
                }
            }
            else if (originalObject is IList) {
                // 设置列表元素值
                int index = Convert.ToInt32(propertyName);
                propertyValue = ((IList)originalObject)[index];
            }
            else {
                // 设置属性值
                PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Instance);
                if (propertyInfo != null) {
                    propertyValue = propertyInfo.GetValue(originalObject, null);
                }
                else {
                    FieldInfo fieldInfo = type.GetField(propertyName, BindingFlags.Public | BindingFlags.GetField | BindingFlags.SetField);
                    if (fieldInfo == null)
                        throw new Exception("在对象中找不到指定的属性").AddExceptionData("类型", type).AddExceptionData("属性", propertyName);
                    propertyValue = fieldInfo.GetValue(originalObject);
                }
            }

            if (properties.Length == 1) {
                // 如果是最后一个"."
                return propertyValue;
            }
            if (propertyValue != null) {
                return GetPropertyValueByPath(propertyValue, properties[1]);
            }
            return null;
        }

        /// <summary>
        /// 用键值对的方式来设置属性
        /// </summary>
        /// <param name="originalObject">对象</param>
        /// <param name="path">属性名称</param>
        /// <param name="value">值</param>
        public static void SetPropertyValueByPath(this object originalObject, string path, object value) {
            originalObject.CheckNotNull("原始对象不能为空");
            Debug.Assert(!path.IsNullOrEmpty());

            // 通过"."来分割属性
            string[] properties = path.Split(new char[] { '.' }, 2);

            Type type = originalObject.GetType();
            string propertyName = properties[0];
            object childObject = null;

            if (type.IsDerivedFrom(typeof(IDictionary))) {
                if (properties.Length == 1) {
                    // 设置字典值
                    ((IDictionary)originalObject)[propertyName] = value;
                }
                else {
                    childObject = ((IDictionary)originalObject)[propertyName];
                }
            }
            else if (originalObject is IList
              && type.IsGenericType && type.GetGenericArguments()[0].IsDerivedFrom(typeof(PaoObject))) {
                // 资产列表
                IList list = originalObject as IList;
                for (int i = 0; i < list.Count; i++) {
                    PaoObject asset = list[i] as PaoObject;
                    if (asset != null && asset.ID == propertyName) {
                        if (properties.Length == 1) {
                            // 设置值
                            list[i] = value;
                        }
                        else {
                            childObject = list[i];
                        }
                    }
                }
            }
            else if (type.IsDerivedFrom(typeof(IList))) {
                // 设置列表元素值
                int index = Convert.ToInt32(propertyName);
                if (properties.Length == 1) {
                    // 设置值
                    ((IList)originalObject)[index] = value;
                }
                else {
                    childObject = ((IList)originalObject)[index];
                }
            }
            else {
                // 设置属性值
                PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Instance);
                if (propertyInfo != null) {
                    if (properties.Length == 1) {
                        // 如果是最后一个"."，则设置属性
                        propertyInfo.SetValue(originalObject, value, null);
                    }
                    else {
                        childObject = propertyInfo.GetValue(originalObject, null);
                    }
                }
                else {
                    FieldInfo fieldInfo = type.GetField(propertyName, BindingFlags.Public | BindingFlags.GetField | BindingFlags.SetField);
                    if (fieldInfo == null)
                        throw new Exception("在对象中找不到指定的属性").AddExceptionData("类型", type).AddExceptionData("属性", propertyName);

                    if (properties.Length == 1) {
                        // 如果是最后一个"."，则设置属性
                        fieldInfo.SetValue(originalObject, value);
                    }
                    else {
                        childObject = fieldInfo.GetValue(originalObject);
                    }
                }
            }


            if (childObject != null) {
                SetPropertyValueByPath(childObject, properties[1], value);
            }
        }
        #endregion
    }
}
