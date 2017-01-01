﻿using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace PAO.WinForm.Editor
{
    /// <summary>
    /// 类：FontEditor
    /// 字体编辑器
    /// 字体编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("字体编辑器")]
    [Description("字体编辑器")]
    public class FontEditor : BaseDevEditController
    {
        #region 插件属性
        #endregion
        public FontEditor() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemButtonEdit();
            WinFormPublic.AddClearButton(edit);
            edit.ButtonClick += (sender, e) =>
            {
                if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) {
                    var buttonEdit = sender as ButtonEdit;
                    var font = buttonEdit.EditValue as Font;
                    var fontDialog = new FontDialog()
                    {
                        Font = font
                    };
                    if (fontDialog.ShowDialog() == DialogResult.OK) {
                        buttonEdit.EditValue = fontDialog.Font;
                    }
                }
            };
            return edit;
        }
    }
}
