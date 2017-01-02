using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;
using System.Drawing;

namespace PAO.WinForm.Editor
{
    /// <summary>
    /// 类：FontNameEditController
    /// 字体名称编辑器
    /// 字体名称编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("字体名称编辑器")]
    [Description("字体名称编辑器")]
    public class FontNameEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public FontNameEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemFontEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(Font) || type == typeof(string);
        }
    }
}
