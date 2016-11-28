using PAO;
using PAO.Event;
using PAO.IO.Text;
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
    /// 类：TransactionEventInfo
    /// 事务事件信息
    /// 记录事务事件信息的类
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("事务事件信息")]
    [Description("记录事务事件信息的类")]
    public class TransactionEventInfo : EventInfo
    {
        const string EventType_TransactionRunning = "事务启动";
        const string EventType_TransactionCommitted = "事务提交";
        const string EventType_TransactionExcepted = "事务异常";
        const string EventType_TransactionFailed = "事务失败";
        const string EventType_TransactionRollbacked = "事务回滚";
        const string EventType_TransactionRollbackExcepted = "事务回滚异常";

        #region 插件属性

        #region 属性：Transaction
        /// <summary>
        /// 属性：Transaction
        /// 事务
        /// 事务
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("事务")]
        [Description("事件对应的事务")]
        public PaoTransaction Transaction {
            get;
            set;
        }
        #endregion 属性：Transaction

        #region 属性：InnerExceptionInfo
        /// <summary>
        /// 属性：InnerExceptionInfo
        /// 内部异常信息
        /// 当事务处于异常或回滚异常时，此属性有效
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("内部异常信息")]
        [Description("当事务处于异常或回滚异常时，此属性有效")]
        public ExceptionEventInfo InnerExceptionInfo {
            get;
            set;
        }
        #endregion 属性：InnerExceptionInfo
        #endregion
        public TransactionEventInfo() {
        }

        public TransactionEventInfo(PaoTransaction trans
            , bool screenshot = false
            , bool snapshot = false) : base(null, trans.ToString(), screenshot, snapshot) {
            Transaction = (PaoTransaction)TextPublic.ObjectClone(trans);
            if(trans.Status is TransStatus_Running) {
                Type = EventType_TransactionRunning;
            } else if (trans.Status is TransStatus_Committed) {
                Type = EventType_TransactionCommitted;
            }
            else if (trans.Status is TransStatus_Excepted) {
                Type = EventType_TransactionExcepted;
                InnerExceptionInfo = new ExceptionEventInfo(trans.Status.As<TransStatus_Excepted>().Exception);
            }
            else if (trans.Status is TransStatus_Failed) {
                Type = EventType_TransactionFailed;
            }
            else if (trans.Status is TransStatus_Rollbacked) {
                Type = EventType_TransactionRollbacked;
            }
            else if (trans.Status is TransStatus_RollbackExcepted) {
                Type = EventType_TransactionRollbackExcepted;
                InnerExceptionInfo = new ExceptionEventInfo(trans.Status.As<TransStatus_RollbackExcepted>().Exception);
            }
        }

        public override string ToString() {
            if (Transaction == null)
                return null;
            base.ToString();
            if (Transaction.Status is TransStatus_Running || Transaction.Status is TransStatus_Rollbacked) {
                return String.Format("[{0} {1} {2:yyyy-MM-dd HH:mm:ss.fffff} 名称:{3} ID: {4}{5}]"
                    , Source
                    , Type
                    , Transaction.StartTime
                    , Transaction.Name
                    , Transaction.ID
                    , Transaction.ParentID.IsNotNullOrEmpty() ? String.Format(" 父ID:{0}", Transaction.ParentID) : null);
            }
            else if (Transaction.Status is TransStatus_Committed || Transaction.Status is TransStatus_Failed) {
                return String.Format("[{0} {1} {2:yyyy-MM-dd HH:mm:ss.fffff} 名称:{3} ID: {4}{5} 耗时:{6}]"
                    , Source
                    , Type
                    , Transaction.StartTime
                    , Transaction.Name
                    , Transaction.ID
                    , Transaction.ParentID.IsNotNullOrEmpty() ? String.Format(" 父ID:{0}", Transaction.ParentID) : null
                    , Transaction.Status.As<Status_Completed>().SpendTime);
            }
            else if (Transaction.Status is TransStatus_Excepted || Transaction.Status is TransStatus_RollbackExcepted) {
                return String.Format("[{0} {1} {2:yyyy-MM-dd HH:mm:ss.fffff} 名称:{3} ID: {4}{5}]\r\n{6}"
                    , Source
                    , Type
                    , Transaction.StartTime
                    , Transaction.Name
                    , Transaction.ID
                    , Transaction.ParentID.IsNotNullOrEmpty() ? String.Format(" 父ID:{0}", Transaction.ParentID) : null
                    , InnerExceptionInfo);
            }

            return Transaction.ToString();
        }
    }
}
