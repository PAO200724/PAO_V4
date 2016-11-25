using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 接口：ITransactionServer
    /// 事务服务接口
    /// 作者：PAO
    /// </summary>
    [ServiceContract]
    public interface ITransactionServer
    {
        /// <summary>
        /// 记录事务
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="transEvent">事务事件</param>
        void LogTransaction(PaoTransaction trans, TransactionEvent transEvent);

        /// <summary>
        /// 启动事务
        /// </summary>
        /// <param name="parentTrans">上级事务</param>
        void StartTransaction(PaoTransaction parentTrans);

        /// <summary>
        /// 完成事务
        /// </summary>
        /// <param name="parentTrans">上级事务</param>
        void EndTransaction();
    }
}
