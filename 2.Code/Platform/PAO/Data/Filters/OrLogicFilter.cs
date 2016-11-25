using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace PAO.Data.Filters
{
    /// <summary>
    /// Or过滤器
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    /// <remarks>
    /// 创建或逻辑表达式的过滤器
    /// </remarks>
    [DataContract(Namespace = "")]
    [Serializable]
    [DisplayName("Or过滤器")]
    [Description("创建或逻辑表达式的过滤器")]
    public class OrLogicFilter : CompositeLogicFilter
    {
        protected override string GetLogicSign() {
            return "OR";
        }

        /// <summary>
        /// 逻辑Anad
        /// </summary>
        /// <param name="dataFilter1">查询条件1</param>
        /// <param name="dataFilter2">查询条件2</param>
        /// <returns>组合条件</returns>
        public static AndLogicFilter operator &(OrLogicFilter dataFilter1, IDataFilter dataFilter2) {
            return new AndLogicFilter() { ChildFilters = new List<IDataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }

        /// <summary>s
        /// 逻辑Anad
        /// </summary>
        /// <param name="dataFilter1">查询条件1</param>
        /// <param name="dataFilter2">查询条件2</param>
        /// <returns>组合条件</returns>
        public static OrLogicFilter operator |(OrLogicFilter dataFilter1, IDataFilter dataFilter2) {
            return new OrLogicFilter() { ChildFilters = new List<IDataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }
    }
}
