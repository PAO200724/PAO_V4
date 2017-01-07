using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;

namespace PAO.Data.ValueFetchers
{
    /// <summary>
    /// 类：ValueFetcher
    /// 值获取器
    /// 所有值获取器的基类
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("值获取器")]
    [Description("所有值获取器的基类")]
    public abstract class ValueFetcher<T> : PaoObject, IValueFetch<T>
    {
        #region 插件属性
        #endregion
        public ValueFetcher() {
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public abstract T Value {
            get;
        }
    }
}
