using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm
{
    /// <summary>
    /// 类：WinFormUI
    /// WinForm式UI
    /// Windows Form模式的用户界面
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("WinForm式UI")]
    [Description("Windows Form模式的用户界面")]
    public class WinFormUI : PaoObject, IUserInterface
    {
        #region 插件属性
        #endregion
        public WinFormUI() {
        }

        public void ShowExceptionDialog(Exception exception) {
            MessageBox.Show(exception.FormatException(), "异常", MessageBoxButtons.OK);
        }
    }
}
