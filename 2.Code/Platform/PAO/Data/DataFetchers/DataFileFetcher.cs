using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data;
using PAO.App;
using PAO.IO;
using System.IO;

namespace PAO.Data.DataFetchers
{
    /// <summary>
    /// 类：DataFileFetcher
    /// 数据文件获取器
    /// 从数据文件中获取数据的数据获取器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据文件获取器")]
    [Description("从数据文件中获取数据的数据获取器")]
    public class DataFileFetcher : PaoObject, IDataFetch
    {
        #region 插件属性

        #region 属性：FilePath
        /// <summary>
        /// 属性：FilePath
        /// 数据文件路径
        /// 包含数据的文件路径
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据文件路径")]
        [Description("包含数据的文件路径")]
        public string FilePath {
            get;
            set;
        }
        #endregion 属性：FilePath
        #endregion
        public DataFileFetcher() {
        }

        DataTable _DataTable = null;
        DataTable DataTable {
            get {
                if(_DataTable == null)
                    Requery();
                return _DataTable;
            }
        }

        private void Requery() {
            if (FilePath == null)
                return;

            string filePath = AppPublic.GetAbsolutePath(FilePath);
            if (!File.Exists(filePath))
                return;

            _DataTable = IOPublic.ReadObjectFromFile(filePath) as DataTable;
        }

        public DataTable FetchData(int startIndex, int count, params DataParameter[] parameterValues) {
            Requery();
            var dataTable = DataTable;
            return dataTable;
        }

        public DataTable GetDataSchema() {
            var dataTable = DataTable;
            return dataTable;
        }

        public DataParameter[] GetParameters() {
            return null;
        }
    }
}
