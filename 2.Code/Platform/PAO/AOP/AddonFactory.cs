using PAO;
using PAO.App;
using PAO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO
{
    /// <summary>
    /// 类：AddonFactory
    /// 插件工厂
    /// 是在默认应用中的GlobalAddonList查找插件的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [Icon(typeof(Resources), "addon_factory")]
    [DataContract(Namespace = "")]
    [Name("插件工厂")]
    [Description("是在默认应用中的GlobalAddonList查找插件的工厂")]
    public class AddonFactory<T> : Factory<T> where T : class
    {
        #region 插件属性
        #region 属性：AddonID
        /// <summary>
        /// 属性：AddonID
        /// 插件ID
        /// 插件ID
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("插件ID")]
        [Description("插件ID")]
        public string AddonID {
            get;
            set;
        }
        #endregion 属性：AddonID
        #endregion
        public AddonFactory() {
        }

        public AddonFactory(string addonID) {
            AddonID = addonID;
        }

        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null, "AddonID");
        }

        protected override T OnCreateInstance() {
            return AddonPublic.GetRuntimeAddonByID(AddonID) as T;
        }
    }
}
