using PAO;
using PAO.IO.Text;
using PAO.Remote.WCF;
using PAO.Trans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote
{
    /// <summary>
    /// 类：RemoteFactory
    /// 远程工厂
    /// 通过远程服务创建实例的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("远程工厂")]
    [Description("通过远程服务创建实例的工厂")]
    public abstract class BaseRemoteFactory<T> : Factory<T>
    {
        #region 插件属性
        #region 属性：ServerAddress
        /// <summary>
        /// 属性：ServerAddress
        /// 服务器地址
        /// 远程服务器地址
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("服务器地址")]
        [Description("远程服务器地址")]
        public string ServerAddress {
            get;
            set;
        }
        #endregion 属性：ServerAddress

        #region 属性：ServiceName
        /// <summary>
        /// 属性：ServieName
        /// 服务名称
        /// 服务对应的名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("服务名称")]
        [Description("服务对应的名称")]
        public string ServiceName {
            get;
            set;
        }
        #endregion 属性：ServiceName

        #endregion
        public BaseRemoteFactory() {
        }
        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null, "ServerAddress", "ServiceName");
        }
        protected override T OnCreateInstance() {
            T result = default(T);
            TransactionPublic.Run("远程调用", () =>
            {
                var remoteService = CreateRemoteService();
                var proxy = new RemoteProxy(typeof(T), remoteService, RemotePublic.DefaultSerializer, ServiceName);
                result = (T)proxy.GetTransparentProxy();
            });
            return result;
        }

        protected abstract IRemoteService CreateRemoteService();
    }
}
