using PAO;
using PAO.UI.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.WinForm.MDI.Views
{
    /// <summary>
    /// 类：ReportViewController
    /// 报表控制器
    /// 报表控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表控制器")]
    [Description("报表控制器")]
    public class ReportViewController : BaseController
    {
        #region 插件属性

        #region 属性：ChildControllers
        /// <summary>
        /// 属性：ChildControllers
        /// 子控制器
        /// 可以是参数获取器或者是数据显示器等
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("子控制器")]
        [Description("可以是参数获取器或者是数据显示器等")]
        public List<Ref<BaseController>> ChildControllers {
            get;
            set;
        }
        #endregion 属性：ChildControllers

        #endregion
        public ReportViewController() {
        }

        protected override IView OnCreateView() {
            var reportView = new ReportView();
            return reportView;
        }
    }
}
