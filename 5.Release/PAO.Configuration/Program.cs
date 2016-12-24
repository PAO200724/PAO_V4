using PAO;
using PAO.App;
using PAO.Config;
using PAO.Configuration.Properties;
using PAO.Event;
using PAO.App.MDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PAO.MVC;
using PAO.Config.Views;
using PAO.Remote.Tcp;
using PAO.Security;
using PAO.Report.Displayers;
using PAO.Report;
using PAO.Report.Views;
using PAO.Data;
using PAO.Data.DataFetchers;
using PAO.Time;
using PAO.Config.DockViews;
using PAO.WinForm;
using PAO.App.MDI.DockViews;
using PAO.Data.Filters;

namespace PAO.Configuration
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
            DevExpress.UserSkins.BonusSkins.Register();
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(Settings.Default.ConfigStart
                , AppPublic.DefaultConfigFileName
                , CreateApplication
                , PrepareAppliation);
        }

        private static void PrepareAppliation(PaoApplication app) {
            ExtendConfigPublic.RegisterEditors();
        }

        

        private static PaoApplication CreateApplication() {
            var app = new MDIApplication()
            {
                ID = "ConfigApplication",
                Caption = "系统配置程序",
                SoftwareID = "PAO_Config",
                DateTimeService = new TcpRemoteFactory<IDateTime>()
                {
                    ServerAddress = "localhost:7990",
                    ServiceName = "DateTimeService"
                },
                EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>()
                    .Append(DebugLogger.Default.ToRef()),
                SecurityService = new TcpRemoteFactory<ISecurity>()
                {
                    ServerAddress = "localhost:7990",
                    ServiceName = "SecurityService"
                },
                ExtendConfigFile = "ExtendProperties.config",
                ExtendAddonList = new List<PaoObject>()
                    .Append(new TcpRemoteFactory<IDataService>()
                    {
                        ID = "CommonDataService",
                        ServerAddress = "localhost:7990",
                        ServiceName = "DataService",
                    }),
                MenuItems = new List<Ref<UIItem>>()
                            .Append(new AddonFactory<UIItem>() { AddonID = "Menu_Config" }),
                Controllers = new List<Ref<BaseController>>()
                    .Append(new TreeMenuController()
                    {
                        Caption = "菜单",
                        ID = "{20E5F90B-4356-4FFF-B454-5175C8F378A7}",
                        MenuItems = new List<Ref<UIItem>>()
                            .Append(new FolderItem()
                            {
                                ID = "Menu_Config",
                                Caption = "配置菜单",
                                ChildItems = new List<Ref<IUIItem>>()
                                    .Append(new ObjectConfigController()
                                    {
                                        Caption = "主配置",
                                    }.ToRef())
                            }.ToRef())
                            .Append(new ReportController()
                            {
                                ID = "Smart_Report",
                                Caption = "智能报表",
                                Tables = new List<ReportDataTable>()
                                    .Append(new ReportDataTable()
                                    {
                                        TableName = "User",
                                        Caption = "用户",
                                        DataFetcher = new RemoteDataServiceFetcher()
                                        {
                                            DataService = new AddonFactory<IDataService>("CommonDataService"),
                                            CommandID = "Command_QueryUsers",
                                        }.ToRef(),
                                        QueryParameters = new List<ReportQueryParameter>()
                                            .Append(new ReportQueryParameter()
                                            {
                                                Name = "@ID",
                                                Caption = "ID",
                                                Type = System.Data.DbType.String,
                                                UserInput = true
                                            })
                                            .Append(new ReportQueryParameter()
                                            {
                                                Name = "@LoginName",
                                                Caption = "登录名",
                                                Type = System.Data.DbType.String,
                                                UserInput = true
                                            })
                                            .Append(new ReportQueryParameter()
                                            {
                                                Name = "@Name",
                                                Caption = "姓名",
                                                Type = System.Data.DbType.String,
                                                UserInput = true
                                            })
                                            .Append(new ReportQueryParameter()
                                            {
                                                Name = "@Tel",
                                                Caption = "电话",
                                                Type = System.Data.DbType.String,
                                                UserInput = true
                                            })
                                            .Append(new ReportQueryParameter()
                                            {
                                                Name = "@Email",
                                                Caption = "电子邮箱",
                                                Type = System.Data.DbType.String,
                                                UserInput = true
                                            }),
                                        DataColumns = new List<ReportDataColumn>()
                                            .Append(new ReportDataColumn()
                                            {
                                                Name = "ID",
                                                Caption = "ID",
                                                Type = System.Data.DbType.String
                                            })
                                            .Append(new ReportDataColumn()
                                            {
                                                Name = "LoginName",
                                                Caption = "登录名",
                                                Type = System.Data.DbType.String
                                            })
                                            .Append(new ReportDataColumn()
                                            {
                                                Name = "Name",
                                                Caption = "姓名",
                                                Type = System.Data.DbType.String
                                            })
                                    }),
                                Displayers = new List<Ref<BaseDataDisplayerController>>()
                                    .Append(new GridControlController()
                                    {
                                        ID = "GridControl1",
                                        Caption = "表格控件1",
                                        DataMember = "User",
                                    }.ToRef())
                                    .Append(new GridControlController()
                                    {
                                        ID = "GridControl2",
                                        Caption = "表格控件2",
                                        DataMember = "User",
                                        GridViewType = GridViewType.AdvancedBandedView
                                    }.ToRef()),
                            }.ToRef()),
                    }.ToRef()),

            };
            return app;
        }

    }
}
