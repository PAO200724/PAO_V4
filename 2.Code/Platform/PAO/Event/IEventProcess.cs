using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Event
{
    /// <summary>
    /// 接口：IEventProcess
    /// 事件处理接口
    /// 作者：PAO
    /// </summary>
    public interface IEventProcess
    {
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="eventInfo">异常信息</param>
        void ProcessEvent(EventInfo eventInfo);
    }
}
