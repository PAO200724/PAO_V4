using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.IO.Text
{
    /// <summary>
    /// 接口:IXmlSerialize
    /// 对象序列化接口
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    public interface ITextSerialize : ISerialize{
        /// <summary>
        /// 将XML转换为对象
        /// </summary>
        /// <param name="xml">XML字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        object TextToObject(string xml);

        /// <summary>
        /// 将对象转换为XML
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>XML字符串</returns>
        string ObjectToText(object obj);
    }
}
