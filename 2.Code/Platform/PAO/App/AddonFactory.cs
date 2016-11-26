using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.App
{
    /// <summary>
    /// 类：AddonFactory
    /// 插件工厂
    /// 是在默认应用中的GlobalAddonList查找插件的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("插件工厂")]
    [Description("是在默认应用中的GlobalAddonList查找插件的工厂")]
    public class AddonFactory<T> : Factory<T> where T : PaoObject
    {
        #region 插件属性
        #region 属性：AddonID
        /// <summary>
        /// 属性：AddonID
        /// 插件ID
        /// 插件ID
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("插件ID")]
        [Description("插件ID")]
        public string AddonID {
            get;
            set;
        }
        #endregion 属性：AddonID
        #endregion
        public AddonFactory() {
        }

        protected override T OnCreateInstance() {
            var addonList = PaoApplication.Default.GlobalAddonList;
            if (addonList.IsNullOrEmpty() || !addonList.ContainsKey(AddonID))
                return default(T);

            return (T)addonList[AddonID].Value;
        }
    }
}
