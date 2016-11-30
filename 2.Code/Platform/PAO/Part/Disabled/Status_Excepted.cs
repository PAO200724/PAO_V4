using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part.Disabled
{
    /// <summary>
    /// 类:Status_Excepted
    /// 异常状态
    /// 表示处于长时间异常的状态
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("异常状态")]
    [Description("表示处于长时间异常的状态")]
    public class Status_Excepted : Status_Disabled
    {
        #region 插件属性
        #region 属性:DetailInformation
        /// <summary>
        /// 属性:DetailInformation
        /// 详细信息
        /// 用字符串表示的异常详细信息
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("详细信息")]
        [Description("用字符串表示的异常详细信息")]
        public string DetailInformation
        {
            get;
            set;
        }
        #endregion 属性:DetailInformation
        #endregion
        public Status_Excepted()
        {
        }

        [NonSerialized]
        private Exception _Exception;
        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception {
            get { return _Exception; }
            set { _Exception = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="exception">异常</param>
        public Status_Excepted(Exception exception) : base(exception.Message)
        {
            Exception = exception;
            DetailInformation = exception.FormatException();
        }

        public override string ToString() {
            return this.ObjectToString(null, "Message", "DetailInformation");
        }
    }
}
