using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using PAO.UI;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：TypeEditController
    /// 类型编辑器
    /// 通过名称编辑类型的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("类型编辑器")]
    [Description("通过名称编辑类型的编辑器")]
    public class TypeEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public TypeEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemButtonEdit();
            edit.Buttons.Clear();
            edit.ParseEditValue += Edit_ParseEditValue;
            WinFormPublic.AddClearButton(edit);
            return edit;
        }

        private void Edit_ParseEditValue(object sender, ConvertEditValueEventArgs e) {
            e.Handled = true;
            if(e.Value.IsNotNullOrEmpty()) {
                e.Value = ReflectionPublic.GetType(e.Value as string);
            }
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(Type);
        }
    }
}
