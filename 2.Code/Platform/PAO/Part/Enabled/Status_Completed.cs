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
    /// 类:Status_Completed
    /// 完成
    /// 完成状态
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("完成")]
    [Description("完成状态")]
    public class Status_Completed : Status_Enabled
    {
        #region 插件属性
        #region 属性：SpendTime
        /// <summary>
        /// 属性：SpendTime
        /// 耗时
        /// 程序完成所耗费的时间
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("耗时")]
        [Description("程序完成所耗费的时间")]
        public TimeSpan SpendTime {
            get;
            set;
        }
        #endregion 属性：SpendTime
        #endregion
        public Status_Completed()
        {
        }

        public Status_Completed(TimeSpan spendTime) {
            SpendTime = spendTime;
        }
        public override string ToString() {
            return this.ObjectToString(null, "SpendTime");
        }
    }
}
