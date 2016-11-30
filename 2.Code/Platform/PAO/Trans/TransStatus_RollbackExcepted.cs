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
    /// 类：Status_RollbackException
    /// 回滚异常
    /// 回滚异常状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("回滚异常")]
    [Description("回滚异常状态")]
    public class TransStatus_RollbackExcepted : Status_Excepted
    {
        #region 插件属性
        #endregion
        public TransStatus_RollbackExcepted() {
        }

        public TransStatus_RollbackExcepted(Exception exp) : base(exp) {
             
        }
    }
}
