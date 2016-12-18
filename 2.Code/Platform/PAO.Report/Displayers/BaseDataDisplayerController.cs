using PAO;
using PAO.UI;
using PAO.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report.Displayers
{
    /// <summary>
    /// 类：BaseDataDisplayerController
    /// 数据显示控制器
    /// 数据显示器的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据显示控制器")]
    [Description("数据显示器的控制器")]
    public abstract class BaseDataDisplayerController : BaseController
    {
        #region 插件属性
        
        #endregion
        public BaseDataDisplayerController() {
        }
        
    }
}
