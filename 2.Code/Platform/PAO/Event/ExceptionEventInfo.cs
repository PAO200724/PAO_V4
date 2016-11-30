using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Event
{
    /// <summary>
    /// 类：ExceptionEventInfo
    /// 异常事件信息
    /// 包含异常的事件信息
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("异常事件信息")]
    [Description("包含异常的事件信息")]
    public class ExceptionEventInfo : EventInfo
    {
        public const string EventType_Exception = "异常";

        #region 插件属性

        #region 属性：ExceptionType
        /// <summary>
        /// 属性：ExceptionType
        /// 异常类型
        /// 异常类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("异常类型")]
        [Description("异常类型")]
        public Type ExceptionType {
            get;
            set;
        }
        #endregion 属性：ExceptionType

        #region 属性：StackTrace
        /// <summary>
        /// 属性：StackTrace
        /// 堆栈信息
        /// 异常堆栈信息
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("堆栈信息")]
        [Description("异常堆栈信息")]
        public string StackTrace {
            get;
            set;
        }
        #endregion 属性：StackTrace

        #region 属性：InnerExceptionInfo
        /// <summary>
        /// 属性：InnerExceptionInfo
        /// 内部异常信息
        /// 内部异常信息
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("内部异常信息")]
        [Description("内部异常信息")]
        public ExceptionEventInfo InnerExceptionInfo {
            get;
            set;
        }
        #endregion 属性：InnerExceptionInfo

        #endregion
        public ExceptionEventInfo() {
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="screenshot">是否截屏</param>
        /// <param name="snapshot">是否进行快照</param>
        /// <returns></returns>
        public ExceptionEventInfo(Exception exception, bool screenshot = false, bool snapshot = false)
            : base(EventType_Exception
                  , exception.Message
                  , screenshot,snapshot) {
            ExceptionType = exception.GetType();
            StackTrace = exception.StackTrace;
            Data = new Dictionary<string, object>().Append(exception.Data);
            if(exception.InnerException != null) {
                InnerExceptionInfo = new ExceptionEventInfo(exception.InnerException, false, false);
            }
        }

        /// <summary>
        /// 递归获取内部异常信息
        /// </summary>
        public virtual string InnerExceptionMessage {
            get {
                if (InnerExceptionInfo == null)
                    return null;

                var innerExceptionMessage = String.Format("\r\n--内部异常---------------\r\n{0}"
                    , InnerExceptionInfo.DetailMessage);
                var innerExceptionInnerMessage = InnerExceptionInfo.InnerExceptionMessage;
                if(innerExceptionInnerMessage.IsNotNullOrEmpty()) {
                    innerExceptionMessage += innerExceptionInnerMessage;
                }

                return innerExceptionMessage;
            }
        }

        /// <summary>
        /// 详细消息
        /// </summary>
        public override string DetailMessage {
            get {
                var dataMessage = DataMessage;
                return String.Format("{0}:{1}\r\n{2}{3}\r\n{4}"
                    , ExceptionType
                    , Message
                    , DataMessage.IsNullOrEmpty() ? null : "\r\n" + DataMessage
                    , StackTrace
                    , InnerExceptionMessage);
            }
        }
    }
}
