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
    public class ImageEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public ImageEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemImageEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(Image) || type == typeof(byte[]);
        }
    }
}
