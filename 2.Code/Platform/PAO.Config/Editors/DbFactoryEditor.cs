using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.UI.WinForm;
using System.Data.Common;
using System.Data;
using PAO.Config.Editors;
using PAO.UI.WinForm.Editors;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：DbFactoryEditor
    /// 数据工厂编辑器
    /// 数据工厂的名称列表编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据工厂编辑器")]
    [Description("数据工厂的名称列表编辑器")]
    public class DbFactoryEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public DbFactoryEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemComboBox();
            WinFormPublic.AddClearButton(edit);
            var factoryClasses = DbProviderFactories.GetFactoryClasses();
            foreach(DataRow dataRow in factoryClasses.Rows) {
                edit.Items.Add(dataRow["InvariantName"]);
            }
            return edit;
        }
    }
}
