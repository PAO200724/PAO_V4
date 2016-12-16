using PAO;
using PAO.App;
using PAO.Data;
using PAO.Report.Properties;
using PAO.UI.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Report.Displayers
{
    /// <summary>
    /// 类：GridControlViewCommand
    /// 表格控件视图命令
    /// 用于创建表格控件视图的命令
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "table")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("表格控件视图命令")]
    [Description("用于创建表格控件视图的命令")]
    public class GridControlController : BaseDataDisplayerController
    {
        #region 插件属性

        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 控件的布局数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("控件的布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData

        #region 属性：DataMember
        /// <summary>
        /// 属性：DataMember
        /// 数据成员
        /// 数据表对应的数据成员
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据成员")]
        [Description("数据表对应的数据成员")]
        public string DataMember {
            get;
            set;
        }
        #endregion 属性：DataMember

        #region 属性：GridViewType
        /// <summary>
        /// 属性：GridViewType
        /// 视图类型
        /// 表格视图的类型
        /// </summary>
        [AddonProperty]
        [DefaultValue(GridViewType.GridView)]
        [DataMember(EmitDefaultValue = false)]
        [Name("视图类型")]
        [Description("表格视图的类型")]
        public GridViewType GridViewType {
            get;
            set;
        }
        #endregion 属性：GridViewType

        #endregion
        public GridControlController() {
            GridViewType = GridViewType.GridView;
        }

        protected override Type ViewType {
            get {
                return typeof(GridControlDataDisplayer);
            }
        }       
    }
}
