using PAO;
using PAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report
{
    /// <summary>
    /// 类：ReportDataTable
    /// 报表的数据表定义
    /// 报表的数据表定义
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表的数据表定义")]
    [Description("报表的数据表定义")]
    public class ReportDataTable : PaoObject
    {
        #region 插件属性
        #region 属性：TableName
        /// <summary>
        /// 属性：TableName
        /// 表名
        /// 数据表名
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("表名")]
        [Description("数据表名")]
        public string TableName {
            get;
            set;
        }
        #endregion 属性：TableName

        #region 属性：Caption
        /// <summary>
        /// 属性：Caption
        /// 标题
        /// 报表标题
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("标题")]
        [Description("报表标题")]
        public string Caption {
            get;
            set;
        }
        #endregion 属性：Caption

        #region 属性：QueryBehavior
        /// <summary>
        /// 属性：QueryBehavior
        /// 查询行为
        /// 查询行为的定义
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("查询行为")]
        [Description("查询行为的定义")]
        public Ref<ReportQueryBehavior> QueryBehavior {
            get;
            set;
        }
        #endregion 属性：QueryBehavior

        #region 属性：DataColumns
        /// <summary>
        /// 属性：DataColumns
        /// 数据字段
        /// 数据列定义
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据字段")]
        [Description("数据列定义")]
        public List<ReportDataColumn> DataColumns {
            get;
            set;
        }
        #endregion 属性：DataColumns

        #region 属性：QueryParameters
        /// <summary>
        /// 属性：QueryParameters
        /// 查询参数
        /// 查询用的参数
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("查询参数")]
        [Description("查询用的参数")]
        public List<ReportDataField> QueryParameters {
            get;
            set;
        }
        #endregion 属性：QueryParameters        

        #region 属性：DataFetcher
        /// <summary>
        /// 属性：DataFetcher
        /// 数据获取器
        /// 数据获取器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据获取器")]
        [Description("数据获取器")]
        public Ref<IDataFetch> DataFetcher {
            get;
            set;
        }
        #endregion 属性：DataFetcher
        #endregion
        public ReportDataTable() {
        }
    }
}
