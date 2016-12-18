using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.MVC
{
    /// <summary>
    /// 视图动作事件参数
    /// </summary>
    public class UIActionEventArgs : EventArgs
    {
        /// <summary>
        /// 动作名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 动作参数
        /// </summary>
        public IEnumerable<object> ActionParameters { get; set; }
    }
}
