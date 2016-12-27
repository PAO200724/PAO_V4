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
    /// 类：ColorPickEditor
    /// 颜色提取编辑器
    /// 颜色提取编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("颜色提取编辑器")]
    [Description("颜色提取编辑器")]
    public class ColorPickEditController : BaseDevEditController
    {
        #region 插件属性
        #endregion
        public ColorPickEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemColorPickEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
