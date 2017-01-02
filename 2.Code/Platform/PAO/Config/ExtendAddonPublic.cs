using PAO.App;
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
            /// 扩展属性存储器
            /// </summary>
        private static ExtendPropertyStorage ExtendPropertyStorage;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="filePath">扩展插件路径</param>
        public static void Initialize(string filePath) {
            if(filePath != null) {
                ExtendPropertyStorage = new Config.ExtendPropertyStorage()
                {
                    FilePath = filePath
                };
            } else {
                ExtendPropertyStorage = null;
            }
        }

        /// <summary>
        /// 抽取插件扩展属性
        /// </summary>
        /// <param name="addon">插件</param>
        /// <param name="properties">需要纳入扩展的属性</param>
        public static void SetAddonExtendProperties(PaoObject addon, params string[] properties) {
            ExtendPropertyStorage.CheckNotNull("扩展插件存储尚未初始化.");
            ExtendPropertyStorage.SaveAddonExtendProperties(addon, properties);
        }

        /// <summary>
        /// 应用插件扩展属性
        /// </summary>
        /// <param name="addon">插件</param>
        public static void GetAddonExtendProperties(PaoObject addon) {
            ExtendPropertyStorage.CheckNotNull("扩展插件存储尚未初始化.");
            ExtendPropertyStorage.LoadAddonExtendProperties(addon);
        }

        /// <summary>
        /// 备份Storage
        /// </summary>
        /// <param name="extendPropertyStorage">扩展属性存储器</param>
        public static void BackupStorage() {
            ExtendPropertyStorage.Backup();
        }

        /// <summary>
        /// 从Storage加载扩展插件
        /// </summary>
        /// <param name="extendPropertyStorage">扩展属性存储器</param>
        public static void LoadAddonExtendPropertiesFromStorage() {
            ExtendPropertyStorage.Load();
        }

        /// <summary>
        /// 保存扩展插件到存储器
        /// </summary>
        /// <param name="extendPropertyStorage">扩展属性存储器</param>
        public static void SaveAddonExtendPropertiesToStorage() {
            ExtendPropertyStorage.CheckNotNull("扩展插件存储尚未初始化.");
            ExtendPropertyStorage.Save();
        }
        #endregion
    }
}
