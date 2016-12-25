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
        public DataFilter DataFilter { get; set; }

        public string Name {
            get {
                if (DataFilter is Sql)
                    return "SQL";
                else if (DataFilter is And)
                    return "AND";
                else if (DataFilter is Or)
                    return "OR";
                else
                    throw new Exception("不支持的过滤器类型").AddExceptionData("过滤器", DataFilter);
            }
        }
        
        public string Sql {
            get {
                if (DataFilter is Sql)
                    return DataFilter.As<Sql>().Filter;
                return null;
            }

            set {
                if (DataFilter is Sql)
                    DataFilter.As<Sql>().Filter = value;
            }
        }
    }
}
