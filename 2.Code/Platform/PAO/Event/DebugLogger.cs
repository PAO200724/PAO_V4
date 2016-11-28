using PAO.Trans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Event {
    /// <summary>
    /// 类:DebugLog
    /// 调试记录器
    /// 将日志记录在调试窗口
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("调试记录器")]
    [Description("将日志记录在调试窗口")]
    public class DebugLogger : PaoObject, IEventProcess {
        /// <summary>
        /// 默认记录器
        /// </summary>
        public readonly static IEventProcess Default = new DebugLogger();
        /// <summary>
        /// 日志格式
        /// </summary>
        const string LogFormat = "[{0}] [{1:yyyy-MM-dd HH:mm:ss.fffff}] {2}{3}";
        #region 插件属性
        #endregion
        public DebugLogger() {
        }

        public void ProcessEvent(EventInfo eventInfo) {
            Debug.WriteLine(eventInfo.ToString());
        }

    }
}
