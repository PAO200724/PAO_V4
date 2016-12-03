using PAO;
using PAO.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote.Tcp
{
    /// <summary>
    /// 类：TcpRemoteService
    /// Tcp远程服务
    /// 用Tcp方式提供远程服务的服务
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("Tcp远程服务")]
    [Description("用Tcp方式提供远程服务的服务")]
    public class TcpRemoteClient : PaoObject, IRemoteService
    {
        #region 插件属性

        #region 属性：ServerAddress
        /// <summary>
        /// 属性：ServerAddress
        /// 服务器地址
        /// Tcp远程服务器地址
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("服务器地址")]
        [Description("Tcp远程服务器地址")]
        public string ServerAddress {
            get;
            set;
        }
        #endregion 属性：ServerAddress
        
        #endregion
        public TcpRemoteClient() {
        }

        public string CallService(string serviceName, string functionName, string header, string inputParameters) {
            string hostName;
            int port;
            try {
                string[] addressStrings = ServerAddress.Split(':');
                hostName = addressStrings[0];
                port = Convert.ToInt32(addressStrings[1]);
            } catch (Exception err) {
                throw new Exception("地址格式错误", err).AddExceptionData("地址", ServerAddress);
            }
               
            var tcpClient = new TcpClient();
            tcpClient.Connect(hostName, port);
            EventPublic.Information("地址{0}连接服务：{1}成功"
                , tcpClient.Client.LocalEndPoint
                , tcpClient.Client.RemoteEndPoint);

            var clientStream = tcpClient.GetStream();
            var reader = new BinaryReader(clientStream);
            var writer = new BinaryWriter(clientStream);

            writer.Write(serviceName);

            writer.Write(functionName);

            writer.Write(header);

            writer.Write(inputParameters);

            // 获取返回参数
            string resultType = reader.ReadString();
            string result = null;
            if(resultType == RemotePublic.SuccessString) {
                result = reader.ReadString();
            } else {
                string message = reader.ReadString();
                string exceptionString = reader.ReadString();
                var remoteException = new Exception(message);
                var fullServiceName = String.Format("{0}.{1}", serviceName, functionName);
                throw new Exception("远程调用服务异常", remoteException)
                    .AddExceptionData("服务地址", ServerAddress)
                    .AddExceptionData("服务", fullServiceName)
                    .AddExceptionData("远程异常信息", exceptionString);
            }

            tcpClient.Close();
            clientStream.Close();
            return result;
        }
    }
}
