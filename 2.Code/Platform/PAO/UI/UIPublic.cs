using PAO.Event;
using PAO.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        /// <param name="err">异常</param>
        public static void ShowExceptionDialog(Exception err) {
            ShowEventDialog(new ExceptionEventInfo(err, true, true));
        }

        /// <summary>
        /// 显示异常对话框
        /// </summary>
        /// <param name="eventInfo">事件信息</param>
        public static void ShowEventDialog(EventInfo eventInfo) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("Event:{0}", eventInfo);
                return;
            }
            DefaultUserInterface.ShowEventDialog(eventInfo);
        }

        /// <summary>
        /// 显示消息对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowInfomationDialog(string text, string caption = null) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("Information:{0}", text);
                return;
            }
            DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.Information);
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowWarningDialog(string text, string caption = null) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("Warning:{0}", text);
                return;
            }
            DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.Warning);
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static void ShowErrorDialog(string text, string caption = null) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("Error:{0}", text);
                return;
            }
            DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.Error);
        }

        /// <summary>
        /// 显示是否对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogReturn ShowYesNoDialog(string text, string caption = null) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("ShowYesNoDialog");
                return DialogReturn.None;
            }
            return DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.YesNo);
        }

        /// <summary>
        /// 显示是/否/取消对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogReturn ShowYesNoCancelDialog(string text, string caption = null) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("ShowYesNoCancelDialog");
                return DialogReturn.None;
            }
            return DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.YesNoCancel);
        }

        /// <summary>
        /// 显示确定/取消对话框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        public static DialogReturn ShowOKCancelDialog(string text, string caption = null) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("ShowOKCancelDialog");
                return DialogReturn.None;
            }
            return DefaultUserInterface.ShowMessageDialog(text, caption, DialogType.OKCancel);
        }

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileFilters">文件过滤器</param>
        public static DialogReturn ShowOpenFileDialog(string caption, ref string fileName, params string[] fileFilters) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("ShowOpenFileDialog");
                return DialogReturn.None;
            }
            return DefaultUserInterface.ShowFileDialog(true, caption, FileExtentions.BuildFileFilter(fileFilters), ref fileName);
        }

        /// <summary>
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileFilters">文件过滤器</param>
        public static DialogReturn ShowSaveFileDialog(string caption, ref string fileName, params string[] fileFilters) {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("ShowSaveFileDialog");
                return DialogReturn.None;
            }
            return DefaultUserInterface.ShowFileDialog(false, caption, FileExtentions.BuildFileFilter(fileFilters), ref fileName);
        }
        

        public static Image ScreenShot() {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("ScreenShot");
                return null;
            }
            return DefaultUserInterface.ScreenShot();
        }
        #endregion

        #region Image
        /// <summary>
        /// 二进制数据转换为图片
        /// </summary>
        /// <param name="binary">二进制数据</param>
        /// <returns>图片</returns>
        public static Image BinaryToImage(byte[] binary) {
            if (binary.IsNullOrEmpty())
                return null;
            using (MemoryStream buffer = new MemoryStream(binary)) {
                return Image.FromStream(buffer);
            }
        }

        /// <summary>
        /// 图片转换为二进制
        /// </summary>
        /// <param name="image">图片</param>
        /// <returns>二进制</returns>
        public static byte[] ImageToBinary(Image image) {
            if (image == null)
                return null;
            using (MemoryStream buffer = new MemoryStream()) {
                image.Save(buffer, image.RawFormat);
                return buffer.ToArray();
            }
        }
        #endregion

        #region WaitingForm

        public static void CloseWaitingForm() {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("CloseWaitingForm");
                return;
            }
            DefaultUserInterface.CloseWaitingForm();
        }

        public static void ShowWaitingForm() {
            if (DefaultUserInterface == null) {
                Debug.WriteLine("ShowWaitingForm");
                return;
            }
            DefaultUserInterface.ShowWaitingForm();
        }
        #endregion
    }
}
