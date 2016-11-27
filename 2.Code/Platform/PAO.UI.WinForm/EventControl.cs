using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.Event;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 事件控件
    /// 显示事件信息
    /// </summary>
    public partial class EventControl : DevExpress.XtraEditors.XtraUserControl
    {
        public EventInfo EventInfo { get; private set; }

        public EventControl() {
            InitializeComponent();
        }

        public void Initialize(EventInfo eventInfo) {
            EventInfo = eventInfo;
            this.TextEditSource.Text = EventInfo.Source;
            this.TextEditMessage.Text = EventInfo.Message;
            this.TextEditTime.Text = EventInfo.Time.ToString();
            this.TextEditType.Text = EventInfo.ExceptionType == null ? EventInfo.Type : EventInfo.Type + " : " + EventInfo.ExceptionType.Name;
            this.MemoEditDetail.Text = EventInfo.DetailInformation.ToString();
            // 数据
            if (EventInfo.Data.IsNotNullOrEmpty()) {
                this.GridControlData.DataSource = this.EventInfo.Data.Select(p => new
                {
                    Key = p.Key,
                    Value = p.Value
                });
            }
            if (EventInfo.ScreenShot != null) {
                this.PictureEditScreenShot.Image = EventInfo.ScreenShot;
            } else {
                this.LayoutControlGroupScreenShot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (EventInfo.AssetSnapshot != null) {
                // TODO: 此处显示资产快照
            }
            else {
                this.LayoutControlItemAssetSnapshot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
    }
}
