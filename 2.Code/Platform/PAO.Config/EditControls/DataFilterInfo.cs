using PAO.Data;
using PAO.Data.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 数据过滤器信息
    /// </summary>
    public class DataFilterInfo
    {
        public string ID {
            get { if (DataFilter == null) return null;
                return DataFilter.ID;
            }
        }
        public string ParentID { get; set; }
        public int ImageIndex { get; set; }
        public IDataFilter DataFilter { get; set; }

        public string Name {
            get {
                if (DataFilter is Filter)
                    return "SQL";
                else if (DataFilter is And)
                    return "AND";
                else if (DataFilter is Or)
                    return "OR";
                else
                    throw new Exception("不支持的过滤器类型").AddExceptionData("过滤器", DataFilter);
            }
        }


        public string ParameterName {
            get {
                if (DataFilter is Filter)
                    return DataFilter.As<Filter>().Name;
                return null;
            }

            set {
                if (DataFilter is Filter)
                    DataFilter.As<Filter>().Name = value;
            }
        }
        public DbType DataType {
            get {
                if (DataFilter is Filter)
                    return DataFilter.As<Filter>().Type;
                return DbType.String;
            }

            set {
                if (DataFilter is Filter)
                    DataFilter.As<Filter>().Type = value;
            }
        }

        public string Sql {
            get {
                if (DataFilter is Filter)
                    return DataFilter.As<Filter>().Sql;
                return null;
            }

            set {
                if (DataFilter is Filter)
                    DataFilter.As<Filter>().Sql = value;
            }
        }
    }
}
