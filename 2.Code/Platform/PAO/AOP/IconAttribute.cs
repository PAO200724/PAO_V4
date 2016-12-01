using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.AOP
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class IconAttribute : Attribute
    {
        /// <summary>
        /// 图标资源名称
        /// </summary>
        public string Icon { get; set; }

        public IconAttribute() {

        }

        public IconAttribute(string icon) {
            Icon = icon;
        }
    }
}
