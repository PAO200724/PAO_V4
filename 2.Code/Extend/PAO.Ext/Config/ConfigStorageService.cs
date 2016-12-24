using PAO;
using PAO.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO.App;
using PAO.Data;
using PAO.IO;
using PAO.Security;

namespace PAO.Ext.Config
{
    /// <summary>
    /// 类：ConfigStorageService
    /// 配置存储服务
    /// 保存/读取配置的服务
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("配置存储服务")]
    [Description("保存/读取配置的服务")]
    public class ConfigStorageService : PaoObject, IConfigStorage, IPermissionSet
    {
        #region 插件属性
        #region 属性：DataService
        /// <summary>
        /// 属性：DataService
        /// 数据服务
        /// 实现本服务所需的数据服务
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据服务")]
        [Description("实现本服务所需的数据服务")]
        public Ref<DataService> DataService {
            get;
            set;
        }
        #endregion 属性：DataService
        #endregion

        public const string Permission_SaveGlobalConfig = "SaveGlobalConfig";
        public IDictionary<string, string> Permissions {
            get {
                return new Dictionary<string, string>()
                    .Append(Permission_SaveGlobalConfig, "保存全局配置");
            }
        }

        #region Sql
        /// <summary>
        /// 查询当前有效的全局配置，按照优先级反向排序
        /// </summary>
        public const string Sql_QueryCurrentGlobalConfig =
    @"SELECT *
  FROM T_Config
 WHERE ConfigName = @ConfigName
   AND SoftwareID = @SoftwareID
   AND ComputerID IS NULL
   AND EnabledTime < getdate()
   AND DisabledTime IS NULL
 ORDER BY Priority DESC";

        /// <summary>
        /// 查询当前有效的本地配置，按照优先级反向排序
        /// </summary>
        public const string Sql_QueryCurrentLocalConfig =
    @"SELECT *
  FROM T_Config
 WHERE ConfigName = @ConfigName
   AND SoftwareID = @SoftwareID
   AND ComputerID = @ComputerID
   AND EnabledTime < getdate()
   AND DisabledTime > getdate()
 ORDER BY Priority DESC";

        /// <summary>
        /// 失效当前有效配置
        /// </summary>
        public const string Sql_DisableCurrentLocalConfig =
    @"UPDATE T_Config
   SET DisabledTime = getdate()
 WHERE ConfigName = @ConfigName
   AND SoftwareID = @SoftwareID
   AND ComputerID = @ComputerID
   AND EnabledTime < getdate()
   AND DisabledTime > getdate()";

        /// <summary>
        /// 失效当前有效配置
        /// </summary>
        public const string Sql_DisableCurrentGlobalConfig =
    @"UPDATE T_Config
   SET DisabledTime = getdate()
 WHERE ConfigName = @ConfigName
   AND SoftwareID = @SoftwareID
   AND ComputerID IS NULL
   AND EnabledTime < getdate()
   AND DisabledTime > getdate()";
        #endregion

        public ConfigStorageService() {
        }

        private void TraverseGlobalConfig(Func<PaoObject, bool> traverseMethod, string configName) {
            var configTable = new ConfigDataSet.T_ConfigDataTable();
            DataService.Value.FillAll(configTable, Sql_QueryCurrentGlobalConfig
                , new DataField("@ConfigName", configName)
                , new DataField("@SoftwareID", PaoApplication.Default.SoftwareID));

            TraverseConfigRows(configTable, traverseMethod, configName);
        }

        private void TraverseLocalConfig(Func<PaoObject, bool> traverseMethod, string configName) {
            var configTable = new ConfigDataSet.T_ConfigDataTable();
            DataService.Value.FillAll(configTable, Sql_QueryCurrentGlobalConfig
                , new DataField("@ConfigName", configName)
                , new DataField("@ComputerID", SecurityPublic.CurrentUser.ComputerID)
                , new DataField("@SoftwareID", PaoApplication.Default.SoftwareID));

            TraverseConfigRows(configTable, traverseMethod, configName);
        }

        private void TraverseConfigRows(ConfigDataSet.T_ConfigDataTable configTable, Func<PaoObject, bool> traverseMethod, string configName) {
            var dataRows = configTable.Cast<ConfigDataSet.T_ConfigRow>();
            // 首先取出优先级较高的扩展配置
            foreach (var extendRow in dataRows) {
                bool useConfig = false;
                if (!extendRow.IsFilterNull()) {
                    var filter = (IClientFilter)IOPublic.Deserialize(extendRow.Filter);
                    if (filter.Predicate(SecurityPublic.CurrentUser.UserID
                        , SecurityPublic.CurrentUser.ComputerID)) {
                        useConfig = true;
                    }
                } else {
                    useConfig = true;
                }

                if (useConfig) {
                    var configObject = (PaoObject)IOPublic.Deserialize(extendRow.Config);
                    if (!traverseMethod(configObject))
                        return;
                }
            }
        }

        public PaoObject LoadGlobalConfig(string configName) {
            PaoObject configObject = null;
            TraverseGlobalConfig((p) =>
            {
                configObject = p;
                return false;
            }, configName);

            return configObject;
        }

        public PaoObject[] LoadGlobalConfigs(string configName) {
            List<PaoObject> addonList = new List<PaoObject>();
            TraverseGlobalConfig((p) =>
            {
                addonList.Add(p);
                return true;
            }, configName);

            return addonList.ToArray();
        }

        public PaoObject LoadLocalConfig(string configName) {
            PaoObject configObject = null;
            TraverseLocalConfig((p) =>
            {
                configObject = p;
                return false;
            }, configName);

            return configObject;
        }
        
        public void SaveGlobalConfig(PaoObject configObject, int priority, IClientFilter clientFilter) {
            var dataService = DataService.Value;
            SecurityPublic.CheckPermission(ID, Permission_SaveGlobalConfig).CheckTrue("当前用户不拥有保存全局配置的权限");
            dataService.Execute(Sql_DisableCurrentLocalConfig
                , new DataField("@ConfigName", configObject.ID)
                , new DataField("@SoftwareID", PaoApplication.Default.SoftwareID));

            var configTable = new ConfigDataSet.T_ConfigDataTable();
            var configRow = configTable.AddT_ConfigRow(Guid.NewGuid()
                , PaoApplication.Default.SoftwareID
                , null
                , configObject.ID
                , priority
                , DateTime.Now
                , DateTime.MaxValue
                , IOPublic.Serialize<byte[]>(clientFilter)
                , IOPublic.Serialize<byte[]>(configObject));
            dataService.UpdateTable(configTable, "T_Config");
        }

        public void SaveLocalConfig(PaoObject configObject) {
            var dataService = DataService.Value;
            dataService.Execute(Sql_DisableCurrentLocalConfig
                , new DataField("@ConfigName", configObject.ID)
                , new DataField("@ComputerID", SecurityPublic.CurrentUser.ComputerID)
                , new DataField("@SoftwareID", PaoApplication.Default.SoftwareID));

            var configTable = new ConfigDataSet.T_ConfigDataTable();
            var configRow = configTable.AddT_ConfigRow(Guid.NewGuid()
                , PaoApplication.Default.SoftwareID
                , SecurityPublic.CurrentUser.ComputerID
                , configObject.ID
                , Int32.MaxValue
                , DateTime.Now
                , DateTime.MaxValue
                , null
                , IOPublic.Serialize<byte[]>(configObject));
            dataService.UpdateTable(configTable, "T_Config");
        }
    }
}
