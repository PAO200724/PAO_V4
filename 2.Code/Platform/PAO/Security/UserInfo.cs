using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Security
{
    /// <summary>
    /// 类：UserInfo
    /// 用户信息
    /// 用户的信息
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("用户信息")]
    [Description("用户的信息")]
    public class UserInfo : PaoObject
    {
        #region 插件属性

        #region 属性：UserID
        /// <summary>
        /// 属性：UserID
        /// 用户ID
        /// 用户唯一标示
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("用户ID")]
        [Description("用户唯一标示")]
        public string UserID {
            get;
            set;
        }
        #endregion 属性：UserID

        #region 属性：UserName
        /// <summary>
        /// 属性：UserName
        /// 用户名
        /// 用户的名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("用户名")]
        [Description("用户的名称")]
        public string UserName {
            get;
            set;
        }
        #endregion 属性：UserName

        #region 属性：HeaderImage
        /// <summary>
        /// 属性：HeaderImage
        /// 头像
        /// 用户头像
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("头像")]
        [Description("用户头像")]
        public Image HeaderImage {
            get;
            set;
        }
        #endregion 属性：HeaderImage
        #endregion
        public UserInfo() {
        }
    }
}
