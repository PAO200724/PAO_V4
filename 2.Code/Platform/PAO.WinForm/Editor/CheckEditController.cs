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
    /// 类：CheckEditor
    /// 复选框编辑器
    /// 复选框编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("复选框编辑器")]
    [Description("复选框编辑器")]
    public class CheckEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public CheckEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemCheckEdit();
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(bool);
        }
    }
}
