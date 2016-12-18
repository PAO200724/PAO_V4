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
    /// 类：DateEditor
    /// 日期编辑器
    /// 日期编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("日期编辑器")]
    [Description("日期编辑器")]
    public class DateEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public DateEditor() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemDateEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
