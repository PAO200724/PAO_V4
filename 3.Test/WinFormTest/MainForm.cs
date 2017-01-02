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
using PAO.WinForm.Controls;
using PAO.UI;
using PAO.Config;
using PAO.App;
using PAO.Config.Controls;
using PAO.Data;
using PAO.Config.Editor;
using PAO.Remote.Tcp;
using TestLibrary;
using PAO.WinForm;
using PAO.Data.Filters;

namespace WinFormTest
{
    public partial class MainForm : XtraForm
    {
        public MainForm() {
            InitializeComponent();
        }

        private void ButtonTestInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            EventControl eventControl = null;
            UIPublic.ShowWaitingForm();
            var eventInfo = new EventInfo(EventInfo.EventType_Information
                , "这是测试消息"
                , true
                , true);
            eventControl = new EventControl();
            eventControl.Initialize(eventInfo);
            UIPublic.CloseWaitingForm();

            WinFormPublic.ShowDialog(eventControl);

        }

        private void ButtonTestException_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.ShowWaitingForm();
            var eventInfo = new ExceptionEventInfo(new Exception("这是测试消息")
                , true
                , true).AddEventData("测试", "测试");
            var eventControl = new EventControl();
            eventControl.Initialize(eventInfo);
            UIPublic.CloseWaitingForm();
            WinFormPublic.ShowDialog(eventControl);
        }

        private void ButtonConfigTools_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.ShowWaitingForm();
            var objectTreeControl = new ObjectTreeEditControl();
            objectTreeControl.EditValue = PaoApplication.Default;
            UIPublic.CloseWaitingForm();
            WinFormPublic.ShowDialog(objectTreeControl);
        }

        private void ButtonAddonSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.ShowWaitingForm();
            var typeSelectControl = new TypeSelectControl();
            typeSelectControl.Initialize(p=>
            {
                return p.IsDerivedFrom<DataFilter>();
            });
            UIPublic.CloseWaitingForm();
            WinFormPublic.ShowDialog(typeSelectControl);
        }

        private void ButtonCallRemote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.ShowWaitingForm();
            string resultString = "";
            var task = Task.Factory.StartNew(() =>
            {
                var testService = new TcpRemoteFactory<ITestService>()
                {
                    ServerAddress = "localhost:7990",
                    ServiceName = "TestService"
                }.Value;
                resultString = testService.GetString("Hello world!");
            });
            task.Wait();
            UIPublic.CloseWaitingForm();
            UIPublic.ShowInfomationDialog(resultString);
        }

        private void ButtonRemoteException_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.ShowWaitingForm();
            try {
                var testService = new TcpRemoteFactory<ITestService>()
                {
                    ServerAddress = "localhost:7990",
                    ServiceName = "TestService"
                }.Value;
                testService.GetString("Exception");
            } catch (Exception err) {
                UIPublic.CloseWaitingForm();
                UIPublic.ShowEventDialog(new ExceptionEventInfo(err, true, true));
            }
        }
    }
}
