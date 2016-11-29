using PAO.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        /// <param name="exception">异常</param>
        public static void ShowExceptionDialog(Exception exception) {
            DefaultUserInterface.ShowExceptionDialog(exception);
        }

        /// <summary>
        /// 显示消息对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowInfomationDialog(string text, string caption = null) {
            DefaultUserInterface.ShowMessageBox(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowWarningDialog(string text, string caption = null) {
            DefaultUserInterface.ShowMessageBox(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowErrorDialog(string text, string caption = null) {
            DefaultUserInterface.ShowMessageBox(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示是否对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogResult ShowYesNoDialog(string text, string caption = null) {
            return DefaultUserInterface.ShowMessageBox(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 显示是/否/取消对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogResult ShowYesNoCancelDialog(string text, string caption = null) {
            return DefaultUserInterface.ShowMessageBox(text, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 显示确定/取消对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogResult ShowOKCancelDialog(string text, string caption = null) {
            return DefaultUserInterface.ShowMessageBox(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        
        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileFilters">文件过滤器</param>
        public static DialogResult ShowOpenFileDialog(string caption, ref string fileName, params string[] fileFilters) {
            return DefaultUserInterface.ShowOpenFileDialog(caption, FileExtentions.BuildFileFilter(fileFilters), ref fileName);
        }

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileFilters">文件过滤器</param>
        public static DialogResult ShowSaveFileDialog(string caption, ref string fileName, params string[] fileFilters) {
            return DefaultUserInterface.ShowSaveFileDialog(caption, FileExtentions.BuildFileFilter(fileFilters), ref fileName);
        }
        #endregion
    }
}
