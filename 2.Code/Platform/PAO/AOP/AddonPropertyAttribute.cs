using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO
{
    /// <summary>
    /// Pao属性特性
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class AddonPropertyAttribute : Attribute
    {

    }
}
