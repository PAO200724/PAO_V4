using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Log {
    /// <summary>
    /// 类：DebugLog
    /// 调试记录器
    /// 将日志记录在调试窗口
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("调试记录器")]
    [Description("将日志记录在调试窗口")]
    public class DebugLogger : PaoObject, ILog {
        /// <summary>
        /// 默认记录器
        /// </summary>
        public readonly static ILog Logger = new DebugLogger();
        /// <summary>
        /// 日志格式
        /// </summary>
        const string LogFormat = "[{0}] {1:yyyy-MM-dd HH:mm:ss.fffff} {2}";
        #region 插件属性
        #endregion
        public DebugLogger() {
        }

        #region ILog 成员

        public void LogInformation(string message, params object[] parameters) {
            var log = String.Format(LogFormat, "信息", DateTime.Now, String.Format(message, parameters));
            Debug.WriteLine(log);
        }

        public void LogWarning(string message, params object[] parameters) {
            var log = String.Format(LogFormat, "警告", DateTime.Now, String.Format(message, parameters));
            Debug.WriteLine(log);
        }

        public void LogException(Exception exception) {
            var log = String.Format(LogFormat, "异常", DateTime.Now, exception.ObjectToString());
            Debug.WriteLine(log);
        }

        #endregion
    }
}
