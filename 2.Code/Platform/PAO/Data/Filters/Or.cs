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
    }
}
