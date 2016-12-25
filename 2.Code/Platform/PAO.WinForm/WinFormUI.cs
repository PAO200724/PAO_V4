using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using PAO;
using PAO.Event;
using PAO.UI;
using PAO.WinForm.Controls;
using PAO.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.WinForm
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
    public class WinFormUI : PaoObject, IUserInterface
    {
        #region 插件属性
        #endregion

        public WinFormUI() {
        }

        public void CloseWaitingForm() {
            SplashScreenManager.CloseForm(false);
        }

        public void ShowEventDialog(EventInfo eventInfo) {
            var eventControl = new EventControl();
            eventControl.Initialize(eventInfo);
            WinFormPublic.ShowDialog(eventControl);
        }

        public DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) {
            return XtraMessageBox.Show(text, caption, buttons, icon);
        }

        public void ShowWaitingForm() {
            CloseWaitingForm();
            SplashScreenManager.ShowForm(typeof(PaoWaitForm));
        }
        /// <summary>
        /// 截屏（主屏幕）
        /// </summary>
        /// <returns>主屏幕图片</returns>
        public Image ScreenShot() {
            return WinFormPublic.ScreenShot(Screen.PrimaryScreen);
        }

        public DialogReturn ShowMessageDialog(string message, string caption, DialogType dialogType) {
            MessageBoxButtons buttons;
            MessageBoxIcon icon;
            switch (dialogType) {
                case DialogType.Information:
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                    break;
                case DialogType.Warning:
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Warning;
                    break;
                case DialogType.Error:
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Error;
                    break;
                case DialogType.OKCancel:
                    buttons = MessageBoxButtons.OKCancel;
                    icon = MessageBoxIcon.Question;
                    break;
                case DialogType.YesNo:
                    buttons = MessageBoxButtons.YesNo;
                    icon = MessageBoxIcon.Question;
                    break;
                case DialogType.YesNoCancel:
                    buttons = MessageBoxButtons.YesNoCancel;
                    icon = MessageBoxIcon.Question;
                    break;
                default:
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.None;
                    break;
            }

            var result = XtraMessageBox.Show(message, caption, buttons, icon);
            return WinFormPublic.DialogResultToDialogReturn(result);
        }

        public DialogReturn ShowFileDialog(bool openOrSave, string caption, string filter, ref string fileName) {
            FileDialog fileDialog;
            if (openOrSave)
                fileDialog = new OpenFileDialog();
            else
                fileDialog = new SaveFileDialog();
            fileDialog.Title = caption;
            fileDialog.FileName = fileName;
            fileDialog.Filter = filter;
            fileDialog.AddExtension = true;
            if (fileName.IsNotNullOrEmpty())
                fileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
            var result = fileDialog.ShowDialog();
            fileName = fileDialog.FileName;
            return WinFormPublic.DialogResultToDialogReturn(result);
        }

    }
}
