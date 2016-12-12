using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;

namespace PAO.Time
{
    /// <summary>
    /// 类：DateTimeService
    /// 日期时间服务
    /// 获取服务器日期时间的服务
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("日期时间服务")]
    [Description("获取服务器日期时间的服务")]
    public class DateTimeService : PaoObject, IDateTime
    {
        #region 插件属性
        #endregion
        public DateTimeService() {
        }

        public DateTime GetCurrentDateTime() {
            return DateTime.Now;
        }
    }
}
