using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Serialization;
using System.Text;
using System.Runtime.Remoting.Messaging;
using PAO.Trans;
using System.Collections;
using System.Runtime.Remoting.Channels;
using PAO.Security;
using PAO.IO;

namespace PAO.Remote
{
    /// <summary>
    /// 类：RemoteProxy
    /// 远程代理
    /// 代理远程对象的类
    /// 作者：PAO
    /// </summary>
    [Name("远程代理")]
    [Description("代理远程对象的类")]
    public class RemoteProxy : RealProxy
    {
        private IRemote RemoteService;
        private string ServiceName;

        public RemoteProxy(Type proxyType, IRemote remoteService, string serviceName) : base(proxyType) {
            RemoteService = remoteService;
            ServiceName = serviceName;
        }

        public override IMessage Invoke(IMessage msg) {
            var head = new Header() { Transaction = PaoTransaction.Current, UserToken = SecurityPublic.CurrentUser };
            var headString = RemotePublic.Serialize(head);

            IMethodCallMessage methodMessage = new MethodCallMessageWrapper((IMethodCallMessage)msg);
            var inArgs = methodMessage.InArgs;
            byte[] argString = null;
            if (!inArgs.IsNull())
                argString = RemotePublic.Serialize(inArgs);
            
            var resultBinary = RemoteService.CallService(RemotePublic.Serialize(ServiceName)
                , RemotePublic.Serialize(methodMessage.MethodName)
                , headString, argString);
            var result = RemotePublic.Deserialize<object>(resultBinary);

            // Create the return message (ReturnMessage)
            return new ReturnMessage(result, null, 0, methodMessage.LogicalCallContext, methodMessage);
        }
    }
}
