using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IMainForm
    /// 主窗体接口
    /// 主窗体接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("主窗体接口")]
    [Description("主窗体接口")]
    public interface IMainForm
    {
        /// <summary>
        /// 等待某个动作完成
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="action">动作</param>
        void Waiting(Action action, string message = "程序运行中...");

        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="status">状态</param>
        void SetStatusText(string status);
    }
}
