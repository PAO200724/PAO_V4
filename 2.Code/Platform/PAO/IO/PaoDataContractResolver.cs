using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace PAO.IO {
    /// <summary>
    /// 类:PaoDataContractResolver
    /// 数据协议获取器
    /// 作者:PAO
    /// </summary>
    public class PaoDataContractResolver : DataContractResolver {
        /// <summary>
        /// 对象类名
        /// </summary>
        private const string ObjectTypeName = "object";

        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver) {
            // 将Namespace解析为类型名称
            Type type = ReflectionPublic.GetType(typeNamespace);
            if (type != null)
                return type;

            return knownTypeResolver.ResolveName(
              typeName, typeNamespace, declaredType, null);
        }

        public override bool TryResolveType(Type type
            , Type declaredType
            , DataContractResolver knownTypeResolver
            , out System.Xml.XmlDictionaryString typeName
            , out System.Xml.XmlDictionaryString typeNamespace) {

            XmlDictionary dictionary = new XmlDictionary();

            // 将类型放到Namespace中，放在typeName中会出现错误
            typeName = dictionary.Add(ObjectTypeName);
            typeNamespace = dictionary.Add(type.FullName);

            return true;
        }
    }
}
