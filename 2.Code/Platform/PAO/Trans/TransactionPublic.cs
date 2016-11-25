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
        /// <summary>
        /// 事务服务
        /// </summary>
        private static ITransactionService TransactionService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="transService">事务服务</param>
        public static void Initialize(ITransactionService transService) {
            TransactionService = transService;
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
            var trans = new PaoTransaction(transName);
            try {
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
                } finally {
                    trans.Fail();
                }
            }
        }
    }
}
