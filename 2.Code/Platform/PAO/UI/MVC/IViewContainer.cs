using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IViewContainer
    /// 视图容器
    /// 视图容器，用于容纳并显示视图
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("文档容器")]
    [Description("文档容器，用于容纳并显示文档")]
    public interface IViewContainer
    {
        /// <summary>
        /// 打开功能项
        /// </summary>
        /// <param name="view">视图</param>
        void OpenView(IView view);
        /// <summary>
        /// 执行UI动作
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="actionName">动作名称</param>
        /// <param name="actionParameters">动作参数</param>
        void DoUIAction(object sender, string actionName, IEnumerable<object> actionParameters);
        /// <summary>
        /// 视图动作事件
        /// </summary>
        event EventHandler<UIActionEventArgs> UIActing;
    }
}
