using PAO.App;
using PAO.RemoteOperationWeb.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PAO.RemoteOperationWeb {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(AppPublic.DefaultConfigFileName
                , Settings.Default.ConfigStart ? (Func<PaoApplication>)null : CreateApplication);
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }

        private static PaoApplication CreateApplication() {
            var app = new PaoApplication();
            return app;
        }
    }
}