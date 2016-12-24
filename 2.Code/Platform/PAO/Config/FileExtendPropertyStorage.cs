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
    public class FileExtendPropertyStorage : PaoObject, IExtendPropertyStorage
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
        public FileExtendPropertyStorage() {
        }

        public void LoadExtendProperties(DataSetExtendProperty.ExtendPropertyDataTable dataTable) {
            var path = AppPublic.GetAbsolutePath(FilePath);
            if(File.Exists(path)) {
                var newTable = IOPublic.ReadObjectFromFile(path) as DataSetExtendProperty.ExtendPropertyDataTable;
                if (newTable != null)
                    dataTable.Merge(newTable);
            }
        }

        public void SaveExtendProperties(DataSetExtendProperty.ExtendPropertyDataTable dataTable) {
            var path = AppPublic.GetAbsolutePath(FilePath);
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            IOPublic.WriteObjectToFile(path, dataTable);
        }
    }
}
