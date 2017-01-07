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
using System.Data;
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
            Name = "查询用户",
            Sql = @"SELECT * FROM T_User WHERE {0}",
            DataFilter = new Sql("ID LIKE @ID")
                & new Sql("Name LIKE @Name")
                & new Sql("LoginName LIKE @LoginName")
                & new Sql("Tel LIKE @Tel")
                & new Sql("Email LIKE @Email"),
        };
        private static readonly DataCommandInfo Command_QueryUserByID = new DataCommandInfo()
        {
            ID = "Command_QueryUserByID",
            Name = "根据ID查询用户",
            Sql = @"SELECT * FROM T_User WHERE ID = @ID"
        };
        private static readonly DataCommandInfo Command_QueryConfig = new DataCommandInfo()
        {
            ID = "Command_QueryConfig",
            Name = "查询配置",
            Sql = @"SELECT * FROM T_Config WHERE {0}",
            DataFilter = new Sql("SoftwareID LIKE @SoftwareID")
                & new Sql("ComputerID LIKE @ComputerID")
                & new Sql("ConfigName LIKE @ConfigName")
                & new Sql("EnabledTime <= @TimeStart AND DisabledTime > @TimeEnd"),
            Parameters = new List<DataParameter>()
                .Append(new DataParameter("@TimeStart", DbType.DateTime))
                .Append(new DataParameter("@TimeEnd", DbType.DateTime))
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
                    .Append(Command_QueryUserByID)
                    .Append(Command_QueryConfig)
            };
        }
    }
}
