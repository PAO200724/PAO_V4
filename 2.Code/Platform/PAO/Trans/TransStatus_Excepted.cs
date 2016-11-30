using PAO;
using PAO.Part.Disabled;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 类：TransStatus_Excepted
    /// 异常
    /// 事务处于异常状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("异常")]
    [Description("事务处于异常状态")]
    public class TransStatus_Excepted : Status_Excepted
    {
        #region 插件属性
        #endregion
        public TransStatus_Excepted() {
        }

        public TransStatus_Excepted(Exception exp) : base(exp) {

        }
    }
}
