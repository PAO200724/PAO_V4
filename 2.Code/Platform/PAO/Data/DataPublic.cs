using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; 

namespace PAO.Data {
    /// <summary>
    /// 静态类:DataPublic
    /// 数据公共类
    /// 作者:PAO
    /// </summary>
    public static class DataPublic {
        /// <summary>
        /// 默认数据连接
        /// </summary>
        public static DataConnection DataConnection;
        /// <summary>
        /// 参数前缀列表
        /// </summary>
        public static readonly string[] ParamPrefixes = new string[]
        {
                "@", ":"
        };

        #region 数据类型
        /// <summary>
        /// 本地Type转换为DbType
        /// </summary>
        /// <param name="type">本地Type</param>
        /// <returns>DbType</returns>
        public static DbType GetDbTypeByNativeType(Type type) {
            if (type == typeof(Int32)) {
                return DbType.Int32;
            }
            else if (type == typeof(Int16)) {
                return DbType.Int16;
            }
            else if (type == typeof(Int64)) {
                return DbType.Int64;
            }
            else if (type == typeof(UInt16)) {
                return DbType.UInt16;
            }
            else if (type == typeof(UInt32)) {
                return DbType.UInt32;
            }
            else if (type == typeof(UInt64)) {
                return DbType.UInt64;
            }
            else if (type == typeof(byte)) {
                return DbType.Byte;
            }
            else if (type == typeof(sbyte)) {
                return DbType.SByte;
            }
            else if (type == typeof(Guid)) {
                return DbType.Guid;
            }
            else if (type == typeof(float)) {
                return DbType.Single;
            }
            else if (type == typeof(double)) {
                return DbType.Double;
            }
            else if (type == typeof(decimal)) {
                return DbType.Decimal;
            }
            else if (type == typeof(DateTime)) {
                return DbType.Date;
            }
            else if (type == typeof(bool)) {
                return DbType.Boolean;
            }
            else if (type == typeof(byte[])) {
                return DbType.Binary;
            }
            else if (type == typeof(string)) {
                return DbType.String;
            }
            else {
                return DbType.Object;
            }
        }

        /// <summary>
        /// DbType转换为本地Type
        /// </summary>
        /// <param name="dbType">DbType</param>
        /// <returns>本地Type</returns>
        public static Type GetNativeTypeByDbType(DbType dbType) {
            switch (dbType) {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.Xml:
                    return typeof(string);
                case DbType.Guid:
                    return typeof(Guid);
                case DbType.Binary:
                    return typeof(byte[]);
                case DbType.Boolean:
                    return typeof(bool);
                case DbType.SByte:
                    return typeof(sbyte);
                case DbType.Int16:
                    return typeof(Int16);
                case DbType.Int32:
                    return typeof(Int32);
                case DbType.Int64:
                    return typeof(Int64);
                case DbType.Byte:
                    return typeof(byte);
                case DbType.UInt16:
                    return typeof(UInt16);
                case DbType.UInt32:
                    return typeof(UInt32);
                case DbType.UInt64:
                    return typeof(UInt64);
                case DbType.Decimal:
                case DbType.VarNumeric:
                case DbType.Currency:
                    return typeof(decimal);
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:
                case DbType.Time:
                case DbType.DateTimeOffset:
                    return typeof(DateTime);
                case DbType.Double:
                    return typeof(double);
                case DbType.Single:
                    return typeof(float);
                default:
                    return typeof(object);
            }
        }
        #endregion

        #region DataService扩展
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="parameters">参数</param>
        /// <param name="dataService">数据服务</param>
        /// <returns>数据表</returns>
        public static DataTable QueryAllBySql(this DataService dataService, string sql, params DataField[] parameters) {
            return dataService.QueryBySql(sql, 0, Int32.MaxValue, parameters);
        }

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="maxCount">最大行数</param>
        /// <param name="parameters">参数</param>
        /// <param name="dataService">数据服务</param>
        /// <param name="dataTable">数据表</param>
        public static void FillBySql(this DataService dataService, DataTable dataTable, string sql, int startIndex, int maxCount, params DataField[] parameters) {
            var table = dataService.QueryBySql(sql, startIndex, maxCount, parameters);

            dataTable.Merge(table, false, MissingSchemaAction.Ignore);
        }

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="parameters">参数</param>
        /// <param name="dataService">数据服务</param>
        /// <param name="dataTable">数据表</param>
        public static void FillAllBySql(this DataService dataService, DataTable dataTable, string sql, params DataField[] parameters) {
            FillBySql(dataService, dataTable, sql, 0, Int32.MaxValue, parameters);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="commandID">命令</param>
        /// <param name="parameters">参数</param>
        /// <param name="dataService">数据服务</param>
        /// <returns>数据表</returns>
        public static DataTable QueryAll(this IDataService dataService, string commandID, params DataField[] parameters) {
            return dataService.Query(commandID, 0, Int32.MaxValue, parameters);
        }

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandID">命令</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="maxCount">最大行数</param>
        /// <param name="parameters">参数</param>
        /// <param name="dataService">数据服务</param>
        /// <param name="dataTable">数据表</param>
        public static void Fill(this IDataService dataService, DataTable dataTable, string commandID, int startIndex, int maxCount, params DataField[] parameters) {
            var table = dataService.Query(commandID, startIndex, maxCount, parameters);

            dataTable.Merge(table, false, MissingSchemaAction.Ignore);
        }

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandID">命令</param>
        /// <param name="parameters">参数</param>
        /// <param name="dataService">数据服务</param>
        /// <param name="dataTable">数据表</param>
        public static void FillAll(this IDataService dataService, DataTable dataTable, string commandID, params DataField[] parameters) {
            Fill(dataService, dataTable, commandID, 0, Int32.MaxValue, parameters);
        }
        #endregion

        #region 参数
        /// <summary>
        /// 在Sql中寻找参数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="paramPrefix">参数前缀</param>
        /// <returns>参数名称列表</returns>
        public static IEnumerable<string> FindParameters(string sql) {
            string paramPrefixString = "";
            foreach(var paramPrefix in ParamPrefixes) {
                paramPrefixString += paramPrefix;
            }
            Regex regex = new Regex(String.Format(@"[{0}]\w+", paramPrefixString));
            var matches = regex.Matches(sql);
            return matches.Cast<Match>().Select(p=>p.ToString());
        }
        #endregion

        #region DataFields
        /// <summary>
        /// 通过数据字段列表创建表
        /// </summary>
        /// <param name="dataFields">数据列列表</param>
        /// <returns>数据表</returns>
        public static DataTable GetTableByFields(IEnumerable<DataField> dataFields) {
            if (dataFields == null)
                return null;
            var schemaTable = new DataTable();
            var keyColumnList = new List<System.Data.DataColumn>();
            foreach(var dataField in dataFields) {
                var newColumn = schemaTable.Columns.Add();
                DataFieldToDataColumn(dataField, newColumn);
                if (dataField.IsKey) {
                    keyColumnList.Add(newColumn);
                }
            }
            if(keyColumnList.IsNotNullOrEmpty()) {
                schemaTable.PrimaryKey = keyColumnList.ToArray();
            }
            return schemaTable;
        }

        /// <summary>
        /// 根据表格获取数据字段列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>数据列列表</returns>
        public static IEnumerable<DataField> GetFieldsByTable(DataTable dataTable) {
            if (dataTable == null)
                return null;

            var dataFields = new List<DataField>();
            foreach(DataColumn dataColumn in dataTable.Columns) {
                var newField = new DataField();
                DataColumnToDataField(dataColumn, newField);
                if (dataTable.PrimaryKey.Contains(dataColumn))
                    newField.IsKey = true;
                dataFields.Add(newField);
            }

            return dataFields;
        }

        /// <summary>
        /// 将数据列转换为报表列
        /// </summary>
        /// <param name="dataColumns">数据列</param>
        /// <param name="dataField">报表列</param>
        public static void DataColumnToDataField(DataColumn dataColumn, DataField dataField) {
            if (dataColumn == null || dataField == null)
                return;

            dataField.Name = dataColumn.ColumnName;
            dataField.ObjectType = dataColumn.DataType;
            dataField.Expression = dataColumn.Expression;
        }

        /// <summary>
        /// 将数据列转换为报表列
        /// </summary>
        /// <param name="dataColumns">数据列</param>
        /// <param name="dataField">报表列</param>
        public static void DataFieldToDataColumn(DataField dataField, DataColumn dataColumn) {
            if (dataColumn == null || dataField == null)
                return;

            dataColumn.ColumnName = dataField.Name;
            dataColumn.DataType = dataField.ObjectType;
            dataColumn.Expression = dataField.Expression;
        }
        
        #endregion
    }
}
