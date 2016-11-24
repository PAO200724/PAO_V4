using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.AOP {
    /// <summary>
    /// 类：ReverseWCFFactory
    /// 反向WCF工厂
    /// 通过反向远程调用实现的反向WCF工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("反向WCF工厂")]
    [Description("通过反向远程调用实现的反向WCF工厂")]
    public class ReverseWCFFactory<T> : Factory<T> {
        #region 插件属性
        #endregion
        public ReverseWCFFactory() {
        }
    }
}
