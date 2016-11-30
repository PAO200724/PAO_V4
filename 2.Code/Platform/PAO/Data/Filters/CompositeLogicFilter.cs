using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace PAO.Data.Filters
{
    /// <summary>
    /// 组合逻辑过滤器
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    /// <remarks>
    /// 创建组合逻辑表达式的过滤器
    /// </remarks>
    [DataContract(Namespace = "")]
    [Serializable]
    [DisplayName("组合逻辑过滤器")]
    [Description("创建And逻辑表达式的过滤器")]
    public abstract class CompositeLogicFilter : BaseDataFilter
    {
        #region 插件属性
        #region 属性:ChildFilters
        /// <summary>
        /// 属性:ChildFilters
        /// 子过滤器
        /// 自过滤器列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("子过滤器")]
        [Description("自过滤器列表")]
        public List<IDataFilter> ChildFilters {
            get;
            set;
        }
        #endregion 属性:ChildFilters
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompositeLogicFilter() {
            ChildFilters = new List<IDataFilter>();
        }

        /// <summary>
        /// 获取逻辑运算符
        /// </summary>
        /// <returns>逻辑运算符</returns>
        protected abstract string GetLogicSign();

        public override string GetFilterString(DataField[] paramValues) {
            string sql = null;

            foreach (var dataFilter in ChildFilters) {
                string childSql = dataFilter.GetFilterString(paramValues);
                if (childSql != null) {
                    if (sql != null)
                        sql += String.Format(" {0} ({1})", GetLogicSign(), childSql);
                    else
                        sql = childSql;
                }
            }

            return sql;
        }

        public override DataField[] GetParameters() {
            IEnumerable<DataField> dataField = new List<DataField>();

            foreach (var dataFilter in ChildFilters) {
                dataField = dataField.Union(dataFilter.GetParameters());
            }
            return dataField.ToArray();
        }
    }
}
