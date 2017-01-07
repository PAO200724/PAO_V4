using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;
using System.Data.Common;
using System.Data;
using PAO.Config.Editor;

namespace PAO.Config.Editor
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
    public class DbFactoryEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public DbFactoryEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemComboBox();
            WinFormPublic.AddClearButton(edit);
            var factoryClasses = DbProviderFactories.GetFactoryClasses();
            foreach(DataRow dataRow in factoryClasses.Rows) {
                edit.Items.Add(dataRow["InvariantName"]);
            }
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(string);
        }
    }
}
