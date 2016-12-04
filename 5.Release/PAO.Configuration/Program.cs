using DevExpress.Skins;
using PAO;
using PAO.App;
using PAO.Config;
using PAO.Config.Controllers;
using PAO.Configuration.Properties;
using PAO.Event;
using PAO.UI.WinForm.MDI;
using PAO.UI.WinForm.MDI.DockPanels;
using PAO.UI.WinForm.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                , Settings.Default.ConfigStart ? (Func<PaoApplication>)null : CreateApplication);
        }


        private static PaoApplication CreateApplication() {
            var app = new MDIApplication()
            {
                Caption = "系统配置程序",
                ClientID = "PAO_Config",
                EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>()
                    .Append(DebugLogger.Default.ToRef())
                    .Append(EventLogger.Default.ToRef()),
                ExtendPropertyStorage = new FileExtendPropertyStorage()
                {
                    FilePath = "ExtendProperties.config"
                }.ToRef(),
                ExtendMenuItems = new List<Ref<UI.WinForm.MVC.Controller>>()
                    .Append(new Controller()
                    {
                        ID = "MenuConfig",
                        Caption = "功能配置",
                        ChildFunctionItems = new List<Ref<Controller>>()
                        .Append(new ObjectConfigController()
                        {
                            Caption = "主功能配置",
                        }.ToRef()),
                    }.ToRef()),
                AutoRunControllers = new List<Ref<Controller>>()
                    .Append(new TreeMenuController()
                    {
                        Caption = "菜单",
                        DockPanelID = new Guid("{20E5F90B-4356-4FFF-B454-5175C8F378A7}"),
                        MenuItems = new List<Ref<Controller>>()
                            .Append(new AddonFactory<Controller>()
                            {
                                AddonID = "MenuConfig",
                            }),
                    }.ToRef()),
            };
            return app;
        }

    }
}
