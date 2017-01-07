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
    /// 类：GuidEdit
    /// GUID编辑器
    /// GUID编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("GUID编辑器")]
    [Description("GUID编辑器")]
    public class GuidEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public GuidEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemButtonEdit();
            edit.Buttons.Clear();
            edit.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            edit.ButtonClick += Edit_ButtonClick;
            WinFormPublic.AddClearButton(edit);
            return edit;
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            if(e.Button.Kind == ButtonPredefines.Plus) {
                if(UIPublic.ShowYesNoDialog("您是否要创建一个新的Guid?") == DialogReturn.Yes) {
                    var edit = sender as ButtonEdit;
                    edit.EditValue = Guid.NewGuid().ToString();
                }
            }
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(Guid) || type == typeof(string);
        }
    }
}
