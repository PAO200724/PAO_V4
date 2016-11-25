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
    /// 类:Status_Enabled
    /// 有效状态
    /// 有效状态
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("有效状态")]
    [Description("有效状态")]
    public class Status_Enabled : Status
    {
        #region 插件属性
        #endregion
        public Status_Enabled()
        {
        }
    }
}
