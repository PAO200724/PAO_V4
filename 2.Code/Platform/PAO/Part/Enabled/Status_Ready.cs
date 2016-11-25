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
    /// 类:Status_Ready
    /// 准备好
    /// 准备完成的状态
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("准备好")]
    [Description("准备完成的状态")]
    public class Status_Ready : Status_Enabled
    {
        #region 插件属性
        #endregion
        public Status_Ready()
        {
        }
    }
}
