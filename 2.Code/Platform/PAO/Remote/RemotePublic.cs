using PAO;
using PAO.IO.Text;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote
{
    /// <summary>
    /// 静态类：RemotePublic
    /// 远程公共类
    /// 作者：PAO
    /// </summary>
    public static class RemotePublic
    {
        /// <summary>
        /// 默认的序列化器
        /// </summary>
        public static ITextSerialize DefaultSerializer = new DataContractTextSerializer();
        /// <summary>
        /// 服务列表
        /// </summary>
        public static Dictionary<string, object> ServiceList = new Dictionary<string, object>();
    }
}
