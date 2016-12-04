using PAO;
using PAO.App;
using PAO.Config.Controls.EditControls;
using PAO.UI.WinForm.MDI;
using PAO.UI.WinForm.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Config.Controllers
{
    /// <summary>
    /// 类：ObjectConfigController
    /// 对象配置控制器
    /// 配置对象的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("对象配置控制器")]
    [Description("配置对象的控制器")]
    public class ObjectConfigController : Controller
    {
        #region 插件属性
        #endregion
        public ObjectConfigController() {
        }

        public override void DoCommand(IMainForm mainForm) {
            var view = new ObjectTreeEditControl();
            view.ExtendPropertyStorageFilePath = AppPublic.GetAbsolutePath("ExtendProperties.config");
            view.SelectedObject = PaoApplication.Default;
            mainForm.ShowView(view, Caption, Icon);
        }
    }
}
