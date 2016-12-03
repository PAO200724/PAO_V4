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

namespace PAO.Remote.WCF
{
    /// <summary>
    /// 类：RemoteFactory
    /// WCF远程工厂
    /// 通过WCF远程调用创建的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("WCF远程工厂")]
    [Description("通过WCF远程调用创建的工厂")]
    public class WCFRemoteFactory<T> : BaseRemoteFactory<T>
    {
        #region 插件属性
        #endregion
        public WCFRemoteFactory() {
        }

        protected override IRemote CreateRemoteService() {
            return new WCFFactory<IRemote>
            {
                Url = ServerAddress
            }.Value;
        }
    }
}
