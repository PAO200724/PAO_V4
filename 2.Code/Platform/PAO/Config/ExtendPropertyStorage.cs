using PAO;
using PAO.App;
using PAO.IO;
using PAO.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using static PAO.Config.DataSetExtendProperty;

namespace PAO.Config
{
    /// <summary>
    /// 类：FileExtendPropertyStorage
    /// 文件时扩展属性存储
    /// 文件形式的扩展属性存储
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("文件时扩展属性存储")]
    [Description("文件形式的扩展属性存储")]
    public class ExtendPropertyStorage : PaoObject
    {
        #region 插件属性
        #region 属性：FilePath
        /// <summary>
        /// 属性：FilePath
        /// 文件路径
        /// 保存扩展属性的文件的路径
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("文件路径")]
        [Description("保存扩展属性的文件的路径")]
        public string FilePath {
            get;
            set;
        }
        #endregion 属性：FilePath
        #endregion

        [NonSerialized]
        private ExtendPropertyDataTable _PropertyTable;
        /// <summary>
        /// 属性表
        /// </summary>
        public ExtendPropertyDataTable PropertyTable {
            get {
                return _PropertyTable;
            }
            set {
                _PropertyTable = value;
            }
        }

        public ExtendPropertyStorage() {
        }

        public void Load() {
            _PropertyTable = new ExtendPropertyDataTable();
            var path = AppPublic.GetAbsolutePath(FilePath);
            if(File.Exists(path)) {
                var newTable = IOPublic.ReadObjectFromFile(path) as ExtendPropertyDataTable;
                if (newTable != null) {
                    PropertyTable.Merge(newTable);
                }
            }
        }

        public void Save() {
            var path = AppPublic.GetAbsolutePath(FilePath);
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            IOPublic.WriteObjectToFile(path, PropertyTable);
        }

        /// <summary>
        /// 抽取插件扩展属性
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="addon">插件</param>
        /// <param name="properties">需要纳入扩展的属性</param>
        public void SaveAddonExtendProperties(PaoObject addon, params string[] properties) {
            // 移除原来的插件属性
            var addonRows = PropertyTable.AsEnumerable<ExtendPropertyRow>().Where(p => p.AddonID == addon.ID).ToList();
            foreach (var addonRow in addonRows) {
                addonRow.Delete();
            }

            if (properties.IsNotNullOrEmpty()) {
                foreach (var property in properties) {
                    var value = addon.GetPropertyValueByPath(property);
                    var newRow = PropertyTable.AddExtendPropertyRow(addon.ID, property, IOPublic.Serialize<string>(value));
                }
            }
            PropertyTable.AcceptChanges();
        }

        /// <summary>
        /// 应用插件扩展属性
        /// </summary>
        /// <param name="dataTable">扩展数据表</param>
        /// <param name="addon">插件</param>
        public void LoadAddonExtendProperties(PaoObject addon) {
            var addonRows = PropertyTable.AsEnumerable<ExtendPropertyRow>().Where(p => p.AddonID == addon.ID).ToList();
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
    }
}
