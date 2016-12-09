using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.Security;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 类：CommandMenuItem
    /// 命令菜单项
    /// 可以执行命令的菜单项
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("命令菜单项")]
    [Description("可以执行命令的菜单项")]
    public abstract class CommandMenuItem : MenuItem, ICommand
    {
        const string Permission_DoCommand = "DoCommand";
        #region 插件属性
        #endregion
        public CommandMenuItem() {
        }

        public virtual void DoCommand() {
            SecurityPublic.CheckPermission(ID, Permission_DoCommand).CheckTrue("当前用户不拥有执行此命令的权限.");
            OnDoCommand();
        }

        protected abstract void OnDoCommand();

        /// <summary>
        /// 许可
        /// </summary>
        public virtual IDictionary<string, string> Permissions {
            get {
                return new Dictionary<string, string>()
                    .Append(Permission_DoCommand, "执行命令");
            }
        }
    }
}
