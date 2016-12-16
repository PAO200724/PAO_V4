using PAO;
using PAO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Event
{
    /// <summary>
    /// 类：EventProcessor
    /// 事件处理器
    /// 基础事件处理器
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [Icon(typeof(Resources), "event_info")]
    [DataContract(Namespace = "")]
    [Name("事件处理器")]
    [Description("基础事件处理器")]
    public abstract class BaseEventProcessor : PaoObject
    {
        #region 插件属性
        #region 属性：Priority
        /// <summary>
        /// 属性：Priority
        /// 优先级
        /// 事件处理优先级，默认为10，数值越大，优先级越高。
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [Name("优先级")]
        [Description("事件处理优先级，默认为10，数值越大，优先级越高。")]
        [DefaultValue("10")]
        public int Priority {
            get;
            set;
        }
        #endregion 属性：Priority

        #region 属性：Handled
        /// <summary>
        /// 属性：Handled
        /// 停止处理
        /// 设定了此属性为True时，不再执行优先级低的事件处理机
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [Name("停止处理")]
        [Description("设定了此属性为True时，不再执行优先级低的事件处理机")]
        [DefaultValue("false")]
        public bool Handled {
            get;
            set;
        }
        #endregion 属性：Handled
        #endregion
        public BaseEventProcessor() {
            Priority = 10;
            Handled = false;
        }

        public abstract void ProcessEvent(EventInfo eventInfo);
    }
}
