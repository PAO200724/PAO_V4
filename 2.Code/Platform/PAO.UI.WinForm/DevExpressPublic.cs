using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using PAO.UI.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 静态类：DevExpressPublic
    /// DevExpress公共类
    /// 作者：PAO
    /// </summary>
    public static class DevExpressPublic
    {
        #region ButtonEditor
        /// <summary>
        /// 添加清除按钮
        /// </summary>
        /// <param name="buttonEdit">按钮编辑器</param>
        public static void AddClearButton(this RepositoryItemButtonEdit buttonEdit) {
            buttonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
        }

        private static void ButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
            if(e.Button.Kind == ButtonPredefines.Delete) {
                var buttonEdit = sender as ButtonEdit;
                buttonEdit.EditValue = null;
            }
        }
        #endregion

    }
}
