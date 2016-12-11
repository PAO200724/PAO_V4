using PAO.App;
using PAO.App.Server;
using PAO.App.Server.Security;
using PAO.Data;
using PAO.Event;
using PAO.Remote.Tcp;
using PAO.Server.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PAO.Server
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
            AppPublic.StartApplication(Settings.Default.ConfigStart
                , AppPublic.DefaultConfigFileName
                , CreateApplication
                , PrepareAppliation);
        }

        private static void PrepareAppliation(PaoApplication app) {
            app.RunAction = () =>
            {
                Application.Run(new MainForm());
            };
        }


        private static PaoApplication CreateApplication() {
            var app = new ServerApplication()
            {
                EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>()
                    .Append(DebugLogger.Default.ToRef())
                    .Append(EventLogger.Default.ToRef()),
                ExtendPropertyStorage = new FileExtendPropertyStorage()
                {
                    FilePath = "ExtendProperties.config"
                }.ToRef(),
                DataService = CreateDataService().ToRef(),
                ServerList = new List<PAO.Ref<PAO.Server.BaseServer>>()
                    .Append(new RemoteTcpServer()
                    {
                        Port = 7990,
                        ServiceList = new Dictionary<string, Ref<PaoObject>>()
                             .Append("SecurityService", new SecurityService().ToRef())
                             .Append("DataService", new AddonFactory<PaoObject>("DataService")),
                    }.ToRef()),

            };
            return app;
        }

        private static DataService CreateDataService() {
            return new DataService()
            {
                ID = "DataService",
                DataConnection = new Data.DataConnection()
                {
                    ID = "PAO Db Connection",
                    DbFactoryName = "System.Data.SqlClient",
                    ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PAO.mdf;Integrated Security=True",
                    ParamPrefix = "@",
                }.ToRef(),
                CommandList = new List<DataCommandInfo>()
                            .Append(SecurityService.DataCommand_QueryUserByID)
                            .Append(SecurityService.DataCommand_QueryUserByName)
                            .Append(SecurityService.DataCommand_QueryUsers)
            };
        }
    }
}
