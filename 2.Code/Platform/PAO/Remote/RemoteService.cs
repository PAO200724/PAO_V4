using PAO;
using PAO.IO.Text;
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

namespace PAO.Remote
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
    public class RemoteService : PaoObject, IRemoteService
    {
        #region 插件属性

        #region 属性：ServiceList
        /// <summary>
        /// 属性：ServiceList
        /// 服务列表
        /// 远程服务列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("服务列表")]
        [Description("远程服务列表")]
        public Dictionary<string, Ref<PaoObject>> ServiceList {
            get;
            set;
        }
        #endregion 属性：ServiceList

        #endregion
        public RemoteService() {
        }

        public string CallService(string serviceName, string functionName, string header, string inputParameters) {
            var result = RemotePublic.CallService(ServiceList, serviceName, functionName, header, inputParameters);

            return result;
        }
    }
}
