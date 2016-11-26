using PAO.IO;
using PAO.IO.Text;
using PAO.Log;
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
        public const string DefaultConfigFileName = "pao.config";
        /// <summary>
        /// 启动应用程序
        /// </summary>
        /// <param name="configFileName">配置文件名，此文件应该放于应用程序目录</param>
        /// <param name="createApplicationFunc">应用创建函数</param>
        public static void StartApplication(string configFileName = DefaultConfigFileName
            , Func<PaoApplication> createApplicationFunc = null) {
            string appDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string configFilePath = Path.Combine(appDir, configFileName);
            PaoApplication app;
            if (createApplicationFunc == null) {
                app = TextPublic.ReadObjectFromFile(configFilePath).As<PaoApplication>();
            } else {
                LogPublic.LogInformation("开始创建应用配置...");
                // 用应用创建函数启动应用
                app = createApplicationFunc();
                // 保存配置文件
                LogPublic.LogInformation("开始保存应用配置...");
                TextPublic.WriteObjectToFile(configFilePath, app);
                LogPublic.LogInformation("应用配置保存完毕.");
            }
            app.Start();
        }
    }
}
