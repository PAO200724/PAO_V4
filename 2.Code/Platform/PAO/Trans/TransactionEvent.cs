using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Trans
{
    /// <summary>
    /// 事务事件
    /// 作者：PAO
    /// </summary>
    public enum TransactionEvent
    {
        Started,    // 开始
        Committed,  // 提交
        Rollbacked, // 回滚
        Excepted    // 异常
    }
}
