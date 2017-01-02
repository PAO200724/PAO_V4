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
    /// 类：ColorEditor
    /// 颜色编辑器
    /// 颜色编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("颜色编辑器")]
    [Description("颜色编辑器")]
    public class ColorEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public ColorEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemColorEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(Color);
        }
    }
}
