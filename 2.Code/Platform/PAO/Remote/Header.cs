using PAO;
using PAO.Security;
using PAO.Trans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote
{
    /// <summary>
    /// 类：Header
    /// 协议头
    /// 远程调用的协议头
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("协议头")]
    [Description("远程调用的协议头")]
    public class Header : Object
    {
        #region 插件属性

        #region 属性：Transaction
        /// <summary>
        /// 属性：Transaction
        /// 事务
        /// 客户端事务
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("事务")]
        [Description("客户端事务")]
        public PaoTransaction Transaction {
            get;
            set;
        }
        #endregion 属性：Transaction

        #region 属性：UserToken
        /// <summary>
        /// 属性：UserToken
        /// 用户令牌
        /// 当前用户的令牌
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("用户令牌")]
        [Description("当前用户的令牌")]
        public UserToken UserToken {
            get;
            set;
        }
        #endregion 属性：UserToken
        #endregion
        public Header() {
        }
    }
}
