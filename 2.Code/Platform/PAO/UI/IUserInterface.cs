using PAO.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI
{
    /// <summary>
    /// 接口：IUserInterface
    /// 用户界面接口
    /// 作者：PAO
    /// </summary>
    public interface IUserInterface
    {
        #region 对话框
        /// <summary>
        /// 显示异常对话框
        /// </summary>
        /// <param name="eventInfo">事件信息</param>
        void ShowEventDialog(EventInfo eventInfo);

        /// <summary>
        /// 显示消息对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">图标</param>
        DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="filter">文件过滤器</param>
        DialogResult ShowOpenFileDialog(string caption, string filter, ref string fileName);

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="filter">文件过滤器</param>
        DialogResult ShowSaveFileDialog(string caption, string filter, ref string fileName);

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="childControl">子控件</param>
        /// <param name="cancelButton">取消按钮</param>
        /// <param name="applyButton">应用按钮</param>
        /// <returns></returns>
        DialogResult ShowDialog(Control childControl);

        /// <summary>
        /// 显示等待窗体
        /// </summary>
        void ShowWaitingForm();

        /// <summary>
        /// 关闭等待窗体
        /// </summary>
        void CloseWaitingForm();
        #endregion
    }
}
