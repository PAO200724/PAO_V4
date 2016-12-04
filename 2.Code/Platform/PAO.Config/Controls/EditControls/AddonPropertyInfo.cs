using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Config.Controls.EditControls
{
    /// <summary>
    /// 插件属性信息
    /// </summary>
    public class AddonPropertyInfo
    {
        /// <summary>
        /// 选择
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public PropertyDescriptor Property { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public object PropertyValue { get; set; }
        /// <summary>
        /// 原始值
        /// </summary>
        public object OriginValue { get; set; }
    }
}
