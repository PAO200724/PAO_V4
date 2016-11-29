using PAO.Event;
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
    /// 类:EventEventProcessor
    /// 系统日志记录器
    /// 在系统日志中记录日志的记录器
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("系统日志记录器")]
    [Description("在系统日志中记录日志的记录器")]
    public class EventLogger : PaoObject, IEventProcess {
        /// <summary>
        /// 默认记录器
        /// </summary>
        public readonly static IEventProcess Default = new EventLogger();
        #region 插件属性
        #endregion

        public EventLogger() {
        }

        public void ProcessEvent(EventInfo eventInfo) {
            EventLog.WriteEntry(eventInfo.Source, eventInfo.ToString());
        }
    }
}
