using DevExpress.XtraEditors.Repository;
using PAO;
using PAO.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.WinForm.Editors
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
    public class EnumEditController : BaseDevEditController
    {
        #region 插件属性
        #endregion
        public EnumEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemComboBox();
            WinFormPublic.AddClearButton(edit);
            // 添加枚举项
            var enumType = PropertyDescriptor.PropertyType;
            if (!enumType.IsEnum)
                throw new Exception("枚举编辑器只支持枚举类型");

            foreach(var enumValue in Enum.GetNames(enumType)) {
                edit.Items.Add(enumValue);
            }
            return edit;
        }
    }
}
