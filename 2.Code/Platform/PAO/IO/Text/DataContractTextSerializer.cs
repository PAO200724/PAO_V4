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

namespace PAO.IO.Text
{
    /// <summary>
    /// WCF数据协议对象序列化器
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    public class DataContractTextSerializer : ITextSerialize
    {
        private readonly static DataContractResolver DefaultResolver = new TextDataContractResolver();
        private readonly static DataContractSerializer Serializer = new DataContractSerializer(typeof(Object)
                , null
                , int.MaxValue
                , false
                , false
                , null
                , DefaultResolver);

        public DataContractTextSerializer() {
        }

        /// <summary>
        /// 将TEXT转换为对象
        /// </summary>
        /// <param name="text">TEXT字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public object TextToObject(string text) {
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
            obj.CheckNotNull();

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
    }
}
