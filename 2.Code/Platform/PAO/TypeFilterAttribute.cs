using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO
{
    /// <summary>
    /// 类型过滤特性
    /// 作者：PAO
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class TypeFilterAttribute : Attribute
    {
        public Func<Type, bool> TypeFilter;
        public TypeFilterAttribute(Func<Type, bool> typeFilter) {
            this.TypeFilter = typeFilter;
        }
    }
}
