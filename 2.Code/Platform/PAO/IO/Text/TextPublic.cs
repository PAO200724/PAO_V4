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
        /// 将文本转换为对象
        /// </summary>
        /// <param name="text">文本字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object TextToObject(string text) {
            return DefaultSerializer.TextToObject(text);
        }

        /// <summary>
        /// 将对象转换为文本
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>文本字符串</returns>
        public static string ObjectToText(object obj) {
            return DefaultSerializer.ObjectToText(obj);
        }

        /// <summary>
        /// 将对象以Xml的方式写入流
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        public static void WriteObjectToStream(Stream stream, object obj) {
            DefaultSerializer.WriteObjectToStream(stream, obj);
        }

        /// <summary>
        /// 保存对象到文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="obj">对象</param>
        public static void WriteObjectToFile(string fileName, object obj) {
            using (SafeFileStream fileStream = new SafeFileStream(fileName, FileMode.Create, FileAccess.Write)) {
                WriteObjectToStream(fileStream, obj);
            }
        }
        /// <summary>
        /// 从Xml流中读取对象
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object ReadObjectFromStream(Stream stream) {
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
                object obj = ReadObjectFromStream(fileStream);
                return obj;
            }
        }
        /// <summary>
        /// 通过Xml克隆对象
        /// </summary>
        /// <param name="sourceObject">源对象</param>
        /// <returns>克隆后的对象</returns>
        public static object ObjectClone(this object sourceObject) { 
            if(sourceObject == null)
                return null;
            MemoryStream buffer = new MemoryStream();
            WriteObjectToStream(buffer, sourceObject);

            buffer.Seek(0, SeekOrigin.Begin);

            return ReadObjectFromStream(buffer);
        }
    }
}
