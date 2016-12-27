using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.Config.Controls;
using PAO.UI;
using PAO.IO;
using DevExpress.XtraEditors;
using PAO.Config.Editor;
using System.Collections;
using PAO.WinForm;
using PAO.WinForm.Editor;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ObjectEditor
    /// 插件编辑控制器
    /// 插件编辑控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("插件编辑控制器")]
    [Description("插件编辑控制器")]
    public class ObjectEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public ObjectEditController() {
        }

        protected override BaseEditControl OnCreateEditControl() {
            var editControl = new ObjectEditControl();
            return editControl;
        }
    }
}
