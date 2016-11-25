using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 类：PaoTransactionScope
    /// 事务范围
    /// 标识一个事务空间的范围
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("事务范围")]
    [Description("标识一个事务空间的范围")]
    public class PaoTransactionScope : IDisposable
    {
        #region 插件属性
        #endregion
        public PaoTransactionScope() {
        }

        public void Dispose() {
        }
    }
}
