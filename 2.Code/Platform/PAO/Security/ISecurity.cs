using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Security
{
    /// <summary>
    /// 接口：IUser
    /// 安全接口
    /// 安全接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("用户接口")]
    [Description("用户接口")]
    public interface ISecurity
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>用户信息</returns>
        UserInfo GetUserInfo();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userID">用户名</param>
        /// <param name="password">密码（MD5）</param>
        string Login(string userID, string password);
    }
}
