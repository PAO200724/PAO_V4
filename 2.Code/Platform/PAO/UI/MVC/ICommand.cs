using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：ICommand
    /// 命令接口
    /// 命令接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("功能项")]
    [Description("功能项")]
    public interface ICommand
    {
        void DoCommand();
    }
}
