using PAO.App;
using PAO.Drawing;
using PAO.IO.Text;
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
        public const string EventType_Information = "信息";
        public const string EventType_Warning = "警告";
        public const string EventType_Error = "错误";
        public const string EventType_Exception = "异常";

        /// <summary>
        /// 创建异常事件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="exception">异常</param>
        /// <param name="screenshot">是否截屏</param>
        /// <param name="snapshot">是否进行快照</param>
        /// <returns></returns>
        public static EventInfo CreateExceptionEvent(string source, Exception exception, bool screenshot = false, bool snapshot = false) {
            var eventInfo = new EventInfo()
            {
                Source = source,
                Time = DateTime.Now,
                Message = exception.Message,
                DetailInformation = exception.FormatException(),
                Type = EventType_Exception,
                ExceptionType = exception.GetType(),
                Data = new Dictionary<string, object>().Append(exception.Data),
                ScreenShot = screenshot ? DrawingPublic.ScreenShot() : (Image)null,
                AssetSnapshot = snapshot ? TextPublic.ObjectClone(PaoApplication.Default) : null
            };
            return eventInfo;
        }


        /// <summary>
        /// 创建事件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="detailInformation">详细信息</param>
        /// <param name="message">消息</param>
        /// <param name="type">事件类型</param>
        /// <param name="data">扩展数据</param>
        /// <param name="screenshot">是否截屏</param>
        /// <param name="snapshot">是否进行快照</param>
        /// <returns></returns>
        public static EventInfo CreateEvent(string source
            , string type
            , string message
            , string detailInformation = null
            , Dictionary<string, object> data = null
            , bool screenshot = false, bool snapshot = false) {
            return new EventInfo()
            {
                Source = source,
                Time = DateTime.Now,
                Message = message,
                Type = type,
                DetailInformation = detailInformation,
                Data = data,
                ScreenShot = screenshot ? DrawingPublic.ScreenShot() : (Image)null,
                AssetSnapshot = snapshot ? TextPublic.ObjectClone(PaoApplication.Default) : null
            };
        }
    }
}
