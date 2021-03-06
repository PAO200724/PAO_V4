﻿using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ToggleSwitchController
    /// 是否切换编辑器
    /// 是否切换编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("是否切换编辑器")]
    [Description("是否切换编辑器")]
    public class ToggleSwitchEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public ToggleSwitchEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemToggleSwitch();
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(bool);
        }
    }
}
