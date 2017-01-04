﻿using PAO;
using PAO.Config.Editor;
using PAO.Data;
using PAO.Report.Controls;
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
        public ReportQueryBehavior QueryBehavior {
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
        public List<DataField> DataColumns {
            get;
            set;
        }
        #endregion 属性：DataColumns

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
            ParameterEditController = new DataFieldsEditController();
        }

        /// <summary>
        /// 获取格式表
        /// DataColumns，则以其为准，否则，以DataColumns为准
        /// </summary>
        /// <returns>格式表</returns>
        public DataTable GetSchemaTable() {
            DataTable schemaTable = null;
            if(DataFetcher.IsNotNull()) {
                schemaTable = DataFetcher.Value.GetDataSchema();
            } else {
                schemaTable = new DataTable();
            }

            // 根据DataColumn填充DataChema
            var columnSchemaTable = DataPublic.GetTableByFields(DataColumns);
            if(columnSchemaTable != null) {
                schemaTable.Merge(columnSchemaTable);
            }
            schemaTable.TableName = TableName;
            return schemaTable;
        }

        /// <summary>
        /// 获取格式表
        /// DataColumns，则以其为准，否则，以DataColumns为准
        /// </summary>
        /// <returns>格式表</returns>
        public IEnumerable<DataField> GetColumns() {
            List<DataField> dataColumns = new List<DataField>(); ;
            if (DataFetcher.IsNotNull()) {
                var schemaTable = DataFetcher.Value.GetDataSchema();
                var fields = DataPublic.GetFieldsByTable(schemaTable);
                dataColumns.AddRange(fields);
            }

            if(DataColumns.IsNotNullOrEmpty()) {
                foreach(DataField dataColumn in DataColumns) {
                    var foundColumn = dataColumns.Where(p => p.Name == dataColumn.Name).FirstOrDefault();
                    if (foundColumn != null)
                        dataColumns.Remove(foundColumn);
                    dataColumns.Add(dataColumn);
                }
            }
            return dataColumns;
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
