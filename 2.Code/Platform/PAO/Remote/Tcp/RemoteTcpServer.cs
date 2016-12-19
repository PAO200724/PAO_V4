using PAO;
using PAO.Event;
using PAO.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PAO.Remote.Tcp
{
    /// <summary>
    /// 类：RemoteTcpServer
    /// Tcp服务器
    /// 利用Socket实现远程服务功能的服务器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("Tcp服务器")]
    [Description("利用Socket实现远程服务功能的服务器")]
    public class RemoteTcpServer : BaseServer
    {
        /// <summary>
        /// 侦听队列允许挂起的最大长度
        /// </summary>
        public static int DefaultBackLog = 200;

        const string LocalHost = "127.0.0.1";

        #region 插件属性
        #region 属性：Port
        /// <summary>
        /// 属性：Port
        /// 端口
        /// 监听端口
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("端口")]
        [Description("监听端口")]
        public int Port {
            get;
            set;
        }
        #endregion 属性：Port

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

        public RemoteTcpServer() {
        }

        /// <summary>
        /// 监听端口队列
        /// </summary>
        [NonSerialized]
        private TcpListener Listener = null;
        /// <summary>
        /// 监听线程
        /// </summary>
        [NonSerialized]
        private Task ListenTask = null;
        
        protected override void OnStart() {
            var localAddr = IPAddress.Parse(LocalHost);

            Listener = new TcpListener(localAddr, Port);
            EventPublic.Information("开始在地址：{0}:{1}监听", localAddr, Port);
            Listener.Start();

            ListenTask = Task.Factory.StartNew(() =>
            {
                while (!Stopped) {
                    try {
                        AcceptSocket(Listener);
                    } catch (Exception err) {
                        EventPublic.Exception(err);
                    }
                }
            });
        }

        protected override void OnStop() {
            // 关闭所有监听端口
            Listener.Stop();
            base.OnStop();
        }

        protected override void Run() {
            ListenTask.Wait();
        }

        private void AcceptSocket(TcpListener listener) {
            var tcpClient = listener.AcceptTcpClient();
            EventPublic.Information("[{0}]收到[{1}]的请求"
                , tcpClient.Client.LocalEndPoint
                , tcpClient.Client.RemoteEndPoint);
            
            // 接收到连接后完成通讯
            var clientStream = tcpClient.GetStream();
            var reader = new BinaryReader(clientStream);
            var writer = new BinaryWriter(clientStream);

            // 读取服务名称
            var serviceName = reader.NetReadBinary();
            // 方法名称
            var functionName = reader.NetReadBinary();
            // 读取协议头
            var header = reader.NetReadBinary();
            // 输入参数
            var inputParameters = reader.NetReadBinary();

            var serviceNameString = RemotePublic.Deserialize<string>(serviceName);
            var functionNameString = RemotePublic.Deserialize<string>(functionName);
            // 调用服务
            EventPublic.Information("开始调用服务：{0}.{1}"
                , serviceNameString
                , functionNameString);
            try {
                var result = RemotePublic.CallService(ServiceList
                    , serviceNameString
                    , functionNameString
                    , RemotePublic.Deserialize<Header>(header)
                    , RemotePublic.Deserialize<object[]>(inputParameters));
                writer.NetWriteObject(RemotePublic.SuccessString);
                writer.NetWriteBinary(result);
            } catch (Exception err) {
                // 发出异常
                writer.NetWriteObject(RemotePublic.FailedString);
                writer.NetWriteObject(err.Message);
                writer.NetWriteObject(err.FormatException());
            }


            tcpClient.Close();
            clientStream.Close();
        }
    }
}
