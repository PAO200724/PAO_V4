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
    /// 类：BasePart
    /// 部件
    /// 部件基类
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("部件")]
    [Description("部件基类")]
    public class BasePart : PaoObject
    {
        #region 插件属性
        #endregion
        public BasePart()
        {
        }
    }
}
