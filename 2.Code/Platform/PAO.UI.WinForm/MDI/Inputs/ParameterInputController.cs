using PAO;
using PAO.UI.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.WinForm.MDI.Inputs
{
    /// <summary>
    /// 类：ParameterInputController
    /// 参数输入控制器
    /// 控制参数输入视图的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("参数输入控制器")]
    [Description("控制参数输入视图的控制器")]
    public class ParameterInputController : BaseController
    {
        #region 插件属性
        #endregion
        public ParameterInputController() {
        }

        protected override IView OnCreateView() {
            var view = new ParameterInputView();
            return view;
        }
    }
}
