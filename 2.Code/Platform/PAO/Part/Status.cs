using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part
{
    /// <summary>
    /// 类：BaseStatus
    /// 状态
    /// 状态基类
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("状态")]
    [Description("状态基类")]
    public class Status : PaoObject
    {
        #region 插件属性
        #endregion
        public Status()
        {
        }

        public override string ToString()
        {
            return this.GetType().GetAttribute<DisplayNameAttribute>(false).DisplayName;
        }
    }
}
