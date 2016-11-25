using PAO.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 静态类：TransactionPublic
    /// 事务公共类
    /// 作者：PAO
    /// </summary>
    public static class TransactionPublic
    {
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
        /// 记录当前事务的事件
        /// </summary>
        /// <param name="transEvent">事务事件</param>
        public static void LogTransaction(TransactionEvent transEvent, Exception exception = null) {
            string transMessage = null;
            switch (transEvent) {
                case TransactionEvent.Started:
                    transMessage = "事务启动";
                    break;
                case TransactionEvent.Commited:
                    transMessage = "事务完成";
                    break;
                case TransactionEvent.Rollbacked:
                    transMessage = "事务回滚";
                    break;
                case TransactionEvent.Excepted:
                    transMessage = "事务异常";
                    break;
                case TransactionEvent.RollbackExcepted:
                    transMessage = "回滚异常";
                    break;
                case TransactionEvent.Exit:
                    transMessage = "事务退出";
                    break;
                default:
                    throw new Exception("未知的事务事件类型");
            }

            if (TransactionService != null)
                TransactionService.LogTransaction(PaoTransaction.Current, transEvent, exception.ObjectToString());

            if(!exception.IsNull()) {
                LogPublic.LogInformation(transMessage, "事务ID", PaoTransaction.Current.ID, "异常", exception.Message);
                LogPublic.LogException(exception);
            } else {
                LogPublic.LogInformation(transMessage, "事务ID", PaoTransaction.Current.ID);
            }
            
        }

        /// <summary>
        /// 在事务中执行
        /// </summary>
        /// <param name="action">动作</param>
        /// <param name="rollbackAction">回滚动作</param>
        public static void Run(Action action, Action rollbackAction = null) {
            var trans = new PaoTransaction();
            try {
                LogTransaction(TransactionEvent.Started);
                action();
                LogTransaction(TransactionEvent.Commited);
            }
            catch (Exception exp) {
                LogTransaction(TransactionEvent.Excepted, exp);
                if (rollbackAction != null) {
                    try {
                        rollbackAction();
                        LogTransaction(TransactionEvent.Rollbacked);
                    }
                    catch (Exception rollExp) {
                        LogTransaction(TransactionEvent.RollbackExcepted, rollExp);
                    }
                }
                throw exp;
            }
            finally {
                trans.End();
                LogTransaction(TransactionEvent.Exit);
            }
        }
    }
}
