using PAO.Event;
using PAO.IO;
using PAO.Trans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.App {
    /// <summary>
    /// 静态类:AppPublic
    /// 应用工具类
    /// 作者:PAO
    /// </summary>
    public static class AppPublic {
        public const string DefaultConfigFileName = "PAO.config";

        /// <summary>
        /// 应用程序目录
        /// </summary>
        private static string _AppDirectory;
        public static string AppDirectory {
            get {
                return _AppDirectory;
            }
        }
        #region 应用程序路径
        /// <summary>
        /// 获取绝对路径
        /// </summary>
        /// <param name="relatedPath">相对路径</param>
        /// <returns>绝对路径</returns>
        public static string GetAbsolutePath(string relatedPath) {
            return Path.Combine(AppDirectory, relatedPath);
        }
        #endregion

        /// <summary>
        /// 启动应用程序
        /// </summary>
        /// <param name="loadFromConfig">从配置加载</param>
        /// <param name="configFileName">配置文件名，此文件应该放于应用程序目录</param>
        /// <param name="createApplicationFunc">应用创建函数</param>
        /// <param name="applicationPrepareFunc">准备应用程序</param>
        /// <param name="overwriteConfigFile">覆盖配置文件</param>
        public static void StartApplication(bool loadFromConfig
            , string configFileName
            , Func<PaoApplication> createApplicationFunc
            , Action<PaoApplication> applicationPrepareFunc
            , bool overwriteConfigFile = false) {

            _AppDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string configFilePath = Path.Combine(_AppDirectory, configFileName);
            
            //首先添加默认的日志记录器
            EventPublic.ClearEventProcessor();
            EventPublic.AddEventProcessor(DebugLogger.Default);
            EventPublic.AddEventProcessor(EventLogger.Default);
            PaoApplication app = null;

            TransactionPublic.Run("插件引擎启动", () => {
                TransactionPublic.Run("加载插件库", () =>
                {
                    AddonPublic.AddDirectory(AppDirectory);
                    string libPathString = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
                    if (!libPathString.IsNullOrEmpty()) {
                        string[] libPaths = libPathString.Split(';');
                        foreach (var libDir in libPaths) {
                            var libPath = GetAbsolutePath(libDir);
                            AddonPublic.AddDirectory(libPath);
                        }
                    }
                    // 重建插件类型列表
                    AddonPublic.RebuildAddonTypeList();
                });

                TransactionPublic.Run("加载配置", () =>
                {
                    if(createApplicationFunc == null)
                        throw new Exception("创建配置的方法不能为空");

                    if (loadFromConfig && !File.Exists(configFilePath)) {
                        app = IOPublic.ReadObjectFromFile(configFilePath).As<PaoApplication>();
                    }
                    else { 
                        // 用应用创建函数启动应用
                        app = createApplicationFunc();
                        if(overwriteConfigFile || !File.Exists(configFilePath)) {
                            // 保存配置文件
                            IOPublic.WriteObjectToFile(configFilePath, app);
                        }
                    }

                    if(applicationPrepareFunc != null) {
                        applicationPrepareFunc(app);
                    }
                });
            });

            app.Start();
        }       
    }
}
