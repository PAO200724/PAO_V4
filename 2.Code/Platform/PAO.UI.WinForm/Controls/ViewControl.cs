using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.MVC;

namespace PAO.UI.WinForm.Controls
{
    /// <summary>
    /// 视图基类
    /// 作者：PAO
    /// </summary>
    public partial class ViewControl : DevExpress.XtraEditors.XtraUserControl, IView
    {
        public ViewControl() {
            InitializeComponent();
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public Image Icon { get; set; }
        /// <summary>
        /// 大图标
        /// </summary>
        public Image LargeIcon { get; set; }
        /// <summary>
        /// 视图容器
        /// </summary>
        public IViewContainer ViewContainer { get; set; }
        /// <summary>
        /// UI动作分发器
        /// </summary>
        public UIActionDispatcher UIActionDispatcher { get; set; }
        /// <summary>
        /// 关闭
        /// </summary>
        public event EventHandler Closing;

        /// <summary>
        /// 发出OnClosing事件
        /// </summary>
        public virtual void CloseView() {
            if (Closing != null)
                Closing(this, new EventArgs());
            OnClosing();
        }

        /// <summary>
        /// 控制器
        /// </summary>
        private BaseController _Controller;

        public virtual BaseController Controller {
            get {
                OnGetController(_Controller);
                return _Controller;
            }
            set {
                _Controller = value;
                if(_Controller != null && _Controller.Surface != null) {
                    this.BackColor = _Controller.Surface.BackColor;
                    this.ForeColor = _Controller.Surface.ForeColor;
                    this.Font = _Controller.Surface.Font;
                }
                OnSetController(_Controller);
            }
        }

        protected virtual void OnSetController(BaseController value) {

        }

        protected virtual void OnGetController(BaseController value) {

        }
        protected virtual void OnClosing() { }

        /// <summary>
        /// 分发动作
        /// </summary>
        /// <param name="actionName">动作名称</param>
        /// <param name="parameters">动作参数</param>
        /// <param name="asyncRun">异步运行</param>
        public void DispatchAction(string actionName, IEnumerable<object> parameters, bool asyncRun = false) {
            if(UIActionDispatcher != null) {
                UIActionDispatcher.DoUIAction(this, actionName, parameters, asyncRun);
            }
        }
    }
}
