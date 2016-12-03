using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using PAO;
using PAO.Event;
using PAO.UI.WinForm.Controls;
using PAO.UI.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 类：WinFormUI
    /// WinForm式UI
    /// Windows Form模式的用户界面
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("WinForm式UI")]
    [Description("Windows Form模式的用户界面")]
    public class DevExpressUI : PaoObject, IUserInterface
    {
        #region 插件属性
        #endregion
        public DevExpressUI() {
        }

        public DialogResult ShowDialog(Control childControl) {
            var dialog = new Dialog();
            dialog.ChildControl = childControl;
            return dialog.ShowDialog();
        }
   
        public void ShowEventDialog(EventInfo eventInfo) {
            var eventControl = new EventControl();
            eventControl.Initialize(eventInfo);
            UIPublic.ShowDialog(eventControl);
        }

        public DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) {
            return XtraMessageBox.Show(text, caption, buttons, icon);
        }

        public DialogResult ShowOpenFileDialog(string caption, string filter, ref string fileName) {
            var fileDialog = new OpenFileDialog();
            fileDialog.Title = caption;
            fileDialog.FileName = fileName;
            fileDialog.Filter = filter;
            if (fileDialog.IsNotNullOrEmpty())
                fileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
            return fileDialog.ShowDialog();
        }

        public DialogResult ShowSaveFileDialog(string caption, string filter, ref string fileName) {
            var fileDialog = new SaveFileDialog();
            fileDialog.Title = caption;
            fileDialog.FileName = fileName;
            fileDialog.Filter = filter;
            if (fileDialog.IsNotNullOrEmpty())
                fileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
            return fileDialog.ShowDialog();
        }
    }
}
