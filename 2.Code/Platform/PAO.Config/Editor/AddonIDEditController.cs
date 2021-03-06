﻿using PAO;
using PAO.Config.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;
using PAO.IO;
using DevExpress.XtraEditors;
using PAO.UI;
using PAO.Controls;
using DevExpress.XtraEditors.Controls;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：AddonFactoryIDEditor
    /// 插件ID编辑器
    /// 在全局插件列表中选择插件ID的编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("插件ID编辑器")]
    [Description("在全局插件列表中选择插件ID的编辑器")]
    public class AddonIDEditController : BaseRepositoryItemEditController
    {
        #region 插件属性

        #region 属性：AddonType
        /// <summary>
        /// 属性：AddonType
        /// 插件类型
        /// 插件类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("插件类型")]
        [Description("插件类型")]
        public Type AddonType {
            get;
            set;
        }
        #endregion 属性：AddonType
        #endregion
        public AddonIDEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemButtonEdit();
            WinFormPublic.AddClearButton(edit);
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.ButtonClick += Edit_ButtonClick;
            return edit;
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            var edit = (ButtonEdit)sender;
            Type AddonType = null;
            if (e.Button.Kind == ButtonPredefines.Ellipsis) {
                var editValue = edit.EditValue;
                var editControl = new AddonSelectControl();

                editControl.AddonFilter = (addon) =>
                {
                    // 匹配插件类型
                    if (AddonType == null || addon.GetType().IsDerivedFrom(AddonType))
                        return true;
                    return false;
                };

                editControl.EditValue = editValue;
                if (WinFormPublic.ShowDialog(editControl) == DialogReturn.OK) {
                    edit.EditValue = editControl.EditValue;
                }
            }
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(string);
        }
    }
}
