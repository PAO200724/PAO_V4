using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part.Enabled
{
    /// <summary>
    /// 类：Status_Pending
    /// 暂停
    /// 暂停状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("暂停")]
    [Description("暂停状态")]
    public class Status_Pending : Status_Enabled
    {
        #region 插件属性
        #endregion
        public Status_Pending()
        {
        }
    }
}
