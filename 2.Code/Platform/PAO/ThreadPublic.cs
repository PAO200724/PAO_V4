using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAO
{
    /// <summary>
    /// 静态类：ThreadPublic
    /// 线程公共类
    /// 作者：PAO
    /// </summary>
    public static class ThreadPublic
    {
        /// <summary>
        /// 在任务中运行
        /// </summary>
        /// <param name="action">动作参数</param>
        /// <param name="timeout">超时事件(单位：毫秒)</param>
        public static void TaskRun(Action action, int timeout = -1) {
            var task = Task.Factory.StartNew(action);
            task.Start();
            task.Wait(timeout);
        }
    }
}
