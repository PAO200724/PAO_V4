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
    /// 类：ImageEditor
    /// 下拉式图片编辑器
    /// 下拉式图片编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("下拉式图片编辑器")]
    [Description("下拉式图片编辑器")]
    public class ImageEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public ImageEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemImageEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
