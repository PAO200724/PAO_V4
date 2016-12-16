﻿using DevExpress.XtraEditors.Repository;
using PAO;
using PAO.UI.WinForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.WinForm.Editors
{
    /// <summary>
    /// 类：BaseEditor
    /// 编辑器
    /// 编辑器基类
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "edit")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("编辑器")]
    [Description("编辑器基类")]
    public abstract class BaseEditor : PaoObject
    {
        #region 插件属性
        #endregion
        public BaseEditor() {
        }

        [NonSerialized]
        public PropertyDescriptor PropertyDescriptor;

        public abstract RepositoryItem CreateEditor();
    }
}
