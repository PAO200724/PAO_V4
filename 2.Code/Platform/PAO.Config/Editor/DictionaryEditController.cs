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

namespace PAO.Config.EditControl
{
    /// <summary>
    /// 类：ObjectEditor
    /// 字典编辑控制器
    /// 字典对象的编辑控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("字典编辑控制器")]
    [Description("字典对象的编辑控制器")]
    public class DictionaryEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public DictionaryEditController() {
        }

        protected override BaseEditControl OnCreateEditControl() {
            var editControl = new DictionaryEditControl();
            return editControl;
        }
    }
}
