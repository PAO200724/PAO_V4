using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.UI.WinForm;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：ToggleSwitchEditor
    /// 是否切换编辑器
    /// 是否切换编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("是否切换编辑器")]
    [Description("是否切换编辑器")]
    public class ToggleSwitchEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public ToggleSwitchEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemToggleSwitch();
            return edit;
        }
    }
}
