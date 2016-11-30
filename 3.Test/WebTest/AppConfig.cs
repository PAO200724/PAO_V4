using PAO;
using PAO.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestLibrary;

namespace WebTest
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
                ServiceList = new Dictionary<string, Ref<PaoObject>>()
                     .Append("TestService", new TestService()),
            };
            return app;
        }
    }
}