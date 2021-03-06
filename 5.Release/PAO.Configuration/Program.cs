﻿using PAO;
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
using PAO.Data.ValueFetchers;
using PAO.Report.ValueFetchers;

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
                                Tables = new List<ReportTableController>()
                                    .Append(new ReportTableController()
                                    {
                                        ID = "Smart_Report_User",
                                        TableName = "User",
                                        Caption = "用户",
                                        DataFetcher = new RemoteDataServiceFetcher()
                                        {
                                            DataService = new AddonFactory<IDataService>("CommonDataService"),
                                            CommandID = "Command_QueryUser",
                                        }.ToRef(),
                                        ChildTables = new List<ReportTableController>()
                                            .Append(new ReportTableController()
                                                {
                                                    ID = "Smart_Report_Child_User",
                                                    TableName = "User1",
                                                    Caption = "用户1",
                                                    DataFetcher = new RemoteDataServiceFetcher()
                                                    {
                                                        DataService = new AddonFactory<IDataService>("CommonDataService"),
                                                        CommandID = "Command_QueryUserByID",
                                                    }.ToRef(),
                                                    QueryParameters = new List<DataParameter>()
                                                        .Append(new DataParameter()
                                                        {
                                                            Name = "@ID",
                                                            ValueFetcher = new BindingSourceValueFetcher()
                                                            {
                                                                FieldName = "ID"
                                                            }
                                                        }),
                                            }),
                                    }).Append(new ReportTableController()
                                    {
                                        ID = "Smart_Report_Config",
                                        TableName = "Config",
                                        Caption = "配置",
                                        DataFetcher = new RemoteDataServiceFetcher()
                                        {
                                            DataService = new AddonFactory<IDataService>("CommonDataService"),
                                            CommandID = "Command_QueryConfig",
                                        }.ToRef(),
                                        QueryParameters = new List<DataParameter>()
                                            .Append(new DataParameter()
                                            {
                                                Name = "@TimeStart",
                                                DbType = System.Data.DbType.DateTime
                                            })
                                            .Append(new DataParameter()
                                            {
                                                Name = "@TimeEnd",
                                                DbType = System.Data.DbType.DateTime
                                            }),
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
