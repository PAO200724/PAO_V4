using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace PAO.Data {
    /// <summary>
    /// 接口:IDataService
    /// 数据服务接口
    /// 作者:PAO
    /// </summary>
    [Addon]
    [ServiceContract]
    public interface IDataService {
        /// <summary>
        /// 获取数据表格式
        /// </summary>
        /// <param name="commandID">命令ID</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetSchema(string commandID);

        /// <summary>
        /// 获取数据表格式
        /// </summary>
        /// <param name="commandID">命令ID</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataField[] GetParameters(string commandID);

        /// <summary>
        /// 通过命令步进式查询
        /// </summary>
        /// <param name="commandID">命令ID</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="maxCount">最大行数</param>
        /// <param name="parameterList">参数</param>
        /// <returns>数据记录集</returns>
        [OperationContract]
        DataTable Query(string commandID, int startIndex, int maxCount, params DataField[] parameters);

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="commandID">命令ID</param>
        /// <param name="parameterList">参数</param>
        [OperationContract]
        void Execute(string commandID, params DataField[] parameterList);

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="commandID">命令ID</param>
        /// <param name="parameterList">参数</param>
        /// <returns>返回值</returns>
        [OperationContract]
        object ExecuteScalar(string commandID, params DataField[] parameterList);

        /// <summary>
        /// 更新表数据
        /// </summary>
        /// <param name="dataTable">数据表，此表必须设置表名，并通过表名在数据库检索数据</param>
        /// <param name="tableName">表名</param>
        /// <returns>数据格式</returns>
        [OperationContract]
        void UpdateTable(DataTable dataTable, string tableName);
    }
}
