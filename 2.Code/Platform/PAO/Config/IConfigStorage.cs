using PAO.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 接口：IConfigStorage
    /// 配置存储接口
    /// 用于存储配置的接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("配置存储接口")]
    [Description("用于存储配置的接口")]
    public interface IConfigStorage
    {
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="configObject">配置对象</param>
        /// <param name="clientFilter">客户端过滤器</param>
        /// <param name="priority">优先级</param>
        void SaveGlobalConfig(PaoObject configObject, int priority, IClientFilter clientFilter);
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="configObject">配置对象</param>
        void SaveLocalConfig(PaoObject configObject);
        /// <summary>
        /// 读取最新的全局配置
        /// </summary>
        /// <param name="configName">配置名称</param>
        /// <returns>最新的配置</returns>
        PaoObject LoadGlobalConfig(string configName);
        /// <summary>
        /// 读取最新的有效全局配置列表(按照优先级排序反向排序)
        /// </summary>
        /// <param name="configName">配置名称</param>
        /// <returns>最新的有效配置</returns>
        PaoObject[] LoadGlobalConfigs(string configName);
        /// <summary>
        /// 读取最新的全局配置
        /// </summary>
        /// <param name="configName">配置名称</param>
        /// <returns>最新的配置</returns>
        PaoObject LoadLocalConfig(string configName);
    }
}
