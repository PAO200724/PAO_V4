using PAO;
using PAO.IO.Text;
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
    [DisplayName("远程服务")]
    [Description("提供远程调用服务协议并分发到具体服务的服务")]
    public class RemoteService : PaoObject, IRemoteService
    {
        #region 插件属性
        #endregion
        public RemoteService() {
        }

        public string CallService(string serviceName, string functionName, string header, string inputParameters) {
            var serializer = RemotePublic.DefaultSerializer;

            // 获取头信息
            Header head = null;
            if (!header.IsNullOrEmpty()) {
                head = (Header)serializer.TextToObject(header);
            }

            string result = null;
            Action callService = () =>
            {
                // 获取服务对象
                if (!RemotePublic.ServiceList.ContainsKey(serviceName)) {
                    throw new Exception("找不到指定的服务名称").AddDetail("服务名称", serviceName);
                }
                var serviceObject = RemotePublic.ServiceList[serviceName];

                // 获取参数信息
                object[] inputParamList = null;
                if (!inputParameters.IsNullOrEmpty()) {
                    inputParamList = (object[])serializer.TextToObject(inputParameters);
                }

                // 获取方法
                var method = serviceObject.GetType().GetMethod(functionName
                    , BindingFlags.Public | BindingFlags.Instance);

                // 调用方法
                var resultObj = method.Invoke(serviceObject, inputParamList);
                result = serializer.ObjectToText(resultObj);
            };

            // 在事务中调用服务
            var transName = String.Format("{0}.{1}", serviceName, functionName);
            if (head != null && head.Transaction != null) {
                TransactionPublic.RunService(head.Transaction, transName, callService);
            } else {
                TransactionPublic.Run(transName, callService);
            }

            return result;
        }
    }
}
