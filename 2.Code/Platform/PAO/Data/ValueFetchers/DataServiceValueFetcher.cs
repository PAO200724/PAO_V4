using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Data.ValueFetchers
{
    /// <summary>
    /// 类：DataServiceValueFetcher
    /// 数据服务值获取器
    /// 通过数据服务获取值的获取器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据服务值获取器")]
    [Description("通过数据服务获取值的获取器")]
    public class DataServiceValueFetcher<T> : ValueFetcher<T>
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
        public DataServiceValueFetcher() {
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override T Value {
            get {
                var dataService = DataService.Value;
                object result = dataService.ExecuteScalar(CommandID);
                if (result == null)
                    return default(T);
                return (T)result;
            }
        }
    }
}
