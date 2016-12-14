using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.UI.MVC;

namespace PAO.Config.DockViews
{
    /// <summary>
    /// 类：PropertyController
    /// 属性视图控制器
    /// 控制PropertyView的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("属性视图控制器")]
    [Description("控制PropertyView的控制器")]
    public class PropertyController : BaseController
    {
        #region 插件属性
        #endregion
        public PropertyController() {
        }
        protected override Type ViewType {
            get {
                return typeof(PropertyView);
            }
        }
    }
}
