﻿using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 类：CheckEditor
    /// 复选框编辑器
    /// 复选框编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("复选框编辑器")]
    [Description("复选框编辑器")]
    public class CheckEditor : BaseRepositoryItemEditor
    {
        #region 插件属性
        #endregion
        public CheckEditor() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemCheckEdit();
            return edit;
        }
    }
}
