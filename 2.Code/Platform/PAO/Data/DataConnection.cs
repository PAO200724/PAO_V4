﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data;
using System.ComponentModel;
using PAO.Properties;
using PAO.Data.Filters;

namespace PAO.Data
{
    /// <summary>
    /// 类:DbConnection
    /// 数据连接
    /// 数据连接以及数据库相关操作
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    [DataContract(Namespace = "")]
    [Icon(typeof(Resources), "database_connect")]
    [Serializable]
    [Name("数据连接信息")]
    [Description("数据连接相关的属性")]
    public class DataConnection : PaoObject, IDataConnection
    {
        #region 插件属性
        #region 属性:DbFactoryName
        /// <summary>
        /// 属性:DbFactoryName
        /// 数据工厂名称
        /// 用于创建数据连接的数据工厂名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据工厂名称")]
        [Description("用于创建数据连接的数据工厂名称")]
        [EditorType("PAO.Config.Editor.DbFactoryEditController")]
        public string DbFactoryName {
            get;
            set;
        }
        #endregion 属性:DbFactoryName

        #region 属性:ConnectionString
        /// <summary>
        /// 属性:ConnectionString
        /// 数据连接字符串
        /// 数据库连接字符串
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据连接字符串")]
        [Description("数据库连接字符串")]
        public string ConnectionString {
            get;
            set;
        }
        #endregion 属性:ConnectionString
        #endregion
        /// <summary>
        /// 构造方法
        /// </summary>
        public DataConnection() {
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "DbFactoryName", "ConnectionString");
        }

        /// <summary>
        /// 创建数据提供器工厂
        /// </summary>
        /// <returns>数据提供器工厂</returns>
        public DbProviderFactory CreateDbProviderFactoryy() {
            if (DbFactoryName.IsNullOrEmpty())
                return null;
            return DbProviderFactories.GetFactory(DbFactoryName);
        }

        [NonSerialized]
        private DbProviderFactory _ProviderFac;
        /// <summary>
        /// 工厂
        /// </summary>
        [Browsable(false)]
        public DbProviderFactory Factory {
            get {
                /// 只用创建一次连接器工厂
                if (_ProviderFac == null)
                    _ProviderFac = CreateDbProviderFactoryy();

                return _ProviderFac;
            }
        }

        #region 连接、命令
        /// <summary>
        /// 连接
        /// </summary>
        public DbConnection CreateConnection() {
            var connection = Factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            return connection;
        }

        /// <summary>
        /// 连接
        /// </summary>
        public DbDataAdapter CreateDataAdapter() {
            return Factory.CreateDataAdapter();
        }
        
        /// <summary>
        /// 创建数据命令
        /// </summary>
        /// <param name="connectionInfo">连接信息</param>
        /// <param name="commandInfo">命令信息</param>
        /// <param name="paramValues">参数值</param>
        /// <returns>数据命令</returns>
        public DbCommand CreateDataCommand(DataCommandInfo commandInfo
                , params DataParameter[] parameterList) {
            DbCommand command = Factory.CreateCommand();
            command.Connection = CreateConnection();
            commandInfo.FillCommand(command, parameterList);

            return command;
        }
        /// <summary>
        /// 创建数据适配器
        /// </summary>
        /// <param name="connectionInfo">连接信息</param>
        /// <param name="commandInfo">命令信息</param>
        /// <param name="paramValues">参数值</param>
        /// <returns>数据适配器</returns>
        public IDbDataAdapter CreateDataAdapter(DataCommandInfo commandInfo
                , params DataParameter[] paramValues) {
            DbCommand command = CreateDataCommand(commandInfo, paramValues);
            DbDataAdapter adapter = CreateDataAdapter();
            adapter.SelectCommand = command;
            return adapter;
        }

        /// <summary>
        /// 创建数据适配器
        /// </summary>
        /// <param name="connectionInfo">连接信息</param>
        /// <param name="tableName">表名</param>
        /// <param name="update">是否更新表</param>
        /// <returns>数据适配器</returns>
        public IDbDataAdapter CreateDataAdapter(string tableName
                , bool update = true) {
            const string accessDbFactoryName = "System.Data.OleDb";
            var commandInfo = new DataCommandInfo() { Sql = String.Format("SELECT * FROM {0} WHERE 1=0", tableName) };
            DbCommand command = CreateDataCommand(commandInfo);
            DbDataAdapter adapter = CreateDataAdapter();
            adapter.SelectCommand = command;

            if (update) {
                DbCommandBuilder commandBuilder = Factory.CreateCommandBuilder();
                commandBuilder.DataAdapter = adapter;
                /// TODO: ACCESS数据库的更新、插入语句需要加[]，暂时的处理方法
                if (DbFactoryName == accessDbFactoryName) {
                    commandBuilder.QuotePrefix = "[";
                    commandBuilder.QuoteSuffix = "]";
                }
                adapter.InsertCommand = commandBuilder.GetInsertCommand();
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            }
            return adapter;
        }
        #endregion

        #region 数据库操作

        /// <summary>
        /// 获取表格式
        /// </summary>
        /// <param name="commandInfo">命令ID</param>
        /// <returns>表格式</returns>
        public DataTable GetSchema(DataCommandInfo commandInfo) {
            var dataAdapter = CreateDataAdapter(commandInfo);
            try {
                string sql = String.Format(@"SELECT * FROM ({0}) SCHEMA_TABLE WHERE 1=0", dataAdapter.SelectCommand.CommandText);
                var selectCommand = new DataCommandInfo()
                {
                    Sql = sql
                };
                dataAdapter.SelectCommand = CreateDataCommand(selectCommand);
                dataAdapter.SelectCommand.Connection.Open();

                DataSet dataSet = new DataSet();
                dataAdapter.FillSchema(dataSet, SchemaType.Source);
                return dataSet.Tables[0];
            }
            finally {
                dataAdapter.SelectCommand.Connection.Close();
            }
        }
        
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="commandInfo">命令ID</param>
        /// <returns>参数列表</returns>
        public DataParameter[] GetParameters(DataCommandInfo commandInfo) {
            return commandInfo.GetDefinedParameters();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="command">命令<</param>
        /// <param name="startIndex">启动索引</param>
        /// <param name="maxCount">数据查询最大行数</param>
        /// <param name="dataTable">数据表</param>
        public void QueryData(DbCommand command, int startIndex, int maxCount, DataTable dataTable) {
            command.Connection.Open();
            try {
                using (var dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)) {
                    for (int i = 0; i < startIndex; i++) {
                        if (!dataReader.Read())
                            return;
                    }

                    for (int i = 0; i < maxCount; i++) {
                        if (!dataReader.Read())
                            break;

                        object[] values = new object[dataReader.FieldCount];
                        dataReader.GetValues(values);
                        // 去掉DBNull，否则无法在WCF中传递
                        for (int j = 0; j < values.Length; j++) {
                            if (values[j].IsNull())
                                values[j] = null;
                        }
                        dataTable.Rows.Add(values);
                    }
                }
                dataTable.AcceptChanges();
            }
            finally {
                command.Connection.Close();
                command.Dispose();
            }
        }

        /// <summary>
        /// 通过Sql查询表
        /// </summary>
        /// <param name="commandInfo">查询命令</param>
        /// <param name="parameterList">参数</param>
        /// <returns>数据记录集</returns>
        public DataTable QueryTableByCommand(DataCommandInfo commandInfo, int startIndex, int maxCount, params DataParameter[] parameterList) {
            var dataTable = GetSchema(commandInfo);
            var command = CreateDataCommand(commandInfo, parameterList);
            QueryData(command, startIndex, maxCount, dataTable);
            return dataTable;
        }


        /// <summary>
        /// 通过Sql查询表
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="dataFilter">数据查询器</param>
        /// <param name="parameterList">参数</param>
        /// <returns>数据记录集</returns>
        public DataTable QueryTableBySql(string sql, DataFilter dataFilter, int startIndex, int maxCount, params DataParameter[] parameterList) {
            var commandInfo = new DataCommandInfo() { Sql = sql, DataFilter = dataFilter };
            var command = CreateDataCommand(commandInfo, parameterList);
            var dataTable = GetSchema(commandInfo);
            QueryData(command, startIndex, maxCount, dataTable);
            return dataTable;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="commandInfo">命令ID</param>
        /// <param name="parameterList">参数列表</param>
        public void Execute(DataCommandInfo commandInfo, params DataParameter[] parameterList) {
            var command = CreateDataCommand(commandInfo, parameterList);
            command.Connection.Open();
            try {
                command.ExecuteNonQuery();
            } finally {
                command.Connection.Close();
                command.Dispose();
            }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="commandInfo">命令ID</param>
        /// <param name="parameterList">参数列表</param>
        public object ExecuteScalar(DataCommandInfo commandInfo, params DataParameter[] parameterList) {
            var command = CreateDataCommand(commandInfo, parameterList);
            command.Connection.Open();
            try {
                return command.ExecuteScalar();
            } finally {
                command.Connection.Close();
                command.Dispose();
            }
        }
        /// <summary>
        /// 更新表数据
        /// </summary>
        /// <param name="dataTable">数据表，此表必须设置表名，并通过表名在数据库检索数据</param>
        /// <param name="tableName">表名</param>
        /// <returns>数据格式</returns>
        public void UpdateTable(DataTable dataTable, string tableName) {
            var dataAdapter = CreateDataAdapter(tableName);
            dataAdapter.SelectCommand.Connection.Open();
            var trans = dataAdapter.SelectCommand.Connection.BeginTransaction();
            try {

                DataSet dataSet = new DataSet();
                dataAdapter.FillSchema(dataSet, SchemaType.Mapped);
                var change = dataTable.GetChanges();
                if (!change.IsNullOrEmpty()) {
                    dataSet.Tables[0].Merge(change);
                    dataAdapter.Update(dataSet);
                }
                trans.Commit();
            }
            finally {
                dataAdapter.SelectCommand.Connection.Close();
            }
        }
        #endregion
    }
}
