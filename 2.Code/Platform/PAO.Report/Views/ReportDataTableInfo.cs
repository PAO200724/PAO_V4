using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report.Views
{
    /// <summary>
    /// 类：ReportDataTableInfo
    /// 报表数据表信息
    /// 报表数据表信息
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表数据表信息")]
    [Description("报表数据表信息")]
    public class ReportDataTableInfo : ReportDataTable
    {
        #region 插件属性

        #region 属性：Icon
        /// <summary>
        /// 属性：Icon
        /// 图标
        /// 图标
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("图标")]
        [Description("图标")]
        public Image Icon {
            get;
            set;
        }
        #endregion 属性：Icon

        #endregion

        [NonSerialized]
        private DataTable CurrentDataTable = null;

        /// <summary>
        /// 数据行数
        /// </summary>
        public int DataCount {
            get {
                if (CurrentDataTable == null)
                    return 0;

                return CurrentDataTable.Rows.Count;
            }
        }

        public ReportDataTableInfo() {
        }
    }
}
