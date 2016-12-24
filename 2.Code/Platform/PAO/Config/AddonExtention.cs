using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 类：AddonExtention
    /// 插件扩展
    /// 插件的扩展属性
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("插件扩展")]
    [Description("插件的扩展属性")]
    public class AddonExtention : PaoObject
    {
        #region 插件属性
        #region 属性：ExtendProperties
        /// <summary>
        /// 属性：ExtendProperties
        /// 扩展属性
        /// 插件的扩展属性
        /// </summary>
        [AddonProperty(ShowInEditor = false)]
        [DataMember(EmitDefaultValue = false)]
        [Name("扩展属性")]
        [Description("插件的扩展属性")]
        public Dictionary<string, object> ExtendProperties {
            get;
            set;
        }
        #endregion 属性：ExtendProperties
        #endregion
        public AddonExtention() {
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="addon">插件</param>
        /// <param name="properties">需要纳入扩展的属性</param>
        public AddonExtention(PaoObject addon, params string[] properties) {
            LoadFromAddon(addon, properties);
        }

        /// <summary>
        /// 从插件中构造
        /// </summary>
        /// <param name="addon">插件</param>
        /// <param name="properties">需要纳入扩展的属性</param>
        public void LoadFromAddon(PaoObject addon, params string[] properties) {
            ID = addon.ID;
            ExtendProperties = new Dictionary<string, object>();
            if (properties.IsNotNullOrEmpty()) {
                foreach (var property in properties) {
                    var value = addon.GetPropertyValueByPath(property);
                    ExtendProperties.Add(property, value);
                }
            }
        }

        /// <summary>
        /// 应用到插件
        /// </summary>
        /// <param name="addon">插件</param>
        public void ApplyToAddon(PaoObject addon) {
            if (addon.ID != ID)
                throw new Exception("扩展属性只能应用到ID相同的插件上");

            if(ExtendProperties.IsNotNullOrEmpty()) {
                foreach (var kv in ExtendProperties) {
                    addon.SetPropertyValueByPath(kv.Key, kv.Value);
                }
            }
        }
    }
}
