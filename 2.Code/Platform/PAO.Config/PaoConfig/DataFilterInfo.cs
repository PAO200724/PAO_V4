using PAO.Data;
using PAO.Data.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Config.PaoConfig
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
                if (DataFilter is SqlFilter)
                    return "SQL";
                else if (DataFilter is AndLogicFilter)
                    return "AND";
                else if (DataFilter is OrLogicFilter)
                    return "OR";
                else
                    throw new Exception("不支持的过滤器类型").AddExceptionData("过滤器", DataFilter);
            }
        }


        public string ParameterName {
            get {
                if (DataFilter is SqlFilter)
                    return DataFilter.As<SqlFilter>().Name;
                return null;
            }

            set {
                if (DataFilter is SqlFilter)
                    DataFilter.As<SqlFilter>().Name = value;
            }
        }
        public DbType DataType {
            get {
                if (DataFilter is SqlFilter)
                    return DataFilter.As<SqlFilter>().Type;
                return DbType.String;
            }

            set {
                if (DataFilter is SqlFilter)
                    DataFilter.As<SqlFilter>().Type = value;
            }
        }
        public string Caption {
            get {
                if (DataFilter is SqlFilter)
                    return DataFilter.As<SqlFilter>().Caption;
                return null;
            }

            set {
                if (DataFilter is SqlFilter)
                    DataFilter.As<SqlFilter>().Caption = value;
            }
        }

        public string Sql {
            get {
                if (DataFilter is SqlFilter)
                    return DataFilter.As<SqlFilter>().Sql;
                return null;
            }

            set {
                if (DataFilter is SqlFilter)
                    DataFilter.As<SqlFilter>().Sql = value;
            }
        }
    }
}
