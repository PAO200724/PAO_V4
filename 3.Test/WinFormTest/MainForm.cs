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

namespace WinFormTest
{
    public partial class MainForm : XtraForm
    {
        public MainForm() {
            InitializeComponent();
        }

        private void ButtonTestInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.WaitForRunning(() =>
            {
                var eventInfo = new EventInfo(EventInfo.EventType_Information
                    , "这是测试消息"
                    , true
                    , true);
                var eventControl = new EventControl();
                eventControl.Initialize(eventInfo);
                UIPublic.ShowDialog(eventControl);
            });

        }

        private void ButtonTestException_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.WaitForRunning(() =>
            {
                var eventInfo = new ExceptionEventInfo(new Exception("这是测试消息")
                    , true
                    , true).AddEventData("测试", "测试");
                var eventControl = new EventControl();
                eventControl.Initialize(eventInfo);
                UIPublic.ShowDialog(eventControl);
            });
        }

        private void ButtonConfigTools_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.WaitForRunning(() =>
            {
                var objectTreeControl = new ObjectTreeControl();
                objectTreeControl.SelectedObject = PaoApplication.Default;
                UIPublic.ShowDialog(objectTreeControl);
            });
        }
    }
}
