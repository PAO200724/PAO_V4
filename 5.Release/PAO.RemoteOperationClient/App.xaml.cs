﻿using PAO.App;
using PAO.RemoteOperationClient.Properties;
using PAO.Test;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace PAO.RemoteOperationClient {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(AppPublic.DefaultConfigFileName
                , Settings.Default.ConfigStart? (Func<PaoApplication>)null : CreateApplication);
        }

        private static PaoApplication CreateApplication() {
            var app = new PaoApplication() {

            };
            return app;
        }
    }
}
