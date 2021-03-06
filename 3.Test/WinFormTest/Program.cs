﻿using PAO.App;
using PAO.UI;
using PAO.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTest.Properties;
using PAO;
using PAO.Event;
using System.Diagnostics;
using PAO.Data;
using PAO.Remote.Tcp;
using TestLibrary;
using PAO.IO;
using PAO.Config;
using PAO.Data.Filters;

namespace WinFormTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            UIPublic.DefaultUserInterface = new WinFormUI();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Test();
            // 应用程序启动时创建PaoApplication
            AppPublic.StartApplication(Settings.Default.ConfigStart
                , AppPublic.DefaultConfigFileName
                , CreateApplication
                , PrepareAppliation);
        }

        private static void PrepareAppliation(PaoApplication app) {

        }

        private static PaoApplication CreateApplication() {
            var app = new PaoApplication()
            {
                EventProcessorList = new List<PAO.Ref<BaseEventProcessor>>()
                    .Append(DebugLogger.Default.ToRef())
                    .Append(EventLogger.Default.ToRef()),
                ServerList = new List<PAO.Ref<PAO.Server.BaseServer>>()
                    .Append(new RemoteTcpServer()
                    {
                        Port = 7991,
                        ServiceList = new Dictionary<string, Ref<PaoObject>>()
                             .Append("TestService", new TestService().ToRef()),
                    }.ToRef()),
                RunAction = () =>
                {
                    Application.Run(new MainForm());
                }
            };
            return app;
        }

        private static void Test() {
            SerializeTest();
            GenericTypeTest();
            AddonTest();
        }

        private static void SerializeTest() {


        }

        private static void AddonTest() {
            Test("typeof(PaoObject).IsAddon()", typeof(PaoObject).IsAddon());

            Test("typeof(Ref<PaoObject>).IsAddon()", typeof(Ref<PaoObject>).IsAddon());

            Test("typeof(Factory<PaoObject>).IsAddon()", typeof(Factory<PaoObject>).IsAddon());

            Test("typeof(Ref<IDataFilter>).IsAddon()", typeof(Ref<DataFilter>).IsAddon());

            Test("typeof(List<IDataFilter>).IsAddon()", typeof(List<DataFilter>).IsAddon());

            Test("typeof(List<Ref<IDataFilter>>).IsAddon()", typeof(List<Ref<DataFilter>>).IsAddon());

            Test("typeof(List<List<Ref<IDataFilter>>>).IsAddon()", typeof(List<List<Ref<DataFilter>>>).IsAddon());

            Test("typeof(object).IsAddon()", typeof(object).IsAddon());
        }

        private static void GenericTypeTest() {
            Test("typeof(Factory<>).IsGenericTypeDefinition", typeof(Factory<>).IsGenericTypeDefinition);

            Test("typeof(Factory<>).BaseType", typeof(Factory<>).BaseType);
            Test("typeof(Factory<>).BaseType == typeof(Ref<>)", typeof(Factory<>).BaseType == typeof(Ref<>));
            Test("typeof(Factory<>).BaseType.GetGenericTypeDefinition() == typeof(Ref<>).GetGenericTypeDefinition()", typeof(Factory<>).BaseType.GetGenericTypeDefinition() == typeof(Ref<>).GetGenericTypeDefinition());
            Test("typeof(Factory<>).GetGenericTypeDefinition().IsAssignableFrom(typeof(Ref<>).GetGenericTypeDefinition())", typeof(Factory<>).GetGenericTypeDefinition().IsAssignableFrom(typeof(Ref<>).GetGenericTypeDefinition()));

            Test("typeof(Ref<>).IsAssignableFrom(typeof(PaoApplication))", typeof(Ref<>).IsAssignableFrom(typeof(PaoApplication)));
            Test("typeof(PaoApplication).IsAssignableFrom(typeof(Ref<>))", typeof(PaoApplication).IsAssignableFrom(typeof(Ref<>)));
            Test("typeof(Ref<>).IsAssignableFrom(typeof(Factory<>)))", typeof(Ref<>).IsAssignableFrom(typeof(Factory<>)));
            Test("typeof(Ref<>).IsAssignableFrom(typeof(Factory<object>)))", typeof(Ref<>).IsAssignableFrom(typeof(Factory<object>)));
            Test("typeof(Ref<object>).IsAssignableFrom(typeof(Factory<object>)))", typeof(Ref<object>).IsAssignableFrom(typeof(Factory<object>)));
            Test("typeof(Ref<string>).IsAssignableFrom(typeof(Factory<object>)))", typeof(Ref<string>).IsAssignableFrom(typeof(Factory<object>)));

            Test("typeof(PaoObject[]).ToString()", typeof(PaoObject[]).ToString());
            Test("typeof(List<PaoObject>).ToString()", typeof(List<PaoObject>).ToString());
            Test("typeof(List<PaoObject>).FullName", typeof(List<PaoObject>).FullName);
            Test("typeof(List<PaoObject>).Name", typeof(List<PaoObject>).Name);
            Test("typeof(List<PaoObject>).AssemblyQualifiedName", typeof(List<PaoObject>).AssemblyQualifiedName);

            Test("typeof(List<PaoObject>).GetTypeString()", typeof(List<PaoObject>).GetTypeString());
            Test("typeof(Dictionary<string,PaoObject>).GetTypeString()", typeof(Dictionary<string, PaoObject>).GetTypeString());
            Test("typeof(List<List<Ref<IDataFilter>>>).GetTypeString()", typeof(List<List<Ref<DataFilter>>>).GetTypeString());
            Test("typeof(List<Dictionary<string,Ref<IDataFilter>>>).GetTypeString()", typeof(List<Dictionary<string, Ref<DataFilter>>>).GetTypeString());
        }

        private static void Test(string testString, object resultObject) {
            Debug.WriteLine("{0}={1}", testString, resultObject);
        }
    }
}
