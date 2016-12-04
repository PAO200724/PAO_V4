using PAO;
using PAO.App;
using PAO.IO.Text;
using PAO.UI;
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
    [Name("事件信息")]
    [Description("异常或其他的事件信息")]
    public class EventInfo : PaoObject
    {
        public const string EventType_Information = "信息";
        public const string EventType_Warning = "警告";
        public const string EventType_Error = "错误";

        #region 插件属性

        #region 属性：Time
        /// <summary>
        /// 属性：Time
        /// 时间
        /// 事件发生的时间
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("时间")]
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
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("事件源")]
        [Description("事件源")]
        [DefaultValue("PAO")]
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
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("消息")]
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
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("事件类型")]
        [Description("事件类型，如果是异常，则是异常的Type字符串")]
        public string Type {
            get;
            set;
        }
        #endregion 属性：Type

        #region 属性：Data
        /// <summary>
        /// 属性：Data
        /// 数据
        /// 异常数据或其他数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据")]
        [Description("异常数据或其他数据")]
        public Dictionary<string, object> Data {
            get;
            set;
        }
        #endregion 属性：Data

        #region 属性：ScreenShot
        /// <summary>
        /// 属性：ScreenShot
        /// 截屏
        /// 屏幕截图
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("截屏")]
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
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("资产快照")]
        [Description("系统资产的快照")]
        public object AssetSnapshot {
            get;
            set;
        }
        #endregion 属性：AssetSnapshot
        #endregion
        public EventInfo() {
            Source = "PAO";
        }

        /// <summary>
        /// 创建事件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="message">消息</param>
        /// <param name="type">事件类型</param>
        /// <param name="screenshot">是否截屏</param>
        /// <param name="snapshot">是否进行快照</param>
        /// <returns></returns>
        public EventInfo(string type
            , string message
            , bool screenshot = false
            , bool snapshot = false) {
            Source = "PAO";
            Time = DateTime.Now;
            Message = message;
            Type = type;
            ScreenShot = screenshot ? UIPublic.ScreenShot() : (Image)null;
            AssetSnapshot = snapshot ? TextPublic.ObjectClone(PaoApplication.Default) : null;
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            const string Format = "[{0} {1} {2:yyyy-MM-dd HH:mm:ss.fffff}] {3}";

            return String.Format(Format, Source, Type, Time, DetailMessage);
        }

        /// <summary>
        /// 数据消息
        /// </summary>
        public virtual string DataMessage {
            get {
                if (Data.IsNullOrEmpty())
                    return null;

                string dataMessage = null;
                foreach (var dataKV in Data) {
                    if (dataMessage.IsNotNullOrEmpty()) {
                        dataMessage += ", ";
                    }
                    dataMessage += String.Format("[{0} : {1}]", dataKV.Key, dataKV.Value);
                }
                return dataMessage;
            }
        }

        /// <summary>
        /// 详细消息
        /// </summary>
        public virtual string DetailMessage {
            get {
                var dataMessage = DataMessage;
                return String.Format("{0}{1}", Message, DataMessage.IsNullOrEmpty()?null:"\r\n" + DataMessage);
            }
        }
    }
}
