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
using PAO.Data.Filters;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：DataFilterEditController
    /// 数据过滤器编辑控制器
    /// 数据过滤器编辑器的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据过滤器编辑控制器")]
    [Description("数据过滤器编辑器的控制器")]
    public class DataFilterEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public DataFilterEditController() {
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new DataFilterEditControl();
            return editControl;
        }

        public static new bool TypeFilter(Type type) {
            return type.IsDerivedFrom(typeof(DataFilter));
        }
    }
}
