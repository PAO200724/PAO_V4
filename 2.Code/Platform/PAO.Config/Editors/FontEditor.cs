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
    /// 类：FontEditor
    /// 字体编辑器
    /// 字体编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("字体编辑器")]
    [Description("字体编辑器")]
    public class FontEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public FontEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemFontEdit();
            DevExpressPublic.AddClearButton(edit);
            return edit;
        }
    }
}
