using PAO.App;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PAO.Event
{
    /// <summary>
    /// 静态类：EventPublic
    /// 事件公共类
    /// 作者：PAO
    /// </summary>
    public static class EventPublic
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AddEventData<T>(this T eventInfo, string key, object value) where T : EventInfo {
            if (eventInfo.Data == null)
                eventInfo.Data = new Dictionary<string, object>();
            eventInfo.Data.Add(key, value);
            return eventInfo;
        }

        /// <summary>
        /// 创建异常
        /// </summary>
        /// <param name="format">格式</param>
        /// <param name="args">参数</param>
        /// <returns>异常</returns>
        public static Exception CreateException(string format, params object[] args) {
            return new Exception(string.Format(format, args));
        }

        #region 事件处理机
        /// <summary>
        /// Log列表
        /// </summary>
        public readonly static List<BaseEventProcessor> ProcessorList = new List<BaseEventProcessor>();

        static EventPublic() {
            AddEventProcessor(DebugLogger.Default);
        }

        /// <summary>
        /// 添加记录器
        /// </summary>
        /// <param name="eventProcessor">日志记录器</param>
        public static void AddEventProcessor(BaseEventProcessor eventProcessor) {
            if (!ProcessorList.Contains(eventProcessor))
                ProcessorList.Add(eventProcessor);
        }

        /// <summary>
        /// 移除记录器
        /// </summary>
        /// <param name="eventProcessor">日志记录器</param>
        public static void RemoveEventProcessor(BaseEventProcessor eventProcessor) {
            if (ProcessorList.Contains(eventProcessor))
                ProcessorList.Remove(eventProcessor);
        }

        /// <summary>
        /// 清除记录器
        /// </summary>
        public static void ClearEventProcessor() {
            ProcessorList.Clear();
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="eventInfo">事件信息</param>
        public static void FireEvent(EventInfo eventInfo) {
            var processorSortByPriority = ProcessorList.OrderBy(p => p.Priority);
            foreach (var eventProcessor in processorSortByPriority) {
                eventProcessor.ProcessEvent(eventInfo);
                // 如果事件处理机Handle了事件，则直接退出循环
                if (eventProcessor.Handled)
                    break;
            }
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="parameters">消息参数</param>
        public static void Information(string message, params object[] parameters) {
            FireEvent(new EventInfo(EventInfo.EventType_Information, String.Format(message, parameters)));
        }

        /// <summary>
        /// 记录警告
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="parameters">消息参数</param>
        public static void Warning(string message, params object[] parameters) {
            FireEvent(new EventInfo(EventInfo.EventType_Warning, String.Format(message, parameters)));
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="parameters">消息参数</param>
        public static void Error(string message, params object[] parameters) {
            FireEvent(new EventInfo(EventInfo.EventType_Error, String.Format(message, parameters)));
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="err">异常</param>
        public static void Exception(Exception err) {
            FireEvent(new ExceptionEventInfo(err));
        }
        #endregion
    }
}
