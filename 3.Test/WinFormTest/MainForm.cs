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

namespace WinFormTest
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
        }

        private void ButtonTestInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var form = new EventTestForm();
            form.Initialize(new EventInfo(EventInfo.EventType_Information
                , "这是测试消息"
                , true
                , true));
            form.ShowDialog();
        }

        private void ButtonTestException_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var form = new EventTestForm();
            form.Initialize(new ExceptionEventInfo(new Exception("这是测试消息")
                , true
                , true).AddEventData("测试", "测试"));
            form.ShowDialog();
        }
    }
}
