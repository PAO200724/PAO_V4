using PAO;
using PAO.IO.Text;
using PAO.Remote.WCF;
using PAO.Trans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote.Tcp
{
    /// <summary>
    /// 类：RemoteFactory
    /// Tcp远程工厂
    /// 通过TCP远程调用创建的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("Tcp远程工厂")]
    [Description("通过TCP远程调用创建的工厂")]
    public class TcpRemoteFactory<T> : BaseRemoteFactory<T>
    {
        #region 插件属性

        #endregion
        public TcpRemoteFactory() {
        }
        protected override IRemoteService CreateRemoteService() {
            return new TcpRemoteClient()
            {
                ServerAddress = ServerAddress
            };
        }
    }
}
