﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO;
using PAO.WinForm;
using System.Windows.Forms;
using PAO.Config.Editor;
using PAO.Data;

namespace PAO.Report.Controls
{
    /// <summary>
    /// 类：DataParametersEditController
    /// 数据项编辑控制器
    /// 数据项编辑器的控制
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据项编辑控制器")]
    [Description("数据项编辑器的控制")]
    public class DataParametersEditController : BaseObjectEditController
    {
        #region 插件属性
        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 保存数据项编辑器布局数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("保存数据项编辑器布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData
        #endregion
        public DataParametersEditController() {
        }

        protected override Control OnCreateEditControl(Type objectType) {
            var editControl = new DataParametersEditControl();
            return editControl;
        }

        public static new bool TypeFilter(Type type) {
            return type.IsDerivedFrom(typeof(IEnumerable<DataParameter>));
        }
    }
}
