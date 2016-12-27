using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using System.Windows.Forms;
using PAO.WinForm;
using PAO.WinForm.Editor;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 类：ObjectLayoutEditorLayoutData
    /// 布局式对象编辑器布局数据
    /// 布局控件形式的对象编辑器布局数据
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("布局式对象编辑器布局数据")]
    [Description("布局控件形式的对象编辑器布局数据")]
    public class ObjectLayoutEditorLayoutData : TypeEditorLayoutData
    {
        #region 插件属性

        #endregion

        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 布局数据
        /// </summary>
        [Browsable(false)]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData

        public ObjectLayoutEditorLayoutData() {
    }
}
}
