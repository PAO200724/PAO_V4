using PAO;
using PAO.Part;
using PAO.Part.Enabled;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 类：TransStatus_Committed
    /// 已提交
    /// 事务提交完毕状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("已提交")]
    [Description("事务提交完毕状态")]
    public class TransStatus_Committed : Status_Completed
    {
        #region 插件属性
        #endregion
        public TransStatus_Committed() {
        }
    }
}
