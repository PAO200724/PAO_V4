using PAO;
using PAO.App;
using PAO.Config;
using PAO.Configuration.Properties;
using PAO.Event;
using PAO.UI.WinForm.MDI;
using PAO.UI.WinForm.MDI.DockViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PAO.UI.MVC;
using PAO.Config.Views;
using PAO.Remote.Tcp;
using PAO.Security;
using PAO.Report.Displayers;
using PAO.Report;
using PAO.Report.Views;
using PAO.Report.Fetchers;
using PAO.Data;

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

        }


        private static PaoApplication CreateApplication() {
            var app = new MDIApplication()
            {
                ID = "ConfigApplication",
                Caption = "系统配置程序",
                ClientID = "PAO_Config",
                EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>()
                    .Append(DebugLogger.Default.ToRef())
                    .Append(EventLogger.Default.ToRef()),
                SecurityService = new TcpRemoteFactory<ISecurity>()
                {
                    ServerAddress = "localhost:7990",
                    ServiceName = "SecurityService"
                },
                ExtendPropertyStorage = new FileExtendPropertyStorage()
                {
                    FilePath = "ExtendProperties.config"
                }.ToRef(),
                MenuItems = new List<Ref<UIItem>>()
                            .Append(new AddonFactory<UIItem>() { AddonID = "Menu_Config" }),
                Controllers = new List<Ref<BaseController>>()
                    .Append(new TreeMenuController()
                    {
                        Caption = "菜单",
                        ID = "{20E5F90B-4356-4FFF-B454-5175C8F378A7}",
                        MenuItems = new List<Ref<UIItem>>()
                            .Append(new UI.MVC.FolderItem()
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
                                        DataFetcher = new DataServiceFetcher()
                                        {
                                            DataService = new TcpRemoteFactory<IDataService>()
                                            {
                                                ServerAddress = "localhost:7990",
                                                ServiceName = "DataService",
                                            }
                                        }.ToRef(),
                                        QueryParameters = new List<ReportDataField>()
                                            .Append(new ReportDataField()
                                            {
                                                Name = "ID",
                                                Caption = "ID",
                                                Type = System.Data.DbType.String
                                            })
                                            .Append(new ReportDataField()
                                            {
                                                Name = "LoginName",
                                                Caption = "登录名",
                                                Type = System.Data.DbType.String
                                            })
                                            .Append(new ReportDataField()
                                            {
                                                Name = "Name",
                                                Caption = "姓名",
                                                Type = System.Data.DbType.String
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
                                Controllers = new List<Ref<BaseController>>()
                                    .Append(new GridControlController()
                                    {
                                        ID = "GridControl",
                                        Caption = "表格控件1",
                                    }.ToRef())
                                    .Append(new GridControlController()
                                    {
                                        ID = "GridControl2",
                                        Caption = "表格控件2",
                                    }.ToRef())
                                    .Append(new GridControlController()
                                    {
                                        ID = "GridControl3",
                                        Caption = "表格控件3",
                                    }.ToRef()),
                            }.ToRef()),
                    }.ToRef()),
            };
            return app;
        }

    }
}
