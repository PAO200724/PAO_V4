using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.WinForm.Editor;

namespace PAO.WinForm.Config
{
    /// <summary>
    /// 类：PropertyConfigInfo
    /// 属性配置信息
    /// 属性在配置画面的配置信息
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("属性配置信息")]
    [Description("属性在配置画面的配置信息")]
    public class PropertyConfigInfo : PaoObject
    {
        #region 插件属性

        #region 属性：DisplayName
        /// <summary>
        /// 属性：DisplayName
        /// 显示名称
        /// 显示名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("显示名称")]
        [Description("显示名称")]
        public string DisplayName {
            get;
            set;
        }
        #endregion 属性：DisplayName

        #region 属性：Description
        /// <summary>
        /// 属性：Description
        /// 描述
        /// 描述
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("描述")]
        [Description("描述")]
        public string Description {
            get;
            set;
        }
        #endregion 属性：Description

        #region 属性：Editor
        /// <summary>
        /// 属性：Editor
        /// 编辑器
        /// 编辑器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("编辑器")]
        [Description("编辑器")]
        public BaseEditController Editor {
            get;
            set;
        }
        #endregion 属性：Editor

        #region 属性：Browsable
        /// <summary>
        /// 属性：Browsable
        /// 可浏览
        /// 可以在配置窗口中浏览
        /// </summary>
        [AddonProperty]
        [DefaultValue(true)]
        [DataMember(EmitDefaultValue = false)]
        [Name("可浏览")]
        [Description("可以在配置窗口中浏览")]
        public bool Browsable {
            get;
            set;
        }
        #endregion 属性：Browsable
        #endregion
        public PropertyConfigInfo() {
            Browsable = true;
        }

        public PropertyConfigInfo(string displayName,string description = null, BaseEditController editor = null, bool browsable = true) {
            DisplayName = displayName;
            Description = description;
            Editor = editor;
            Browsable = browsable;
        }
    }
}
