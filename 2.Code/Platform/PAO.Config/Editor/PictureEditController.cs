﻿using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;
using System.Drawing;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ImageEditor
    /// 图片编辑器
    /// 图片编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("图片编辑器")]
    [Description("图片编辑器")]
    public class PictureEditController : BaseRepositoryItemEditController
    {
        #region 插件属性
        #endregion
        public PictureEditController() {
        }

        protected override RepositoryItem OnCreateRepositoryItem(Type objectType) {
            var edit = new RepositoryItemPictureEdit();
            return edit;
        }

        public static new bool TypeFilter(Type type) {
            return type == typeof(Image) || type == typeof(byte[]);
        }
    }
}
