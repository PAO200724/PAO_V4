﻿using PAO;
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
    [DataContract(Namespace = "")]
    [DisplayName("事件处理器")]
    [Description("基础事件处理器")]
    public abstract class BaseEventProcessor : PaoObject
    {
        #region 插件属性
        #region 属性：Priority
        /// <summary>
        /// 属性：Priority
        /// 优先级
        /// 事件处理优先级，默认为10
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("优先级")]
        [Description("事件处理优先级，默认为10")]
        [DefaultValue("10")]
        public int Priority {
            get;
            set;
        }
        #endregion 属性：Priority
        #endregion
        public BaseEventProcessor() {
            Priority = 10;
        }

        public abstract void ProcessEvent(EventInfo eventInfo);
    }
}
