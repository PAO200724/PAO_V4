using PAO.Event;
using PAO.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 静态类：ConfigStoragePublic
    /// 配置存储公共类
    /// 作者：PAO
    /// </summary>
    public static class ConfigStoragePublic
    {
        /// <summary>
        /// 配置存储列表
        /// </summary>
        private static Dictionary<string, ConfigStorage> ConfigStorages = new Dictionary<string, ConfigStorage>();

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="dirPath">目录路径</param>
        public static void SaveConfigStorages(string dirPath) {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            if (ConfigStorages == null)
                return;
            foreach (var configStorage in ConfigStorages.Values) {
                var fileName = String.Format("{0}.config", configStorage.StorageName);
                IOPublic.WriteObjectToFile(Path.Combine(dirPath, fileName), configStorage);
            }
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="dirPath">目录路径</param>
        public static void LoadConfigStorages(string dirPath) {
            ConfigStorages = new Dictionary<string, Config.ConfigStorage>();
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            var filePaths = Directory.GetFiles(dirPath, "*.config");
            foreach(var filePath in filePaths) {
                try {
                    var configStorage = IOPublic.ReadObjectFromFile(filePath) as ConfigStorage;
                    if(configStorage != null) {
                        ConfigStorages.Add(configStorage.StorageName, configStorage);
                    }
                } catch (Exception err) {
                    EventPublic.Exception(err);
                }
            }
        }

        /// <summary>
        /// 移除配置
        /// </summary>
        /// <param name="storageName">配置名称</param>
        /// <param name="id">配置ID</param>
        /// <returns>配置对象</returns>
        public static void RemoveConfig(string storageName, string id) {
            if (ConfigStorages == null)
                return;

            if (!ConfigStorages.ContainsKey(storageName))
                return;

            ConfigStorages[storageName].RemoveConfig(id);
        }


        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="storageName">配置名称</param>
        /// <param name="id">配置ID</param>
        /// <returns>配置对象</returns>
        public static object GetConfig(string storageName, string id) {
            if (ConfigStorages == null)
                return null;

            if (!ConfigStorages.ContainsKey(storageName))
                return null;

            return ConfigStorages[storageName].GetConfig(id);
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="storageName">配置名称</param>
        /// <param name="id">配置ID</param>
        /// <param name="configObject">配置对象</param>
        public static void SetConfig(string storageName, string id, object configObject) {
            if (ConfigStorages == null)
                ConfigStorages = new Dictionary<string, Config.ConfigStorage>();

            if (ConfigStorages.ContainsKey(storageName))
                ConfigStorages[storageName].SetConfig(id, configObject);
            else {
                var configStorage = new ConfigStorage() {
                    StorageName = storageName    
                };
                configStorage.SetConfig(id, configObject);
                ConfigStorages.Add(storageName, configStorage);
            }
        }

        /// <summary>
        /// 查找配置Key列表
        /// </summary>
        /// <param name="storageName">配置名称</param>
        /// <param name="keyFilter">Key过滤器</param>
        /// <returns>配置Key列表</returns>
        public static IEnumerable<string> FindConfigKeys(string storageName, Func<string, bool> keyFilter) {
            if (ConfigStorages == null)
                return null;

            if (!ConfigStorages.ContainsKey(storageName))
                return null;

            return ConfigStorages[storageName].FindConfigKeys(keyFilter);
        }
    }
}
