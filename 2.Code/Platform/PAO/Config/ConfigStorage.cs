using PAO;
using PAO.App;
using PAO.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 类：ConfigStorage
    /// 配置存储
    /// 配置存储器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("配置存储")]
    [Description("配置存储器")]
    public class ConfigStorage : PaoObject
    {
        #region 插件属性
        #region 属性：StorageName
        /// <summary>
        /// 属性：StorageName
        /// 存储名称
        /// 配置存储的名称，如果在本地，此存储将作为文件名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("存储名称")]
        [Description("配置存储的名称，如果在本地，此存储将作为文件名称")]
        public string StorageName {
            get;
            set;
        }
        #endregion 属性：StorageName

        #region 属性：Configs
        /// <summary>
        /// 属性：Configs
        /// 配置
        /// 配置项，配置项的键可用于查找配置
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("配置")]
        [Description("配置项，配置项的键可用于查找配置")]
        public Dictionary<string, object> Configs {
            get;
            set;
        }
        #endregion 属性：Configs
        #endregion

        public ConfigStorage() {
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="id">配置ID</param>
        /// <returns>配置对象</returns>
        public object GetConfig(string id) {
            if (Configs == null)
                return null;

            if (!Configs.ContainsKey(id))
                return null;

            return Configs[id];
        }

        /// <summary>
        /// 移除配置
        /// </summary>
        /// <param name="id">配置ID</param>
        public void RemoveConfig(string id) {
            if (Configs == null)
                return;

            if (!Configs.ContainsKey(id))
                return;

            Configs.Remove(id);
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="id">配置ID</param>
        /// <param name="configObject">配置对象</param>
        public void SetConfig(string id, object configObject) {
            if (Configs == null)
                Configs = new Dictionary<string, object>();

            if (Configs.ContainsKey(id))
                Configs[id] = configObject;
            else
                Configs.Add(id, configObject);
        }
    }
}
