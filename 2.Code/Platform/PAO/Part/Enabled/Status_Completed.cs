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
    /// 类：Status_Completed
    /// 完成
    /// 完成状态
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("完成")]
    [Description("完成状态")]
    public class Status_Completed : PaoObject
    {
        #region 插件属性
        #endregion
        public Status_Completed()
        {
        }
    }
}
