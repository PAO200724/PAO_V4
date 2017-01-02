using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.WinForm;
using System.Windows.Forms;
using PAO.WinForm.Editor;
using PAO.Data;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：DataCommandInfoEditController
    /// 数据命令编辑控制器
    /// 数据命令编辑器的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据命令编辑控制器")]
    [Description("数据命令编辑器的控制器")]
    public class DataCommandInfoEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public DataCommandInfoEditController() {
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new DataCommandInfoEditControl();
            return editControl;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(DataCommandInfo);
        }
    }
}
