using PAO.Log;
using PAO.Server;
using PAO.Trans;
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

        #region 属性:LoggerList
        /// <summary>
        /// 属性:LoggerList
        /// 日志记录器列表
        /// 记录日志的日志记录器列表
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("日志记录器列表")]
        [Description("记录日志的日志记录器列表")]
        public List<Ref<ILog>> LoggerList {
            get;
            set;
        }
        #endregion 属性:LoggerList
        #endregion

        /// <summary>
        /// 应用程序目录
        /// </summary>
        [NonSerialized]
        private string _AppDirectory;
        public string AppDirectory {
            get {
                return _AppDirectory;
            }
        }

        /// <summary>
        /// 运行方法
        /// </summary>
        /// <returns></returns>
        [NonSerialized]
        public Action RunAction;

        public PaoApplication() {
            ServerList = new List<PAO.Ref<Server.BaseServer>>();
            LoggerList = new List<PAO.Ref<Log.ILog>>();
        }

        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null/*,"属性名称"*/);
        }
        #region 应用程序路径
        /// <summary>
        /// 获取绝对路径
        /// </summary>
        /// <param name="relatedPath">相对路径</param>
        /// <returns>绝对路径</returns>
        public string GetAbsolutePath(string relatedPath) {
            return Path.Combine(AppDirectory, relatedPath);
        }
        #endregion

        /// <summary>
        /// 运行
        /// </summary>
        public void Start() {
            // 一个应用中只能有一个默认应用程序
            Default = this;
            TransactionPublic.Run("主应用程序", () =>
            {
                //首先添加默认的日志记录器
                LogPublic.ClearLogger();
                LogPublic.AddLogger(DebugLogger.Logger);
                LogPublic.AddLogger(EventLogger.Logger);

                TransactionPublic.Run("启动准备", OnStart);

                #region 插件
                _AppDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

                TransactionPublic.Run("加载插件", () =>
                {
                    LogPublic.LogInformation("开始加载插件...");
                    AddonPublic.AddDirectory(AppDirectory);
                    string libPathString = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
                    if (!libPathString.IsNullOrEmpty()) {
                        string[] libPaths = libPathString.Split(';');
                        foreach (var libDir in libPaths) {
                            var libPath = GetAbsolutePath(libDir);
                            AddonPublic.AddDirectory(libPath);
                        }
                    }
                    LogPublic.LogInformation("插件加载完毕.");
                });
                #endregion 插件

                #region 日志
                TransactionPublic.Run("准备日志", () =>
                {
                     if (!LoggerList.IsNullOrEmpty()) {
                         LogPublic.ClearLogger();
                         foreach (var logger in LoggerList) {
                             var logObj = logger.Value;
                             LogPublic.AddLogger(logObj);
                         }
                     }
                 });
                #endregion 日志

                #region 服务
                TransactionPublic.Run("启动服务", () =>
                {
                    if (!ServerList.IsNullOrEmpty()) {
                        foreach (var server in ServerList) {
                            var serverObj = server.Value;
                            if (serverObj == null)
                                throw new Exception("服务创建失败");
                            serverObj.Start();
                            LogPublic.LogInformation("服务{0}启动完毕.", serverObj.ObjectToString());
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
        /// <summary>
        /// 程序退出
        /// </summary>
        protected virtual void OnException(Exception err) {
            throw err;
        }

        protected virtual void OnRunning() {

        }
    }
}
