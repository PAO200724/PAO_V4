using PAO;
using PAO.WinForm.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：CommonObjectEditController
    /// 通用对象编辑控制器
    /// 通用对象编辑控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("通用对象编辑控制器")]
    [Description("通用对象编辑控制器")]
    public class CommonObjectEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public CommonObjectEditController() {
        }

        protected override Control OnCreateEditControl(Type objectType) {
            if(objectType == null) {
                return null;
            } 

            if(objectType.IsAddonDictionaryType()) {
                return new DictionaryEditController().CreateEditControl(objectType); ;
            }

            if (objectType.IsAddonListType()) {
                return new ListEditController().CreateEditControl(objectType); ;
            }

            return ObjectPropertyEditController.CreateTypeEditControl(objectType); ;
        }
    }
}
