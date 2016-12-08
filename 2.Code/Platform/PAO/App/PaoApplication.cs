using PAO.Event;
using PAO.IO.Text;
using PAO.Remote;
using PAO.Server;
using PAO.Trans;
using PAO.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
    [Name("Pao应用")]
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
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("客户端ID")]
        [Description("客户端应用的唯一标识")]
        public string ClientID {
            get;
            set;
        }
        #endregion 属性:ClientID

        #region 属性:EventProcessorList
        /// <summary>
        /// 属性:EventProcessorList
        /// 事件处理器列表
        /// 事件处理器列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("日志记录器列表")]
        [Description("记录日志的日志记录器列表")]
        public List<Ref<BaseEventProcessor>> EventProcessorList {
            get;
            set;
        }
        #endregion 属性:EventProcessorList

        #region 属性:ServerList
        /// <summary>
        /// 属性:ServerList
        /// 服务器列表
        /// 应用中后台运行的服务列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("服务器列表")]
        [Description("应用中后台运行的服务列表")]
        public List<Ref<BaseServer>> ServerList {
            get;
            set;
        }
        #endregion 属性:ServerList
        
        #region 属性：ExtendAddonList
        /// <summary>
        /// 属性：ExtendAddonList
        /// 扩展插件
        /// 扩展的全局插件
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("扩展插件")]
        [Description("扩展的全局插件")]
        public List<PaoObject> ExtendAddonList {
            get;
            set;
        }
        #endregion 属性：ExtendAddonList       

        #region 属性：ExtendPropertyStorageList
        /// <summary>
        /// 属性：ExtendPropertyStorage
        /// 扩展属性存储
        /// 存储扩展属性的存储器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("扩展属性存储")]
        [Description("存储扩展属性的存储器")]
        public Ref<IExtendPropertyStorage> ExtendPropertyStorage {
            get;
            set;
        }
        #endregion 属性：ExtendPropertyStorageList
        #endregion

        #region Actions
        /// <summary>
        /// 运行方法
        /// </summary>
        /// <returns></returns>
        [NonSerialized]
        public Action RunAction;

        /// <summary>
        /// 程序准备动作
        /// </summary>
        [NonSerialized]
        public Action PrepareAction;

        /// <summary>
        /// 异常响应方法
        /// </summary>
        [NonSerialized]
        public Action<Exception> ExceptionAction;
        #endregion

        /// <summary>
        /// 全局插件列表
        /// 此列表用于检索应用中的插件，当建立插件引用时，应当在此表中增加插件
        /// </summary>
        [NonSerialized]
        private Dictionary<string, PaoObject> GlobalAddonList = new Dictionary<string, PaoObject>();

        public PaoApplication() {
            ServerList = new List<PAO.Ref<Server.BaseServer>>();
            EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>();
            ExceptionAction = ShowExceptionDialog;
        }


        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null/*,"属性名称"*/);
        }

        /// <summary>
        /// 准备
        /// </summary>
        public virtual void OnPreparing() {
            if (PrepareAction != null)
                PrepareAction();
        }

        /// <summary>
        /// 运行
        /// </summary>
        public virtual void OnRunning() {
            if (RunAction != null)
                RunAction();
        }

        public virtual void OnException(Exception err) {
            if (ExceptionAction != null)
                ExceptionAction(err);
        }
        /// <summary>
        /// 运行
        /// </summary>
        public void Start() {
            // 一个应用中只能有一个默认应用程序
            Default = this;
            TransactionPublic.Run("主应用程序", () =>
            {
                TransactionPublic.Run("应用程序初始化", () =>
                {
                    TransactionPublic.Run("准备启动", OnPreparing);

                    TransactionPublic.Run("扩展配置加载", () =>
                    {
                        if (ExtendPropertyStorage != null) {
                            AddonPublic.ExtendPropertyStorage = ExtendPropertyStorage.Value;
                            AddonPublic.LoadAddonExtendPropertiesFromStorage();
                        }
                        //  遍历插件，应用插件
                        AddonPublic.TraverseAddon((addon) =>
                        {
                            if(addon is PaoObject) {
                                AddonPublic.ApplyAddonExtendProperties(addon as PaoObject);
                            }
                            return false;
                        }, PaoApplication.Default);
                    });

                    TransactionPublic.Run("检索全局插件", ()=> {
                        AddonPublic.SearchRuntimeAddons(this);
                    });

                    #region 事件
                    TransactionPublic.Run("事件处理机准备", () =>
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

                    #region 服务器
                    TransactionPublic.Run("启动服务器列表", () =>
                    {
                        if (ServerList.IsNotNullOrEmpty()) {
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
                });

                #region 程序
                TransactionPublic.Run("启动程序", Run);
                #endregion 程序

                TransactionPublic.Run("应用程序退出", () =>
                {
                    TransactionPublic.Run("扩展属性保存", ()=>
                    {
                        AddonPublic.SaveAddonExtendPropertiesToStorage();
                    });
                });
            }, OnException);
        }
        /// <summary>
        /// 程序运行
        /// </summary>
        protected virtual void Run() {
            OnRunning();
        }

        /// <summary>
        /// 显示异常对话框
        /// </summary>
        /// <param name="exception">异常对话框</param>
        protected virtual void ShowExceptionDialog(Exception exception) {
            UIPublic.ShowWaitingForm();
            var eventInfo = new ExceptionEventInfo(exception, true, true);
            UIPublic.CloseWaitingForm();
            UIPublic.ShowEventDialog(eventInfo);
        }
    }
}
