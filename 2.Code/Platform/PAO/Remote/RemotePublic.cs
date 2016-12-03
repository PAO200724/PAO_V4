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
        /// 表示成功的字符串（用于返回参数）
        /// </summary>
        public const string SuccessString = "Success";
        /// <summary>
        /// 表示失败的字符串（用于返回参数）
        /// </summary>
        public const string FailedString = "Failed";

        /// <summary>
        /// 默认的序列化器
        /// </summary>
        public static ITextSerialize DefaultSerializer = new DataContractTextSerializer();

        #region 调用服务
        /// <summary>
        /// 调用服务方法
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="functionName">方法名称</param>
        /// <param name="header">协议头</param>
        /// <param name="inputParameters">输入参数</param>
        /// <returns></returns>
        public static string CallService(Dictionary<string, Ref<PaoObject>> serviceList, string serviceName, string functionName, string header, string inputParameters) {
            var serializer = RemotePublic.DefaultSerializer;

            // 获取头信息
            Header head = null;
            if (!header.IsNullOrEmpty()) {
                head = (Header)serializer.TextToObject(header);
            }

            // 设置线程用户
            SecurityPublic.ThreadUser = head.UserToken;

            string result = null;
            Action callService = () =>
            {
                // 获取服务对象
                if (!serviceList.ContainsKey(serviceName)) {
                    throw new Exception("找不到指定的服务名称").AddExceptionData("服务名称", serviceName);
                }
                var serviceObject = serviceList[serviceName].Value;

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
            }
            else {
                TransactionPublic.Run(transName, callService);
            }

            return result;
        }
        #endregion
    }
}
