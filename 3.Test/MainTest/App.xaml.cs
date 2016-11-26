using MainTest.Properties;
using PAO.App;
using PAO.Trans;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MainTest {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(AppPublic.DefaultConfigFileName
                , Settings.Default.ConfigStart ? (Func<PaoApplication>)null : CreateApplication);
        }

        private static PaoApplication CreateApplication() {
            var app = new PaoApplication()
            {
                RunAction = () =>
                {
                    // 执行工作
                    TransactionPublic.Run("客户端程序", ()=>
                    {
                        var testClient = new TestService.TestServiceClient();
                        testClient.DoWork(PaoTransaction.Current);
                    });
                }
            };
            return app;
        }
    }
}
