using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 接口:ITransactionServer
    /// 事务服务接口
    /// 作者:PAO
    /// </summary>
    [ServiceContract]
    public interface ITransactionService
    {
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
