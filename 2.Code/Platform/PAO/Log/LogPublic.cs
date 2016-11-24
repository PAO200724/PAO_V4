using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAO.Log;

namespace PAO.Log {
    /// <summary>
    /// 静态类：LogPublic
    /// 日志公共类
    /// 作者：PAO
    /// </summary>
    public static class LogPublic {
        /// <summary>
        /// Log列表
        /// </summary>
        public readonly static List<ILog> LoggerList = new List<ILog>();

        static LogPublic() {
            AddLogger(DebugLogger.Logger);
        }

        /// <summary>
        /// 添加记录器
        /// </summary>
        /// <param name="logger">日志记录器</param>
        public static void AddLogger(ILog logger) {
            LoggerList.Add(logger);
        }

        /// <summary>
        /// 移除记录器
        /// </summary>
        /// <param name="logger">日志记录器</param>
        public static void RemoveLogger(ILog logger) {
            if (LoggerList.Contains(logger))
                LoggerList.Remove(logger);
        }

        /// <summary>
        /// 清除记录器
        /// </summary>
        public static void ClearLogger() {
            LoggerList.Clear();
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="parameters">消息参数</param>
        public static void LogInformation(string message, params object[] parameters) {
            foreach (var logger in LoggerList) {
                logger.LogInformation(message, parameters);
            }
        }

        /// <summary>
        /// 记录警告
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="parameters">消息参数</param>
        public static void LogWarning(string message, params object[] parameters) {
            foreach (var logger in LoggerList) {
                logger.LogWarning(message, parameters);
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="err">异常</param>
        public static void LogException(Exception err) {
            foreach (var logger in LoggerList) {
                logger.LogException(err);
            }
        }

    }
}
