using PAO.App;
using PAO.App.Server;
using PAO.Config;
using PAO.Data;
using PAO.Data.Filters;
using PAO.Event;
using PAO.Ext.Security;
using PAO.Remote.Tcp;
using PAO.Server.Properties;
using PAO.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PAO.Server
{
    static class Program
    {
        #region Commands
        private static readonly DataCommandInfo Command_QueryUser = new DataCommandInfo()
        {
            ID = "Command_QueryUser",
            Sql = @"SELECT * FROM T_User WHERE {0}",
            DataFilter = new Filter("ID LIKE @ID")
                & new Filter("Name LIKE @Name")
                & new Filter("LoginName LIKE @LoginName")
                & new Filter("Tel LIKE @Tel")
                & new Filter("Email LIKE @Email"),
        };
        private static readonly DataCommandInfo Command_QueryConfig = new DataCommandInfo()
        {
            ID = "Command_QueryConfig",
            Sql = @"SELECT * FROM T_Config WHERE {0}",
            DataFilter = new Filter("SoftwareID LIKE @SoftwareID")
                & new Filter("ComputerID LIKE @ComputerID")
                & new Filter("ConfigName LIKE @ConfigName")
                & new Filter("EnabledTime <= @TimeStart AND DisabledTime > @TimeEnd"),
        };
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(Settings.Default.ConfigStart
                , AppPublic.DefaultConfigFileName
                , CreateApplication
                , PrepareAppliation);
        }


        private static void PrepareAppliation(PaoApplication app) {
        }

        private static PaoApplication CreateApplication() {
            var app = new ServerApplication()
            {
                EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>()
                    .Append(DebugLogger.Default.ToRef()),
                ExtendConfigFile = "ExtendProperties.config",
                DataService = CreateDataService().ToRef(),
                ServerList = new List<PAO.Ref<PAO.Server.BaseServer>>()
                    .Append(new RemoteTcpServer()
                    {
                        Port = 7990,
                        ServiceList = new Dictionary<string, Ref<PaoObject>>()
                             .Append("SecurityService", new SecurityService()
                             {
                                 DataService = new AddonFactory<DataService>("DataService")
                             }.ToRef())
                             .Append("DateTimeService", new DateTimeService().ToRef())
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
                    ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PAO.mdf;Integrated Security=True"
                }.ToRef(),
                CommandList = new List<DataCommandInfo>()
                    .Append(Command_QueryUser)
                    .Append(Command_QueryConfig)
            };
        }
    }
}
