using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 类：ToggleSwitchController
    /// 是否切换编辑器
    /// 是否切换编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("是否切换编辑器")]
    [Description("是否切换编辑器")]
    public class ToggleSwitchEditController : BaseDevEditController
    {
        #region 插件属性
        #endregion
        public ToggleSwitchEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemToggleSwitch();
            return edit;
        }
    }
}
