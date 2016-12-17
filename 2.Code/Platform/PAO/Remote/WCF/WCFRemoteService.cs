using PAO;
using PAO.Security;
using PAO.Trans;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PAO.Remote.WCF
{
    /// <summary>
    /// 类：RemoteService
    /// 远程服务
    /// 提供远程调用服务协议并分发到具体服务的服务
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("远程服务")]
    [Description("提供远程调用服务协议并分发到具体服务的服务")]
    public class WCFRemoteService : PaoObject, IRemote
    {
        #region 插件属性
        #endregion

        internal static Dictionary<string, Ref<PaoObject>> ServiceList;

        public WCFRemoteService() {
        }

        public byte[] CallService(byte[] serviceName, byte[] functionName, byte[] header, byte[] inputParameters) {
            var result = RemotePublic.CallService(ServiceList, serviceName, functionName, header, inputParameters);

            return result;
        }
    }
}
