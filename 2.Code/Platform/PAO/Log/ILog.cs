using PAO.Trans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Log {
    /// <summary>
    /// 接口:ILog
    /// 日志记录接口
    /// 作者:PAO
    /// </summary>
    public interface ILog {
        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="parameters">参数</param>
        void LogInformation(string message, params object[] parameters);
        /// <summary>
        /// 记录警告
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="parameters">参数</param>
        void LogWarning(string message, params object[] parameters);
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="exception">异常</param>
        void LogException(Exception exception);
        /// <summary>
        /// 记录事务
        /// </summary>
        /// <param name="trans">事务</param>
        void LogTransaction(PaoTransaction trans);
    }
}
