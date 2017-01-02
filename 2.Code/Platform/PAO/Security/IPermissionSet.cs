using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Security
{
    /// <summary>
    /// 接口：IPermissionSet
    /// 许可接口
    /// 提供权限许可功能的接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("许可接口")]
    [Description("提供权限许可功能的接口")]
    public interface IPermissionSet
    {
        /// <summary>
        /// 允许的权限
        /// </summary>
        IEnumerable<string> Permissions { get; }
    }
}
