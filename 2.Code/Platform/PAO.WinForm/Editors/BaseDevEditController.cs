using DevExpress.XtraEditors.Repository;
using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 类：BaseRepositoryItemEditor
    /// RepositoryItem编辑器
    /// RepositoryItem形式的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("RepositoryItem编辑器")]
    [Description("RepositoryItem形式的编辑器")]
    public abstract class BaseDevEditController : BaseEditController
    {
        #region 插件属性
        #endregion
        public BaseDevEditController() {
        }

        protected abstract RepositoryItem OnCreateRepositoryItem();

        public override RepositoryItem CreateRepositoryItem() {
            var repositoryItem = OnCreateRepositoryItem();
            repositoryItem.ReadOnly = ReadOnly;
            if (repositoryItem is RepositoryItemButtonEdit && repositoryItem.ReadOnly) {
                repositoryItem.As<RepositoryItemButtonEdit>().Buttons.Clear();
            }
            return repositoryItem;
        }

        public override Control CreateEditControl() {
            var repositoryItem = CreateRepositoryItem();
            var editor = repositoryItem.CreateEditor();
            editor.Properties.Assign(repositoryItem);
            return editor;
        }
    }
}
