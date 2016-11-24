using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PAO {
    /// <summary>
    /// 静态类：ReflectionPublic
    /// 反射公共类
    /// 作者：PAO
    /// </summary>
    public static class ReflectionPublic {
        const string FullGenericTypeNameFormat = "{0}`1[[{2}]],{1}";
        const string GenericTypeNameFormat = "{0}`1[[{1}]]";
        const string TypeElmentTag = "Type";
        const string NullString = "NULL";
        /// <summary>
        /// 基础类型
        /// </summary>
        public static Type[] BasicType = new Type[] 
        {
            typeof(SByte)
            , typeof(Int16)
            , typeof(Int32)
            , typeof(Int64)
            , typeof(Byte)
            , typeof(UInt16)
            , typeof(UInt32)
            , typeof(UInt64)
            , typeof(Char)
            , typeof(Single)
            , typeof(Double)
            , typeof(Decimal)
            , typeof(String)
            , typeof(DateTime)
            , typeof(Boolean)
        };

        #region 类型
        public static Type GetType(string typeName) {
            Func<AssemblyName, Assembly> assemblyResolver = (name) =>
            {
                foreach (var asmb in AppDomain.CurrentDomain.GetAssemblies()) {
                    if (asmb.GetName().Name == name.Name)
                        return asmb;
                }
                return null;
            };
            Func<Assembly, string, bool, Type> typeResolver = (assembly, name, ignoreCase) =>
            {
                if (assembly != null)
                    return assembly.GetType(name, false, ignoreCase);

                // 从当前AppDomain中查找
                foreach (var asmb in AppDomain.CurrentDomain.GetAssemblies()) {
                    Type type = asmb.GetType(name);
                    if (type != null)
                        return type;
                }
                return null;
            };
            return Type.GetType(typeName, assemblyResolver, typeResolver, false);
        }

        /// <summary>
        /// 获取ref类型的原始类型
        /// </summary>
        /// <param name="refType">ref类型</param>
        /// <returns>如果是Ref类型，则原始类型；否则返回输入的类型。如输入String&类型，则返回String类型</returns>
        public static Type GetOriginalTypeByRef(Type refType) {
            if (refType.IsByRef) {
                string typeName = refType.FullName;
                return Type.GetType(typeName.Substring(0, typeName.Length - 1));
            } else {
                return refType;
            }
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="componentType">组件类型</param>
        /// <param name="parameters">构造方法参数</param>
        /// <returns>对象</returns>
        public static object CreateInstance(this Type componentType, params object[] parameters) {
            if (componentType.IsArray && parameters.IsNullOrEmpty()) {
                return Activator.CreateInstance(componentType, 0);
            }

            return Activator.CreateInstance(componentType, parameters);
        }
        /// <summary>
        /// 获取类型的全限定名称
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <param name="childTypeQualifiedNames">子类型全限定名称</param>
        /// <returns>全限定名称</returns>
        private static string GetFullGenericTypeNameString(string typeName
            , params string[] childTypeQualifiedNames) {
            if (childTypeQualifiedNames == null || childTypeQualifiedNames.Length == 0)
                return typeName;

            int childTypeCount = childTypeQualifiedNames.Length;
            string fullTypeName = typeName;
            fullTypeName += "`" + childTypeCount.ToString();

            string childTypeString = null;
            foreach (string childTypeQualifiedName in childTypeQualifiedNames) {
                if (childTypeString != null)
                    childTypeString += ",";

                childTypeString += "[" + childTypeQualifiedName + "]";
            }

            fullTypeName += "[" + childTypeString + "]";
            return fullTypeName;
        }

        /// <summary>
        /// 获取泛型类型
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="typeName">类名</param>
        /// <param name="childTypeQualifiedNames">泛型名称</param>
        /// <returns>泛型类型</returns>
        public static Type GetGenericType(string assemblyName
            , string typeName
            , params string[] childTypeQualifiedNames) {
            string fullTypeName = GetFullGenericTypeNameString(typeName, childTypeQualifiedNames) + "," + assemblyName;

            return Type.GetType(fullTypeName);
        }
        /// <summary>
        /// 获取泛型类型
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="typeName">类名</param>
        /// <param name="childTypeQualifiedNames">泛型名称</param>
        /// <returns>泛型类型</returns>
        public static Type GetGenericType(this Assembly assembly
            , string typeName
            , params string[] childTypeQualifiedNames) {
            string fullTypeName = GetFullGenericTypeNameString(typeName, childTypeQualifiedNames);
            return assembly.GetType(fullTypeName);
        }
        /// <summary>
        /// 判断类型是否数字
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>是否是数字类型</returns>
        public static bool IsNumberType(this Type type) {
            if (type == typeof(decimal)
                || type == typeof(Int16)
                || type == typeof(Int32)
                || type == typeof(Int64)
                || type == typeof(UInt16)
                || type == typeof(UInt32)
                || type == typeof(UInt64)
                || type == typeof(Byte)
                || type == typeof(SByte)
                || type == typeof(float)
                || type == typeof(double)) {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 判断类型是否整数
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>是否是整数类型</returns>
        public static bool IsIntegerType(this Type type) {
            if (type == typeof(Int16)
                || type == typeof(Int32)
                || type == typeof(Int64)
                || type == typeof(UInt16)
                || type == typeof(UInt32)
                || type == typeof(UInt64)
                || type == typeof(Byte)
                || type == typeof(SByte)) {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 是否为字典类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>是否字典类型</returns>
        public static bool IsDictionary(this Type type) {
            return type.FindInterface(typeof(IDictionary));
        }
        /// <summary>
        /// 是否可以枚举
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>是否枚举类型</returns>
        public static bool IsEnumerable(this Type type) {
            return type.FindInterface(typeof(IEnumerable));
        }
        /// <summary>
        /// 是否是集合类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>是否是集合类型</returns>
        public static bool IsCollection(this Type type) {
            return type.FindInterface(typeof(ICollection));
        }

        /// <summary>
        /// 获取元素类型
        /// </summary>
        /// <param name="collectionType">集合类型</param>
        /// <returns>集合中元素类型</returns>
        public static Type GetElementType(this Type collectionType) {
            if (collectionType.IsArray) {
                return collectionType.GetElementType();
            }

            foreach (var interfaceType in collectionType.GetInterfaces()) {
                if (interfaceType.IsDerivedFrom(typeof(IDictionary<,>))) {
                    return interfaceType.GetGenericArguments()[1];
                }
            }

            foreach (var interfaceType in collectionType.GetInterfaces()) {
                if (interfaceType.IsDerivedFrom(typeof(IEnumerable<>))) {
                    return interfaceType.GetGenericArguments()[0];
                }
            }
            return typeof(object);
        }

        /// <summary>
        /// 获取显示名称
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>显示名称</returns>
        public static string GetDisplayName(this Type type) {
            var nameAttr = type.GetAttribute<DisplayNameAttribute>(true);
            if (nameAttr != null)
                return nameAttr.DisplayName;

            return type.Name;
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>描述</returns>
        public static string GetDescription(this Type type) {
            var descAttr = type.GetAttribute<DescriptionAttribute>(true);
            if (descAttr != null)
                return descAttr.Description;

            return type.FullName;
        }

        /// <summary>
        /// 是否是指定類別
        /// </summary>
        /// <param name="type">類別</param>
        /// <param name="parameters">參數數組,第一個參數就是指定類別</param>
        /// <returns>如果是指定類別,返回true,否則返回false.</returns>
        public static bool IsType(this Type type, Type baseType) {
            if (type == baseType)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 類別是否實現了某個接口
        /// </summary>
        /// <param name="type">類別</param>
        /// <param name="interfaceTypeFullName">接口类型名称</param>
        /// <returns>如果是否實現了某個接口,返回true,否則返回false.</returns>
        public static bool FindInterface(this Type type, string interfaceTypeFullName) {
            if (type.GetInterfaces().FirstOrDefault(p =>
            {
                return p.FullName == interfaceTypeFullName;
            }) == null)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 類別是否實現了某個接口
        /// </summary>
        /// <param name="type">類別</param>
        /// <param name="interfaceType">接口类型</param>
        /// <returns>如果是否實現了某個接口,返回true,否則返回false.</returns>
        public static bool FindInterface(this Type type, Type interfaceType) {
            if (type.GetInterfaces().FirstOrDefault(p =>
            {
                return p == interfaceType || (p.IsGenericType && p.GetGenericTypeDefinition() == interfaceType);
            }) == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 是否从父类继承
        /// </summary>
        /// <param name="testType">待测试类类型</param>
        /// <param name="parentType">父类</param>
        /// <returns>是否从父类继承</returns>
        public static bool IsDerivedFrom(this Type testType, Type parentType) {
            return testType == parentType
                || (testType.IsGenericType && parentType != null && parentType.IsAssignableFrom(testType.GetGenericTypeDefinition()))
                || parentType.IsAssignableFrom(testType)
                || testType.FindInterface(parentType);
        }

        /// <summary>
        /// 是否是指定類別
        /// </summary>
        /// <param name="type">類別</param>
        /// <typeparam name="T">指定類別</typeparam>
        /// <returns>如果是指定類別,返回true,否則返回false.</returns>
        public static bool IsType<T>(this Type type) {
            if (type == typeof(T))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否枚举类型
        /// </summary>
        /// <param name="type">要判断的类型</param>
        /// <param name="elmentType">枚举元素类型</param>
        /// <returns>如果是某个指定元素类型的枚举类型返回true，否则返回false</returns>
        public static bool IsEnumerableOf(this Type type, Type elmentType) {
            if (type.IsGenericType
                && type.GetGenericTypeDefinition().IsDerivedFrom(typeof(IEnumerable<>))
                && type.GetGenericArguments()[0].IsDerivedFrom(elmentType))
                return true;

            return false;
        }

        /// <summary>
        /// 是否字典类型
        /// </summary>
        /// <param name="type">要判断的类型</param>
        /// <param name="elmentType">字典元素类型</param>
        /// <returns>如果是某个指定元素类型的字典类型返回true，否则返回false</returns>
        public static bool IsDictionaryOf(this Type type, Type elmentType) {
            if (type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(IDictionary<,>)
                && type.GetGenericArguments()[1].IsDerivedFrom(elmentType))
                return true;

            return false;
        }

        /// <summary>
        /// 是否是指定類別的子類
        /// </summary>
        /// <param name="type">類別</param>
        /// <param name="parameters">參數數組,第一個參數就是指定類別</param>
        /// <returns>如果是指定類別的子類,返回true,否則返回false.</returns>
        public static bool IsSubClassOf(this Type type, Type baseType) {
            if (type.IsSubclassOf(baseType))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否是指定類別的子類
        /// </summary>
        /// <param name="testType">類別</param>
        /// <typeparam name="T">指定類別</typeparam>
        /// <returns>如果是指定類別的子類,返回true,否則返回false.</returns>
        public static bool IsSubClassOf<T>(this Type testType) {
            if (testType.IsSubclassOf(typeof(T)))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 類別是否實現了某個接口
        /// </summary>
        /// <param name="type">類別</param>
        /// <typeparam name="T">接口類別</typeparam>
        /// <returns>如果是否實現了某個接口,返回true,否則返回false.</returns>
        public static bool FindInterface<T>(this Type type) {
            return FindInterface(type, typeof(T).FullName);
        }


        /// <summary>
        /// 類別是否擁有某個特性
        /// </summary>
        /// <param name="type">類別</param>
        /// <param name="parameters">參數數組,第一個參數就是特性的類別</param>
        /// <returns>如果類別擁有某個特性,返回true,否則返回false.</returns>
        public static bool AttributeInType(this Type type, Type attributeType) {
            if (type.GetCustomAttributes(attributeType, false).Length == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 類別是否擁有某個特性
        /// </summary>
        /// <param name="type">類別</param>
        /// <typeparam name="T">指定特性類別</typeparam>
        /// <returns>如果類別擁有某個特性,返回true,否則返回false.</returns>
        public static bool AttributeInType<T>(this Type type) where T : Attribute {
            if (type.GetCustomAttributes(typeof(T), false).Length == 0)
                return false;
            else
                return true;
        }
        #endregion

        #region 程序集
        /// <summary>
        /// 查找类型
        /// </summary>
        /// <param name="assemblies">程序集列表</param>
        /// <param name="findMethod">查找条件</param>
        /// <returns>类型列表</returns>
        public static List<Type> FindTypes(
            this IEnumerable<Assembly> assemblies
            , Predicate<Type> findMethod) {
            List<Type> typeList = new List<Type>();
            foreach (Assembly assembly in assemblies) {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types) {
                    if (findMethod != null && findMethod(type)) {
                        typeList.Add(type);
                    }
                }
            }
            return typeList;
        }

        /// <summary>
        /// 查找类别
        /// </summary>
        /// <param name="assemblies">程序集列表</param>
        /// <param name="findMethod">查找条件</param>
        /// <returns>类型列表</returns>
        public static List<Type> FindTypes(
            this IEnumerable<Assembly> assemblies,
            Predicate<Assembly> assemblyFindMethod
            , Predicate<Type> typeFindMethod) {
            System.Diagnostics.Debug.Assert(assemblies != null);

            List<Type> typeList = new List<Type>();
            foreach (Assembly assembly in assemblies) {
                if (assemblyFindMethod == null || assemblyFindMethod(assembly)) {
                    foreach (Type type in assembly.GetTypes()) {
                        if (typeFindMethod == null || typeFindMethod(type)) {
                            typeList.Add(type);
                        }
                    }
                }
            }
            return typeList;
        }

        #endregion

        #region 检查

        /// <summary>
        /// 檢查類是否是某個類的子類
        /// </summary>
        /// <param name="testType">类型</param>
        /// <param name="errorMessage">异常消息</param>
        /// <param name="extendParameters">异常扩展参数</param>
        public static void CheckBaseType<T>(this Type testType, string errorMessage, params object[] extendParameters) {
            System.Diagnostics.Debug.Assert(testType != null);
            if (!testType.IsSubclassOf(typeof(T)))
                throw new Exception(errorMessage);
        }

        /// <summary>
        /// 檢查類是否是某個類的子類
        /// </summary>
        /// <param name="testType">类型</param>
        public static void CheckBaseType<T>(this Type testType) {
            CheckBaseType<T>(testType, "Type is not a child.");
        }

        /// <summary>
        /// 檢查對象是否為某個類別
        /// </summary>
        /// <param name="testObject">对象</param>
        /// <param name="errorMessage">异常消息</param>
        /// <param name="extendParameters">异常扩展参数</param>
        public static void CheckType<T>(this object testObject, string errorMessage) {
            if (!(testObject is T))
                throw new Exception(errorMessage);
        }

        /// <summary>
        /// 檢查對象是否為某個類別
        /// </summary>
        /// <param name="testObject">对象</param>
        public static void CheckType<T>(this object testObject) {
            CheckType<T>(testObject, "Object type is not matched.");
        }

        /// <summary>
        /// 检查是否从父类继承
        /// </summary>
        /// <param name="testType">待测试类类型</param>
        /// <param name="parentType">父类</param>
        public static void CheckTypeDerivedFrom(this Type testType, Type parentType) {
            System.Diagnostics.Debug.Assert(testType != null);
            System.Diagnostics.Debug.Assert(parentType != null);
            if(!IsDerivedFrom(testType, parentType))
                throw new Exception("Check Type Derived From Error.");
        }
        #endregion

        #region 特性
        /// <summary>
        /// 查找程序集的特性
        /// </summary>
        /// <param name="assemblies">程序集列表</param>
        /// <param name="findMethod">查找条件</param>
        /// <returns>特性列表</returns>
        public static List<Attribute> FindAssemblyAttributes(
            this IEnumerable<Assembly> assemblies, Predicate<Attribute> findMethod) {
            List<Attribute> attributeList = new List<Attribute>();
            foreach (Assembly assembly in assemblies) {
                object[] attributes = assembly.GetCustomAttributes(false);
                foreach (Attribute attribute in attributes) {
                    if (findMethod != null && findMethod(attribute)) {
                        attributeList.Add(attribute);
                    }
                }
            }
            return attributeList;
        }
        /// <summary>
        /// 查找程序集中某个类型的特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="assemblies">程序集列表</param>
        /// <returns>特性列表</returns>
        public static List<T> FindAssemblyAttributes<T>(this IEnumerable<Assembly> assemblies)
            where T : Attribute {
            List<Attribute> attributeList = FindAssemblyAttributes(assemblies, delegate(Attribute attribute)
            {
                if (attribute.GetType() == typeof(T))
                    return true;

                return false;
            });
            List<T> typedAttributeList = new List<T>();
            foreach (T attribute in attributeList) {
                typedAttributeList.Add(attribute);
            }

            return typedAttributeList;
        }
        /// <summary>
        /// 成员是否拥有某个特性
        /// </summary>
        /// <param name="memberInfo">成员信息</param>
        /// <param name="attributeType">特性类型</param>
        /// <param name="inherit">是否考虑继承</param>
        /// <returns>成员是否拥有某个特性</returns>
        public static bool HasAttribute(this MemberInfo memberInfo, Type attributeType, bool inherit) {
            Attribute[] attributes = (Attribute[])memberInfo.GetCustomAttributes(attributeType, inherit);
            if (attributes.IsNullOrEmpty())
                return false;
            return true;
        }

        /// <summary>
        /// 成员是否拥有某个特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="memberInfo">成员信息</param>
        /// <param name="inherit">是否考虑继承</param>
        /// <returns>成员是否拥有某个特性</returns>
        public static bool HasAttribute<T>(this MemberInfo memberInfo, bool inherit)
            where T : Attribute {
            return HasAttribute(memberInfo, typeof(T), inherit);
        }

        /// <summary>
        /// 获取某个类型的第一个特性
        /// </summary>
        /// <param name="memberInfo">成员信息</param>
        /// <param name="attributeType">特性类型</param>
        /// <param name="inherit">是否考虑继承</param>
        /// <returns>第一个特性</returns>
        public static Attribute GetAttribute(this MemberInfo memberInfo, Type attributeType, bool inherit) {
            Attribute[] attributes = (Attribute[])memberInfo.GetCustomAttributes(attributeType, inherit);
            if (attributes.IsNullOrEmpty())
                return null;
            return attributes[0];
        }
        /// <summary>
        /// 获取特性列表
        /// </summary>
        /// <param name="memberInfo">成员信息</param>
        /// <param name="attributeType">特性类型</param>
        /// <param name="inherit">是否考虑继承</param>
        /// <returns>特性列表</returns>
        public static Attribute[] GetAttributes(this MemberInfo memberInfo, Type attributeType, bool inherit) {
            Attribute[] attributes = (Attribute[])memberInfo.GetCustomAttributes(attributeType, inherit);

            return attributes;
        }

        /// <summary>
        /// 获取某个类型的第一个特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="memberInfo">成员信息</param>
        /// <param name="inherit">是否考虑继承</param>
        /// <returns>第一个特性</returns>
        public static T GetAttribute<T>(this MemberInfo memberInfo, bool inherit)
            where T : Attribute {
            return (T)GetAttribute(memberInfo, typeof(T), inherit);
        }
        /// <summary>
        /// 获取特性列表
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="memberInfo">成员信息</param>
        /// <param name="inherit">是否考虑继承</param>
        /// <returns>特性列表</returns>
        public static T[] GetAttributes<T>(this MemberInfo memberInfo, bool inherit)
            where T : Attribute {
            return (T[])GetAttributes(memberInfo, typeof(T), inherit);
        }

        /// <summary>
        /// 获取某个特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="attributes">特性列表</param>
        /// <returns>特性</returns>
        public static T GetAttribute<T>(this AttributeCollection attributes) where T : Attribute {
            foreach (var attribute in attributes) {
                if (attribute is T) {
                    return attribute as T;
                }
            }

            return default(T);
        }
        #endregion 特性
    }
}
