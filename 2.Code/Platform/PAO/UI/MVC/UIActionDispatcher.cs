using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 类：UIActionDispatcher
    /// UI动作分发器
    /// 作者：PAO
    /// </summary>
    public class UIActionDispatcher
    {
        /// <summary>
        /// 分发器所在的控件
        /// </summary>
        private Control Container;

        public UIActionDispatcher(Control container) {
            Container = container;
        }

        /// <summary>
        /// 执行UI动作
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="actionName">动作名称</param>
        /// <param name="actionParameters">动作参数</param>
        /// <param name="asyncRun">异步执行</param>
        public void DoUIAction(object sender
            , string actionName
            , IEnumerable<object> actionParameters
            , bool asyncRun = false) {
            if(UIActing != null) {
                var eventArgs = new UIActionEventArgs()
                {
                    ActionName = actionName,
                    ActionParameters = actionParameters
                };
                if(asyncRun) {
                    Task.Factory.StartNew(()=> {
                        Container.Invoke(UIActing, sender, eventArgs);
                    });
                } else {
                    UIActing(sender, eventArgs);
                }
            }
        }

        /// <summary>
        /// 视图动作事件
        /// </summary>
        public event EventHandler<UIActionEventArgs> UIActing;
    }
}
