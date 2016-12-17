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
    public class TcpRemote : PaoObject, IRemote
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
        public TcpRemote() {
        }

        public byte[] CallService(byte[] serviceName, byte[] functionName, byte[] header, byte[] inputParameters) {
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
            EventPublic.Information("[{0}]连接[{1}]成功"
                , tcpClient.Client.LocalEndPoint
                , tcpClient.Client.RemoteEndPoint);

            var clientStream = tcpClient.GetStream();
            var reader = new BinaryReader(clientStream);
            var writer = new BinaryWriter(clientStream);

            writer.NetWriteBinary(serviceName);

            writer.NetWriteBinary(functionName);

            writer.NetWriteBinary(header);

            writer.NetWriteBinary(inputParameters);

            // 获取返回参数
            string resultType = reader.NetReadObject<string>();
            byte[] result = null;
            if(resultType == RemotePublic.SuccessString) {
                result = reader.NetReadBinary();
            }
            else {
                var message = reader.NetReadObject<string>();
                var exceptionString = reader.NetReadObject<string>();

                var remoteException = new Exception(message);
                var fullServiceName = String.Format("{0}.{1}"
                    , RemotePublic.Deserialize<string>(serviceName)
                    , RemotePublic.Deserialize<string>(functionName));
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
