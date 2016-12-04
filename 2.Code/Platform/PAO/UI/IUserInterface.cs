using PAO.Event;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

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
        /// 显示异常对话框
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="caption">标题</param>
        /// <param name="dialogType">对话框类型</param>
        DialogReturn ShowMessageDialog(string message, string caption, DialogType dialogType);

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="openOrSave">打开True/关闭False</param>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="filter">文件过滤器</param>
        DialogReturn ShowFileDialog(bool openOrSave, string caption, string filter, ref string fileName);
        
        /// <summary>
        /// 显示等待窗体
        /// </summary>
        void ShowWaitingForm();

        /// <summary>
        /// 关闭等待窗体
        /// </summary>
        void CloseWaitingForm();

        /// <summary>
        /// 截屏
        /// </summary>
        /// <returns>图片</returns>
        Image ScreenShot();
        #endregion
    }
}
