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

namespace PAO.UI.WinForm.Controls
{
    /// <summary>
    /// 事件控件
    /// 显示事件信息
    /// </summary>
    public partial class EventControl : BaseDialogControl
    {
        private EventInfo _EventInfo;
        /// <summary>
        /// 事件信息
        /// </summary>
        public EventInfo EventInfo {
            get { return _EventInfo; }
            set { _EventInfo = value;
                Initialize(_EventInfo);
            }
        }

        public EventControl() {
            InitializeComponent();
            ShowApplyButton = false;
        }

        public void Initialize(EventInfo eventInfo) {
            _EventInfo = eventInfo;
            this.TextEditSource.Text = _EventInfo.Source;
            this.TextEditMessage.Text = _EventInfo.Message;
            this.TextEditTime.Text = _EventInfo.Time.ToString();
            this.TextEditType.Text = _EventInfo.Type;
            this.MemoEditDetail.Text = _EventInfo.DetailMessage;
            // 数据
            if (_EventInfo.Data.IsNotNullOrEmpty()) {
                this.GridControlData.DataSource = this._EventInfo.Data.Select(p => new
                {
                    Key = p.Key,
                    Value = p.Value
                });
            }
            if (_EventInfo.ScreenShot != null) {
                this.ImageControl.Image = _EventInfo.ScreenShot;
            } else {
                this.LayoutControlGroupScreenShot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (_EventInfo.AssetSnapshot != null) {
                // TODO: 此处显示资产快照
            }
            else {
                this.LayoutControlItemAssetSnapshot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
    }
}
