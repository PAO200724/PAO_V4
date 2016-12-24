using PAO.IO;
using PAO.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PAO.Config.DataSetExtendProperty;

namespace PAO.Config
{
    /// <summary>
    /// 静态类：ExtendAddonPublic
    /// 扩展插件公共类
    /// 作者：PAO
    /// </summary>
    public static class ExtendAddonPublic
    {
        #region 扩展属性
        /// <summary>
        /// 抽取插件扩展属性
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="addon">插件</param>
        /// <param name="properties">需要纳入扩展的属性</param>
        public static void SaveAddonExtendProperties(ExtendPropertyDataTable dataTable, PaoObject addon, params string[] properties) {
            // 移除原来的插件属性
            var addonRows = dataTable.AsEnumerable<ExtendPropertyRow>().Where(p => p.AddonID == addon.ID).ToList();
            foreach (var addonRow in addonRows) {
                addonRow.Delete();
            }

            if (properties.IsNotNullOrEmpty()) {
                foreach (var property in properties) {
                    var value = addon.GetPropertyValueByPath(property);
                    var newRow = dataTable.AddExtendPropertyRow(addon.ID, property, IOPublic.Serialize<string>(value));
                }
            }
            dataTable.AcceptChanges();
        }

        /// <summary>
        /// 应用插件扩展属性
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="addon">插件</param>
        public static void LoadAddonExtendProperties(ExtendPropertyDataTable dataTable, PaoObject addon) {
            var addonRows = dataTable.AsEnumerable<ExtendPropertyRow>().Where(p => p.AddonID == addon.ID).ToList();
            foreach (var addonRow in addonRows) {
                try {
                    addon.SetPropertyValueByPath(addonRow.PropertyName, IOPublic.Deserialize<string>(addonRow.PropertyValue));
                }
                catch {
                    if (UIPublic.ShowYesNoDialog(String.Format("读取属性：{0}.{1}的本地配置时发生异常，您是否要继续，如果继续，本地配置将会被覆盖.", addon.GetType(), addonRow.PropertyName)) != DialogReturn.Yes) {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 从Storage加载扩展插件
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="extendPropertyStorage">扩展属性存储器</param>
        public static void LoadAddonExtendPropertiesFromStorage(ExtendPropertyDataTable dataTable, IExtendPropertyStorage extendPropertyStorage) {
            if (extendPropertyStorage != null) {
                extendPropertyStorage.LoadExtendProperties(dataTable);
            }
        }

        /// <summary>
        /// 保存扩展插件到存储器
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="extendPropertyStorage">扩展属性存储器</param>
        public static void SaveAddonExtendPropertiesToStorage(ExtendPropertyDataTable dataTable, IExtendPropertyStorage extendPropertyStorage) {
            if (extendPropertyStorage != null) {
                extendPropertyStorage.SaveExtendProperties(dataTable);
            }
        }

        #endregion
    }
}
