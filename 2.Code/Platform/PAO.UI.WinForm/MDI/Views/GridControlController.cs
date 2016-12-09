using PAO;
using PAO.UI.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.WinForm.MDI.Views
{
    /// <summary>
    /// 类：GridControlViewCommand
    /// 表格控件视图命令
    /// 用于创建表格控件视图的命令
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("表格控件视图命令")]
    [Description("用于创建表格控件视图的命令")]
    public class GridControlController : BaseController
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

        #region 属性：DataSchema
        /// <summary>
        /// 属性：DataSchema
        /// s数据格式
        /// 数据格式
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("s数据格式")]
        [Description("数据格式")]
        public DataSet DataSchema {
            get;
            set;
        }
        #endregion 属性：DataSchema
        #endregion
        public GridControlController() {
        }

        protected override void OnDoCommand() {
            var gridControlView = new GridControlView();
            gridControlView.FromUIItem(this);
            MVCPublic.MainForm.OpenView(gridControlView);
        }
    }
}
