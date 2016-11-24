using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PAO.IO
{
    /// <summary>
    /// WCF数据协议对象序列化器
    /// 作者：刘丹(Daniel.liu)
    /// </summary>
    public class DataContractXmlSerializer : IXmlSerialize
    {
        DataContractSerializer Serializer;

        public DataContractXmlSerializer() {
            RebuildSerializer();
        }

        /// <summary>
        /// 重新创建
        /// </summary>
        public void RebuildSerializer() {
            Serializer = new DataContractSerializer(typeof(Object)
                , null
                , int.MaxValue
                , false
                , false
                , null
                , new PaoDataContractResolver());
        }

        /// <summary>
        /// 将XML转换为对象
        /// </summary>
        /// <param name="xml">XML字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public object XmlStringToObject(string xml) {
            StringReader reader = new StringReader(xml);
            XmlReader xmlReader = XmlReader.Create(reader);
            object result = Serializer.ReadObject(xmlReader);
            reader.Close();
            return result;
        }

        /// <summary>
        /// 将对象转换为XML
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>XML字符串</returns>
        public string ObjectToXmlString(object obj) {
            obj.CheckNotNull();

            StringWriter writer = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(writer);
            Serializer.WriteObject(xmlWriter, obj);
            writer.Close();
            return writer.GetStringBuilder().ToString();
        }

        /// <summary>
        /// 将对象以Xml的方式写入流
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        public void WriteObjectToXmlStream(Stream stream, object obj) {
            obj.CheckNotNull();

            Serializer.WriteObject(stream, obj);
        }

        /// <summary>
        /// 从Xml流中读取对象
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public object ReadObjectFromXmlStream(Stream stream) {
            return Serializer.ReadObject(stream);
        }
    }
}
