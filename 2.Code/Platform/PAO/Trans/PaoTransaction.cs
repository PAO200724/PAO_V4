using PAO;
using PAO.Log;
using PAO.Part;
using PAO.Part.Enabled;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 类:PaoTransaction
    /// 事务
    /// PAO架构中的事务支持类
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("事务")]
    [Description("PAO架构中的事务支持类")]
    public class PaoTransaction : BasePart
    {
        #region 插件属性
        #region 属性:ParentID
        /// <summary>
        /// 属性:ParentID
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
        #endregion 属性:ParentID

        #region 属性:Name
        /// <summary>
        /// 属性:Name
        /// 事务名称
        /// 事务名称
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("事务名称")]
        [Description("事务名称")]
        public string Name {
            get;
            set;
        }
        #endregion 属性:Name

        #region 属性：StartTime
        /// <summary>
        /// 属性：StartTime
        /// 启动时间
        /// 事务启动时间
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("启动时间")]
        [Description("事务启动时间")]
        public DateTime StartTime {
            get;
            set;
        }
        #endregion 属性：StartTime
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

        internal PaoTransaction(string name = null) {
            Parent = Current;
            Current = this;
            Name = name;
            StartTime = DateTime.Now;
            Status = Status.Default<TransStatus_Running>();
            LogPublic.LogTransaction(this);
        }
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="exp"></param>
        internal void Exception(Exception exp) {
            Status = new TransStatus_Excepted(exp);
            LogPublic.LogTransaction(this);
        }
        /// <summary>
        /// 回滚异常
        /// </summary>
        /// <param name="exp"></param>
        internal void RollbackException(Exception exp) {
            Status = new TransStatus_RollbackExcepted(exp);
            LogPublic.LogTransaction(this);
        }
        /// <summary>
        /// 回滚
        /// </summary>
        internal void Rollback() {
            Status = Status.Default<TransStatus_Rollbacked>();
            LogPublic.LogTransaction(this);
        }
        /// <summary>
        /// 失败
        /// </summary>
        internal void Fail() {
            Status = new TransStatus_Failed() { SpendTime = DateTime.Now - StartTime };
            LogPublic.LogTransaction(this);
            End();
        }
        /// <summary>
        /// 提交
        /// </summary>
        internal void Commit() {
            Status = new TransStatus_Committed() { SpendTime = DateTime.Now - StartTime };
            LogPublic.LogTransaction(this);
            End();
        }
        /// <summary>
        /// 结束事务
        /// </summary>
        private void End() {
            Current = Parent;
            Parent = null;
        }

        public override string ToString() {
            return this.ObjectToString(null, "ID", "ParentID", "Status");
        }
    }
}
