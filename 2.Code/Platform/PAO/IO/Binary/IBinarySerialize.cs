using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.IO.Binary
{
    /// <summary>
    /// 接口：IBinarySerialize
    /// 二进制序列化接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    public interface IBinarySerialize : ISerialize
    {
        /// <summary>
        /// 将对象转换为二进制
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>二进制数组</returns>
        byte[] ObjectToBinary(object obj);

        /// <summary>
        /// 二进制转换为对象
        /// </summary>
        /// <param name="binary">二进制数组</param>
        /// <returns>对象</returns>
        object BinaryToObject(byte[] binary);
    }
}
