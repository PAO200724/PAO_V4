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
    /// 类：SpinEditor
    /// 微调编辑器
    /// 微调编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("微调编辑器")]
    [Description("微调编辑器")]
    public class SpinEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public SpinEditor() {
        }

        public override RepositoryItem CreateEditor() {
            var edit = new RepositoryItemSpinEdit();
            DevExpressPublic.AddClearButton(edit);
            return edit;
        }
    }
}