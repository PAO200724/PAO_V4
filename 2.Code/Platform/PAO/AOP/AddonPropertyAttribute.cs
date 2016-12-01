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
        /// <summary>
        /// 是否在编辑器中可见
        /// </summary>
        public bool ShowInEditor { get; set; }
        /// <summary>
        /// 编辑器类型
        /// </summary>
        public Type EditorType { get; set; }
        public AddonPropertyAttribute() {
            ShowInEditor = true;
        }
    }
}
