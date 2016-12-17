using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PAO.IO.Serializers
{
    /// <summary>
    /// Xml对象序列化器
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    public class XmlSerializer : ISerialize<string>, ISerialize<byte[]>
    {
        private readonly static DataContractResolver DefaultResolver = new TextDataContractResolver();
        private readonly static DataContractSerializer Serializer = new DataContractSerializer(typeof(Object)
                , null
                , int.MaxValue
                , false
                , false
                , null
                , DefaultResolver);

        public XmlSerializer() {
        }

        /// <summary>
        /// 将TEXT转换为对象
        /// </summary>
        /// <param name="text">TEXT字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public object TextToObject(string text) {
            if (text.IsNullOrEmpty())
                return null;

            if (text == "null")
                return null;
            StringReader reader = new StringReader(text);
            XmlReader textReader = XmlReader.Create(reader);
            object result = Serializer.ReadObject(textReader);
            reader.Close();
            return result;
        }

        /// <summary>
        /// 将对象转换为TEXT
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>TEXT字符串</returns>
        public string ObjectToText(object obj) {
            if (obj.IsNull())
                return null;

            StringWriter writer = new StringWriter();
            XmlTextWriter textWriter = new XmlTextWriter(writer);
            Serializer.WriteObject(textWriter, obj);
            writer.Close();
            return writer.GetStringBuilder().ToString();
        }

        /// <summary>
        /// 将对象以Text的方式写入流
        /// </summary>
        /// <param name="stream">Text字符流</param>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        public void WriteObjectToStream(Stream stream, object obj) {
            obj.CheckNotNull();

            Serializer.WriteObject(stream, obj);
        }

        /// <summary>
        /// 从Text流中读取对象
        /// </summary>
        /// <param name="stream">Text字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public object ReadObjectFromStream(Stream stream) {
            return Serializer.ReadObject(stream);
        }
        
        object ISerialize<string>.Deserialize(string serializedObject) {
            if (serializedObject.IsNullOrEmpty())
                return null;

            if (serializedObject == "null")
                return null;
            StringReader reader = new StringReader(serializedObject);
            XmlReader textReader = XmlReader.Create(reader);
            object result = Serializer.ReadObject(textReader);
            reader.Close();
            return result;
        }

        object ISerialize<byte[]>.Deserialize(byte[] serializedObject) {
            if (serializedObject.IsNullOrEmpty())
                return null;

            using (MemoryStream buffer = new MemoryStream(serializedObject)) {
                object result = Serializer.ReadObject(buffer);
                return result;
            }
        }

        string ISerialize<string>.Serialize(object origionObject) {
            if (origionObject.IsNull())
                return null;

            StringWriter writer = new StringWriter();
            XmlTextWriter textWriter = new XmlTextWriter(writer);
            Serializer.WriteObject(textWriter, origionObject);
            writer.Close();
            return writer.GetStringBuilder().ToString();
        }

        byte[] ISerialize<byte[]>.Serialize(object origionObject) {
            if (origionObject == null)
                return null;

            using (MemoryStream buffer = new MemoryStream()) {
                Serializer.WriteObject(buffer, origionObject);
                return buffer.ToArray();
            }
        }
    }
}
