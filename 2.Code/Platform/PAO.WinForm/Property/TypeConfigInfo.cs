using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.WinForm.Editors;

namespace PAO.WinForm.Config
{
    /// <summary>
    /// 类：TypeConfigInfo
    /// 类型配置信息
    /// 类型在配置画面所需的一些信息
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("类型配置信息")]
    [Description("类型在配置画面所需的一些信息")]
    public class TypeConfigInfo : PaoObject
    {
        #region 插件属性
        #region 属性：PropertyConfigInfoList
        /// <summary>
        /// 属性：Properties
        /// 属性信息
        /// 类型的属性信息
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("属性信息")]
        [Description("类型的属性信息")]
        public Dictionary<string, PropertyConfigInfo> PropertyConfigInfoList {
            get;
            set;
        }
        #endregion 属性：Properties

        #region 属性：EditControlType
        /// <summary>
        /// 属性：EditControlType
        /// 编辑器类型
        /// 编辑器控件类型
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("编辑器类型")]
        [Description("编辑器控件类型")]
        public Type EditControlType {
            get;
            set;
        }
        #endregion 属性：EditControlType

        #region 属性：ShowDefinedPropertyOnly
        /// <summary>
        /// 属性：ShowDefinedPropertyOnly
        /// 只显示定义了的属性
        /// 只显示定义了的属性，未定义的属性不显示
        /// </summary>
        [AddonProperty]
        [DefaultValue(false)]
        [DataMember(EmitDefaultValue = false)]
        [Name("只显示定义了的属性")]
        [Description("只显示定义了的属性，未定义的属性不显示")]
        public bool ShowDefinedPropertyOnly {
            get;
            set;
        }
        #endregion 属性：ShowDefinedPropertyOnly
        #endregion
        public TypeConfigInfo() {
            PropertyConfigInfoList = new Dictionary<string, Config.PropertyConfigInfo>();
            ShowDefinedPropertyOnly = false;
        }

        public static TypeConfigInfo Create(Type editorType = null, bool showDefinedPropertyOnly = false) {
            return new TypeConfigInfo()
            {
                ShowDefinedPropertyOnly = showDefinedPropertyOnly,
                EditControlType = editorType
            };
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="property">属性</param>
        /// <param name="displayName">显示名称</param>
        /// <param name="description">描述</param>
        /// <param name="editor">编辑器</param>
        /// <param name="browsable">可浏览</param>
        /// <returns>this</returns>
        public TypeConfigInfo AddProperty(string property, string displayName = null, string description = null, BaseEditor editor = null, bool browsable = true) {
            if (PropertyConfigInfoList == null)
                PropertyConfigInfoList = new Dictionary<string, Config.PropertyConfigInfo>();

            var propertyConfigInfo = new PropertyConfigInfo(displayName, description, editor, browsable);
            if(PropertyConfigInfoList.ContainsKey(property)) {
                PropertyConfigInfoList[property] = propertyConfigInfo;
            } else {
                PropertyConfigInfoList.Add(property, propertyConfigInfo);
            }
            return this;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="property">属性</param>
        /// <param name="editor">编辑器</param>
        /// <returns>this</returns>
        public TypeConfigInfo AddProperty(string property, bool browsable) {
            return AddProperty(property, null, null, null, browsable);
        }
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="property">属性</param>
        /// <param name="editor">编辑器</param>
        /// <returns>this</returns>
        public TypeConfigInfo AddProperty(string property, BaseEditor editor) {
            return AddProperty(property, null, null, editor);
        }

        /// <summary>
        /// 获取属性配置信息
        /// </summary>
        /// <param name="property">属性</param>
        /// <returns>配置信息</returns>
        internal PropertyConfigInfo GetPropertyConfigInfo(string property) {
            if (PropertyConfigInfoList.ContainsKey(property)) {
                return PropertyConfigInfoList[property];
            }
            return null;
        }
    }
}
