using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.WinForm;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：AddonExtentionEditController
    /// 插件扩展编辑控制器
    /// 插件扩展编辑器的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("插件扩展编辑控制器")]
    [Description("插件扩展编辑器的控制器")]
    public class AddonExtentionEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public AddonExtentionEditController() {
        }

        protected override BaseEditControl OnCreateEditControl() {
            var editControl = new AddonExtentionEditControl();
            return editControl;
        }
    }
}
