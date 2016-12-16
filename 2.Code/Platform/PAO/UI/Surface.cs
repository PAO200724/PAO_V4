using PAO;
using PAO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI
{
    /// <summary>
    /// 类：Surface
    /// 外表
    /// 界面外表，颜色、字体等的定义
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "picture")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("外表")]
    [Description("界面外表，颜色")]
    public class Surface : PaoObject
    {
        #region 插件属性

        #region 属性：BackColor
        /// <summary>
        /// 属性：BackColor
        /// 背景色
        /// 主背景色
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("背景色")]
        [Description("主背景色")]
        public Color BackColor {
            get;
            set;
        }
        #endregion 属性：BackColor

        #region 属性：BackColor2
        /// <summary>
        /// 属性：BackColor2
        /// 次背景色
        /// 次背景色
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("次背景色")]
        [Description("次背景色")]
        public Color BackColor2 {
            get;
            set;
        }
        #endregion 属性：BackColor2

        #region 属性：ForeColor
        /// <summary>
        /// 属性：ForeColor
        /// 前景色
        /// 前景色
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("前景色")]
        [Description("前景色")]
        public Color ForeColor {
            get;
            set;
        }
        #endregion 属性：ForeColor

        #region 属性：Font
        /// <summary>
        /// 属性：Font
        /// 字体
        /// 字体
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("字体")]
        [Description("字体")]
        public Font Font {
            get;
            set;
        }
        #endregion 属性：Font

        #endregion
        public Surface() {
        }
    }
}
