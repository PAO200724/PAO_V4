using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 接口：IDialogControl
    /// 对话框控件
    /// 作者：PAO
    /// </summary>
    public interface IDialogControl
    {
        /// <summary>
        /// 显示取消按钮
        /// </summary>
        bool ShowCancelButton { get; }
        /// <summary>
        /// 显示应用按钮
        /// </summary>
        bool ShowApplyButton { get; }

        /// <summary>
        /// 退出时事件
        /// </summary>
        /// <param name="dialogResult">对话框结果</param>
        /// <param name="cancel">取消</param>
        void OnClosing(DialogResult dialogResult, ref bool cancel);

        /// <summary>
        /// 应用按钮按下时的事件
        /// </summary>
        void OnApply();

        /// <summary>
        /// 设置窗体状态
        /// </summary>
        /// <param name="form">窗体</param>
        void SetFormState(Form form);

        /// <summary>
        /// 应用按钮状态变化事件
        /// </summary>
        event EventHandler<ApplyButtonStateChangedEventArgs> ApplyButtonStateChanged;
    }
}
