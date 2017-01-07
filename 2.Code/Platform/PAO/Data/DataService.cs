using PAO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PAO.Data {
    /// <summary>
    /// 类：DataService
    /// 数据服务
    /// 数据服务
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [Icon(typeof(Resources), "data_service")]
    [DataContract(Namespace = "")]
    [Name("数据服务")]
    [Description("数据服务")]
    public class DataService : PaoObject, IDataService {
        #region 插件属性
        #region 属性：DataConnection
        /// <summary>
        /// 属性：DataConnection
        /// 数据连接
        /// 用于连接数据库的数据连接
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据连接")]
        [Description("用于连接数据库的数据连接")]
        public Ref<IDataConnection> DataConnection {
            get;
            set;
        }
        #endregion 属性：DataConnection

        #region 属性:CommandList
        /// <summary>
        /// 属性:CommandList
        /// 命令列表
        /// 数据库命令列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("命令列表")]
        [Description("数据库命令列表")]
        public List<DataCommandInfo> CommandList {
            get;
            set;
        }
        #endregion 属性:CommandList
        #endregion

        /// <summary>
        /// 根据命令ID获取命令
        /// </summary>
        /// <param name="commandID">命令ID</param>
        /// <returns>数据命令信息</returns>
        public DataCommandInfo GetDataCommandInfoByID(string commandID) {
            return (from cmd in CommandList
                    where cmd.ID == commandID
                    select cmd).FirstOrDefault();
        }

        /// <summary>
        /// 获取数据格式
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>数据格式</returns>
        public System.Data.DataTable GetSchemaBySql(string sql) {
            var commandInfo = new DataCommandInfo() { Sql = sql };
            return DataConnection.Value.GetSchema(commandInfo);
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>参数列表</returns>
        public DataParameter[] GetParametersBySql(string sql) {
            var commandInfo = new DataCommandInfo() { Sql = sql };
            return DataConnection.Value.GetParameters(commandInfo);
        }

        public System.Data.DataTable QueryBySql(string sql, int startIndex, int maxCount, params DataParameter[] parameters) {
            var commandInfo = new DataCommandInfo() { Sql = sql };
            return DataConnection.Value.QueryTableByCommand(commandInfo, startIndex, maxCount, parameters);
        }

        public void ExecuteBySql(string sql, params DataParameter[] parameterList) {
            var commandInfo = new DataCommandInfo() { Sql = sql };
            DataConnection.Value.Execute(commandInfo, parameterList);
        }

        public object ExecuteScalarBySql(string sql, params DataParameter[] parameterList) {
            var commandInfo = new DataCommandInfo() { Sql = sql };
            return DataConnection.Value.ExecuteScalar(commandInfo, parameterList);
        }
        
        #region IDataService 成员

        public System.Data.DataTable GetSchema(string commandID) {
            var commandInfo = GetDataCommandInfoByID(commandID);
            return DataConnection.Value.GetSchema(commandInfo);
        }

        public DataParameter[] GetParameters(string commandID) {
            var commandInfo = GetDataCommandInfoByID(commandID);
            return DataConnection.Value.GetParameters(commandInfo);
        }

        public System.Data.DataTable Query(string commandID, int startIndex, int maxCount, params DataParameter[] parameters) {
            var commandInfo = GetDataCommandInfoByID(commandID);
            return DataConnection.Value.QueryTableByCommand(commandInfo, startIndex, maxCount, parameters);
        }

        public void Execute(string commandID, params DataParameter[] parameterList) {
            var commandInfo = GetDataCommandInfoByID(commandID);
            DataConnection.Value.Execute(commandInfo, parameterList);
        }

        public object ExecuteScalar(string commandID, params DataParameter[] parameterList) {
            var commandInfo = GetDataCommandInfoByID(commandID);
            return DataConnection.Value.ExecuteScalar(commandInfo, parameterList);
        }

        public void UpdateTable(System.Data.DataTable dataTable, string tableName) {
            DataConnection.Value.UpdateTable(dataTable, tableName);
        }

        #endregion
    }
}
