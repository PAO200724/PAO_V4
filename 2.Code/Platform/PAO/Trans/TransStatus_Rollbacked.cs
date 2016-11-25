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
    /// 类：Status_Rollbacked
    /// 已经回滚
    /// 已经回滚状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("已经回滚")]
    [Description("已经回滚状态")]
    public class TransStatus_Rollbacked : Status_Enabled
    {
        #region 插件属性
        #endregion
        public TransStatus_Rollbacked() {
        }
    }
}
