using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part
{
    /// <summary>
    /// 类:BasePart
    /// 部件
    /// 部件基类
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("部件")]
    [Description("部件基类")]
    public class BasePart : PaoObject
    {
        #region 插件属性
        #region 属性:Status
        /// <summary>
        /// 属性:Status
        /// 状态
        /// 部件状态
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("状态")]
        [Description("部件状态")]
        public Status Status
        {
            get;
            set;
        }
        #endregion 属性:Status
        #endregion
        public BasePart()
        {
        }
    }
}
