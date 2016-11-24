using PAO.Log;
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
    /// 类：PaoApplication
    /// Pao应用
    /// 包含了Pao框架启动所需的基本功能
    /// 作者：PAO
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
        #region 属性：ClientID
        /// <summary>
        /// 属性：ClientID
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
        #endregion 属性：ClientID
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

        public PaoApplication() {
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
        public void Run() {
            // 一个应用中只能有一个默认应用程序
            Default = this;
            try {
                LogPublic.LogInformation("PAO应用启动");
                OnStart();
                
                _AppDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

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

                LogPublic.LogInformation("程序开始运行...");
                OnRunning();
                LogPublic.LogInformation("程序运行完毕.");
            } catch (Exception err) {
                LogPublic.LogException(err);
                OnException(err);
            } finally {
                OnExit();
                LogPublic.LogInformation("PAO应用退出");
            }
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
        }
        /// <summary>
        /// 程序退出
        /// </summary>
        protected virtual void OnExit() {
        }
        /// <summary>
        /// 程序运行
        /// </summary>
        protected virtual void OnRunning() {
        }
    }
}
