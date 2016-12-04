using PAO.Event;
using PAO.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PAO.UI
{
    /// <summary>
    /// 静态类：UIPublic
    /// UI公共类
    /// 作者：PAO
    /// </summary>
    public static class UIPublic
    {
        public static IUserInterface DefaultUserInterface;

        #region 对话框
        /// <summary>
        /// 显示异常对话框
        /// </summary>
        /// <param name="eventInfo">事件信息</param>
        public static void ShowEventDialog(EventInfo eventInfo) {
            DefaultUserInterface.ShowEventDialog(eventInfo);
        }

        /// <summary>
        /// 显示消息对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowInfomationDialog(string text, string caption = null) {
            DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.Information);
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowWarningDialog(string text, string caption = null) {
            DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.Warning);
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowErrorDialog(string text, string caption = null) {
            DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.Error);
        }

        /// <summary>
        /// 显示是否对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogReturn ShowYesNoDialog(string text, string caption = null) {
            return DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.YesNo);
        }

        /// <summary>
        /// 显示是/否/取消对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogReturn ShowYesNoCancelDialog(string text, string caption = null) {
            return DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.YesNoCancel);
        }

        /// <summary>
        /// 显示确定/取消对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogReturn ShowOKCancelDialog(string text, string caption = null) {
            return DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.OKCancel);
        }

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileFilters">文件过滤器</param>
        public static DialogReturn ShowOpenFileDialog(string caption, ref string fileName, params string[] fileFilters) {
            return DefaultUserInterface.ShowFileDialog(true, caption, FileExtentions.BuildFileFilter(fileFilters), ref fileName);
        }

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileFilters">文件过滤器</param>
        public static DialogReturn ShowSaveFileDialog(string caption, ref string fileName, params string[] fileFilters) {
            return DefaultUserInterface.ShowFileDialog(false, caption, FileExtentions.BuildFileFilter(fileFilters), ref fileName);
        }
        

        public static Image ScreenShot() {
            return DefaultUserInterface.ScreenShot();
        }
        #endregion


        #region WaitingForm

        public static void CloseWaitingForm() {
            DefaultUserInterface.CloseWaitingForm();
        }

        public static void ShowWaitingForm() {
            CloseWaitingForm();
            DefaultUserInterface.ShowWaitingForm();
        }
        #endregion
    }
}
