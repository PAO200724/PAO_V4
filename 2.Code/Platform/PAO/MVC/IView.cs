﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PAO.MVC
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
    public interface IView : IUIItem, IClosable
    {
        /// <summary>
        /// 控制器
        /// </summary>
        BaseController Controller { get; set; }
        /// <summary>
        /// 视图容器
        /// </summary>
        IViewContainer ViewContainer { get; set; }
    }
}
