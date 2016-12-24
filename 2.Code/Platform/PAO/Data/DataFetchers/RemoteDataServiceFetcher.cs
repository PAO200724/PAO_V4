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
    /// 类：DataServiceFetcher
    /// 远程数据服务获取器
    /// 从远程数据服务获取数据的数据获取器，远程数据服务获取器需要通过已经在服务注册的命令ID来获取数据
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "fetcher")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("远程数据服务获取器")]
    [Description("从远程数据服务获取数据的数据获取器，远程数据服务获取器需要通过已经在服务注册的命令ID来获取数据")]
    public class RemoteDataServiceFetcher : PaoObject, IDataFetch
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
        public Ref<IDataService> DataService {
            get;
            set;
        }
        #endregion 属性：DataService
        
        #region 属性：CommandID
        /// <summary>
        /// 属性：CommandID
        /// 命令ID
        /// 数据命令ID
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("命令ID")]
        [Description("数据命令ID")]
        public string CommandID {
            get;
            set;
        }
        #endregion 属性：CommandID
        #endregion
        public RemoteDataServiceFetcher() {
        }

        public DataTable FetchData(int startIndex, int count, params DataField[] parameterValues) {
            var dataService = DataService.Value;
            return dataService.Query(CommandID, startIndex, count, parameterValues);
        }

        public DataTable GetDataSchema() {
            var dataService = DataService.Value;
            return dataService.GetSchema(CommandID);
        }
    }
}
