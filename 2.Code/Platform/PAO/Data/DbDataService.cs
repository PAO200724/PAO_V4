using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PAO.Data {
    /// <summary>
    /// 类：DbDataService
    /// 数据处理器
    /// 数据库服务
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("数据服务")]
    [Description("数据库服务")]
    public class DbDataService : PaoObject, IDataService {
        #region 插件属性
        #region 属性：DataConnection
        /// <summary>
        /// 属性：DataConnection
        /// 数据连接
        /// 用于连接数据库的数据连接
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("数据连接")]
        [Description("用于连接数据库的数据连接")]
        public DataConnection DataConnection {
            get;
            set;
        }
        #endregion 属性：DataConnection
        #endregion

        #region IDataService 成员

        public System.Data.DataTable GetSchema(string commandID) {
            return DataConnection.GetSchema(commandID);
        }

        public DataField[] GetParameters(string commandID) {
            return DataConnection.GetParameters(commandID);
        }

        public System.Data.DataTable Query(string commandID, int startIndex, int maxCount, params DataField[] parameters) {
            return DataConnection.QueryTableByCommand(commandID, startIndex, maxCount, parameters);
        }

        public void Execute(string commandID, params DataField[] parameterList) {
            DataConnection.Execute(commandID, parameterList);
        }

        public object ExecuteScalar(string commandID, params DataField[] parameterList) {
            return DataConnection.ExecuteScalar(commandID, parameterList);
        }

        public void UpdateTable(System.Data.DataTable dataTable, string tableName) {
            DataConnection.UpdateTable(dataTable, tableName);
        }

        #endregion
    }
}
