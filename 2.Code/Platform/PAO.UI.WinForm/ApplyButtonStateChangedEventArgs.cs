using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 应用按钮状态变化事件参数
    /// </summary>
    public class ApplyButtonStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 是否生效
        /// </summary>
        public bool Enabled { get; set; }

        public ApplyButtonStateChangedEventArgs() {

        }
    }
}
