using PAO;
using PAO.Event;
using PAO.Part;
using PAO.Part.Disabled;
using PAO.Part.Enabled;
using PAO.Part.Enabled.Running;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PAO.Server
{
    /// <summary>
    /// 类:BaseServer
    /// 基础服务器
    /// 服务器基类，服务器是在后台背景线程运行的程序
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("基础服务器")]
    [Description("服务器基类，服务器是在后台背景线程运行的程序")]
    public abstract class BaseServer : BasePart
    {
        #region 插件属性
        #region 属性:StopTimeout
        /// <summary>
        /// 属性:StopTimeout
        /// 停止超时
        /// 停止服务的等待超时时间，单位:毫秒
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("停止超时")]
        [Description("停止服务的等待超时时间，单位:毫秒")]
        public int StopTimeout {
            get;
            set;
        }
        #endregion 属性:StopTimeout

        #region 属性:TaskCreationOptions
        /// <summary>
        /// 属性:TaskCreationOptions
        /// 任务创建选项
        /// 服务任务创建的选项
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("任务创建选项")]
        [Description("服务任务创建的选项")]
        public TaskCreationOptions TaskCreationOptions {
            get;
            set;
        }
        #endregion 属性:TaskCreationOptions
        #endregion

        /// <summary>
        /// 服务停止
        /// </summary>
        protected bool Stopped { get; private set; }

        /// <summary>
        /// 服务线程
        /// </summary>
        private Task ServerTask;

        public BaseServer() {
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        public void Start() {
            Stopped = false;
            if (Status is Status_Disabled) {
                EventPublic.Warning("服务被禁止，不能启动.");
                return;
            }

            Status = Status.Default<Status_Running>();
            ServerTask = new Task(() =>
            {
                Run();
                if(Status is Status_Enabled) {
                    Status = Status.Default<Status_Ready>();
                }
                OnStop();
            }, TaskCreationOptions);
            ServerTask.Start();
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop() {
            StopRunning();
            Stopped = true;
            ServerTask.Wait(StopTimeout);
        }

        /// <summary>
        /// 启动服务前的方法
        /// </summary>
        protected virtual void OnStart() {
        }

        /// <summary>
        /// 停止服务后的方法
        /// </summary>
        protected virtual void OnStop() {

        }

        /// <summary>
        /// 运行时的方法
        /// 典型的方法应当判定Stopped，如果服务已经停止，则应当退出服务
        /// 在方法中可以设定服务的状态，如异常时禁用等
        /// </summary>
        protected abstract void Run();


        /// <summary>
        /// 停止运行的方法，如果在Running中已经考虑了Stopped状态并停止了服务，则不需要实现此方法
        /// </summary>
        protected virtual void StopRunning() { }
    }
}
