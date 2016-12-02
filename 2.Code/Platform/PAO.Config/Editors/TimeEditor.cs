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
    /// 类：TimeEditor
    /// 时间编辑器
    /// 时间编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("时间编辑器")]
    [Description("时间编辑器")]
    public class TimeEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public TimeEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemTimeEdit();
            DevExpressPublic.AddClearButton(edit);
            return edit;
        }
    }
}
