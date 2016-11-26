using System;
using System.Collections.Generic;
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
        /// <summary>
        /// 显示异常对话框
        /// </summary>
        /// <param name="exception">异常</param>
        void ShowExceptionDialog(Exception exception);
    }
}
