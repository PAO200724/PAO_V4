using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.IO.Binary
{
    /// <summary>
    /// 静态类：BinaryPublic
    /// 二进制公共类
    /// 作者：PAO
    /// </summary>
    public static class BinaryPublic
    {
        public static IBinarySerialize DefaultSerializer = new BinarySerializer();

        /// <summary>
        /// 将Binary转换为对象
        /// </summary>
        /// <param name="Binary">Binary数组</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object BinaryToObject(byte[] Binary) {
            return DefaultSerializer.BinaryToObject(Binary);
        }

        /// <summary>
        /// 将对象转换为Binary
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>Binary数组</returns>
        public static byte[] ObjectToBinary(object obj) {
            return DefaultSerializer.ObjectToBinary(obj);
        }

        /// <summary>
        /// 将对象以Binary的方式写入流
        /// </summary>
        /// <param name="stream">Binary字符流</param>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        public static void WriteObjectToBinaryStream(Stream stream, object obj) {
            DefaultSerializer.WriteObjectToStream(stream, obj);
        }

        /// <summary>
        /// 保存对象到文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="obj">对象</param>
        public static void WriteObjectToFile(string fileName, object obj) {
            using (SafeFileStream fileStream = new SafeFileStream(fileName, FileMode.Create, FileAccess.Write)) {
                BinaryPublic.WriteObjectToBinaryStream(fileStream, obj);
            }
        }
        /// <summary>
        /// 从Binary流中读取对象
        /// </summary>
        /// <param name="stream">Binary字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object ReadObjectFromBinaryStream(Stream stream) {
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
                object obj = BinaryPublic.ReadObjectFromBinaryStream(fileStream);
                return obj;
            }
        }
        /// <summary>
        /// 通过Binary克隆对象
        /// </summary>
        /// <param name="sourceObject">源对象</param>
        /// <returns>克隆后的对象</returns>
        public static object ObjectClone(this object sourceObject) {
            MemoryStream buffer = new MemoryStream();
            WriteObjectToBinaryStream(buffer, sourceObject);

            buffer.Seek(0, SeekOrigin.Begin);

            return ReadObjectFromBinaryStream(buffer);
        }
    }
}
