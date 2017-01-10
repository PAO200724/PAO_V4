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
using PAO.Config.Controls;

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

        [NonSerialized]
        public Func<bool, Type> TypePredicate = null;

        public TypeEditController() {
        }
        public TypeEditController(Func<bool, Type> typePredicate) {
            TypePredicate = typePredicate;
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemButtonEdit();
            edit.ParseEditValue += Edit_ParseEditValue;
            edit.ButtonClick += Edit_ButtonClick;
            WinFormPublic.AddClearButton(edit);
            return edit;
        }

        private void Edit_ParseEditValue(object sender, ConvertEditValueEventArgs e) {
            e.Handled = true;
            if(e.Value.IsNotNullOrEmpty()) {
                if (e.Value is string) {
                    e.Value = ReflectionPublic.GetType(e.Value as string);
                }
            }
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            if (e.Button.Kind == ButtonPredefines.Ellipsis) {
                var typeSelectControl = new TypeSelectControl();
                if (TypePredicate == null) {
                    typeSelectControl.Initialize((p) => {
                        return true;
                    });
                }
                else {
                    typeSelectControl.Initialize(TypeFilter);
                }
                if (WinFormPublic.ShowDialog(typeSelectControl) == DialogReturn.OK) {
                    var edit = sender as ButtonEdit;
                    edit.EditValue = typeSelectControl.SelectedType;
                }
            }
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(Type);
        }
    }
}
