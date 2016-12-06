using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;

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
    public class CommandMenuItem : MenuItem, ICommand
    {
        #region 插件属性

        #region 属性：Command
        /// <summary>
        /// 属性：Command
        /// 命令
        /// 命令对象
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("命令")]
        [Description("命令对象")]
        public Ref<ICommand> Command {
            get;
            set;
        }
        #endregion 属性：Command
        #endregion
        public CommandMenuItem() {
        }

        public virtual void DoCommand() {
            if(Command != null) {
                Command.Value.DoCommand();
            }
        }
    }
}
