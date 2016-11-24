using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace PAO {
    /// <summary>
    /// 静态类：ObjectPublic
    /// 对象公共类，内含对象相关的公共方法
    /// 作者：PAO
    /// </summary>
    public static class ObjectPublic {
        #region 空值判断
        /// <summary>
        /// 对象是否为空
        /// </summary>
        /// <param name="testObject">待测试对象</param>
        /// <returns>对象为空返回True，否则返回False</returns>
        public static bool IsNull(this object testObject) {
            return IsNullOrEmpty(testObject, NothingType.Nullable);
        }

        /// <summary>
        /// 对象是否为空
        /// </summary>
        /// <param name="testObject">待测试对象</param>
        /// <param name="nothingType">空对象类型</param>
        /// <returns>对象为空返回True，否则返回False</returns>
        public static bool IsNullOrEmpty(this object testObject, NothingType nothingType = NothingType.All) {
            // 对引用判断
            if ((int)(nothingType & NothingType.Reference) != 0) {
                if (testObject == null)
                    return true;
            }

            // 对DBNull的判断
            if ((int)(nothingType & NothingType.DBNull) != 0) {
                if (testObject == Convert.DBNull)
                    return true;
            }

            // 对List的判断
            if ((int)(nothingType & NothingType.List) != 0) {
                if (testObject is ICollection && (testObject as ICollection).Count == 0)
                    return true;
            }

            // 对String的判断
            if ((int)(nothingType & NothingType.String) != 0) {
                if (testObject is string && (testObject as string) == String.Empty)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 如果测试对象为空，则返回一个默认对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="testObject">测试对象</param>
        /// <param name="objectForNothing">对象为空时返回的默认对象</param>
        /// <param name="nothingType">空对象类型</param>
        /// <returns>如果对象为空，返回一个默认对象；否则，返回对象本身</returns>
        public static T IfNothing<T>(this T testObject, T objectForNothing , NothingType nothingType = NothingType.All) {
            if (IsNullOrEmpty(testObject, nothingType))
                return objectForNothing;

            return testObject;
        }


        #endregion

        #region 对错检查
        /// <summary>
        /// 检查布尔变量是否为True
        /// </summary>
        /// <param name="boolValue">布尔变量</param>
        /// <param name="message">如果不为True，抛出的异常信息</param>
        /// <param name="extendParameters">扩展信息</param>
        public static void CheckTrue(this bool boolValue, string message) {
            if (!boolValue)
                throw new Exception(message);
        }

        /// <summary>
        /// 检查布尔变量是否为False
        /// </summary>
        /// <param name="boolValue">布尔变量</param>
        /// <param name="message">如果不为False，抛出的异常信息</param>
        /// <param name="extendParameters">异常扩展信息</param>
        public static void CheckFalse(this bool boolValue, string message) {
            CheckTrue(!boolValue, message);
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        public static void CheckNullOrEmpty(this object testObject) {
            CheckNullOrEmpty(testObject, "Object is null or empty.");
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        /// <param name="message">如果对象为空，抛出的异常信息</param>
        /// <param name="extendParamters">异常扩展信息</param>
        public static void CheckNullOrEmpty(this object testObject, string message) {
            if (!testObject.IsNullOrEmpty())
                throw new Exception(message);
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        public static void CheckNull(this object testObject) {
            CheckNull(testObject, "Object is null.");
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        /// <param name="message">如果对象为空，抛出的异常信息</param>
        /// <param name="extendParamters">异常扩展信息</param>
        public static void CheckNull(this object testObject, string message) {
            if (!testObject.IsNullOrEmpty(NothingType.Nullable))
                throw new Exception(message);
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        /// <returns>如果对象为DBNull或者为null则返回true,否则返回false</returns>
        public static void CheckNotNullOrEmpty(this object testObject) {
            CheckNotNullOrEmpty(testObject, "Object is null or empty.");
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        /// <returns>如果对象为DBNull或者为null则返回true,否则返回false</returns>
        /// <param name="message">如果对象不为空，抛出的异常信息</param>
        /// <param name="extendParamters">异常扩展信息</param>
        public static void CheckNotNullOrEmpty(this object testObject, string message) {
            if (testObject.IsNullOrEmpty())
                throw new Exception(message);
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        /// <returns>如果对象为DBNull或者为null则返回true,否则返回false</returns>
        public static void CheckNotNull(this object testObject) {
            CheckNotNull(testObject, "Object is null.");
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="testObject">测试对象</param>
        /// <returns>如果对象为DBNull或者为null则返回true,否则返回false</returns>
        /// <param name="message">如果对象不为空，抛出的异常信息</param>
        /// <param name="extendParamters">异常扩展信息</param>
        public static void CheckNotNull(this object testObject, string message) {
            if (testObject.IsNull())
                throw new Exception(message);
        }
        #endregion

        #region 类型转换
        /// <summary>
        /// 获取实例
        /// 如果是代理对象，则获取其OriginalObject，然后转换类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="originalObject">原始对象</param>
        /// <returns>实例或者是代理对象的原始实例</returns>
        public static T As<T>(this object originalObject) {
            if (originalObject is T)
                return (T)originalObject;

            return default(T);
        }
        #endregion

        #region 获取/设置属性
        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">成员名称</param>
        /// <returns>成员值</returns>
        public static object GetMemberValue(this object obj, string propertyName) {
            return GetMemberValue<object>(obj, propertyName);
        }

        /// <summary>
        /// 获取成员值
        /// 如果能找到相应属性，返回属性值，
        /// 如果能找到相应字段，返回字段值
        /// 如果是字典，则根据键查找值，
        /// 如果是DataRow，则获取列的值，
        /// 否则，报错
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性</param>
        /// <returns>属性值</returns>
        public static T GetMemberValue<T>(this object obj, string propertyName) {
            if (obj.IsNullOrEmpty(NothingType.Nullable) || propertyName.IsNullOrEmpty())
                return default(T);

            var objType = obj.GetType();
            var property = objType.GetProperty(propertyName);
            if (property != null) {
                try {
                    return property.GetValue(obj, null).As<T>();
                } catch {
                    return default(T);
                }
            } else {
                var field = objType.GetField(propertyName);
                if (field != null) {
                    try {
                        return field.GetValue(obj).As<T>();
                    } catch {
                        return default(T);
                    }
                }
            }
            // 获取索引器属性
            PropertyInfo thisMember = objType.GetProperty("Item", typeof(string));
            if (thisMember != null) {
                return thisMember.GetValue(obj
                    , new object[] { propertyName }).As<T>();
            }
            if (obj is IDictionary) {
                var dict = obj.As<IDictionary>();
                if (!dict.Contains(propertyName))
                    return default(T);

                return dict[propertyName].As<T>();
            } 
            
            if (obj is DataRow) {
                var dataRow = obj.As<DataRow>();
                if (!dataRow.Table.Columns.Contains(propertyName))
                    throw new Exception("数据行中找不到指定的列").AddDetail("ColumnName", propertyName);
                if (dataRow.IsNull(propertyName))
                    return default(T);
                return dataRow[propertyName].As<T>();
            }

            throw new Exception("找不到指定的成员")
                .AddDetail("Type", objType)
                .AddDetail("MemberName", propertyName);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyValue">属性值</param>
        /// <returns>返回obj</returns>
        public static T SetMemberValue<T>(this T obj, string propertyName, object propertyValue) {
            if (obj.IsNullOrEmpty(NothingType.Nullable) || propertyName.IsNullOrEmpty())
                return obj;

            Type objType = obj.GetType();
            var property = objType.GetProperty(propertyName);
            if (property != null) {
                property.SetValue(obj, propertyValue, null);
                return obj;
            } else {
                var field = objType.GetField(propertyName);
                if (field != null) {
                    field.SetValue(obj, propertyValue);
                    return obj;
                }
            }
            // 设置索引器属性
            PropertyInfo thisMember = objType.GetProperty("Item", typeof(string));
            if (thisMember != null) {
                thisMember.SetValue(obj
                    , propertyValue
                    , new object[] { propertyName });
                return obj;
            }
            if (obj is IDictionary) {
                var dict = obj.As<IDictionary>();
                if (!dict.Contains(propertyName))
                    dict.Add(propertyValue, propertyValue);
                else
                    dict[propertyName] = propertyValue;
                return obj;
            }
            
            if (obj is DataRow) {
                var dataRow = obj.As<DataRow>();
                if (!dataRow.Table.Columns.Contains(propertyName))
                    throw new Exception("数据行中找不到指定的列").AddDetail("ColumnName", propertyName);

                dataRow[propertyName] = propertyValue;
            }
            return obj;
        }
        #endregion

        #region ToString
        /// <summary>
        /// 将对象转换为字符串
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns>详细的异常字符串</returns>
        public static string ObjectToString(this Exception exception) {
            var exceptionMessage = exception.ToString();
            var detailMessage = "详细信息：\r\n";
            foreach (var dataItem in exception.Data.Keys) {
                detailMessage += String.Format("\t[{0}]: {1}", dataItem, exception.Data[dataItem]);
            }
            var fullMessage = String.Format("异常类型：{0}\r\n异常信息：{1}\r\n{2}\r\n------------------------------\r\n{3}"
                , exception.GetType().FullName
                , exception.Message
                , detailMessage, exception);
            return fullMessage;
        }

        /// <summary>
        /// 将对象转化为字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="properties">要显示的属性</param>
        /// <returns>对象字符串</returns>
        public static String ObjectToString(this object obj, string objString = null, params string[] properties) {
            if (obj == null)
                return null;

            var displayString = objString;
            if (displayString.IsNullOrEmpty()) {
                displayString = obj.GetType().Name;
                DisplayNameAttribute displayNameAttrib = obj.GetType().GetAttribute<DisplayNameAttribute>(true);
                if (displayNameAttrib != null)
                    displayString = displayNameAttrib.DisplayName;
            }

            string propertyString = null;
            foreach (var property in properties) {
                if (property == null)
                    continue;

                var value = obj.GetMemberValue(property);
                if (value == null)
                    continue;

                if (propertyString.IsNullOrEmpty())
                    propertyString += ",";

                var prop = obj.GetType().GetProperty(property);
                var propNameAttr = prop.GetAttribute<DisplayNameAttribute>(true);

                propertyString += String.Format("{0}={1}", propNameAttr==null?property:propNameAttr.DisplayName, value);
            }

            return string.Format("{0}{1}", displayString
                , propertyString.IsNullOrEmpty() ? "" : String.Format("[{0}]", propertyString));
        }
        #endregion

        #region 初始化简化方法
        /// <summary>
        /// 添加数据细节
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static T AddDetail<T>(this T exception, string key, object value) where T : Exception {
            exception.Data.Add(key, value);
            return exception;
        }

        /// <summary>
        /// 添加元素到字典
        /// </summary>
        /// <param name="dict">字典</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>字典</returns>
        public static Dictionary<K, V> Append<K, V>(this Dictionary<K, V> dict, K key, V value) {
            dict.Add(key, value);
            return dict;
        }

        /// <summary>
        /// 添加元素到字典
        /// </summary>
        /// <param name="dict">字典</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>字典</returns>
        public static Dictionary<K, V> Append<K, V>(this Dictionary<K, V> dict, IEnumerable<KeyValuePair<K, V>> elements) {
            foreach (KeyValuePair<K, V> element in elements) {
                dict.Add(element.Key, element.Value);
            }
            return dict;
        }

        /// <summary>
        /// 添加元素到列表
        /// </summary>
        /// <param name="list">列表</param>
        /// <param name="elements">元素</param>
        /// <returns>列表</returns>
        public static List<T> Append<T>(this List<T> list, params T[] elements) {
            foreach (T element in elements) {
                list.Add(element);
            }
            return list;
        }

        /// <summary>
        /// 添加元素到列表
        /// </summary>
        /// <param name="list">列表</param>
        /// <param name="elements">元素</param>
        /// <returns>列表</returns>
        public static List<T> Append<T>(this List<T> list, IEnumerable<T> elements) {
            if (elements.IsNullOrEmpty())
                return list;

            foreach (T element in elements) {
                list.Add(element);
            }
            return list;
        }
        #endregion
    }
}
