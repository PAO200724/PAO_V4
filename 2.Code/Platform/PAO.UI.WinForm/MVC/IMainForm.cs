using DevExpress.XtraBars.Docking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm.MVC
{
    /// <summary>
    /// 接口：IMainForm
    /// 主窗体
    /// 主窗体接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("主窗体")]
    [Description("主窗体接口")]
    public interface IMainForm
    {
        /// <summary>
        /// 显示视图
        /// </summary>
        /// <param name="view">视图</param>
        /// <param name="caption">标题</param>
        /// <param name="icon">图标</param>
        void ShowView(Control view, string caption, Image icon);

        /// <summary>
        /// 显示停靠容器
        /// </summary>
        /// <param name="id">唯一标示</param>
        /// <param name="view">视图</param>
        /// <param name="caption">标题</param>
        /// <param name="icon">图标</param>
        /// <param name="dockingStyle">停靠位置</param>
        void ShowDockPanel(Guid id, Control view, DockingStyle dockingStyle, string caption, Image icon);

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
