using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data;
using System.ComponentModel;
using PAO.Properties;
using System.Data.Common;
using PAO.Data.Filters;

namespace PAO.Data
{
    /// <summary>
    /// 类:DataCommandInfo
    /// 数据命令信息
    /// 用于保存数据命令属性的对象
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    [DataContract(Namespace = "")]
    [Icon(typeof(Resources), "script")]
    [Serializable]
    [Name("数据命令信息")]
    [Description("用于保存数据命令属性的对象")]
    public class DataCommandInfo : PaoObject
    {
        #region 插件属性

        #region 属性:Name
        /// <summary>
        /// 属性:Name
        /// 名称
        /// 数据命令名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("名称")]
        [Description("数据命令名称")]
        public string Name {
            get;
            set;
        }
        #endregion 属性:Name

        #region 属性:Sql
        /// <summary>
        /// 属性:Sql
        /// SQL语句
        /// 数据查询语句
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("SQL语句")]
        [Description("数据查询语句")]
        [EditorType("PAO.Config.Editor.MemoExEditController")]
        public string Sql {
            get;
            set;
        }
        #endregion 属性:Sql

        #region 属性:DataFilter
        /// <summary>
        /// 属性:DataFilter
        /// 数据过滤器
        /// 用于过滤数据的过滤器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据过滤器")]
        [Description("用于过滤数据的过滤器")]
        public DataFilter DataFilter {
            get;
            set;
        }
        #endregion 属性:DataFilter

        #region 属性：Parameters
        /// <summary>
        /// 属性：Parameters
        /// 参数
        /// 参数列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("参数")]
        [Description("参数列表")]
        public List<DataParameter> Parameters {
            get;
            set;
        }
        #endregion 属性：Parameters

        #endregion

        const string TrueFilter = "1=1";
        /// <summary>
        /// 构造方法
        /// </summary>
        public DataCommandInfo() {
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Name");
        }

        public virtual string GetCommandText(DataParameter[] parameterList, bool ignoreNullValue) {
            string filterString;
            if (DataFilter == null) {
                return Sql;
            }

            filterString = DataFilter.GetFilterString(parameterList, ignoreNullValue);
            if (filterString.IsNullOrEmpty())
                filterString = TrueFilter;
            
            return String.Format(Sql, filterString);
        }
        
        public virtual DataParameter[] GetDefinedParameters() {
            List<DataParameter> parameters = new List<Data.DataParameter>();

            string sql = GetCommandText(null, false);
            // 从Sql创建参数
            var paramNames = DataPublic.FindParameters(sql);
            foreach (var paramName in paramNames) {
                // 如果参数列表中已经存在，则不再重复
                if (parameters.Any(p => p.Name == paramName)) {
                    continue;
                }
                DataParameter predefinedParam = null;
                if (Parameters.IsNotNull()) {
                    predefinedParam = Parameters.Where(p => p.Name == paramName).FirstOrDefault();
                }
                if (predefinedParam != null) {
                    parameters.Add(predefinedParam);
                }
                else {
                    var newParam = new DataParameter(paramName, DbType.String);
                    parameters.Add(newParam);
                }
            }
            return parameters.ToArray();
        }

        public virtual void FillCommand(DbCommand command, DataParameter[] parameterList) {
            command.CommandText = GetCommandText(parameterList, true);

            string sql = GetCommandText(parameterList, true);
            // 从Sql创建参数
            var paramNames = DataPublic.FindParameters(sql);
            foreach (var paramName in paramNames) {
                DbParameter dbParam;
                // 如果参数列表中已经存在，则不再重复
                if (command.Parameters.Contains(paramName)) {
                    dbParam = command.Parameters[paramName];
                } else {
                    dbParam = command.CreateParameter();
                    dbParam.ParameterName = paramName;
                    command.Parameters.Add(dbParam);
                }

                // 设置参数值
                if (parameterList.IsNotNullOrEmpty()) {
                    var paramValue = parameterList.Where(p => p.Name == paramName).FirstOrDefault();
                    if (paramValue != null) {
                        dbParam.Value = paramValue.Value;
                    }
                }
            }
        }
    }
}
