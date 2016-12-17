using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.IO
{
    /// <summary>
    /// 接口：ISerialize
    /// 序列化接口
    /// 序列化接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("序列化接口")]
    [Description("序列化接口")]
    public interface ISerialize
    {
        /// <summary>
        /// 将对象以Xml的方式写入流
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="obj">对象</param>
        void WriteObjectToStream(Stream stream, object obj);

        /// <summary>
        /// 从Xml流中读取对象
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        object ReadObjectFromStream(Stream stream);
    }

    public interface ISerialize<T> : ISerialize
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="serializedObject">序列化对象</param>
        /// <returns>反序列化对象</returns>
        object Deserialize(T serializedObject);
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="origionObject">原始对象</param>
        /// <returns>序列化对象</returns>
        T Serialize(object origionObject);
    }
}
