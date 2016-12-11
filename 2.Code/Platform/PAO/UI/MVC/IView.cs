using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IView
    /// 视图接口
    /// 所有视图都应该实现的接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("文档接口")]
    [Description("所有视图都应该实现的接口")]
    public interface IView : IUIItem
    {
        /// <summary>
        /// 控制器
        /// </summary>
        BaseController Controller { get; set; }
        /// <summary>
        /// 关闭视图
        /// </summary>
        void CloseView();
        /// <summary>
        /// 关闭事件
        /// </summary>
        event EventHandler Closing;
        /// <summary>
        /// 视图容器
        /// </summary>
        IViewContainer ViewContainer { get; set; }
        /// <summary>
        /// UI动作分发器
        /// </summary>
        UIActionDispatcher UIActionDispatcher { get; set; }
    }
}
