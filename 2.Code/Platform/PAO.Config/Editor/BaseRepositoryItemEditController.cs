using DevExpress.XtraEditors.Repository;
using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：BaseRepositoryItemEditController
    /// RepositoryItem编辑器
    /// RepositoryItem形式的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("RepositoryItem编辑器")]
    [Description("RepositoryItem形式的编辑器")]
    public abstract class BaseRepositoryItemEditController : BaseEditController
    {
        #region 插件属性
        #endregion

        public BaseRepositoryItemEditController() {

        }
        public BaseRepositoryItemEditController(bool staticType) : base(staticType){
        }
        protected override Control OnCreateEditControl(Type objectType) {
            
            var repositoryItem = CreateRepositoryItem(objectType);
            var editor = repositoryItem.CreateEditor();
            editor.Properties.Assign(repositoryItem);
            return editor;
        }
    }
}
