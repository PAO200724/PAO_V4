using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part
{
    /// <summary>
    /// 类:Status_Disabled
    /// 失效状态
    /// 失效状态
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("失效状态")]
    [Description("失效状态")]
    public class Status_Disabled : Status
    {
        #region 插件属性
        #region 属性:Message
        /// <summary>
        /// 属性:Message
        /// 失效消息
        /// 失效的说明
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("异常消息")]
        [Description("失效的说明")]
        public string Message
        {
            get;
            set;
        }
        #endregion 属性:Message
        #endregion
        public Status_Disabled()
        {
        }

        public Status_Disabled(string message)
        {
            Message = message;
        }
        public override string ToString()
        {
            return this.ObjectToString(base.ToString(), "Message");
        }
    }
}
