using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAO.IO;

namespace PAO.IO.Text
{
    /// <summary>
    /// 静态类:IOPublic
    /// 输入输出公共类
    /// 作者:PAO
    /// </summary>
    public static class TextPublic {
        public static ITextSerialize DefaultSerializer = new DataContractTextSerializer();

        /// <summary>
        /// 将XML转换为对象
        /// </summary>
        /// <param name="xml">XML字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object XmlStringToObject(string xml) {
            return DefaultSerializer.TextToObject(xml);
        }

        /// <summary>
        /// 将对象转换为XML
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>XML字符串</returns>
        public static string ObjectToXmlString(object obj) {
            return DefaultSerializer.ObjectToText(obj);
        }

        /// <summary>
        /// 将对象以Xml的方式写入流
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        public static void WriteObjectToXmlStream(Stream stream, object obj) {
            DefaultSerializer.WriteObjectToStream(stream, obj);
        }

        /// <summary>
        /// 保存对象到文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="obj">对象</param>
        public static void WriteObjectToFile(string fileName, object obj) {
            using (SafeFileStream fileStream = new SafeFileStream(fileName, FileMode.Create, FileAccess.Write)) {
                WriteObjectToXmlStream(fileStream, obj);
            }
        }
        /// <summary>
        /// 从Xml流中读取对象
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object ReadObjectFromXmlStream(Stream stream) {
            return DefaultSerializer.ReadObjectFromStream(stream);
        }

        /// <summary>
        /// 从文件读取对象
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <return>对象</return>
        public static object ReadObjectFromFile(string fileName) {
            if (!File.Exists(fileName))
                return null;

            using (SafeFileStream fileStream = new SafeFileStream(fileName, FileMode.Open, FileAccess.Read)) {
                object obj = ReadObjectFromXmlStream(fileStream);
                return obj;
            }
        }
        /// <summary>
        /// 通过Xml克隆对象
        /// </summary>
        /// <param name="sourceObject">源对象</param>
        /// <returns>克隆后的对象</returns>
        public static object ObjectClone(this object sourceObject) {
            MemoryStream buffer = new MemoryStream();
            WriteObjectToXmlStream(buffer, sourceObject);

            buffer.Seek(0, SeekOrigin.Begin);

            return ReadObjectFromXmlStream(buffer);
        }
    }
}
