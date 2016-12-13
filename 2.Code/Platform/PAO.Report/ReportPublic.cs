using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using PAO.Data;
using PAO.UI.WinForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Report
{
    /// <summary>
    /// 静态类：ReportPublic
    /// 报表公共类
    /// 作者：PAO
    /// </summary>
    public static class ReportPublic
    {
        /// <summary>
        /// 将数据列转换为报表列
        /// </summary>
        /// <param name="dataColumns">数据列</param>
        /// <param name="reportColumn">报表列</param>
        public static void DataColumnToReportColumn(DataColumn dataColumn, ReportDataColumn reportColumn) {
            if (dataColumn == null || reportColumn == null)
                return;

            reportColumn.Name = dataColumn.ColumnName;
            reportColumn.Type = DataPublic.GetDbTypeByNativeType(dataColumn.DataType);
            reportColumn.Caption = dataColumn.Caption;
            reportColumn.Expression = dataColumn.Expression;
        }

        /// <summary>
        /// 从数据表获取报表列
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>报表列</returns>
        public static IEnumerable<ReportDataColumn> GetReportDataColumns(DataTable dataTable) {
            var reportColumns = new List<Report.ReportDataColumn>();
            var pkColumn = dataTable.PrimaryKey;
            foreach (DataColumn dataColumn in dataTable.Columns) {
                var reportColumn = new ReportDataColumn();
                DataColumnToReportColumn(dataColumn, reportColumn);
                if(pkColumn.Contains(dataColumn)) {
                    reportColumn.IsKey = true;
                }
                reportColumns.Add(reportColumn);
            }
            return reportColumns;
        }

        /// <summary>
        /// 重建报表列（从源列中复制类型，其余保持不变）
        /// </summary>
        /// <param name="destColumns">目标列</param>
        /// <param name="srcColumns">源列</param>
        public static void RebuildReportColumn(List<ReportDataColumn> destColumns, IEnumerable<ReportDataColumn> srcColumns) {
            foreach(var srcColumn in srcColumns) {
                var destColumn = destColumns.Where(p => p.Name == srcColumn.Name).FirstOrDefault();
                if (destColumn != null) {
                    destColumn.Type = srcColumn.Type;
                } else {
                    destColumns.Add(srcColumn);
                }
            }
        }

        #region ParameterInput
        public static void CreateParameterInputRows(VGridControl parameterGridControl, IEnumerable<ReportDataTable> reportDataTables) {
            parameterGridControl.Rows.Clear();
            foreach (var reportTable in reportDataTables) {
                var categoryRow = new CategoryRow(reportTable.Caption);

                foreach (var parameter in reportTable.QueryParameters) {
                    if (parameter.UserInput) {
                        var editorRow = new EditorRow(parameter.Caption);
                        editorRow.Properties.Caption = parameter.Caption;
                        editorRow.Properties.FieldName = parameter.Name;
                        RepositoryItem editor = null;
                        if (parameter.Editor != null) {
                            editor = parameter.Editor.CreateEditor();
                        }
                        else {
                            Type valueType = DataPublic.GetNativeTypeByDbType(parameter.Type);
                            var edit = WinFormPublic.GetDefaultEditorByType(valueType);
                            editor = edit.CreateEditor();
                        }
                        editorRow.Properties.RowEdit = editor;

                        if (parameter.ValueFetcher != null) {
                            editorRow.Properties.Value = parameter.ValueFetcher.Value.FetchValue();
                        }
                        categoryRow.ChildRows.Add(editorRow);
                    }

                }
                if (categoryRow.ChildRows.IsNotNullOrEmpty()) {
                    parameterGridControl.Rows.Add(categoryRow);
                }
            }
        }
        #endregion

    }
}
