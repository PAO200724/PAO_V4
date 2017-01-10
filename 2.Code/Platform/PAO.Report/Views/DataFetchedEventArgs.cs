using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PAO.Report.Views
{
    /// <summary>
    /// 数据获取事件参数
    /// 作者：PAO
    /// </summary>
    public class DataFetchedEventArgs :EventArgs
    {
        public DataTable DataTable { get; set; }

        public DataFetchedEventArgs() {

        }

        public DataFetchedEventArgs(DataTable dataTable) {
            DataTable = dataTable;
        }
    }
}
