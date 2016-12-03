using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 类：WaitingForm
    /// 等待
    /// 用于显示等待窗体的类
    /// 作者：PAO
    /// </summary>
    [Name("等待")]
    [Description("用于显示等待窗体的类")]
    public class Waiting : Component
    {
        #region 插件属性
        #endregion
        public Waiting() {
            DevExpressPublic.ShowWaitingForm();
        }

        protected override void Dispose(bool disposing) {
            DevExpressPublic.CloseWaitingForm();
            base.Dispose(disposing);
        }
    }
}
