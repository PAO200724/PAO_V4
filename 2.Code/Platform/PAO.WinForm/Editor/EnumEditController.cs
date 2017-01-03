using DevExpress.XtraEditors.Repository;
using PAO;
using PAO.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.WinForm.Editor
{
    /// <summary>
    /// 类：EnumEditor
    /// 枚举编辑器
    /// 枚举类型的列表编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("枚举编辑器")]
    [Description("枚举类型的列表编辑器")]
    public class EnumEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public EnumEditController() {
        }
        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemComboBox();

            WinFormPublic.AddClearButton(edit);
            // 添加枚举项
            if (objectType != null && !objectType.IsEnum)
                throw new Exception("枚举编辑器只支持枚举类型");

            foreach(var enumValue in Enum.GetValues(objectType)) {
                edit.Items.Add(enumValue);
            }
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type.IsEnum;
        }
    }
}
