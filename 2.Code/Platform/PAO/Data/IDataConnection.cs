using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace PAO.Data
{
    /// <summary>
    /// 接口：IDataConnection
    /// 数据连接接口
    /// 用于连接数据的接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("数据连接接口")]
    [Description("用于连接数据的接口")]
    public interface IDataConnection
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="commandInfo">命令信息</param>
        /// <param name="parameterList">参数列表</param>
        void Execute(DataCommandInfo commandInfo, params DataField[] parameterList);
        /// <summary>
        /// 执行并返回
        /// </summary>
        /// <param name="commandInfo">命令信息</param>
        /// <param name="parameterList">参数列表</param>
        /// <returns>返回值</returns>
        object ExecuteScalar(DataCommandInfo commandInfo, params DataField[] parameterList);
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="commandInfo">命令信息</param>
        /// <returns>参数列表</returns>
        DataField[] GetParameters(DataCommandInfo commandInfo);
        /// <summary>
        /// 获取数据架构
        /// </summary>
        /// <param name="commandInfo">命令信息</param>
        /// <returns>数据架构</returns>
        DataTable GetSchema(DataCommandInfo commandInfo);
        /// <summary>
        /// 根据命令查询数据表
        /// </summary>
        /// <param name="commandInfo">明林信息</param>
        /// <param name="startIndex">其实行号</param>
        /// <param name="maxCount">行数</param>
        /// <param name="parameterList">参数列表</param>
        /// <returns>数据表</returns>
        DataTable QueryTableByCommand(DataCommandInfo commandInfo, int startIndex, int maxCount, params DataField[] parameterList);
        /// <summary>
        /// 更新表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="tableName">表名</param>
        void UpdateTable(DataTable dataTable, string tableName);
    }
}