﻿using PAO;
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
    /// 列表编辑控制器
    /// 列表对象的编辑控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("列表编辑控制器")]
    [Description("列表对象的编辑控制器")]
    public class ListEditController : BaseObjectEditController
    {
        #region 插件属性
        #endregion
        public ListEditController() {
        }

        protected override BaseEditControl OnCreateEditControl() {
            var editControl = new ListEditControl();
            return editControl;
        }
        
    }
}