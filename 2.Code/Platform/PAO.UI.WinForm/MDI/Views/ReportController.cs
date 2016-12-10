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

namespace PAO.UI.WinForm.MDI.Views
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
        
        #region 属性：DataFetchers
        /// <summary>
        /// 属性：DataFetchers
        /// 数据获取器
        /// 用于查询获取数据的数据获取器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据获取器")]
        [Description("用于查询获取数据的数据获取器")]
        public List<Ref<IDataFetch>> DataFetchers {
            get;
            set;
        }
        #endregion 属性：DataFetchers

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

        #region 属性：DataSchema
        /// <summary>
        /// 属性：DataSchema
        /// s数据格式
        /// 数据格式
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("s数据格式")]
        [Description("数据格式")]
        public DataSet DataSchema {
            get;
            set;
        }

        #endregion 属性：DataSchema

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
