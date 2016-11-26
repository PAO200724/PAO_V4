using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PAO.IO.Binary
{
    /// <summary>
    /// 类：BinarySerializer
    /// 二进制序列化器
    /// 利用BinaryFormatter进行序列化的二进制序列化器
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("二进制序列化器")]
    [Description("利用BinaryFormatter进行序列化的二进制序列化器")]
    public class BinarySerializer : PaoObject, IBinarySerialize
    {
        private static readonly BinaryFormatter Serializer = new BinaryFormatter();
        #region 插件属性
        #endregion
        public BinarySerializer() {
        }

        public object BinaryToObject(byte[] binary) {
            if (binary.IsNullOrEmpty())
                return null;

            var formatter = new BinaryFormatter();
            var buffer = new MemoryStream(binary);
            return formatter.Deserialize(buffer);
        }

        public byte[] ObjectToBinary(object obj) {
            if (obj.IsNull())
                return null;

            var formatter = new BinaryFormatter();
            var buffer = new MemoryStream();
            formatter.Serialize(buffer, obj);
            return buffer.ToArray();
        }

        public object ReadObjectFromStream(Stream stream) {
            return Serializer.Deserialize(stream);
        }

        public void WriteObjectToStream(Stream stream, object obj) {
            Serializer.Serialize(stream, obj);
        }
    }
}
