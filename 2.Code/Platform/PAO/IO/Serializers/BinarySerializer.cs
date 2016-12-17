using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PAO.IO.Serializers
{
    /// <summary>
    /// 类：BinarySerializer
    /// 二进制序列化器
    /// 利用BinaryFormatter进行序列化的二进制序列化器
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("二进制序列化器")]
    [Description("利用BinaryFormatter进行序列化的二进制序列化器")]
    public class BinarySerializer : PaoObject, ISerialize<byte[]>
    {
        private static readonly BinaryFormatter Serializer = new BinaryFormatter();
        #region 插件属性
        #endregion
        public BinarySerializer() {
        }
        
        public byte[] ObjectToBinary(object obj) {
            if (obj.IsNull())
                return null;

            var formatter = new BinaryFormatter();
            using (var buffer = new MemoryStream()) {
                formatter.Serialize(buffer, obj);
                var binary = buffer.ToArray();
                return binary;
            }
        }

        public object ReadObjectFromStream(Stream stream) {
            return Serializer.Deserialize(stream);
        }

        public void WriteObjectToStream(Stream stream, object obj) {
            Serializer.Serialize(stream, obj);
        }


        public object Deserialize(byte[] serializedObject) {
            if (serializedObject.IsNullOrEmpty())
                return null;

            var formatter = new BinaryFormatter();
            using (var buffer = new MemoryStream(serializedObject)) {
                var obj = formatter.Deserialize(buffer);
                return obj;
            }
        }

        public byte[] Serialize(object origionObject) {
            if (origionObject.IsNull())
                return null;

            var formatter = new BinaryFormatter();
            using (var buffer = new MemoryStream()) {
                formatter.Serialize(buffer, origionObject);
                var binary = buffer.ToArray();
                return binary;
            }
        }
    }
}
