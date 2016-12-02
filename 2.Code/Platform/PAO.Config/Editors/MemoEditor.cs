﻿using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.UI.WinForm;

namespace PAO.Config.Editors
{
    /// <summary>
    /// 类：MemoEditor
    /// 多行文本编辑器
    /// 多行文本编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("多行文本编辑器")]
    [Description("多行文本编辑器")]
    public class MemoEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public MemoEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemMemoExEdit();
            DevExpressPublic.AddClearButton(edit);
            return edit;
        }
    }
}
