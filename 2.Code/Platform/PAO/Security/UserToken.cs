using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Security
{
    /// <summary>
    /// 类：UserToken
    /// 用户令牌
    /// 包含用户基础信息的令牌
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("用户令牌")]
    [Description("包含用户基础信息的令牌")]
    public class UserToken : PaoObject
    {
        #region 插件属性

        #region 属性：ComputerID
        /// <summary>
        /// 属性：ComputerID
        /// 计算机ID
        /// 当前计算机的唯一标识
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("计算机ID")]
        [Description("当前计算机的唯一标识")]
        public string ComputerID {
            get;
            set;
        }
        #endregion 属性：ComputerID

        #endregion
        public UserToken() {
        }
    }
}
