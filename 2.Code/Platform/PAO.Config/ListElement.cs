using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 类：ListElement
    /// 列表项目
    /// 列表项目
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("列表项目")]
    [Description("列表项目")]
    public class ListElement : PaoObject
    {
        #region 插件属性
        #region 属性：Index
        /// <summary>
        /// 属性：Index
        /// 索引
        /// 列表索引号,如果是字典元素，则是Key
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("索引")]
        [Description("列表索引号,如果是字典元素，则是Key")]
        public object Index {
            get;
            set;
        }
        #endregion 属性：Index


        #region 属性：Element
        /// <summary>
        /// 属性：Element
        /// 元素
        /// 列表元素对象
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("元素")]
        [Description("列表元素对象")]
        public object Element {
            get;
            set;
        }
        #endregion 属性：Element
        #endregion
        public ListElement() {
        }
    }
}
