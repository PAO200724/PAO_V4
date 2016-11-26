using System;
using System.Collections.Generic;
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

        /// <summary>
        /// 显示异常对话框
        /// </summary>
        /// <param name="exception">异常</param>
        public static void ShowExceptionDialog(Exception exception) {
            DefaultUserInterface.ShowExceptionDialog(exception);
        }
    }
}
