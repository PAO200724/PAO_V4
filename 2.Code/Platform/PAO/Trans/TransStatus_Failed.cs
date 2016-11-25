using PAO;
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
    /// 类：TransStatus_Failed
    /// 失败
    /// 事务处于执行失败的状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("失败")]
    [Description("事务处于执行失败的状态")]
    public class TransStatus_Failed : Status_Completed
    {
        #region 插件属性
        #endregion
        public TransStatus_Failed() {
        }
    }
}
