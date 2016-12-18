using PAO;
using PAO.App;
using PAO.Config.Controls.EditControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO.UI.MVC;
using PAO.IO;
using PAO.Config.Properties;

namespace PAO.Config.Views
{
    /// <summary>
    /// 类：ObjectConfigController
    /// 对象配置控制器
    /// 配置对象的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "cog")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("对象配置控制器")]
    [Description("配置对象的控制器")]
    public class ObjectConfigController : BaseController
    {
        #region 插件属性
        #region 属性：ConfigFile
        /// <summary>
        /// 属性：ConfigFile
        /// 配置文件
        /// 配置文件路径
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("配置文件")]
        [Description("配置文件路径")]
        public string ConfigFile {
            get;
            set;
        }
        #endregion 属性：ConfigFile

        #region 属性：ExtendPropertyConfigFile
        /// <summary>
        /// 属性：ExtendPropertyConfigFile
        /// 扩展属性配置文件
        /// 扩展属性配置文件路径
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("扩展属性配置文件")]
        [Description("扩展属性配置文件路径")]
        public string ExtendPropertyConfigFile {
            get;
            set;
        }
        #endregion 属性：ExtendPropertyConfigFile
        #endregion
        public ObjectConfigController() {
        }

        internal const string DefaultExtendPropertyConfigFile = "ExtendProperties.config";
        protected override Type ViewType {
            get {
                return typeof(ObjectConfigView);
            }
        }
    }
}
