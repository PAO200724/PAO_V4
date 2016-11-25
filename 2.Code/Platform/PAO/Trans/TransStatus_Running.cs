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
    /// 类：TransStatus_Running
    /// 运行中
    /// 运行中状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("运行中")]
    [Description("运行中状态")]
    public class TransStatus_Running : Status_Running
    {
        #region 插件属性
        #endregion
        public TransStatus_Running() {
        }
    }
}
