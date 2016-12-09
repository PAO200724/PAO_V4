﻿using PAO;
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
using PAO.Config.Commands;
using PAO.Remote.Tcp;
using PAO.Security;
using PAO.UI.WinForm.MDI.Views;
using PAO.UI.WinForm.MDI.Commands;

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
            AppPublic.StartApplication(AppPublic.DefaultConfigFileName
                , Settings.Default.ConfigStart ? (Func<PaoApplication>)null : CreateApplication
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

                Commands = new List<Ref<ICommand>>()
                    .Append(new MenuCommand()
                    {
                        MenuItems = new List<Ref<UIItem>>()
                            .Append(new AddonFactory<UIItem>() { AddonID = "Menu_Config" })
                    }.ToRef())
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
                                    .Append(new ObjectConfigCommand()
                                    {
                                        Caption = "主配置",
                                    }.ToRef())
                            }.ToRef())
                            .Append(new GridControlController()
                            {
                                Caption = "表格视图"
                            }.ToRef()),
                    }.ToRef()),
            };
            return app;
        }

    }
}
