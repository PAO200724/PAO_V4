using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;

namespace PAO
{
    /// <summary>
    /// 图标特性
    /// 作者：PAO
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class IconAttribute : Attribute
    {
        /// <summary>
        /// 图标资源所在的类型
        /// </summary>
        public Type ResourceType { get; set; }
        /// <summary>
        /// 图标资源名称
        /// </summary>
        public string Icon { get; set; }

        public IconAttribute(Type resourceType, string icon) {
            ResourceType = resourceType;
            Icon = icon;
        }

        public IconAttribute(string icon) {
            Icon = icon;
        }

        public Image GetIcon() {
            return new ResourceManager(ResourceType).GetObject(Icon) as Image;
        }

        public static Image GetIcon(Type objectType) {
            var iconAttr = objectType.GetAttribute<IconAttribute>(true);
            if (iconAttr == null)
                return null;

            return iconAttr.GetIcon();
        }
    }
}
