using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;

namespace PAO.WinForm.Editor
{
    /// <summary>
    /// 类：SkinNameEditController
    /// 皮肤名称编辑控制器
    /// 用于编辑皮肤名称的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("皮肤名称编辑控制器")]
    [Description("用于编辑皮肤名称的编辑器")]
    public class SkinNameEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public SkinNameEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemComboBox();

            WinFormPublic.AddClearButton(edit);
            // 添加皮肤项
            foreach (SkinContainer cnt in SkinManager.Default.Skins) {
                edit.Items.Add(cnt.SkinName);
            }
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(string);
        }
    }
}
