using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace PAO.Data.Filters
{
    /// <summary>
    /// And过滤器
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    /// <remarks>
    /// 创建与逻辑表达式的过滤器
    /// </remarks>
    [DataContract(Namespace = "")]
    [Serializable]
    [Name("And过滤器")]
    [Description("创建与逻辑表达式的过滤器")]
    public class And : CompositeLogicFilter
    {
        protected override string GetLogicSign() {
            return "AND";
        }
    }
}
