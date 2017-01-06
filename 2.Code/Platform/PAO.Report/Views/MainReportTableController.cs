using PAO;
using PAO.Data;
using PAO.Report.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report.Views
{
    /// <summary>
    /// 类：MainReportTableController
    /// 主报表控制器
    /// 主报表控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("主报表控制器")]
    [Description("主报表控制器")]
    public class MainReportTableController : ReportTableController
    {
        #region 插件属性

        #region 属性：QueryParameters
        /// <summary>
        /// 属性：QueryParameters
        /// 查询参数
        /// 查询参数
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("查询参数")]
        [Description("查询参数")]
        public List<DataField> QueryParameters {
            get;
            set;
        }
        #endregion 属性：QueryParameters

        #region 属性：ParameterEditController
        /// <summary>
        /// 属性：ParameterEditController
        /// 参数编辑控制器
        /// 参数编辑控制器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("参数编辑控制器")]
        [Description("参数编辑控制器")]
        public DataFieldsEditController ParameterEditController {
            get;
            set;
        }
        #endregion 属性：ParameterEditController
        #endregion
        public MainReportTableController() {
        }


        /// <summary>
        /// 获取查询参数列表
        /// 如果QueryParameters有值，则以其为准，否则，以DataFetcher为准
        /// </summary>
        /// <returns>查询参数列表</returns>
        public IEnumerable<DataField> GetParameters() {
            List<DataField> queryParameters = new List<DataField>();
            if (DataFetcher.IsNotNull()) {
                var parameters = DataFetcher.Value.GetParameters();
                if (parameters.IsNotNullOrEmpty())
                    queryParameters.AddRange(parameters);
            }

            if (QueryParameters.IsNotNullOrEmpty()) {
                for (int i = 0; i < queryParameters.Count; i++) {
                    var foundParam = QueryParameters.Where(p => p.Name == queryParameters[i].Name).FirstOrDefault();
                    if (foundParam != null) {
                        queryParameters[i] = foundParam;
                    }
                }
            }
            return queryParameters;
        }
    }
}
