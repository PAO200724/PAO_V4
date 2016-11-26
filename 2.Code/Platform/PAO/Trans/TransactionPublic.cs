using PAO.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 静态类:TransactionPublic
    /// 事务公共类
    /// 作者:PAO
    /// </summary>
    public static class TransactionPublic
    {
        #region 事件信息
        public const string Event_Start = "事务启动";
        public const string Event_End = "事务启动";
        public const string Event_Committed = "事务提交";
        public const string Event_Excepted = "事务异常";
        public const string Event_Rollbacked = "事务回滚";
        public const string Event_RollbackExcepted = "回滚异常";
        #endregion

        #region 运行事务
        /// <summary>
        /// 事务列表
        /// </summary>
        private static Dictionary<string, PaoTransaction> TransactionList = new Dictionary<string, PaoTransaction>();

        /// <summary>
        /// 服务端启动事务（注意：带事务的服务必须调用此方法）
        /// </summary>
        /// <example>
        /// RunService(trans, ()=> { CallSomeFunc();});
        /// </example>
        /// <param name="clientTrans">客户端事务</param>
        /// <param name="transName">事务名称</param>
        /// <param name="exceptionAction">异常动作</param>
        /// <param name="action">动作</param>
        /// <param name="rollbackAction">回滚动作</param>
        public static void RunService(PaoTransaction clientTrans
            , string transName
            , Action action
            , Action<Exception> exceptionAction = null
            , Action rollbackAction = null) {
            // 将客户端事务插入当前事务中
            if (PaoTransaction.Current != null)
                clientTrans.Parent = PaoTransaction.Current.Parent;
            PaoTransaction.Current = clientTrans;
            try {
                // 运行事务
                Run(transName, action, exceptionAction, rollbackAction);
            }
            finally {
                // 运行完成后恢复原事务
                PaoTransaction.Current = PaoTransaction.Current.Parent;
            }
        }

        /// <summary>
        /// 在事务中执行
        /// </summary>
        /// <param name="transName">事务名称</param>
        /// <param name="exceptionAction">异常动作</param>
        /// <param name="action">动作</param>
        /// <param name="rollbackAction">回滚动作</param>
        public static void Run(string transName, Action action
            , Action<Exception> exceptionAction = null
            , Action rollbackAction = null) {

            // 先从事务列表中查找可能存在的事务
            PaoTransaction trans = new PaoTransaction() { Name = transName };

            try {
                trans.Start();
                action();
                trans.Commit();
            }
            catch (Exception exp) {
                try {
                    trans.Exception(exp);
                    if (exceptionAction != null) {
                        exceptionAction(exp);
                    }

                    if (rollbackAction != null) {
                        try {
                            rollbackAction();
                            trans.Rollback();
                        }
                        catch (Exception rollExp) {
                            trans.RollbackException(rollExp);
                        }
                    }
                    else {
                        throw exp;
                    }
                }
                finally {
                    trans.Fail();
                }
            }
        }
        /// <summary>
        /// 在事务中执行
        /// </summary>
        /// <param name="action">动作</param>
        /// <param name="exceptionAction">异常动作</param>
        /// <param name="rollbackAction">回滚动作</param>
        public static void Run(Action action, Action<Exception> exceptionAction = null, Action rollbackAction = null) {
            Run(null, action, exceptionAction, rollbackAction);
        }
        #endregion 运行事务
    }
}
