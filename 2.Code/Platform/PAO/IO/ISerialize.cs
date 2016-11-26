using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.IO
{
    /// <summary>
    /// 接口：ISerialize
    /// 序列化接口
    /// 作者：PAO
    /// </summary>
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
}
