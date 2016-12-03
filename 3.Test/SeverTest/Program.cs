using PAO.App;
using PAO.Event;
using SeverTest.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PAO;
using PAO.Remote.Tcp;
using TestLibrary;

namespace SeverTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(AppPublic.DefaultConfigFileName
                , Settings.Default.ConfigStart ? (Func<PaoApplication>)null : CreateApplication);
        }

        private static PaoApplication CreateApplication() {
            var app = new PaoApplication()
            {
                EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>()
                    .Append(DebugLogger.Default.ToRef())
                    .Append(EventLogger.Default.ToRef()),
                ServerList = new List<PAO.Ref<PAO.Server.BaseServer>>()
                    .Append(new RemoteTcpServer()
                    {
                        Port = 7990,
                        ServiceList = new Dictionary<string, Ref<PaoObject>>()
                             .Append("TestService", new TestService().ToRef()),
                    }.ToRef()),
                RunAction = () =>
                {
                    Application.Run(new MainForm());
                }
            };
            return app;
        }
    }
}
