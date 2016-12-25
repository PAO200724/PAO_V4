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
    /// 类：TimeEditor
    /// 时间编辑器
    /// 时间编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("时间编辑器")]
    [Description("时间编辑器")]
    public class TimeEditor : BaseRepositoryItemEditor
    {
        #region 插件属性
        #endregion
        public TimeEditor() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemTimeEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
