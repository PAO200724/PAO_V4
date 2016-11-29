using PAO.App;
using PAO.UI;
using PAO.UI.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTest.Properties;

namespace WinFormTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            UIPublic.DefaultUserInterface = new DevExpressUI();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(AppPublic.DefaultConfigFileName
                , Settings.Default.ConfigStart ? (Func<PaoApplication>)null : CreateApplication);
        }

        private static PaoApplication CreateApplication() {
            var app = new PaoApplication()
            {
                RunAction = () =>
                {
                    Application.Run(new MainForm());
                }
            };
            return app;
        }
    }
}
