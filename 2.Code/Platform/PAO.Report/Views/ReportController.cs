using PAO;
using PAO.App;
using PAO.Data;
using PAO.UI.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report.Views
{
    /// <summary>
    /// 类：ReportController
    /// 报表控制器
    /// 报表控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表控制器")]
    [Description("报表控制器")]
    public class ReportController : BaseController
    {
        #region 插件属性

        #region 属性：Controllers
        /// <summary>
        /// 属性：Controllers
        /// 控制器列表
        /// 可以是参数获取器或者是数据显示器等
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("子控制器")]
        [Description("可以是参数获取器或者是数据显示器等")]
        public List<Ref<BaseController>> Controllers {
            get;
            set;
        }
        #endregion 属性：Controllers
     
        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 布局数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData

        #region 属性：Tables
        /// <summary>
        /// 属性：Tables
        /// 数据表定义
        /// 报表中的数据表定义
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据表定义")]
        [Description("报表中的数据表定义")]
        public ReportDataTable Tables {
            get;
            set;
        }
        #endregion 属性：Tables

        #region 属性：QueryBehavior
        /// <summary>
        /// 属性：QueryBehavior
        /// 查询行为
        /// 整个报表查询行为的定义
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("查询行为")]
        [Description("整个报表查询行为的定义")]
        public Ref<ReportQueryBehavior> QueryBehavior {
            get;
            set;
        }
        #endregion 属性：QueryBehavior
        #endregion

        public ReportController() {
        }

        protected override IView OnCreateView() {
            var reportView = new ReportView();
            reportView.Closing += (s, e) =>
            {
                LayoutData = reportView.LayoutData;
                AddonPublic.FetchAddonExtendProperties(this, "LayoutData");
            };
            if (Controllers.IsNotNullOrEmpty()) {
                foreach(var controller in Controllers) {
                    var view = controller.Value.CreateAndOpenView(reportView);
                    view.UIActionDispatcher = reportView.UIActionDispatcher;
                }
            }
            AddonPublic.ApplyAddonExtendProperties(this);
            reportView.LayoutData = LayoutData;
            return reportView;
        }
    }
}
