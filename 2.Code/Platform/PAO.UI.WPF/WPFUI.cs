using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.WPF
{
    /// <summary>
    /// 类：WPFUI
    /// WPF式的用户界面
    /// WPF样式的用户界面
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("WPF式的用户界面")]
    [Description("WPF样式的用户界面")]
    public class WPFUI : PaoObject, IUserInterface
    {
        #region 插件属性
        #endregion
        public WPFUI() {
        }

        public void ShowExceptionDialog(Exception exception) {
            
        }
    }
}
