using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;

namespace PAO.WinForm.Editor
{
    /// <summary>
    /// 类：FontNameEditor
    /// 字体名称编辑器
    /// 字体名称编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("字体名称编辑器")]
    [Description("字体名称编辑器")]
    public class FontNameEditor : BaseDevEditController
    {
        #region 插件属性
        #endregion
        public FontNameEditor() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemFontEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
