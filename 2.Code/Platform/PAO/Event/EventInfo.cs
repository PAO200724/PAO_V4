using PAO;
using PAO.App;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Event
{
    /// <summary>
    /// 类：EventInfo
    /// 事件信息
    /// 异常或其他的事件信息
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("事件信息")]
    [Description("异常或其他的事件信息")]
    public class EventInfo : PaoObject
    {
        #region 插件属性

        #region 属性：Time
        /// <summary>
        /// 属性：Time
        /// 时间
        /// 事件发生的时间
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("时间")]
        [Description("事件发生的时间")]
        public DateTime Time {
            get;
            set;
        }
        #endregion 属性：Time

        #region 属性：Source
        /// <summary>
        /// 属性：Source
        /// 事件源
        /// 事件源
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("事件源")]
        [Description("事件源")]
        public string Source {
            get;
            set;
        }
        #endregion 属性：Source

        #region 属性：Message
        /// <summary>
        /// 属性：Message
        /// 消息
        /// 事件消息
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("消息")]
        [Description("事件消息")]
        public string Message {
            get;
            set;
        }
        #endregion 属性：Message

        #region 属性：Type
        /// <summary>
        /// 属性：Type
        /// 事件类型
        /// 事件类型，如果是异常，则是异常的Type字符串
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("事件类型")]
        [Description("事件类型，如果是异常，则是异常的Type字符串")]
        public string Type {
            get;
            set;
        }
        #endregion 属性：Type

        #region 属性：DetailInformation
        /// <summary>
        /// 属性：DetailInformation
        /// 详细信息
        /// 事件详细信息
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("详细信息")]
        [Description("事件详细信息")]
        public string DetailInformation {
            get;
            set;
        }
        #endregion 属性：DetailInformation

        #region 属性：Data
        /// <summary>
        /// 属性：Data
        /// 数据
        /// 异常数据或其他数据
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("数据")]
        [Description("异常数据或其他数据")]
        public Dictionary<string, object> Data {
            get;
            set;
        }
        #endregion 属性：Data

        #region 属性：ExceptionType
        /// <summary>
        /// 属性：ExceptionType
        /// 异常类型
        /// 异常类型
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("异常类型")]
        [Description("异常类型")]
        public Type ExceptionType {
            get;
            set;
        }
        #endregion 属性：ExceptionType

        #region 属性：ScreenShot
        /// <summary>
        /// 属性：ScreenShot
        /// 截屏
        /// 屏幕截图
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("截屏")]
        [Description("屏幕截图")]
        public Image ScreenShot {
            get;
            set;
        }
        #endregion 属性：ScreenShot


        #region 属性：AssetSnapshot
        /// <summary>
        /// 属性：AssetSnapshot
        /// 资产快照
        /// 系统资产的快照
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("资产快照")]
        [Description("系统资产的快照")]
        public object AssetSnapshot {
            get;
            set;
        }
        #endregion 属性：AssetSnapshot
        #endregion
        public EventInfo() {
        }
    }
}
