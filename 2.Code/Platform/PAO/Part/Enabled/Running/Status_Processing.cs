using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part.Enabled.Running
{
    /// <summary>
    /// 类:Status_Processing
    /// 处理中
    /// 处理中状态
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("处理中")]
    [Description("处理中状态")]
    public class Status_Processing : Status_Running
    {
        #region 插件属性
        #region 属性:Step
        /// <summary>
        /// 属性:Step
        /// 步骤
        /// 当前处理步骤（百分比）
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("步骤")]
        [Description("当前处理步骤（百分比）")]
        public double Step
        {
            get;
            set;
        }
        #endregion 属性:Step
        #endregion
        public Status_Processing()
        {
        }

        public Status_Processing(double step)
        {
            Step = step;
        }
        public override string ToString() {
            return this.ObjectToString(null, "Step");
        }

    }
}
