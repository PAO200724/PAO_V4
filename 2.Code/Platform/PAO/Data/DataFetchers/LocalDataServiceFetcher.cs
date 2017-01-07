using PAO;
using PAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data;
using PAO.Properties;

namespace PAO.Data.DataFetchers
{
    /// <summary>
    /// 类：LocalDataServiceFetcher
    /// 数据服务获取器
    /// 从本地数据服务获取数据的数据获取器，本地数据服务获取器可以通过Sql直接获取数据
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "fetcher")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据服务获取器")]
    [Description("从本地数据服务获取数据的数据获取器，本地数据服务获取器可以通过Sql直接获取数据")]
    public class LocalDataServiceFetcher : PaoObject, IDataFetch
    {
        #region 插件属性
        #region 属性：DataService
        /// <summary>
        /// 属性：DataService
        /// 数据服务
        /// 数据服务
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据服务")]
        [Description("数据服务")]
        public Ref<DataService> DataService {
            get;
            set;
        }
        #endregion 属性：DataService

        #region 属性：CommandID
        /// <summary>
        /// 属性：Sql
        /// Sql语句
        /// 用于获取数据的Sql语句
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("Sql语句")]
        [Description("用于获取数据的Sql语句")]
        public string Sql {
            get;
            set;
        }
        #endregion 属性：CommandID
        #endregion
        public LocalDataServiceFetcher() {
        }

        public DataTable FetchData(int startIndex, int count, params DataParameter[] parameterValues) {
            var dataService = DataService.Value;
            return dataService.QueryBySql(Sql, startIndex, count, parameterValues);
        }

        public DataTable GetDataSchema() {
            var dataService = DataService.Value;
            return dataService.GetSchemaBySql(Sql);
        }

        public DataParameter[] GetParameters() {
            var dataService = DataService.Value;
            return dataService.GetParametersBySql(Sql);
        }
    }
}
