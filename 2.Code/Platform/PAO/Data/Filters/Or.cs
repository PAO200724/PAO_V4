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
    [Name("Or过滤器")]
    [Description("创建或逻辑表达式的过滤器")]
    public class Or : CompositeLogicFilter
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
        public static And operator &(Or dataFilter1, IDataFilter dataFilter2) {
            return new And() { ChildFilters = new List<IDataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }

        /// <summary>s
        /// 逻辑Anad
        /// </summary>
        /// <param name="dataFilter1">查询条件1</param>
        /// <param name="dataFilter2">查询条件2</param>
        /// <returns>组合条件</returns>
        public static Or operator |(Or dataFilter1, IDataFilter dataFilter2) {
            return new Or() { ChildFilters = new List<IDataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }
    }
}
