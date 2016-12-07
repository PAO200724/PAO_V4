using PAO;
using PAO.UI.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class GridControlViewCommand : CommandMenuItem
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
        #endregion
        public GridControlViewCommand() {
        }

        protected override void OnDoCommand(object container) {
            var viewContainer = container as IViewContainer;
            if(viewContainer != null) {
                var gridControlView = new GridControlView();
                gridControlView.FromUIItem(this);
                viewContainer.OpenView(gridControlView);
            }
        }
    }
}
