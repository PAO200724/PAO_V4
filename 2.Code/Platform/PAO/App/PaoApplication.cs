using PAO.Event;
using PAO.IO.Text;
using PAO.Remote;
using PAO.Server;
using PAO.Trans;
using PAO.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.App {
    /// <summary>
    /// 类:PaoApplication
    /// Pao应用
    /// 包含了Pao框架启动所需的基本功能
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("Pao应用")]
    [Description("包含了Pao框架启动所需的基本功能")]
    public class PaoApplication : PaoObject {
        /// <summary>
        /// 默认应用
        /// </summary>
        public static PaoApplication Default {
            get;
            private set;
        }
        #region 插件属性
        #region 属性:ClientID
        /// <summary>
        /// 属性:ClientID
        /// 客户端ID
        /// 客户端应用的唯一标识
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("客户端ID")]
        [Description("客户端应用的唯一标识")]
        public string ClientID {
            get;
            set;
        }
        #endregion 属性:ClientID

        #region 属性:EventProcessorList
        /// <summary>
        /// 属性:EventProcessorList
        /// 日志记录器列表
        /// 记录日志的日志记录器列表
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("日志记录器列表")]
        [Description("记录日志的日志记录器列表")]
        public List<Ref<IEventProcess>> EventProcessorList {
            get;
            set;
        }
        #endregion 属性:EventProcessorList

        #region 属性:ServerList
        /// <summary>
        /// 属性:ServerList
        /// 服务列表
        /// 应用中后台运行的服务列表
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("服务列表")]
        [Description("应用中后台运行的服务列表")]
        public List<Ref<BaseServer>> ServerList {
            get;
            set;
        }
        #endregion 属性:ServerList

        #region 属性：ServiceList
        /// <summary>
        /// 属性：ServiceList
        /// 服务列表
        /// 加载在远程服务器中的服务列表
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("服务列表")]
        [Description("加载在远程服务器中的服务列表")]
        public Dictionary<string, Ref<object>> ServiceList {
            get;
            set;
        }
        #endregion 属性：ServiceList

        #region 属性：GlobalAddonList
        /// <summary>
        /// 属性：GlobalAddonList
        /// 全局插件列表
        /// 此列表用于检索应用中的插件，当建立插件引用时，应当在此表中增加插件
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("全局插件列表")]
        [Description("此列表用于检索应用中的插件，当建立插件引用时，应当在此表中增加插件")]
        public Dictionary<string, Ref<PaoObject>> GlobalAddonList {
            get;
            set;
        }
        #endregion 属性：GlobalAddonList

        #region 属性：UserInterface
        /// <summary>
        /// 属性：UserInterface
        /// 用户界面
        /// 用户界面
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("用户界面")]
        [Description("用户界面")]
        public Ref<IUserInterface> UserInterface {
            get;
            set;
        }
        #endregion 属性：UserInterface
        #endregion

        /// <summary>
        /// 运行方法
        /// </summary>
        /// <returns></returns>
        [NonSerialized]
        public Action RunAction;

        public PaoApplication() {
            ServerList = new List<PAO.Ref<Server.BaseServer>>();
            EventProcessorList = new List<PAO.Ref<IEventProcess>>();
            ServiceList = new Dictionary<string, PAO.Ref<object>>();
        }

        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null/*,"属性名称"*/);
        }

        /// <summary>
        /// 异常响应方法
        /// </summary>
        public Action<Exception> OnException;

        /// <summary>
        /// 运行
        /// </summary>
        public void Start() {
            // 一个应用中只能有一个默认应用程序
            Default = this;
            TransactionPublic.Run("主应用程序", () =>
            {
                TransactionPublic.Run("启动准备", OnStart);

                #region 用户界面
                if (UserInterface.IsNotNull()) {
                    UIPublic.DefaultUserInterface = UserInterface.Value;
                }
                #endregion 用户界面

                #region 日志
                TransactionPublic.Run("准备日志", () =>
                {
                     if (!EventProcessorList.IsNullOrEmpty()) {
                         EventPublic.ClearEventProcessor();
                         foreach (var EventProcessor in EventProcessorList) {
                             var logObj = EventProcessor.Value;
                             EventPublic.AddEventProcessor(logObj);
                         }
                     }
                 });
                #endregion 日志

                #region 远程服务
                TransactionPublic.Run("加载远程服务", () =>
                {
                    if (ServiceList.IsNullOrEmpty())
                        return;

                    // 默认为DataContract序列化器
                    RemotePublic.DefaultSerializer = new DataContractTextSerializer();
                    RemotePublic.ServiceList = new Dictionary<string, object>();
                    foreach(var key in ServiceList.Keys) {
                        RemotePublic.ServiceList.Add(key, ServiceList[key].Value);
                    }
                });
                #endregion
                
                #region 服务器
                TransactionPublic.Run("启动服务器列表", () =>
                {
                    if (!ServerList.IsNullOrEmpty()) {
                        foreach (var server in ServerList) {
                            var serverObj = server.Value;
                            if (serverObj == null)
                                throw new Exception("服务创建失败");
                            serverObj.Start();
                            EventPublic.Information("服务{0}启动完毕.", serverObj.ObjectToString());
                        }
                    }
                });
                #endregion 服务

                #region 程序
                TransactionPublic.Run("启动服务", Run);
                #endregion 程序
            }, OnException);
        }

        /// <summary>
        /// 程序运行
        /// </summary>
        protected virtual void Run() {
            if (RunAction != null)
                RunAction();

            OnRunning();
        }

        /// <summary>
        /// 程序启动
        /// </summary>
        protected virtual void OnStart(){
        }

        protected virtual void OnRunning() {

        }
    }
}
