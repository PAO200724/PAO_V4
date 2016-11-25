using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part.Enabled.Running
{
    /// <summary>
    /// 类：Status_Running
    /// 运行中
    /// 运行中状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("运行中")]
    [Description("运行中状态")]
    public class Status_Running : Status_Enabled
    {
        #region 插件属性
        #endregion
        public Status_Running()
        {
        }
    }
}
