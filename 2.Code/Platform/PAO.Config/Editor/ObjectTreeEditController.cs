using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.WinForm;
using System.Windows.Forms;
using PAO.Config.Editor;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ObjectTreeEditController
    /// 树型对象编辑控制器
    /// 树形对象编辑器的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("树型对象编辑控制器")]
    [Description("树形对象编辑器的控制器")]
    public class ObjectTreeEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public ObjectTreeEditController() {
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new ObjectTreeEditControl();
            return editControl;
        }


        public static new bool TypeFilter(Type type) {
            return false;
        }
    }
}
