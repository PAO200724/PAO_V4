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
using PAO.IO.Text;
using System.Runtime.Remoting.Channels;
using PAO.Security;

namespace PAO.Remote
{
    /// <summary>
    /// 类：RemoteProxy
    /// 远程代理
    /// 代理远程对象的类
    /// 作者：PAO
    /// </summary>
    [DisplayName("远程代理")]
    [Description("代理远程对象的类")]
    public class RemoteProxy : RealProxy
    {
        private IRemoteService RemoteService;
        private ITextSerialize Serializer;
        private string ServiceName;

        public RemoteProxy(Type proxyType, IRemoteService remoteService, ITextSerialize serializer, string serviceName) : base(proxyType) {
            RemoteService = remoteService;
            Serializer = serializer;
            ServiceName = serviceName;
        }

        public override IMessage Invoke(IMessage msg) {
            var head = new Header() { Transaction = PaoTransaction.Current, UserToken = SecurityPublic.CurrentUser };
            var headString = Serializer.ObjectToText(head);

            IMethodCallMessage methodMessage = new MethodCallMessageWrapper((IMethodCallMessage)msg);
            var inArgs = methodMessage.InArgs;
            string argString = null;
            if (!inArgs.IsNull())
                argString = Serializer.ObjectToText(inArgs);

            var resultString = RemoteService.CallService(ServiceName, methodMessage.MethodName, headString, argString);
            object result = null;
            if (!resultString.IsNullOrEmpty())
                result = Serializer.TextToObject(resultString);

            // Create the return message (ReturnMessage)
            return new ReturnMessage(result, null, 0, methodMessage.LogicalCallContext, methodMessage);
        }
    }
}
