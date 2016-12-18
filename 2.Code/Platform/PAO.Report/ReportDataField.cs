using PAO;
using PAO.Data;
using PAO.WinForm.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report
{
    /// <summary>
    /// 类：ReportDataField
    /// 报表数据字段
    /// 报表中的列和查询参数用的数据字段
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("查询参数")]
    [Description("查询参数")]
    public class ReportDataField : DataField
    {
        #region 插件属性
        #region 属性:Caption
        /// <summary>
        /// 属性:Caption
        /// 标题
        /// 字段标题
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("标题")]
        [Description("字段标题")]
        public string Caption {
            get;
            set;
        }
        #endregion 属性:Caption
        
        #region 属性：Editor
        /// <summary>
        /// 属性：Editor
        /// 编辑器
        /// 参数编辑器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("编辑器")]
        [Description("参数编辑器")]
        public BaseEditor Editor {
            get;
            set;
        }
        #endregion 属性：Editor
        #endregion
        public ReportDataField() {
        }
    }
}
