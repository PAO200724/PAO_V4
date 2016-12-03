using PAO.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PAO;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
using PAO.UI;
using PAO.Config;
using PAO.App;
using PAO.Config.Controls;
using PAO.Data;
using PAO.Config.Controls.EditControls;
using PAO.Remote.Tcp;
using TestLibrary;

namespace WinFormTest
{
    public partial class MainForm : XtraForm
    {
        public MainForm() {
            InitializeComponent();
        }

        private void ButtonTestInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var eventInfo = new EventInfo(EventInfo.EventType_Information
                , "这是测试消息"
                , true
                , true);
            var eventControl = new EventControl();
            eventControl.Initialize(eventInfo);
            UIPublic.ShowDialog(eventControl);

        }

        private void ButtonTestException_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var eventInfo = new ExceptionEventInfo(new Exception("这是测试消息")
                , true
                , true).AddEventData("测试", "测试");
            var eventControl = new EventControl();
            eventControl.Initialize(eventInfo);
            UIPublic.ShowDialog(eventControl);
        }

        private void ButtonConfigTools_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var objectTreeControl = new ObjectTreeEditControl();
            objectTreeControl.SelectedObject = PaoApplication.Default;
            UIPublic.ShowDialog(objectTreeControl);
        }

        private void ButtonAddonSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var typeSelectControl = new TypeSelectControl();
            typeSelectControl.Initialize(p=>
            {
                return p.IsDerivedFrom<IDataFilter>();
            });
            UIPublic.ShowDialog(typeSelectControl);
        }

        private void ButtonCallRemote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var testService = new TcpRemoteFactory<ITestService>() {
                ServerAddress = "localhost:7990",
                ServiceName = "TestService"
            }.Value;
            UIPublic.ShowInfomationDialog(testService.GetString("Hello world!"));
        }

        private void ButtonRemoteException_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                var testService = new TcpRemoteFactory<ITestService>()
                {
                    ServerAddress = "localhost:7990",
                    ServiceName = "TestService"
                }.Value;
                testService.GetString("Exception");
            } catch (Exception err) {
                UIPublic.ShowExceptionDialog(err);
            }
        }
    }
}
