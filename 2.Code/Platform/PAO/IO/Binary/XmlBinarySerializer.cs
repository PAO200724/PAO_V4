using PAO;
using PAO.IO.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.IO.Binary
{
    /// <summary>
    /// 类：XmlSerializer
    /// Xml序列化器
    /// 通过XmlPublic序列化对象的序列化器
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("Xml序列化器")]
    [Description("通过XmlPublic序列化对象的序列化器")]
    public class XmlBinarySerializer : PaoObject, IBinarySerialize
    {
        /// <summary>
        /// 默认编码器
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;
        #region 插件属性
        #endregion
        public XmlBinarySerializer() {
        }

        public object BinaryToObject(byte[] binary) {
            if (binary.IsNullOrEmpty())
                return null;

            var xmlString = DefaultEncoding.GetString(binary);
            return TextPublic.TextToObject(xmlString);
        }

        public byte[] ObjectToBinary(object obj) {
            if (obj.IsNull())
                return null;

            var xmlString = TextPublic.ObjectToText(obj);
            return DefaultEncoding.GetBytes(xmlString);
        }

        public object ReadObjectFromStream(Stream stream) {
            return TextPublic.ReadObjectFromStream(stream);
        }

        public void WriteObjectToStream(Stream stream, object obj) {
            TextPublic.WriteObjectToStream(stream, obj);
        }
    }
}
