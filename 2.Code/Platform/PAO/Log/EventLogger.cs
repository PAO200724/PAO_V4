using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Log {
    /// <summary>
    /// 类：EventLogger
    /// 系统日志记录器
    /// 在系统日志中记录日志的记录器
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("系统日志记录器")]
    [Description("在系统日志中记录日志的记录器")]
    public class EventLogger : PaoObject, ILog {
        /// <summary>
        /// 默认事件源名称
        /// </summary>
        public const string DefaultEventSourceName = "PAO";
        /// <summary>
        /// 默认记录器
        /// </summary>
        public readonly static ILog Logger = new EventLogger();
        #region 插件属性
        #region 属性：EventSource
        /// <summary>
        /// 属性：EventSource
        /// 事件源
        /// 时间记录对应的事件源
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("事件源")]
        [Description("时间记录对应的事件源")]
        public string EventSource {
            get;
            set;
        }
        #endregion 属性：EventSource
        #endregion

        public EventLogger() {
            EventSource = DefaultEventSourceName;
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "EventSource");
        }
        #region ILog 成员

        public void LogInformation(string message, params object[] parameters) {
            var fullMessage = String.Format(message, parameters);
            EventLog.WriteEntry(EventSource, fullMessage, EventLogEntryType.Information);
        }

        public void LogWarning(string message, params object[] parameters) {
            var fullMessage = String.Format(message, parameters);
            EventLog.WriteEntry(EventSource, fullMessage, EventLogEntryType.Warning);
        }

        public void LogException(Exception exception) {
            var fullMessage = exception.ObjectToString();
            EventLog.WriteEntry(EventSource, fullMessage, EventLogEntryType.Error);
        }
        #endregion
    }
}
