using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.AOP
{
    /// <summary>
    /// 类：ObjectFolder
    /// 包含多个对象的目录
    /// 包含多个对象的对项目路
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("包含多个对象的目录")]
    [Description("包含多个对象的对项目路")]
    public class ObjectFolder : PaoObject
    {
        #region 插件属性

        #region 属性：ObjectList
        /// <summary>
        /// 属性：ObjectList
        /// 对象列表
        /// 子对象列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("对象列表")]
        [Description("子对象列表")]
        public List<Ref<PaoObject>> ObjectList {
            get;
            set;
        }
        #endregion 属性：ObjectList
        #endregion
        public ObjectFolder() {
        }
    }
}
