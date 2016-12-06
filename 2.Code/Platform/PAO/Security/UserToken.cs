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
    [Name("用户令牌")]
    [Description("包含用户基础信息的令牌")]
    public class UserToken : PaoObject
    {
        #region 插件属性

        #region 属性：SessinID
        /// <summary>
        /// 属性：SessinID
        /// 会话ID
        /// 验证服务器生成的会话ID，每次用户登录生成一个会话
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("会话ID")]
        [Description("验证服务器生成的会话ID，每次用户登录生成一个会话")]
        public string SessinID {
            get;
            set;
        }
        #endregion 属性：SessinID

        #region 属性：UserID
        /// <summary>
        /// 属性：UserID
        /// 用户ID
        /// 用户唯一编号
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("用户ID")]
        [Description("用户唯一编号")]
        public string UserID {
            get;
            set;
        }
        #endregion 属性：UserID

        #region 属性：ComputerID
        /// <summary>
        /// 属性：ComputerID
        /// 计算机ID
        /// 当前计算机的唯一标识
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("计算机ID")]
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
