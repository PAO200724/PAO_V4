using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.IO {
    /// <summary>
    /// 接口：IXmlSerialize
    /// 对象序列化接口
    /// 作者：刘丹(Daniel.liu)
    /// </summary>
    public interface IXmlSerialize {
        /// <summary>
        /// 重新创建
        /// </summary>
        void RebuildSerializer();

        /// <summary>
        /// 将XML转换为对象
        /// </summary>
        /// <param name="xml">XML字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        object XmlStringToObject(string xml);

        /// <summary>
        /// 将对象转换为XML
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>XML字符串</returns>
        string ObjectToXmlString(object obj);

        /// <summary>
        /// 将对象以Xml的方式写入流
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="obj">对象</param>
        void WriteObjectToXmlStream(Stream stream, object obj);
        
        /// <summary>
        /// 从Xml流中读取对象
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        object ReadObjectFromXmlStream(Stream stream);
    }
}
