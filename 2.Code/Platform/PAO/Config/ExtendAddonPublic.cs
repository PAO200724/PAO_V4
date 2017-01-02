using PAO.App;
using PAO.IO;
using PAO.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 静态类：ExtendAddonPublic
    /// 扩展插件公共类
    /// 作者：PAO
    /// </summary>
    public static class ExtendAddonPublic
    {
        public const string ExtendAddonStorageName = "ExtendAddons";

        /// <summary>
        /// 获取插件属性ID，用于在配置存储中检索
        /// </summary>
        /// <param name="addon">插件</param>
        /// <param name="propertyName">属性名</param>
        /// <returns>插件属性ID</returns>
        private static string GetAddonPropertyID(PaoObject addon, string propertyName) {
            var id = String.Format("{0}&{1}", addon.ID, propertyName);
            return id;
        }
        #region 扩展属性

        /// <summary>
        /// 抽取插件扩展属性
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="addon">插件</param>
        /// <param name="properties">需要纳入扩展的属性</param>
        public static void SetAddonExtendProperties(PaoObject addon, params string[] properties) {
            if (addon.IsNotNull() && properties.IsNotNullOrEmpty()) {
                foreach (var property in properties) {
                    var propertyValue = addon.GetPropertyValueByPath(property);
                    var propertyID = GetAddonPropertyID(addon, property);
                    if (propertyValue.IsNotNull()) {
                        ConfigStoragePublic.SetConfig(ExtendAddonStorageName, propertyID, propertyValue);
                    }
                }
            }
        }

        /// <summary>
        /// 应用插件扩展属性
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="addon">插件</param>
        public static void GetAddonExtendProperties(PaoObject addon) {
            if (addon == null)
                return;

            var keys = ConfigStoragePublic.FindConfigKeys(ExtendAddonStorageName
                , (key) =>{
                    return key.IndexOf(addon.ID + "&") == 0;
                });

            if (keys.IsNullOrEmpty())
                return;

            foreach(var key in keys) {
                string[] ids = key.Split(new char[] { '&' }, 2);
                string propertyName = ids[1];
                var propertyValue = ConfigStoragePublic.GetConfig(ExtendAddonStorageName, key);
                AddonPublic.SetPropertyValueByPath(addon, propertyName, propertyValue);
            }
        }
        #endregion
    }
}
