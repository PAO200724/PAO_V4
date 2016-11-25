using PAO;
using PAO.Log;
using PAO.Part;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 类：PaoTransaction
    /// PAO事务类
    /// PAO架构中的事务支持类
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("PAO事务类")]
    [Description("PAO架构中的事务支持类")]
    public class PaoTransaction : PaoObject
    {
        #region 插件属性
        #region 属性：ParentID
        /// <summary>
        /// 属性：ParentID
        /// 上级事务ID
        /// 上级事务的唯一标识
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("上级事务ID")]
        [Description("上级事务的唯一标识")]
        public string ParentID {
            get;
            set;
        }
        #endregion 属性：ParentID
        #endregion

        /// <summary>
        /// 当前事务
        /// </summary>
        [ThreadStatic]
        private static PaoTransaction _Current;
        public static PaoTransaction Current {
            get {
                return _Current;
            }
            private set {
                _Current = value;
            }
        }

        /// <summary>
        /// 上级事务
        /// </summary>
        private PaoTransaction _Parent;
        private PaoTransaction Parent {
            get { return _Parent; }
            set {
                _Parent = value;
                if (_Parent == null)
                    ParentID = null;
                else
                    ParentID = value.ID;
            }
        }

        internal PaoTransaction() {
            Parent = Current;
            Current = this;
        }

        /// <summary>
        /// 结束事务
        /// </summary>
        internal void End() {
            Current = Parent;
        }

    }
}
