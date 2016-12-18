using PAO;
using PAO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.MVC
{
    /// <summary>
    /// 类：Controller
    /// 控制器
    /// 控制器（可以作为菜单）
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "form")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("控制器")]
    [Description("控制器（可以作为菜单）")]
    public class UIItem : PaoObject, IUIItem
    {
        #region 插件属性

        #region 属性：Caption
        /// <summary>
        /// 属性：Caption
        /// 标题
        /// 菜单标题
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("标题")]
        [Description("菜单标题")]
        public string Caption {
            get;
            set;
        }
        #endregion 属性：Caption

        #region 属性：IconImage
        /// <summary>
        /// 属性：IconImage
        /// 图标图像
        /// 图标的图像
        /// </summary>
        [AddonProperty]
        [DataMember(Name="Icon", EmitDefaultValue = false)]
        [Name("图标图像")]
        [Description("图标的图像")]
        public Image IconImage {
            get;
            set;
        }
        #endregion 属性：IconImage

        #region 属性：LargeIcon
        /// <summary>
        /// 属性：LargeIcon
        /// 大图标
        /// 菜单大图标
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("大图标")]
        [Description("菜单大图标")]
        public Image LargeIcon {
            get;
            set;
        }
        #endregion 属性：LargeIcon

        #endregion

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image Icon {
            get {
                if (IconImage != null)
                    return IconImage;
                // 获取视图的图标
                Type type = this.GetType();
                var iconAttr = type.GetAttribute<IconAttribute>(true);
                if (iconAttr != null) {
                    return iconAttr.GetIcon();
                }
                return null;
            }
            set {
                IconImage = value;
            }
        }

        public UIItem() {
        }

        public override string ToString() {
            return this.ObjectToString(null, "Caption");
        }

    }
}
