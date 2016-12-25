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
    /// 类：ImageEditor
    /// 图片编辑器
    /// 图片编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("图片编辑器")]
    [Description("图片编辑器")]
    public class PictureEditor : BaseRepositoryItemEditor
    {
        #region 插件属性
        #endregion
        public PictureEditor() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemPictureEdit();
            return edit;
        }
    }
}
