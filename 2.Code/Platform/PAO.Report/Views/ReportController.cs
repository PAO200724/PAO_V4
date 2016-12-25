using PAO;
using PAO.App;
using PAO.Data;
using PAO.Report.Displayers;
using PAO.Report.Properties;
using PAO.MVC;
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
    [Icon(typeof(Resources), "report")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表控制器")]
    [Description("报表控制器")]
    public class ReportController : BaseController
    {
        #region 插件属性

        #region 属性：Displayers
        /// <summary>
        /// 属性：数据显示器
        /// 数据显示器
        /// 数据显示器列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据显示器")]
        [Description("数据显示器列表")]
        public List<Ref<BaseDataDisplayerController>> Displayers {
            get;
            set;
        }
        #endregion 属性：Displayers

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
        public List<ReportDataTable> Tables {
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
        public ReportQueryBehavior QueryBehavior {
            get;
            set;
        }
        #endregion 属性：QueryBehavior

        #endregion

        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 布局数据
        /// </summary>
        [Browsable(false)]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData
        public ReportController() {
        }
        protected override Type ViewType {
            get {
                return typeof(ReportView);
            }
        }
    }
}
