using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 类：Controller
    /// 控制器
    /// 控制器（可以作为菜单）
    /// 作者：PAO
    /// </summary>
    [Addon]
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

        #region 属性：Icon
        /// <summary>
        /// 属性：Icon
        /// 图标
        /// 菜单图标
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("图标")]
        [Description("菜单图标")]
        public Image Icon {
            get;
            set;
        }
        #endregion 属性：Icon

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

        [NonSerialized]
        private IUIContainer _UIContainer;
        /// <summary>
        /// UI容器
        /// </summary>
        [Browsable(false)]
        public IUIContainer UIContainer {
            get { return _UIContainer; }
            set { _UIContainer = value; }
        }


        public UIItem() {
        }

        public override string ToString() {
            return this.ObjectToString(null, "Caption");
        }

    }
}
