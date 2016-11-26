using PAO.App;
using PAO.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAO.RemoteOperationClient
{
    /// <summary>
    /// 类：App
    /// 应用程序创建类
    /// 作者：PAO
    /// </summary>
    public static class AppConfig
    { 
        public static PaoApplication CreateApplication() {
            var app = new PaoApplication()
            {
            };
            return app;
        }
    }
}